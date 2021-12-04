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
        public Vector centroCopia;
        public Vector centroLimpiar;

        public HelloEscenario(Dictionary<string, Objeto3D> listaDeObjetos3D, Vector centro)
        {
            this.listaDeObjetos3D = listaDeObjetos3D;
            this.centro = centro;
            centroCopia = centro;
            centroLimpiar = centro;
            foreach (var objeto3D in listaDeObjetos3D)
            {
                foreach (var cara in objeto3D.Value.listaDeCaras)
                {
                    Vector newCentroCara = new Vector(cara.Value.centro.X + centro.X, cara.Value.centro.Y + centro.Y, cara.Value.centro.Z + centro.Z);
                    cara.Value.centro = newCentroCara;

                }
            }
            //setNuevoCentro(this.centro);
        }

        public void setNuevoCentro(Vector centro)
        {
            this.centro = centro;
            foreach (var objeto3d in listaDeObjetos3D)
            {
                Vector newCentro = centro + objeto3d.Value.centro;
                objeto3d.Value.setNuevoCentro(newCentro);
            }
        }

        public HelloEscenario(Vector centro)
        {
            this.listaDeObjetos3D = new Dictionary<string, Objeto3D>();
            this.centro = centro;
            centroCopia = centro;
            centroLimpiar = centro;
        }

        public void Add(string key, Objeto3D objeto)
        {
            listaDeObjetos3D.Add(key, objeto);
                foreach (var cara in objeto.listaDeCaras)
                {
                    Vector newCentroCara = this.centro + cara.Value.centro;
                    cara.Value.centro = newCentroCara;
                    cara.Value.centroLimpiar = this.centro + cara.Value.centroLimpiar;
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
                objeto3D.Value.RotarEscenario(x, y, z, centroCopia);
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
                objeto3D.Value.EscaladoEscenario(x, y, z, centroCopia);
            }
        }

        public void Limpiar()
        {
            foreach (var objeto3D in listaDeObjetos3D)
            {
                objeto3D.Value.Limpiar();
            }
        }

    }
}
