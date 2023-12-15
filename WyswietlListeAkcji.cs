using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    internal class WyswietlListeAkcja : IAkcja
    {
        public void WykonajAkcje()
        {

            try
            {

                string text = System.IO.File.ReadAllText(@"\ScoreList.txt");
                System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }
    }
}
