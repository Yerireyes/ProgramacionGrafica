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

namespace ProgramacionGrafica
{
    public partial class Form1 : Form
    {
        Game game;
        HelloEscenario escenario;
        HelloEscenario escenario2;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            escenario = new HelloEscenario(new Vector(-200, -100, 0));
            escenario.Add("cubo", CargadorJson.Cargar("../../Objetos/prueba.json"));
            escenario.Add("piramide", CargadorJson.Cargar("../../Objetos/prueba1.json"));
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
                FaceComboBox.SelectedItem.ToString()).Rotar(
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
                FaceComboBox.SelectedItem.ToString()).Trasladar(
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
    }
}
