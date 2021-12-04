using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Escena
    {
        public Dictionary<string, Accion> listaDeAcciones;
        
        public Escena(Dictionary<string, Accion> listaDeAcciones)
        {
            this.listaDeAcciones = listaDeAcciones;
        }

        public void Aplicar()
        {
            foreach (var accion in listaDeAcciones)
            {
                accion.Value.Aplicar();
            }
        }
    }
}
