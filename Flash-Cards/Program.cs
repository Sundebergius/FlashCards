using System;
using System.Threading;
using flashCards;
using Microsoft.Data.SqlClient;

namespace Flashcards
{
    class Program
    {
        static void Main()
        {
            DatabaseManager.CheckDatabase();
            UserCommands.MainMenu();
        }
    }
}