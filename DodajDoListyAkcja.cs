using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class DodajDoListyAkcja:IAkcja
    {
        
        public void WykonajAkcje()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"\ScoreList.txt");

                sw.WriteLine($"1. Gracz: ");

                sw.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            
        }
    }
}
