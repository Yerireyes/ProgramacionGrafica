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
            escenario.Dibujar();
            //GL.Rotate(1, 1, 1, 0);
            //escenario.Rotar(0.01f, 0.01f, 0.01f);
            //escenario.Obtener("cubo2").Rotar(0.1f, 0.1f, 0.1f);

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
