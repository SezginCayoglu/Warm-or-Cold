using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WarmAndCold
{
    internal static class Serialization_Deserialization
    {
        public static void SavePlayersList()
        {
            try
            {
                string json = JsonConvert.SerializeObject(Player.Players, Formatting.Indented);

                using(StreamWriter sw = new StreamWriter("spielerliste.json"))
                {
                    sw.WriteLine(json);
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void LoadPlayersList()
        {
            try
            {
                string json;
                if (File.Exists("spielerliste.json"))
                {
                    using (StreamReader sr = new StreamReader("spielerliste.json"))
                    {
                        json = sr.ReadToEnd();
                    }
                    Player.Players = JsonConvert.DeserializeObject<List<Player>>(json);
                }
                else throw new FileNotFoundException("Datei nicht gefunden");
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
