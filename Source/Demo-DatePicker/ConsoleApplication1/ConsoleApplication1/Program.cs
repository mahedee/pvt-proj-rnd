using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> mixedList = new List<object>();

            mixedList.Add("First Group:");

            // Add some integers to the list.  
            for (int j = 1; j < 5; j++)
            {
                mixedList.Add(j);
            }

            // Add another string and more integers.
            mixedList.Add("Second Group:");
            for (int j = 5; j < 10; j++)
            {
                mixedList.Add(j);
            }

            // Display the elements in the list. Declare the loop variable by  
            // using var, so that the compiler assigns its type. 
            foreach (var item in mixedList)
            {
                Console.WriteLine(item);
            }

            var sum = 0;
            for (var j = 1; j < 5; j++)
            {

                sum += (int)mixedList[j] * (int)mixedList[j];
            }

            // The sum displayed is 30, the sum of 1 + 4 + 9 + 16.
            Console.WriteLine("Sum: " + sum);

            int value = 5;
            Console.WriteLine(value);

            object boxedValue = (object)value;

            Console.WriteLine(boxedValue);

            int unboxedValue = (int)boxedValue;

            Console.WriteLine(unboxedValue);

            Console.ReadKey();

        }

    }
}
