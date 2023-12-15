using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Menu
    {
        private Dictionary<int, OpcjaMenu> OpcjeMenu { get; set; }

        public Menu()
        {
            OpcjeMenu = new Dictionary<int, OpcjaMenu>();
            InicjujMenu();
        }

        private void InicjujMenu()
        {
            DodajOpcjeMenu("Nowa gra", new WlaczGre());
            DodajOpcjeMenu("Wyświetl liste punktacji", new WyswietlListeAkcja());
            DodajOpcjeMenu("Dodaj wynik do listy", new DodajDoListyAkcja());
            DodajOpcjeMenu("Zamknij program", new ZamknijProgramAkcja());
        }

        public void WywolajMenu()
        {
           Wyswietl();
            var wybranaOpcja =WybierzOpcje();
            Console.Clear();
            WykonajOpcje(wybranaOpcja);
        }

        private void DodajOpcjeMenu(string napis, IAkcja akcja)
        {
            if (OpcjeMenu.Count == 9)
            {
                throw new Exception("Za dużo elementów w menu");
            }
            OpcjeMenu.Add(OpcjeMenu.Count + 1, new OpcjaMenu(napis, akcja));
        }

        public void Wyswietl()
        {
            foreach (KeyValuePair<int, OpcjaMenu> item in OpcjeMenu)
            {
                Console.WriteLine($"{item.Key}. {item.Value.ToString()}");
            }
        }

        internal int WybierzOpcje()
        {
            Console.Write("Twój Wybór: ");

            ConsoleKeyInfo wybranyKlawisz = Console.ReadKey();
            bool sukces = int.TryParse(wybranyKlawisz.KeyChar.ToString(), out int wybranaOpcja);

            Console.Clear();

            if (sukces && OpcjeMenu.ContainsKey(wybranaOpcja))
            {
                return wybranaOpcja;
            }
            else
            {
                return -1;
            }
        }

        public void WykonajOpcje(int indeksWybranejOpcji)
        {
            if (OpcjeMenu.ContainsKey(indeksWybranejOpcji))
            {
                OpcjaMenu opcja = OpcjeMenu.GetValueOrDefault(indeksWybranejOpcji);
                opcja.Wykonaj();
            }
        }
    }
}