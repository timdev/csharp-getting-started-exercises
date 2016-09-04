using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main()
        {

            var list = new List<string>();



            while(true)
            {
                
                Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
                var cmd = Console.ReadLine().Trim();
                if(cmd == "--"){
                    list.Clear();
                }else if(cmd.StartsWith("+ ")){
                    list.Add(cmd.Substring(2));
                }else if(cmd.StartsWith("- ")){
                    list.RemoveAll(s => s.Equals(cmd.Substring(2)));
                }else if(cmd == "q"){
                    return;                
                }else{
                    Console.WriteLine("Error: Invalid command.");
                }

                printList(list);
            }

        }

        public static void printList(List<string> list)
        {
            if (list.Count > 0){
                Console.WriteLine("Current List:");
                list.ForEach(Console.WriteLine);
            }else{
                Console.Write("[List is currently empty.]");
            }
            Console.WriteLine();
        }
    }

    
}
