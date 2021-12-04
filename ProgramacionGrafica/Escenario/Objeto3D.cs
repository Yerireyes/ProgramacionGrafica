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
        public Vector centroCopia;
        public Vector centroLimpiar;
        public Objeto3D(Dictionary<string, Face> listaDeCaras, Vector centro)
        {
            this.listaDeCaras = listaDeCaras;
            this.centro = centro;
            centroCopia = centro;
            centroLimpiar = centro;
            foreach (var cara in listaDeCaras)
            {
                Vector newCentro = this.centro + cara.Value.centro;
                cara.Value.centro = newCentro;
                cara.Value.centroLimpiar = this.centroLimpiar + cara.Value.centroLimpiar;
            }
            //setNuevoCentro(this.centro);
        }

        public void setNuevoCentro(Vector nuevoCentro)
        {
            this.centro = nuevoCentro;
            foreach (var cara in listaDeCaras)
            {
                Vector nuevoCentroCara = nuevoCentro + cara.Value.centro;
                cara.Value.centro = nuevoCentroCara;
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
                face.Value.RotarObjeto(x, y, z, centroCopia);
            }
            
        }

        public void RotarEscenario(float x, float y, float z, Vector centro)
        {
            foreach (var face in this.listaDeCaras)
            {
                face.Value.RotarEscenario(x, y, z, centroCopia);
            }
            x = MathHelper.DegreesToRadians(x);
            y = MathHelper.DegreesToRadians(y);
            z = MathHelper.DegreesToRadians(z);
            Matrix3 matrizRotacion = Matrix3.CreateRotationX(x) * Matrix3.CreateRotationY(y) * Matrix3.CreateRotationZ(z);
            centroCopia = centroCopia * matrizRotacion;
        }

        public void Trasladar(float x, float y, float z)
        {
            foreach (var face in this.listaDeCaras)
            {
                face.Value.Trasladar(x, y, z);
            }
            centroCopia = centroCopia + new Vector(x, y, z);
        }

        public void Escalado(float x, float y, float z)
        {
            foreach (var face in this.listaDeCaras)
            {
                face.Value.EscaladoObjeto(x, y, z, centroCopia);
            }
        }

        public void EscaladoEscenario(float x, float y, float z, Vector centro)
        {
            foreach (var face in this.listaDeCaras)
            {
                face.Value.EscaladoEscenario(x, y, z, centroCopia);
            }
            centroCopia = centroCopia * Matrix3.CreateScale(x, y, z);
        }

        public Dictionary<string, Face> GetListaDeCaras()
        {
            return this.listaDeCaras;
        }

        public void Limpiar()
        {
            foreach (var cara in listaDeCaras)
            {
                cara.Value.Limpiar();
            }
            this.centroCopia = this.centroLimpiar;
        }
    }
}
