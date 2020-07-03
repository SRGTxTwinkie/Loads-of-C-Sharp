using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterBasicsLibrary
{
    public class Range
    {

        // Pass 3 ints into this to return an int[] with a range of numbers with your step 

        public static int[] NewRange(int start, int end, int step)
        {
            end++;

            int[] final = new int[end];

            for (int i = start; i < end; i += step)
            {
                final[i] = i;
            }

            return final;
        }

        // Pass 2 ints into this to return an int[] with a range of numbers with a default step of 1

        public static int[] NewRange(int start, int end)
        {
            end++;

            int[] final = new int[end];

            for (int i = start; i < end; i += 1)
            {
                final[i] = i;
            }

            return final;
        }
    }
}
