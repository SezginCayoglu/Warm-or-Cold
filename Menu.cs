using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmAndCold
{
    internal static class Menu
    {
        public static void Start() 
        {
            Menue();
        }

        public static void Menue()
        {
            bool invalidInput = true;
            while (invalidInput == true)
            {
                Console.Clear();
                invalidInput = false;
                Console.WriteLine("[1] Neues Spiel");
                Console.WriteLine("[2] Score-Liste");
                Console.WriteLine("[3] Beenden");
                string? input = Console.ReadLine();
                if (input != null)
                {
                    if (input == "1")
                    { Console.Clear(); NewGame(); }
                    else if (input == "2")
                    { Console.Clear(); Player.ShowAllScores(); }
                    else if (input == "3")
                    {
                        Serialization_Deserialization.SavePlayersList();
                        Environment.Exit(0);
                    }
                    else { Console.WriteLine("Ungültige Eingabe"); invalidInput = true; }
                }
            }
        }

        public static void NewGame()
        {
            Player.AddPlayer();
            Game.GenerateRandomNumber();
            Game.InformPlayerAboutGameplay();
            if(Player.GetPlayer() != null)
            Game.CheckIfInputNumberIsWarmerOrColderThanLastInput(Player.GetPlayer());
        }
    }
}
