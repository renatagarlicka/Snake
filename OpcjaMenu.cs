using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class OpcjaMenu
    {
        private readonly string napis;
        private readonly IAkcja akcja;

        public OpcjaMenu(string napis, IAkcja akcja)
        {
            this.napis = napis;
            this.akcja = akcja;
        }

        public string Napis
        {
            get
            {
                return napis;
            }
        }

        public override string ToString()
        {
            return napis;
        }

        public void Wykonaj()
        {
            akcja.WykonajAkcje();
        }

    }
}
