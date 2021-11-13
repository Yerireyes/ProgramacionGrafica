using ConsoleApp5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramacionGrafica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Game game = new Game(1000, 700, ":D");
            game.Run();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Escenario1.Checked)
            {
                Game.escenario.Rotar(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
            }
            if (Escenario2.Checked)
            {
                Game.escenario2.Rotar(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Escenario1.Checked)
            {
                Game.escenario.Trasladar(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
            }
            if (Escenario2.Checked)
            {
                Game.escenario2.Trasladar(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Escenario1.Checked)
            {
                Game.escenario.Escalado(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
            }
            if (Escenario2.Checked)
            {
                Game.escenario2.Escalado(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
            }
            
        }

    }
}
