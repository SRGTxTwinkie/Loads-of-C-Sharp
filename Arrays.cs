using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterBasicsLibrary
{
    public class Arrays
    {

        // Pass a double and an array into this to return a new array with the old and new data in it

        public static double[] Add(double to_add, double[] to_copy)
        {
            double[] final = new double[to_copy.Length + 1];

            for (int i = 0; i < to_copy.Length; i++)
            {
                final[i] = to_copy[i];
            }

            final[final.Length - 1] = to_add;

            return final;
        }


        // Pass an int and an array into this to return a new array with the old and new data in it

        public static int[] Add(int to_add, int[] to_copy)
        {
            int[] final = new int[to_copy.Length + 1];

            for (int i = 0; i < to_copy.Length; i++)
            {
                final[i] = to_copy[i];
            }

            final[final.Length - 1] = to_add;

            return final;
        }

        // Pass a string and an array into this to return a new array with the old and new data in it

        public static string[] Add(string to_add, string[] to_copy)
        {
            string[] final = new string[to_copy.Length + 1];

            for (int i = 0; i < to_copy.Length; i++)
            {
                final[i] = to_copy[i];
            }

            final[final.Length - 1] = to_add;

            return final;
        }

        // Pass an int and an array into this to check if there is a matching int

        public static bool InArray(int[] check_array, int to_check)
        {
            bool in_array = false;

            for (int i = 0; i < check_array.Length; i++)
            {
                if (check_array[i] == to_check)
                {
                    in_array = true;
                }

            }

            return in_array;
        }

        // Pass an string and an array into this to check if there is a matching string

        public static bool InArray(string[] check_array, string to_check)
        {
            bool in_array = false;

            for (int i = 0; i < check_array.Length; i++)
            {
                if (check_array[i].Equals(to_check))
                {
                    in_array = true;
                }

            }

            return in_array;
        }

        //Pass a double and an array into this to check if there is a matching double

        public static bool InArray(double[] check_array, double to_check)
        {
            bool in_array = false;

            for (int i = 0; i < check_array.Length; i++)
            {
                if (check_array[i] == to_check)
                {
                    in_array = true;
                }

            }

            return in_array;
        }

    }
}
