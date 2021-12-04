using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp5
{
    class Transformacion
    {
        public Matrix3 matrizRotacion = Matrix3.Identity;
        public Matrix3 matrizEscalado = Matrix3.Identity;
        public Vector traslacion;
        public string nombreDelObjetoATransformar;


        public Transformacion(Matrix3 matrizRotacion, Matrix3 matrizEscalado, Vector traslacion, string nombreDelObjetoATransformar)
        {
            this.matrizRotacion = matrizRotacion;
            this.matrizEscalado = matrizEscalado;
            this.traslacion = traslacion;
            this.nombreDelObjetoATransformar = nombreDelObjetoATransformar;
        }


    }
}
