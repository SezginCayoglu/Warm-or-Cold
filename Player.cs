using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WarmAndCold
{
    internal class Player
    {
        public string Name { get => name; set => name = value; }
        public int Score { get => score; set => score = value; }
        public static List<Player> Players { get => players; set => players = value; }


        private string name;
        private int score;
        private static List<Player> players = new List<Player>();
        private static Player? player;

        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        internal static Player? GetPlayer()
        {
            return player;
        }

        public static void AddPlayer()
        {
            Console.WriteLine("Willkommen beim Spiel warm oder kalt.");
            Console.WriteLine("Gib bitte deinen Namen ein");
            string? inputName = Console.ReadLine();
            if (inputName != null)
                player = new Player(inputName, 0);
            if(player != null)
            players.Add(player);
            Console.Clear();
            Console.WriteLine($"Hallo {inputName},");
        }

        public static void ShowAllScores()
        {
                var allScores = from alls in players
                                orderby alls.score ascending
                                select alls;
                Console.WriteLine("Menü = Beliebige Taste\n");
                foreach (var alls in allScores)
                {
                    Console.WriteLine($"Name: {alls.name}");
                    Console.WriteLine($"Score: {alls.score}\n");
                }
            Console.ReadKey();
            Console.Clear();
            Menu.Start();
        }

        public void CountAttempts()
        {
            this.score += 1;
        }
    }
}
