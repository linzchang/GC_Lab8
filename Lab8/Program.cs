using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            int userNumber, studentNumber;
            bool parsed;
            string userAnswer;

            String [,] studentList = new string [15,3] {
                { "Michael Hern", "Canton, MI", "Chicken Wings" },
                { "Taylor Everts", "Caro, MI", "Chicken Cordon Bleu" },
                { "Josh Zimmerman", "Taylor, MI", "Turkey"},
                { "Lin-z Chang", "Toledo, OH", "Ice Cream" },
                { "Madelyn Hilty", "Oxford, MI", "Croissant" },
                { "Nana Banahene", "Guana", "Empanadas" },
                { "Rochelle Toles aka Roach", "Mars", "Space Cheese" },
                { "Shah Shahid", "Newark, NJ", "Chicken Wings" },
                { "Tim Broughton", "Detroit, MI", "Chicken Parm" },
                { "Abby Wessels", "Traverse City, MI", "Soup" },
                { "Blake Shaw aka Jedi Shaw", "Los Angeles, CA", "Cannolis" },
                { "Bob Valentic", "St. Clair Shores, MI", "Pizza" },
                { "Jordan Owiesny", "Warren, MI", "Burgers" },
                { "Jay Stiles", "Macomb, MI", "Pickles" },
                { "Jon Shaw", "Huntington Woods, MI", "Ribs" }
                };

            //welcome text
            Console.WriteLine("Welcome to the Dev.Build 2.0 student database!");

            while (true)
            {
                //ask user which student they would like to know about, take in user input
                Console.WriteLine("Which student would you like to learn more about? (enter a number 1-15): ");
                parsed = int.TryParse(Console.ReadLine(), out userNumber);

                //validate input
                if (ValidateInput(userNumber, parsed) == true)
                {
                    continue;
                }

                //edit userinput to match 0 based array indexes
                studentNumber = userNumber - 1;

                //pull data for given student using user input
                GetStudentInfo(studentList, userNumber, studentNumber);

                //ask user if they want to know about another student
                Console.WriteLine("Would you like to learn about another student? Type N to quit.");
                userAnswer = Console.ReadLine().ToUpper();
                if (userAnswer == "N")
                {
                    break;
                }

            }
        }

        public static bool ValidateInput (int userNumber, bool parsed)
        {
            bool Invalid = true;

            //if user did not enter a number re-prompt them
            if (parsed == false)
            {
                Console.WriteLine("That is not valid input.");
                return Invalid;
            }
            //if user entered a number out of range re-prompt them
            else if (userNumber < 1 || userNumber > 15)
            {
                Console.WriteLine("That student does not exist.  Please try again.");
                return Invalid;
            }
            //otherwise continue
            else
            {
                Invalid = false;
                return Invalid;
            }
        }

        public static void GetStudentInfo(string[,] studentList, int userNumber, int studentNumber)
        {
            string userChoice1, userChoice2;
            
            //compare user input to the index of the row (student number)
            //give student name, ask user if they want info on hometown or favorite food
            Console.WriteLine("Student " + userNumber + " is " + studentList[studentNumber, 0] + ".");

            while (true)
            {
                Console.WriteLine("What would you like to know about " + studentList[studentNumber, 0] + "? (enter 1 for 'Hometown' or 2 for 'Favorite food')");
                userChoice1 = Console.ReadLine().ToLower();
                //compare user input to the index of the column (specific student)
                //check if user wants to know about hometown
                if (userChoice1 == "1" || userChoice1 == "hometown")
                {

                    Console.WriteLine(studentList[studentNumber, 0] + " is from " + studentList[studentNumber, 1] + ".");
                }
                //check if user wants to know about favorite food
                else if (userChoice1 == "2" || userChoice1 == "favorite food")
                {
                    Console.WriteLine(studentList[studentNumber, 0] + "'s favorite food is " + studentList[studentNumber, 2] + ".");
                }
                //validate input
                else
                {
                    Console.WriteLine("That data does not exist. Please try again.");
                    continue;
                }

                //ask if user would like to know more about specific student
                Console.WriteLine("Would you like to know more about " + studentList[studentNumber, 0] + "? Type N to quit.");
                userChoice2 = Console.ReadLine().ToUpper();
                if (userChoice2 == "N")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
