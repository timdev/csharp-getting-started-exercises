/*
 * Start with the Customer and Order code shown above. Write a program that demonstrates the following requirements:
 *
 * Customers have a property exposing their historic Orders
 * Customers expose a method for adding an Order
 * Trying to add a null Order should do nothing
 * Trying to add an Order with an existing OrderNumber should replace the existing Order (not add a duplicate)
 * Orders should expose an OrderDate (which can be read/write)
 * Trying to add an order with an OrderDate in the future should do nothing
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace ConsoleApplication
{


    public class Program
    {
        public static void Main()
        {
            
            var cust = new Customer("Joe Custie");

            cust.AddOrder(new Order("1", DateTime.Parse("2015-12-21 12:21:00")));
            
            // this one should be dropped, since Order "1" already exists.
            cust.AddOrder(new Order("1", DateTime.Now));

            // Should be okay. 
            cust.AddOrder(new Order("2"));

            // Should be okay.
            cust.AddOrder(new Order("3", DateTime.Now.Subtract(TimeSpan.FromDays(5))));

            // Should be dropped, date is in future.
            cust.AddOrder(new Order("4", DateTime.Now.AddDays(2)));

            // Should do nothign.
            cust.AddOrder(null);

            printList(cust.Orders);
    
            // Add one more and print again.  (To test that ReadOnlyCollection is actually proxying to the underlying List).
            cust.AddOrder(new Order("5", DateTime.Now.AddDays(-10)));
            Console.WriteLine();
            printList(cust.Orders);
        }

        private static void printList(IEnumerable<Order> orders)
        {
            foreach(Order order in orders)
            {
                Console.WriteLine(order.OrderNumber + "\t" + ( ! order.OrderDate.HasValue ? "" : order.OrderDate.Value.ToString("s")));
            }

        }
    }

    /**
     * Orders are entities, identified by OrderNumber.  
     * IEquatable is implemented so two instances with the same OrderNumber are considered equal.
     */ 
    public class Order : IEquatable<Order>
    {
        public string OrderNumber { get; }

        public DateTime? OrderDate { get; set; }

        // Basic overloading of constructor to allow setting OrderDate at instantiation time.
        public Order(string orderNumber)
        {
            OrderNumber = orderNumber;            
        }

        public Order(string orderNumber, DateTime orderDate)
        {
            OrderNumber = orderNumber;
            OrderDate = orderDate;
        }

        public bool Equals(Order other)
        {
            return other.OrderNumber == OrderNumber;
        }
    }

    public class Customer
    {
        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
        }

        public ReadOnlyCollection<Order> Orders
        {
            get
            {
                if (_ordersView == null){
                    _ordersView = new ReadOnlyCollection<Order>(_orders);
                }
                return _ordersView;
            }
        }

        public void AddOrder(Order order)
        {
            // "Trying to add a null Order should do nothing"
            if( null == order) return;

            // "Trying to add an Order with an existing OrderNumber should replace the existing Order (not add a duplicate)"
            // (Note that Order implements IEquatable<Order>)
            if (_orders.Contains(order)) return;

            // "Trying to add an order with an OrderDate in the future should do nothing"
            if (order.OrderDate > DateTime.Now) return;
            
            // Add the order
            _orders.Add(order);

        }

        // Internal mutable list of orders.
        private List<Order> _orders = new List<Order>();

        // Internal read-only list of orders.
        private ReadOnlyCollection<Order> _ordersView;
        
    }    
}
