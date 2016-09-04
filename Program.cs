using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        // Write a program that initializes a list integer numbers,
        // and then prints the numbers out along with their sum. 
        public static void Main()
        {
            var nums = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23 };

            Console.WriteLine("Numbers: " + String.Join(", ", nums));

            int sum = 0;
            foreach(int num in nums) sum += num;

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine("Sum (Linq): " + nums.Sum());
        }
    }

    
}
