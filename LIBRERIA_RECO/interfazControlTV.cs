using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using LIBRERIA_RECO.Properties;

namespace LIBRERIA_RECO
{
    public partial class interfazControlTV : UserControl
    {
        public interfazControlTV()
        {
            try
            {
                InitializeComponent();
                serialPort1.PortName = "COM6";
                serialPort1.BaudRate = 9600;
                // serialPort1.Open();
                label2.Text = "TV Apagada";
                pictureBox1.ImageLocation = "OFF.png";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        bool bandera = false;
        Music m = new Music();
        string dato;



        private void interfazControlTV_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("4");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
            serialPort1.Write("o");
            label1.Text = "Encendido";
            if (bandera == false)
            {
                label2.Text = "TV Encendida";
                pictureBox1.ImageLocation = "ON.png";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                bandera = true;

            }
            else
            {

                label2.Text = "TV Apagada";
                pictureBox1.ImageLocation = "OFF.png";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                bandera = false;
            }
            serialPort1.Close();
        }

        private void btnmenos_Click(object sender, EventArgs e)
        {
            serialPort1.Write("2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("3");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1
            serialPort1.Write("a");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 2
            serialPort1.Write("b");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 3
            serialPort1.Write("c");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 4
            serialPort1.Write("d");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // 5
            serialPort1.Write("e");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 6
            serialPort1.Write("f");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // 7
            serialPort1.Write("g");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // 8
            serialPort1.Write("h");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 9
            serialPort1.Write("i");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // 0
            serialPort1.Write("j");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            {
                // .
                serialPort1.Write("k");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //activada
            serialPort1.Write("m");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //desactivada
            serialPort1.Write("m");
        }


    }
}
