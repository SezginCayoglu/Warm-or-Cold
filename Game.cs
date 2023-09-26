using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmAndCold
{
    static internal class Game
    {
        public static int RandomNumber { get => randomNumber; set => randomNumber = value; }
        public static int InputNumber1 { get => inputNumber1; set => inputNumber1 = value; }
        public static int InputNumber2 { get => inputNumber2; set => inputNumber2 = value; }
        public static int DifferenceInput1 { get => differenceInput1; set => differenceInput1 = value; }
        public static int DifferenceInput2 { get => differenceInput2; set => differenceInput2 = value; }

        private static int randomNumber;
        private static int inputNumber1;
        private static int inputNumber2;
        private static int differenceInput1;
        private static int differenceInput2;

        public static void GenerateRandomNumber()
        {
            var random = new Random();
            randomNumber = random.Next(1, 101);
        }

        public static void CalculateDiffBetweenRandomNumAndInput1()
        {
            if (randomNumber > inputNumber1)
                DifferenceInput1 = randomNumber - inputNumber1;
            if (randomNumber < inputNumber1)
                DifferenceInput1 = inputNumber1 - randomNumber;  
        }

        public static void CalculateDiffBetweenRandomNumAndInput2()
        {
            if (randomNumber > inputNumber2)
                differenceInput2 = randomNumber - inputNumber2;
            if (randomNumber < inputNumber2)
                differenceInput2 = inputNumber2 - randomNumber;
        }

        public static void WarmerOrColderNotification()
        {
            if (differenceInput2 < differenceInput1)
                Console.WriteLine($"Wärmer"); //Console.WriteLine($"Wärmer Diff1 = {differenceInput2}");
            if (differenceInput2 > differenceInput1)
                Console.WriteLine($"Kälter"); //Console.WriteLine($"Kälter Diff2 = {differenceInput2}");
            if (differenceInput2 == differenceInput1 && randomNumber != inputNumber1 && randomNumber != inputNumber2)
                Console.WriteLine($"Temperatur bleibt unverändert"); //Console.WriteLine($"Temperatur bleibt unverändert Diff1 = {differenceInput2}");
        }

        public static void CheckIfInputNumberIsWarmerOrColderThanLastInput(Player? player) 
        {
            if(player != null)
            {
                CommandPromptInputNumber1();
                CalculateDiffBetweenRandomNumAndInput1();
                CheckIfPlayerWon(player);
                CommandPromptInputNumber2();
                CalculateDiffBetweenRandomNumAndInput2();
                CheckIfPlayerWon(player);
                inputNumber1 = inputNumber2;
                WarmerOrColderNotification();

                while (randomNumber != inputNumber1 && randomNumber != inputNumber2)
                {
                    CommandPromptInputNumber2();
                    CalculateDiffBetweenRandomNumAndInput1();
                    CheckIfPlayerWon(player);
                    inputNumber1 = inputNumber2;
                    CalculateDiffBetweenRandomNumAndInput2();
                    WarmerOrColderNotification();
                }
            }
        }

        public static void InformPlayerAboutGameplay()
        {
            Console.WriteLine("Du musst eine Zahl von 0 - 100 erraten.");
            Console.WriteLine("Ab der zweiten Eingabe erhältst du die Meldungen 'wärmer' oder 'kälter'.");
            //Console.WriteLine($"Vorrübergehende Testausgabe, Zufallszahl: {randomNumber}\n");
        }

        public static void CheckIfPlayerWon(Player player)
        {
            if (InputNumber1 == randomNumber || InputNumber2 == randomNumber)
            {
                player.CountAttempts();
                Console.WriteLine("Herzlichen Glückwunsch, du hast die richtige Zahl erraten.\n");
                Console.WriteLine($"Name: {player.Name}\nAnzahl Versuche: {player.Score}");
                Console.WriteLine("Menü: M");
                Console.WriteLine("Neues Spiel: Beliebige Taste");
                ConsoleKeyInfo input; input = Console.ReadKey();
                if (input.Key == ConsoleKey.M)
                {
                    Console.Clear();
                    Menu.Start();
                }
                else
                {
                    Console.Clear();
                    Menu.NewGame();
                }
            }
            else if (InputNumber1 != randomNumber && InputNumber2 != randomNumber)
            {
                player.CountAttempts();
            }
        }

        public static void CommandPromptInputNumber1()
        {
            bool inputIsInteger = false;
            while (!inputIsInteger)
            {
                inputIsInteger = int.TryParse(Console.ReadLine(), out inputNumber1);
                if (!inputIsInteger)
                    Console.WriteLine("Bitte nur Ganzzahlen eingeben.");
            }
        }

        public static void CommandPromptInputNumber2() 
        {
            bool inputIsInteger = false;
            while (!inputIsInteger)
            {
                inputIsInteger = int.TryParse(Console.ReadLine(), out inputNumber2);
                if (!inputIsInteger)
                    Console.WriteLine("Bitte nur Ganzzahlen eingeben.");                
            }
        }
    }
}
