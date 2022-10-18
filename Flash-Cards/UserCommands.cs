using flashcards.Models;
using Flashcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace flashcards
{
    internal class UserCommands
    {
        internal static void MainMenu()
        {
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("\n\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to Close Application.");
                Console.WriteLine("Type 1 to Manage Flashcards.");
                Console.WriteLine("Type 2 to Study");

                string CommandInput = Console.ReadLine();
                while (string.IsNullOrEmpty(CommandInput) || !int.TryParse(CommandInput, out _))
                {
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 2.\n");
                }

                int command = Convert.ToInt32(CommandInput);

                switch (command)
                {
                    case 0:
                        closeApp = true;
                        break;
                    case 1:
                        StacksMenu();
                        break;
                    case 2:
                        StudyMenu();
                        break;
                    default:
                        Console.WriteLine("\nInvalid command. Please type a number from 0 to 2.\n");
                        break;
                }
            }
        }
        internal static string GetIdForManageStack()
        {
            string stackIdString = Console.ReadLine();

            while (string.IsNullOrEmpty(stackIdString) || !int.TryParse(stackIdString, out _))
            {
                Console.WriteLine("\nInvalid Command. Please type a numeric value");
                stackIdString = Console.ReadLine();
            }

            return stackIdString;
        }
        internal static void StacksMenu()
        {
            Console.WriteLine("\n\nFlashcard stacks Area\n");
            StacksController.GetStacks();

            bool closeArea = false; 
            while (closeArea == false)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to Close Application.");
                Console.WriteLine("Type 1 to return to Main Menu.");
                Console.WriteLine("Type 2 to Create New Stack.");
                Console.WriteLine("Type 3 to Manage a Stack.");

                string CommandInput = Console.ReadLine();

                while (string.IsNullOrEmpty(CommandInput) || !int.TryParse(CommandInput, out _))
                {
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 3.\n");
                    CommandInput = Console.ReadLine();
                }

                int command = Convert.ToInt32(CommandInput);

                switch (command)
                {
                    case 0:
                        closeArea = true;
                        break;
                    case 1:
                        MainMenu();
                        break;
                    case 2: 
                        StacksController.CreateStack();
                        break;
                    case 3:
                        StacksController.ManageStack();
                        break;
                    default:
                        Console.WriteLine("\nInvalid Command. Please type a number from 0 to 3.\n");
                        break;
                }
            }
        }
        internal static void ManageStackMenu(int id, List<FlashcardsWithStack> stack)
        {
            int stackId = (int)id;

            bool closeArea = false;
            while (closeArea == false)
            {
                
            }
        }
    }
}