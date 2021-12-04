using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Guion
    {
        public Dictionary<string, Escena> listaDeEscenas;

        public Guion(Dictionary<string, Escena> listaDeEscenas)
        {
            this.listaDeEscenas = listaDeEscenas;
        }

        public void Aplicar()
        {
            foreach (var escena in listaDeEscenas)
            {
                escena.Value.Aplicar();
            }
        }
    }
}
