using System;
using System.Collections.Generic;
using System.Linq;
using BetterBasicsLibrary;
using System.IO;

namespace rubySchoolStuff
{
    class Program
    {
        Range range = new Range();                                              // New better basics Range
        Arrays arrays = new Arrays();                                           // New better bascis Array
        StringParse stringParse = new StringParse();                            // New String Parser from better basics

        // Averages
        static void dataAverages()                                              // This handles big datasets and just has a few things to parse data from it
        {           
            double current_data;
            string to_exit = "";
            bool done = true;
            double[] data = new double[0];

            Console.WriteLine("Type anything other than a number to exit");
            Console.Write("Input: ");

            to_exit = Console.ReadLine();
            done = double.TryParse(to_exit, out current_data);                  // First use of the better basics libary. This one has all the try parse in it and is self contained

            while (done)                                                        // Will loop thru until a blank line is found
            {
                data = Arrays.Add(current_data, data);                          // Arrays.add is also a better basics thing. Instead of using a list you can use array and it will make a new array size of + 1
                Console.Write("Input: ");
                to_exit = Console.ReadLine();
                done = double.TryParse(to_exit, out current_data);
            }

            averagesMenu(data);

        }

        static void averagesMenu(double[] data)
        {
            int choice;
            bool exit = false;
            string[] options = { "List all Data", "Find Average", "Find all unique", "Find all Specific", "New Dataset", "Import Dataset" ,"Exit" }; 

            Console.WriteLine("What do you want to do with the data set?");

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, options[i]);
            }                                                                       
                                                                                // This just lists the menu options
            Console.Write("Data: ");
            choice = StringParse.Int();

            switch (choice)                                                     //  Just picks the correct function to run
            {
                case 1:
                    Console.Clear();
                    listAllData(data);
                    break;
                case 2:
                    Console.Clear();
                    findAverage(data);
                    break;
                case 3:
                    Console.Clear();
                    listUniq(data);
                    break;
                case 4:
                    Console.Clear();
                    findValue(data);
                    break;
                case 5:
                    Console.Clear();
                    dataAverages();
                    break;
                case 6:
                    Console.Clear();
                    averagesMenu(importFile());
                    break;
                case 7:
                    Console.Clear();
                    exit = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Command not recognized");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

            if (!exit)
            {
                averagesMenu(data);
            }   

        }                              // Holds all the menu options for data handler

        static void listAllData(double[] data)                                  // For loop that loops thru an array, thats it
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine("Data point {0}: {1}", i + 1, data[i]);
            }
        }
        
        static void findAverage(double[] data)
        {
            double arraySum = 0;
            int arrLength = data.Length;

            for(int i = 0; i < arrLength; i++)
            {
                arraySum += data[i]; 
            }

            Console.WriteLine("Average of the data is: {0}", arraySum / arrLength);

        }                               // Loops thru the array and divides total by arr length

        static void listUniq(double[] data)
        {
            List<double> dataList = new List<double>();

            foreach (double i in data)
            {
                dataList.Add(i);
            }

            Console.WriteLine("Unique values are: ");

            foreach (double i in dataList.Distinct())
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();

        }                                  // Uses the list Distinct call and displays all of it

        static void findValue(double[] data)
        {
            int arr_value;
            List<int> positions = new List<int>();


            Console.WriteLine("Enter the digit you want to find. Will return all instances of value and place in array.");
            arr_value = StringParse.Int("Value");

            for(int i = 0; i < data.Length; i++)
            {
                if(data[i] == arr_value)
                {
                    positions.Add(i);
                }
            }

            Console.Write("{0} was found at positon(s): ", arr_value);
            foreach(int i in positions)
            {
                Console.Write(" |{0}| ", i);
            }

            Console.WriteLine();

        }                                 // Loops thru the array and checks for the given double. Returns position of array if found

        static double[] importFile()                                            // Uses SystemIO to take a file path, writes it to a list, and converts that list to a double[]
        {

            string file_path;
            List<string> text = new List<string>();
            List<double> convertedArr = new List<double>();

            Console.WriteLine("Copy paste the path to the file, they need to be in a list with a new line between each.");
            Console.Write("File Path: ");
            file_path = Console.ReadLine();
            text = File.ReadAllLines(file_path).ToList();

            foreach(string i in text)
            {
                convertedArr.Add(Double.Parse(i));
            }

            return convertedArr.ToArray();
        }

        // Overtime compensation
        static void hoursWorked()
        {
            double hours;
            double overtime = 0;
            double hourly_wage = 11.50;
            double overtime_payed;
            double regular_wage;
            double total_amount;

            Console.Write("How many hours have you worked this week: ");

            hours = StringParse.Double();

            if (hours < 40)
            {
                Console.WriteLine("No overtime this week.");
            }
            else
            {
                overtime = hours - 40;

                Console.WriteLine("You have {0} hours of overtime this week", overtime);
            }

            overtime_payed = (overtime * hourly_wage) * 1.5;
            regular_wage = hours * hourly_wage;
            total_amount = overtime_payed + regular_wage;

            Console.WriteLine(
            "Total overtime payed this week is {0} \n" +
            "Total non-overtime payed this week is {1} \n" + 
            "Total amount earned this week is {2}"
            ,overtime_payed
            ,regular_wage
            ,total_amount
            );
        }                                            // Calculates overtime pay based on hours and given payrate 

        // Book Thing
        static void howManyBooks()
        {
            int book_num;
            double book_price;
            double total_cost;
            double total_cost_discounted;
            double discount;

            Console.Write("How many books are you gonna need: ");
            book_num = StringParse.Int();

            Console.Write("How much does the book cost: ");
            book_price = StringParse.Double();

            discount = discountDecider(book_num);
            total_cost = book_num * book_price;
            total_cost_discounted = total_cost * discount;
            
            Console.WriteLine("You have received a discount of {0} off!", (discount).ToString("0%"));
            Console.WriteLine("Your total is {0}", (total_cost - discount).ToString("$0.00"));
            Console.WriteLine("Without the discount your total would have been {0}", (total_cost).ToString("$0.00"));
            Console.WriteLine("You saved {0} from your discount.", (total_cost_discounted).ToString("$0.00"));

        }                                           // Calculates a discount rate and discount amount based on number of books bought

        static double discountDecider(int book_num)
        {
            double final_discount;

            if (Arrays.InArray(Range.NewRange(1, 9, 1), book_num))
            {
                final_discount = 0;
            }
            else if (Arrays.InArray(Range.NewRange(10, 19, 1), book_num))
            {
                final_discount = 0.20;
            }
            else if (Arrays.InArray(Range.NewRange(20, 49, 1), book_num))
            {
                final_discount = 0.30;
            }
            else if (Arrays.InArray(Range.NewRange(50, 99, 1), book_num))
            {
                final_discount = 0.40;
            }
            else
            {
                final_discount = 0.50;
            }


            return final_discount;
        }                          // Uses if statements with ranges to check discount rate

        // Package Weight 
        static void runPackagePrice()
        {
            double package_weight;
            double cost_per_pound;

            package_weight = getPackWeight();
            cost_per_pound = getCostPerPound(package_weight);

            Console.WriteLine("Package cost per pound is ${0}", cost_per_pound.ToString("#.00"));
            Console.WriteLine("The shipping cost is going to be ${0}", (cost_per_pound * package_weight).ToString("#.00"));
        }                                        // Shipping cost given weight and price per pound of package

        static double getCostPerPound(double weight)
        { 

            if(weight == 1)
            {
                return 1.10;
            }
            else if (Arrays.InArray(Range.NewRange(2, 6, 1), (int)weight))
            {
                return 2.20;      
            }
            else if (Arrays.InArray(Range.NewRange(7, 10, 1), (int)weight))
            {
                return 3.70;
            }
            else
            {
                return 3.80;
            }
        }                         // More range practice

        static double getPackWeight()
        {
            double number;

            Console.Write("Enter the package weight: ");

            number = StringParse.Double();
            
            return number;  
        }                                        // Grabs a double of package weight

        // Temperature Array
        static void tempPushArray()
        {
            double average_temperature = 0.0;
            double current_month_temp;
            double[] temperatures = new double[12];
            string[] months = { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            for (int i = 0; i < months.Length; i++)
            {
                current_month_temp = getTemp(months[i]);
                temperatures[i] = current_month_temp;
                average_temperature += current_month_temp;
            }

            Console.WriteLine("Average Temp was {0} degrees Fahrenheit", (average_temperature / months.Length).ToString("0.00"));
        }                                          // Calculates temperature based on user input for all the months

        static double getTemp(string month)
        {
            double temp;

            Console.Write("How hot was it in {0}: ", month);

            temp = StringParse.Double();

            return temp;
        }                                  // Grabs a double and returns it

        //Display Menu
        static void displayAndGrabMenuOption()
        {
            /* 
            All you have to do is add the function name to the list and list options and your set
            The list calls it and then loops back to Main.
            Making sure that the user input is a number was more work.
            */

            List<Action> lst = new List<Action>(); // Makes a new list to hold the functions

            int method_to_run;
            string input;
            bool is_int;
            
            string[] list_options = { "Package price finder", "Temperature to array", "Book Discounts", "Overtime Calculator", "Average Data" }; // Names of Menu options
            lst.AddRange(new Action[] { runPackagePrice, tempPushArray, howManyBooks, hoursWorked, dataAverages }); // Adds functions to the lists

            // Loops thru menu options
            for (int i = 0; i < list_options.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, list_options[i]);
            }

            Console.Write("Pick an option from 1 to {0}: ", list_options.Length);

            input = Console.ReadLine();
            is_int = int.TryParse(input, out method_to_run);

            // Loops thru function list and calls given number
            while (!is_int)
            {
                input = Console.ReadLine();
                is_int = int.TryParse(input, out method_to_run);
            }

            Console.Clear();

            lst[method_to_run - 1]();
        }                               // Holds the method calls and menu options

        // Main
        static void Main(string[] args)
        {
            //This looks nice so I keep it in

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            displayAndGrabMenuOption();

            Main(args);

        }                                      // Literally only serves to call the displayAndGrabMenuOption
    }
}
