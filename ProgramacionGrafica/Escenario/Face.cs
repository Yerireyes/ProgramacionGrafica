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
        public Color color { get; set; }
        public Vector centro { get; set; }
        public Vector traslacion { get; set; } = new Vector(0, 0, 0);
        Matrix3 matrizRotacion =  Matrix3.Identity;
        Matrix3 matrizEscalado = Matrix3.Identity;

        public Face(Dictionary<string, Vector> listaDeVertices, Color color, Vector centro)
        {
            this.listaDeVertices = listaDeVertices;
            this.color = color;
            this.centro = centro;
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
                Vector vectorADibujar = vertice.Value * matrizRotacion * matrizEscalado;
                vectorADibujar += centro + traslacion;
                GL.Vertex3(vectorADibujar.X, vectorADibujar.Y, vectorADibujar.Z);

            }
            GL.End();
        }

        public void Rotar(float anguloX, float anguloY, float anguloZ)
        {
            anguloX = MathHelper.DegreesToRadians(anguloX);
            anguloY = MathHelper.DegreesToRadians(anguloY);
            anguloZ = MathHelper.DegreesToRadians(anguloZ);
            matrizRotacion *= Matrix3.CreateRotationX(anguloX) * Matrix3.CreateRotationY(anguloY) * Matrix3.CreateRotationZ(anguloZ);
        }
        
        public void Trasladar(float x, float y, float z)
        {
            traslacion += new Vector(x, y, z);
        }

        public void Escalado(float x, float y, float z)
        {
            matrizEscalado *= Matrix3.CreateScale(x, y, z); 
        }
    }
}
