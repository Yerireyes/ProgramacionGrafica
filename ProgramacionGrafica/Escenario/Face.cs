using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleApp5
{
    class Face
    {
        public Dictionary<string, Vector> listaDeVertices { get; set; }
        public Dictionary<string, Vector> listaDeVerticesCopia { get; set; }
        public Color color { get; set; }
        public Vector centro { get; set; }
        public Vector traslacion { get; set; } = new Vector(0, 0, 0);
        public Matrix3 matrizRotacion = Matrix3.Identity;
        public Matrix3 matrizEscalado = Matrix3.Identity;
        public Vector centroCaraCopia { get; set; }
        public Vector centroTransformar { get; set; }
        public Vector centroLimpiar { get; set; }
        public Vector centroLimpiar2 { get; set; }

        public Face(Dictionary<string, Vector> listaDeVertices, Color color, Vector centro)
        {
            this.listaDeVertices = listaDeVertices;
            listaDeVerticesCopia = new Dictionary<string, Vector>();
            foreach (var vertice in listaDeVertices)
            {
                listaDeVerticesCopia.Add(vertice.Key, new Vector(vertice.Value.X, vertice.Value.Y, vertice.Value.Z));
            }
            this.color = color;
            this.centro = centro;
            centroCaraCopia = centro;
            centroLimpiar = centro;
            centroLimpiar2 = centro;
            centroTransformar = new Vector(0, 0, 0);
        }
        
        public void Insertar(Vector nuevoVertice, string key)
        {
            listaDeVertices.Add(key, nuevoVertice);
        }

        public void Eliminar(string key)
        {
            listaDeVertices.Remove(key);
        }

        public Vector Obtener(string key)
        {
            return listaDeVertices[key];
        }

        public void Dibujar()
        {
            GL.Color4(color);
            GL.Begin(PrimitiveType.Polygon);           
            foreach (var vertice in listaDeVertices)
            {
                Vector vectorADibujar = (vertice.Value + centroTransformar) * matrizRotacion * matrizEscalado;
                vectorADibujar -= (centroTransformar * matrizRotacion * matrizEscalado);
                vertice.Value.X = vectorADibujar.X;
                vertice.Value.Y = vectorADibujar.Y;
                vertice.Value.Z = vectorADibujar.Z;
                vectorADibujar += traslacion + centro ;
                GL.Vertex3(vectorADibujar.X, vectorADibujar.Y, vectorADibujar.Z);
            }
            GL.End();
            this.centroTransformar = new Vector(0, 0, 0);
            matrizRotacion = Matrix3.Identity;
            matrizEscalado = Matrix3.Identity;
        }

        public void RotarCara(float anguloX, float anguloY, float anguloZ) 
        {
            Rotar(anguloX, anguloY, anguloZ);
        }
        public void RotarObjeto(float anguloX, float anguloY, float anguloZ, Vector centro)
        {
            Rotar(anguloX, anguloY, anguloZ);
            this.centroTransformar = this.centroCaraCopia;
            this.centro = this.centro - centroCaraCopia;
            this.centroCaraCopia = centroCaraCopia * matrizRotacion;
            this.centro = this.centro + centroCaraCopia;
        }
        public void RotarEscenario(float anguloX, float anguloY, float anguloZ, Vector centro)
        {
            Rotar(anguloX, anguloY, anguloZ);
            this.centroTransformar = centro + this.centroCaraCopia;
            this.centro = this.centro - centroTransformar;
            this.centroCaraCopia = (centroCaraCopia + centro) * matrizRotacion;
            this.centroCaraCopia = centroCaraCopia - centro * matrizRotacion;
            this.centro = this.centro + centroCaraCopia + centro * matrizRotacion;
        }

        public void Rotar(float anguloX, float anguloY, float anguloZ)
        {
            
            anguloX = MathHelper.DegreesToRadians(anguloX);
            anguloY = MathHelper.DegreesToRadians(anguloY);
            anguloZ = MathHelper.DegreesToRadians(anguloZ);
            matrizRotacion = Matrix3.CreateRotationX(anguloX) * Matrix3.CreateRotationY(anguloY) * Matrix3.CreateRotationZ(anguloZ);
        }

            public void Trasladar(float x, float y, float z)
        {
            traslacion += new Vector(x, y, z);
        }
        public void TrasladarCara(float x, float y, float z)
        {
            traslacion += new Vector(x, y, z);
            centroCaraCopia = centroCaraCopia + new Vector(x, y, z);
        }

        public void Escalado(float x, float y, float z)
        {
            EscaladoCara(x, y, z, centroCaraCopia);
        }
        public void EscaladoCara(float x, float y, float z, Vector centro)
        {
            matrizEscalado = Matrix3.CreateScale(x, y, z);
        }
        public void EscaladoObjeto(float x, float y, float z, Vector centro)
        {
            matrizEscalado = Matrix3.CreateScale(x, y, z);
            this.centro = this.centro - centroCaraCopia;
            centroCaraCopia = centroCaraCopia * matrizEscalado;
            this.centroTransformar = centroCaraCopia;
            this.centro = this.centro + centroCaraCopia;
        }
        public void EscaladoEscenario(float x, float y, float z, Vector centro)
        {
            matrizEscalado = Matrix3.CreateScale(x, y, z);
            this.centro = this.centro - centroCaraCopia - centro;
            this.centroTransformar = centroCaraCopia + centro;
            centroCaraCopia = ((centroCaraCopia + centro) * matrizEscalado) - (centro * matrizEscalado);
            this.centro = this.centro + centroCaraCopia + (centro * matrizEscalado) ;
        }

        public void Limpiar()
        {
            listaDeVertices = new Dictionary<string, Vector>();
            foreach (var vertice in listaDeVerticesCopia)
            {
                listaDeVertices.Add(vertice.Key.ToString(), new Vector(vertice.Value.X, vertice.Value.Y, vertice.Value.Z));
            }
            centroCaraCopia = centroLimpiar2;
            centro = centroLimpiar;
            traslacion = new Vector(0, 0, 0);
        }
    }
}
