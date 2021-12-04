using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Accion
    {
        public Dictionary<string, Transformacion> listaDeTransformaciones;
        public int tiempoInicio;
        public int tiempoFinal;
        public int duracion;

        public Accion(Dictionary<string, Transformacion> listaDeTransformaciones)
        {
            this.listaDeTransformaciones = listaDeTransformaciones;
        }

        public Dictionary<string, Transformacion> Aplicar()
        {
            return listaDeTransformaciones;
        }
    }
}
