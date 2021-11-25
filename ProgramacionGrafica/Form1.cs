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
        HelloEscenario escenario2;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            escenario = new HelloEscenario(new Vector(-200, -100, 0));
            Dictionary<string, Vector> caraFrente = new Dictionary<string, Vector>();
            caraFrente.Add("vector1", new Vector(-25, -25, 0));
            caraFrente.Add("vector2", new Vector(25, -25, 0));
            caraFrente.Add("vector3", new Vector(25, 25, 0));
            caraFrente.Add("vector4", new Vector(-25, 25, 0));
            Dictionary<string, Vector> caraArriba = new Dictionary<string, Vector>();
            caraArriba.Add("vector1", new Vector(-25, 0, -25));
            caraArriba.Add("vector2", new Vector(25, 0, -25));
            caraArriba.Add("vector3", new Vector(25, 0, 25));
            caraArriba.Add("vector4", new Vector(-25, 0, 25));
            Dictionary<string, Vector> caraAtras = new Dictionary<string, Vector>();
            caraAtras.Add("vector1", new Vector(-25, -25, 0));
            caraAtras.Add("vector2", new Vector(25, -25, 0));
            caraAtras.Add("vector3", new Vector(25, 25, 0));
            caraAtras.Add("vector4", new Vector(-25, 25, 0));
            Dictionary<string, Vector> caraAbajo = new Dictionary<string, Vector>();
            caraAbajo.Add("vector1", new Vector(-25, 0, -25));
            caraAbajo.Add("vector2", new Vector(25, 0, -25));
            caraAbajo.Add("vector3", new Vector(25, 0, 25));
            caraAbajo.Add("vector4", new Vector(-25, 0, 25));
            Dictionary<string, Vector> caraDerecha = new Dictionary<string, Vector>();
            caraDerecha.Add("vector1", new Vector(0, -25, -25));
            caraDerecha.Add("vector2", new Vector(0, -25, 25));
            caraDerecha.Add("vector3", new Vector(0, 25, 25));
            caraDerecha.Add("vector4", new Vector(0, 25, -25));
            Dictionary<string, Vector> caraIzquierda = new Dictionary<string, Vector>();
            caraIzquierda.Add("vector1", new Vector(0, -25, -25));
            caraIzquierda.Add("vector2", new Vector(0, -25, 25));
            caraIzquierda.Add("vector3", new Vector(0, 25, 25));
            caraIzquierda.Add("vector4", new Vector(0, 25, -25));

            Face caraCuboFrente = new Face(caraFrente, Color.Green, new Vector(0, 0, -25));
            Face caraCuboArriba = new Face(caraArriba, Color.Red, new Vector(0, 25, 0));
            Face caraCuboAtras = new Face(caraAtras, Color.Blue, new Vector(0, 0, 25));
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
            Objeto3D cubo = new Objeto3D(caraCubo, new Vector(0, 0, 0));
            escenario.Add("cubo", cubo);
            //escenario.Add("cubo", CargadorJson.Cargar("../../Objetos/prueba.json"));
            //escenario.Add("piramide", CargadorJson.Cargar("../../Objetos/prueba1.json"));
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
            game.escenario2 = this.escenario2;
            game.Run();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ObjetosComboBox.SelectedItem.ToString() == "Escenario")
            {
                game.transformacion = 1;
                game.x = float.Parse(textBox1.Text);
                game.y = float.Parse(textBox2.Text);
                game.z = float.Parse(textBox3.Text);
                //escenario.Rotar(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
                
                return;
            }

            if (FaceComboBox.SelectedItem.ToString() == "Objeto")
            {
                escenario.Obtener(ObjetosComboBox.SelectedItem.ToString()).Rotar(
                    float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
                return;
            }
            
            escenario.Obtener(ObjetosComboBox.SelectedItem.ToString()).Obtener(
                FaceComboBox.SelectedItem.ToString()).Rotar(
                    float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
                return;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ObjetosComboBox.SelectedItem.ToString() == "Escenario")
            {
                game.transformacion = 2;
                game.x = float.Parse(textBox1.Text);
                game.y = float.Parse(textBox2.Text);
                game.z = float.Parse(textBox3.Text);
                return;
            }

            if (FaceComboBox.SelectedItem.ToString() == "Objeto")
            {
                escenario.Obtener(ObjetosComboBox.SelectedItem.ToString()).Trasladar(
                    float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
                return;
            }

            escenario.Obtener(ObjetosComboBox.SelectedItem.ToString()).Obtener(
                FaceComboBox.SelectedItem.ToString()).Trasladar(
                    float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
            return;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ObjetosComboBox.SelectedItem.ToString() == "Escenario")
            {
                game.transformacion = 3;
                game.x = float.Parse(textBox1.Text);
                game.y = float.Parse(textBox2.Text);
                game.z = float.Parse(textBox3.Text);
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
    }
}
