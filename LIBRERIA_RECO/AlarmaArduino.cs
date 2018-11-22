using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRERIA_RECO
{
    public partial class AlarmaArduino : Form
    {
        public AlarmaArduino()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = @"c:\recursos\1.gif";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ImageLocation = @"c:\recursos\2.gif";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.ImageLocation = @"c:\recursos\4.gif";
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.ImageLocation = @"c:\recursos\2.gif";
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            
            hilosonido();
        }
        bool pasadas = false;

        public void hilosonido()
        {
            //Crea la Instancia del hilo y Manda llamar al Metodo Guerra

            Thread t = new Thread(Guerra);
            t.Start();


        }
        //Instancia el dll Music1

        public void Guerra()
        {

            SoundPlayer s1 = new SoundPlayer(@"c:\recursos\alarma.wav");
            s1.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pasadas)
                panel1.BackColor = Color.Blue;
            else
                panel1.BackColor = Color.Red;
            pasadas = !pasadas;
        }

        private void buttonNormal1_Click(object sender, EventArgs e)
        {
            this.Close();
            //a.timer1.Start();
            //Music m = new Music();
            //m.adesac();
            Close();
        }


    }
}
