using ConsoleApp5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ProgramacionGrafica
{
    partial class Form1 : Form
    {
        Game game;
        public HelloEscenario escenario;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            escenario = new HelloEscenario(new Vector(0, 0, 0));
            Dictionary<string, Vector> caraFrente = new Dictionary<string, Vector>();
            caraFrente.Add("vector1", new Vector(-25, -25, 0));
            caraFrente.Add("vector2", new Vector(25, -25, 0));
            caraFrente.Add("vector3", new Vector(25, 25, 0));
            caraFrente.Add("vector4", new Vector(-25, 25, 0));
            Dictionary<string, Vector> caraArriba = new Dictionary<string, Vector>();
            caraArriba.Add("vector5", new Vector(-25, 0, 25));
            caraArriba.Add("vector6", new Vector(25, 0, 25));
            caraArriba.Add("vector7", new Vector(25, 0, -25));
            caraArriba.Add("vector8", new Vector(-25, 0, -25));
            Dictionary<string, Vector> caraAtras = new Dictionary<string, Vector>();
            caraAtras.Add("vector9", new Vector(-25, -25, 0));
            caraAtras.Add("vector10", new Vector(25, -25, 0));
            caraAtras.Add("vector11", new Vector(25, 25, 0));
            caraAtras.Add("vector12", new Vector(-25, 25, 0));
            Dictionary<string, Vector> caraAbajo = new Dictionary<string, Vector>();
            caraAbajo.Add("vector13", new Vector(-25, 0, 25));
            caraAbajo.Add("vector14", new Vector(25, 0, 25));
            caraAbajo.Add("vector15", new Vector(25, 0, -25));
            caraAbajo.Add("vector16", new Vector(-25, 0, -25));
            Dictionary<string, Vector> caraDerecha = new Dictionary<string, Vector>();
            caraDerecha.Add("vector17", new Vector(0, -25, 25));
            caraDerecha.Add("vector18", new Vector(0, -25, -25));
            caraDerecha.Add("vector19", new Vector(0, 25, -25));
            caraDerecha.Add("vector20", new Vector(0, 25, 25));
            Dictionary<string, Vector> caraIzquierda = new Dictionary<string, Vector>();
            caraIzquierda.Add("vector21", new Vector(0, -25, 25));
            caraIzquierda.Add("vector22", new Vector(0, -25, -25));
            caraIzquierda.Add("vector23", new Vector(0, 25, -25));
            caraIzquierda.Add("vector24", new Vector(0, 25, 25));

            Face caraCuboFrente = new Face(caraFrente, Color.Green, new Vector(0, 0, 25));
            Face caraCuboArriba = new Face(caraArriba, Color.Red, new Vector(0, 25, 0));
            Face caraCuboAtras = new Face(caraAtras, Color.Blue, new Vector(0, 0, -25));
            Face caraCuboAbajo = new Face(caraAbajo, Color.LightGray, new Vector(0, -25, 0));
            Face caraCuboDerecha = new Face(caraDerecha, Color.Yellow, new Vector(25, 0, 0));
            Face caraCuboIzquierda = new Face(caraIzquierda, Color.GreenYellow, new Vector(-25, 0, 0));

            Dictionary<string, Face> caraCubo = new Dictionary<string, Face>();
            caraCubo.Add("caraFrente", caraCuboFrente);
            caraCubo.Add("caraArriba", caraCuboArriba);
            caraCubo.Add("caraAtras", caraCuboAtras);
            caraCubo.Add("caraAbajo", caraCuboAbajo);
            caraCubo.Add("caraDerecha", caraCuboDerecha);
            caraCubo.Add("caraIzquierda", caraCuboIzquierda);



            Dictionary<string, Vector> caraFrente2 = new Dictionary<string, Vector>();
            caraFrente2.Add("vector1", new Vector(-25, -25, 0));
            caraFrente2.Add("vector2", new Vector(25, -25, 0));
            caraFrente2.Add("vector3", new Vector(25, 25, 0));
            caraFrente2.Add("vector4", new Vector(-25, 25, 0));
            Dictionary<string, Vector> caraArriba2 = new Dictionary<string, Vector>();
            caraArriba2.Add("vector5", new Vector(-25, 0, -25));
            caraArriba2.Add("vector6", new Vector(25, 0, -25));
            caraArriba2.Add("vector7", new Vector(25, 0, 25));
            caraArriba2.Add("vector8", new Vector(-25, 0, 25));
            Dictionary<string, Vector> caraAtras2 = new Dictionary<string, Vector>();
            caraAtras2.Add("vector9", new Vector(-25, -25, 0));
            caraAtras2.Add("vector10", new Vector(25, -25, 0));
            caraAtras2.Add("vector11", new Vector(25, 25, 0));
            caraAtras2.Add("vector12", new Vector(-25, 25, 0));
            Dictionary<string, Vector> caraAbajo2 = new Dictionary<string, Vector>();
            caraAbajo2.Add("vector13", new Vector(-25, 0, -25));
            caraAbajo2.Add("vector14", new Vector(25, 0, -25));
            caraAbajo2.Add("vector15", new Vector(25, 0, 25));
            caraAbajo2.Add("vector16", new Vector(-25, 0, 25));
            Dictionary<string, Vector> caraDerecha2 = new Dictionary<string, Vector>();
            caraDerecha2.Add("vector17", new Vector(0, -25, -25));
            caraDerecha2.Add("vector18", new Vector(0, -25, 25));
            caraDerecha2.Add("vector19", new Vector(0, 25, 25));
            caraDerecha2.Add("vector20", new Vector(0, 25, -25));
            Dictionary<string, Vector> caraIzquierda2 = new Dictionary<string, Vector>();
            caraIzquierda2.Add("vector21", new Vector(0, -25, -25));
            caraIzquierda2.Add("vector22", new Vector(0, -25, 25));
            caraIzquierda2.Add("vector23", new Vector(0, 25, 25));
            caraIzquierda2.Add("vector24", new Vector(0, 25, -25));

            Face caraCuboFrente2 = new Face(caraFrente2, Color.Green, new Vector(0, 0, 0));
            Face caraCuboArriba2 = new Face(caraArriba2, Color.Red, new Vector(0, 0, 0));
            Face caraCuboAtras2 = new Face(caraAtras2, Color.Blue, new Vector(0, 0, 0));
            Face caraCuboAbajo2 = new Face(caraAbajo2, Color.LightGray, new Vector(0, 0, 0));
            Face caraCuboDerecha2 = new Face(caraDerecha2, Color.Yellow, new Vector(0, 0, 0));
            Face caraCuboIzquierda2 = new Face(caraIzquierda2, Color.GreenYellow, new Vector(0, 0, 0));

            Dictionary<string, Face> caraCubo2 = new Dictionary<string, Face>();
            caraCubo2.Add("caraFrente", caraCuboFrente2);
            caraCubo2.Add("caraArriba", caraCuboArriba2);
            caraCubo2.Add("caraAtras", caraCuboAtras2);
            caraCubo2.Add("caraAbajo", caraCuboAbajo2);
            caraCubo2.Add("caraDerecha", caraCuboDerecha2);
            caraCubo2.Add("caraIzquierda", caraCuboIzquierda2);

            Objeto3D cubo = new Objeto3D(caraCubo, new Vector(50, 50, 50));
            Objeto3D cubo2 = new Objeto3D(caraCubo2, new Vector(-100, -50, 0));
            //CargadorJson.Guardar("../../Objetos/cubo.json", cubo);
            //CargadorJson.Guardar("../../Objetos/cubo2.json", cubo2);
            escenario.Add("cubo", cubo);
            escenario.Add("cubo2", cubo2);
            //escenario.Add("cubo", CargadorJson.Cargar("../../Objetos/cubo.json"));
            //escenario.Add("cubo2", CargadorJson.Cargar("../../Objetos/cubo2.json"));
            Thread hilo = new Thread(gameDown);
            hilo.Start();
            ObjetosComboBox.Items.Add("Escenario");
            foreach (var key in escenario.listaDeObjetos3D.Keys)
            {
                ObjetosComboBox.Items.Add(key);
            }
            ObjetosComboBox.SelectedIndex = 0;
            mostrarCaras();
        }

        private void mostrarCaras()
        {
            FaceComboBox.Items.Clear();
            if (ObjetosComboBox.SelectedItem.ToString() == "Escenario")
            {
                FaceComboBox.Enabled = false;
                return;
            }
            FaceComboBox.Enabled = true;
            FaceComboBox.Items.Add("Objeto");
            foreach (var key in escenario.Obtener(ObjetosComboBox.SelectedItem.ToString()).GetListaDeCaras().Keys)
            {
                FaceComboBox.Items.Add(key);
            }
            FaceComboBox.SelectedIndex = 0;
        }

        private void gameDown()
        {
            game = new Game(700, 600, ":D");
            game.escenario = this.escenario;
            game.Run();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ObjetosComboBox.SelectedItem.ToString() == "Escenario")
            {
                escenario.Rotar(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));

                return;
            }

            if (FaceComboBox.SelectedItem.ToString() == "Objeto")
            {
                escenario.Obtener(ObjetosComboBox.SelectedItem.ToString()).Rotar(
                    float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
                return;
            }
            
            escenario.Obtener(ObjetosComboBox.SelectedItem.ToString()).Obtener(
                FaceComboBox.SelectedItem.ToString()).RotarCara(
                    float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
                return;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ObjetosComboBox.SelectedItem.ToString() == "Escenario")
            {
                escenario.Trasladar(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
                return;
            }

            if (FaceComboBox.SelectedItem.ToString() == "Objeto")
            {
                escenario.Obtener(ObjetosComboBox.SelectedItem.ToString()).Trasladar(
                    float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
                return;
            }

            escenario.Obtener(ObjetosComboBox.SelectedItem.ToString()).Obtener(
                FaceComboBox.SelectedItem.ToString()).TrasladarCara(
                    float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
            return;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ObjetosComboBox.SelectedItem.ToString() == "Escenario")
            {
                escenario.Escalado(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
                return;
            }

            if (FaceComboBox.SelectedItem.ToString() == "Objeto")
            {
                escenario.Obtener(ObjetosComboBox.SelectedItem.ToString()).Escalado(
                    float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
                return;
            }

            escenario.Obtener(ObjetosComboBox.SelectedItem.ToString()).Obtener(
                FaceComboBox.SelectedItem.ToString()).Escalado(
                    float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
            return;

        }

        private void ObjetosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarCaras();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            escenario.Limpiar();
        }
    }
}
