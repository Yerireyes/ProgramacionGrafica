using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
namespace ConsoleApp5
{
    class HelloEscenario
    {
        public Dictionary<string, Objeto3D> listaDeObjetos3D { get; set; }
        public Vector centro { get; set; }

        public HelloEscenario(Dictionary<string, Objeto3D> listaDeObjetos3D, Vector centro)
        {
            this.listaDeObjetos3D = listaDeObjetos3D;
            this.centro = centro;
            foreach (var objeto3D in listaDeObjetos3D)
            {
                Vector newCentro = new Vector(objeto3D.Value.centro.X + this.centro.X, objeto3D.Value.centro.Y + this.centro.Y, objeto3D.Value.centro.Z + this.centro.Z);
                objeto3D.Value.centro = newCentro;
                foreach (var cara in objeto3D.Value.listaDeCaras)
                {
                    Vector newCentroCara = new Vector(cara.Value.centro.X + newCentro.X, cara.Value.centro.Y + newCentro.Y, cara.Value.centro.Z + newCentro.Z);
                    cara.Value.centro = newCentroCara;

                }
            }
        }

        public HelloEscenario(Vector centro)
        {
            this.listaDeObjetos3D = new Dictionary<string, Objeto3D>();
            this.centro = centro;
            
        }

        public void Add(string key, Objeto3D objeto)
        {
            listaDeObjetos3D.Add(key, objeto);
            Vector newCentro = new Vector(objeto.centro.X + this.centro.X, objeto.centro.Y + this.centro.Y, objeto.centro.Z + this.centro.Z);
            objeto.centro = newCentro;
                foreach (var cara in objeto.listaDeCaras)
                {
                    Vector newCentroCara = new Vector(cara.Value.centro.X + newCentro.X, cara.Value.centro.Y + newCentro.Y, cara.Value.centro.Z + newCentro.Z);
                    cara.Value.centro = newCentroCara;

                }
            
        }

        public void Dibujar()
        {
            foreach (var objeto3D in listaDeObjetos3D)
            {
                objeto3D.Value.Dibujar();
            }
        }

        public Objeto3D Obtener(string key)
        {
            return listaDeObjetos3D[key];
        }

        public void Rotar(float x, float y, float z)
        {
            foreach (var objeto3D in listaDeObjetos3D)
            {
                objeto3D.Value.Rotar(x, y, z);
            }

        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (var objeto3D in listaDeObjetos3D)
            {
                objeto3D.Value.Trasladar(x, y, z);
            }
        }
        
        public void Escalado(float x, float y, float z)
        {
            foreach (var objeto3D in listaDeObjetos3D)
            {
                objeto3D.Value.Escalado(x, y, z);
            }
        }

    }
}
