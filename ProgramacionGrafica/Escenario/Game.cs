﻿using System;
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
        public static HelloEscenario escenario;
        public static HelloEscenario escenario2;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color4.White);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(-500, 500, -500, 500, -500, 500);
            escenario = new HelloEscenario(new Vector(-200, -100, 0));
            escenario.Add("cubo", CargadorJson.Cargar("../../Objetos/prueba.json"));
            escenario.Add("piramide", CargadorJson.Cargar("../../Objetos/prueba1.json"));
            escenario2 = new HelloEscenario(new Vector(50, 50, 0));
            escenario2.Add("cubo", CargadorJson.Cargar("../../Objetos/prueba.json"));
            escenario2.Add("piramide", CargadorJson.Cargar("../../Objetos/prueba1.json"));
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
            //escenario.Rotar(0, 1, 0);
            //escenario.Obtener("cubo").Obtener("cara4").Rotar(1, 1, 0);
            escenario2.Dibujar();
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