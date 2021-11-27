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
        public Vector vectorRotacion;

        public Face(Dictionary<string, Vector> listaDeVertices, Color color, Vector centro)
        {
            this.listaDeVertices = listaDeVertices;
            this.color = color;
            this.centro = centro;
            vectorRotacion = new Vector(0, 0, 0);
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
            
            GL.Rotate(vectorRotacion.X, 1, 0, 0);
            GL.Rotate(vectorRotacion.Y, 0, 1, 0);
            GL.Rotate(vectorRotacion.Z, 0, 0, 1);
            GL.Color4(color);
            GL.Begin(PrimitiveType.Polygon);

            foreach (var vertice in listaDeVertices)
            {
                Vector vectorADibujar = vertice.Value * matrizRotacion * matrizEscalado;
                vectorADibujar += centro + traslacion;
                GL.PushMatrix();
                GL.Vertex3(vectorADibujar.X, vectorADibujar.Y, vectorADibujar.Z);
                GL.PopMatrix();

            }
            GL.End();
            
        }

        public void Rotar(float anguloX, float anguloY, float anguloZ)
        {
            anguloX = MathHelper.DegreesToRadians(anguloX);
            anguloY = MathHelper.DegreesToRadians(anguloY);
            anguloZ = MathHelper.DegreesToRadians(anguloZ);
            matrizRotacion *= Matrix3.CreateRotationX(anguloX) * Matrix3.CreateRotationY(anguloY) * Matrix3.CreateRotationZ(anguloZ);
            //    vectorRotacion.X += anguloX;
            //    vectorRotacion.Y += anguloY;
            //    vectorRotacion.Z += anguloZ;
        }

        //public static void RotarObjeto(float anguloX, float anguloY, float anguloZ, Vector centro, Dictionary<string, Face> listaDeCaras) 
        //{
        //    foreach (var cara in listaDeCaras)
        //    {
        //        //rotarEjeX(anguloX, centro, cara.Value.listaDeVertices);
        //        //rotarEjeY(anguloY, centro, cara.Value.listaDeVertices);
        //        //rotarEjeZ(anguloZ, centro, cara.Value.listaDeVertices);
        //        anguloX = MathHelper.DegreesToRadians(anguloX);
        //        anguloY = MathHelper.DegreesToRadians(anguloY);
        //        anguloZ = MathHelper.DegreesToRadians(anguloZ);
        //        //matrizRotacion *= Matrix3.CreateRotationX(anguloX) * Matrix3.CreateRotationY(anguloY) * Matrix3.CreateRotationZ(anguloZ);
        //    }

        //}

        //public static void rotarEjeX(float k, Vector centro, Dictionary<string, Vector> listaDeVertices)
        //{
        //    foreach (var vector in listaDeVertices)
        //    {
        //        float oldY = vector.Value.Y;
        //        float oldZ = vector.Value.Z;
        //        vector.Value.Y = centro.Y + (float)((oldY - centro.Y) * Math.Cos(k) - (oldZ - centro.Z) * Math.Sin(k));
        //        vector.Value.Z = centro.Z + (float)((oldZ - centro.Z) * Math.Cos(k) + (oldY - centro.Y) * Math.Sin(k));
        //    }
        //}

        //public static void rotarEjeY(float k, Vector centro, Dictionary<string, Vector> listaDeVertices)
        //{
        //    foreach (var vector in listaDeVertices)
        //    {
        //        float oldZ = vector.Value.Z;
        //        float oldX = vector.Value.X;
        //        vector.Value.Z = centro.Z + (float)((oldZ - centro.Z) * Math.Cos(k) - (oldX - centro.X) * Math.Sin(k));
        //        vector.Value.X = centro.X + (float)((oldX - centro.X) * Math.Cos(k) + (oldZ - centro.Z) * Math.Sin(k));
        //    }
        //}

        //public static void rotarEjeZ(float k, Vector centro, Dictionary<string, Vector> listaDeVertices)
        //{
        //    foreach (var vector in listaDeVertices)
        //    {
        //        float oldX = vector.Value.X;
        //        float oldY = vector.Value.Y;
        //        vector.Value.X = centro.X + (float)((oldX - centro.X) * Math.Cos(k) - (oldY - centro.Y) * Math.Sin(k));
        //        vector.Value.Y = centro.Y + (float)((oldY - centro.Y) * Math.Cos(k) + (oldX - centro.X) * Math.Sin(k));
        //    }
        //}
        //public void pruebaLocaLocanga(float theta, Vector centroCubo)
        //{
        //    float sinTheta = (float)Math.Sin(theta);
        //    float cosTheta = (float)Math.Cos(theta);

        //    foreach (var cara in listaDeVertices)
        //    {
        //        var x = cara.Value.X;
        //        var y = cara.Value.Y;
        //        var z = cara.Value.Z;
        //        //cara.Value.X = x * cosTheta - y * sinTheta;
        //        //cara.Value.Y = y * cosTheta + x * sinTheta;

        //        cara.Value.Y =centroCubo.Y + (y - centroCubo.Y) * cosTheta - (z - centroCubo.Z) * sinTheta;
        //        cara.Value.Z =centroCubo.Z + (z - centroCubo.Z) * cosTheta + (y - centroCubo.Y) * sinTheta;

        //        //cara.Value.Z = z * cosTheta - x * sinTheta;
        //        //cara.Value.X = x * cosTheta + z * sinTheta;
        //    }
        //}
        public void Trasladar(float x, float y, float z)
        {
            traslacion += new Vector(x, y, z);
        }

        public void Escalado(float x, float y, float z)
        {
            this.centro = new Vector(centro.X * x, centro.Y * y, centro.Z * z);
            matrizEscalado *= Matrix3.CreateScale(x, y, z); 
        }
    }
}
