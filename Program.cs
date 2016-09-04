using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main()
        {

            var list = new List<string>();

            while (true)
            {

                Console.WriteLine("Enter command (+ item, - item, or -- to clear.  Type q to quit.)):");
                var cmd = Console.ReadLine().Trim();
                if (cmd == "--")
                {
                    clearList(list);
                }
                else if (cmd.StartsWith("+ "))
                {
                    addItemToList(list, cmd.Substring(2));
                }
                else if (cmd.StartsWith("- "))
                {
                    removeItemFromList(list, cmd.Substring(2));
                }
                else if (cmd == "q")
                {
                    Console.WriteLine("Goodbye!");
                    return;
                }
                else
                {
                    Console.WriteLine("Error: Invalid command.");
                }

                printList(list);
            }
        }

        public static void removeItemFromList(List<string> list, string item)
        {
            list.RemoveAll(s => s.Equals(item));
        }

        public static void addItemToList(List<string> list, string item)
        {
            list.Add(item);
        
        }
        public static void clearList(List<string> list)
        {
            list.Clear();
        }

        public static void printList(List<string> list)
        {
            if (list.Count > 0)
            {
                Console.WriteLine("Current List:");
                foreach(string item in list)
                {
                    Console.WriteLine($"  * {item}");
                }
            }
            else
            {
                Console.Write("[List is currently empty.]");
            }
            Console.WriteLine();
        }
    }


}
