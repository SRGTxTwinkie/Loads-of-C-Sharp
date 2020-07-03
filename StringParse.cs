﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterBasicsLibrary
{
    public class StringParse
    {

        // Call this to Parse a string for an int from the console
        //
        // I.E.
        //Console.Write("What number would you like: ");
        //var string_from_int = StringParse.Int()

        public static int Int()
        {
            string string_in = Console.ReadLine();
            int final_int;
            bool is_int;

            is_int = int.TryParse(string_in, out final_int);

            while (!is_int)
            {
                string_in = Console.ReadLine();
                is_int = int.TryParse(string_in, out final_int);
            }

            return final_int;
        }

        // Call this to print out a prompt, read, and parse an int from the console
        //
        // I.E.
        // var string_from_int = StringParse.Int("What number would you like: ");

        public static int Int(string output)
        {
            Console.Write(output + ": ");
            string string_in = Console.ReadLine();
            int final_int;
            bool is_int;

            is_int = int.TryParse(string_in, out final_int);

            while (!is_int)
            {
                string_in = Console.ReadLine();
                is_int = int.TryParse(string_in, out final_int);
            }

            return final_int;
        }

        //Same as int

        public static double Double()
        {
            string string_in = Console.ReadLine();
            double final_double;
            bool is_double;

            is_double = double.TryParse(string_in, out final_double);

            while (!is_double)
            {
                string_in = Console.ReadLine();
                is_double = double.TryParse(string_in, out final_double);
            }

            return final_double;
        }

        // Same as int

        public static double Double(string output)
        {
            Console.Write(output + ": ");
            string string_in = Console.ReadLine();
            double final_double;
            bool is_double;

            is_double = double.TryParse(string_in, out final_double);

            while (!is_double)
            {
                string_in = Console.ReadLine();
                is_double = double.TryParse(string_in, out final_double);
            }

            return final_double;
        }
    }
}
