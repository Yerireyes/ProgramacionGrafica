using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp5
{
    class Objeto3D
    {
        public Dictionary<string, Face> listaDeCaras { get; set; }
        public Vector centro { get; set; }
        public Objeto3D(Dictionary<string, Face> listaDeCaras, Vector centro)
        {
            this.listaDeCaras = listaDeCaras;
            this.centro = centro;
            foreach (var cara in listaDeCaras)
            {
                Vector newCentro = new Vector(centro.X + cara.Value.centro.X, centro.Y + cara.Value.centro.Y, centro.Z + cara.Value.centro.Z);
                cara.Value.centro = newCentro;
            }
        }
        
        public void Insertar(Face nuevaCara, string key)
        {
            listaDeCaras.Add(key, nuevaCara);
        }

        public void Eliminar(string key)
        {
            listaDeCaras.Remove(key);
        }

        public Face Obtener(string key)
        {
            return listaDeCaras[key];
        }

        public void Dibujar()
        {
            
            foreach (var face in this.listaDeCaras)
            {
                face.Value.Dibujar();
            }
          
        }
        
        public void Rotar(float x, float y, float z)
        {
            foreach (var face in this.listaDeCaras)
            {
                face.Value.Rotar(x, y, z);
            }

        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (var face in this.listaDeCaras)
            {
                face.Value.Trasladar(x, y, z);
            }
        }

        public void Escalado(float x, float y, float z)
        {
            foreach (var face in this.listaDeCaras)
            {
                face.Value.Escalado(x, y, z);
            }
        }

        public Dictionary<string, Face> GetListaDeCaras()
        {
            return this.listaDeCaras;
        }
    }
}
