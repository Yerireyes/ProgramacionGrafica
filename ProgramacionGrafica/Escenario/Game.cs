using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ConsoleApp5
{
    class Game : GameWindow
    {
        private Dictionary<String, Objeto3D> objetos = new Dictionary<String, Objeto3D>();
        private Dictionary<String, Objeto3D> objetos1 = new Dictionary<String, Objeto3D>();
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }
        public HelloEscenario escenario;
        public HelloEscenario escenario2;
        public int transformacion = 0;
        public float x;
        public float y;
        public float z;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.White);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(-500, 500, -500, 500, -500, 500);
            
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            switch (transformacion)
            {
                case 1:
                    GL.Rotate(x, 1, 0, 0);
                    GL.Rotate(y, 0, 1, 0);
                    GL.Rotate(z, 0, 0, 1);
                    transformacion = 0;
                    break;

                case 2:
                    GL.Translate( x, y, z);
                    transformacion = 0;
                    break;

                case 3:
                    GL.Scale((double) x, (double) y, (double) z);
                    transformacion = 0;
                    break;
            }
            escenario.Dibujar();
            
            SwapBuffers();
            base.OnRenderFrame(e);
        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}
