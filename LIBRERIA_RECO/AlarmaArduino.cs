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
            pictureBox3.ImageLocation = @"c:\recursos\3.gif";
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.ImageLocation = @"c:\recursos\4.gif";
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.ImageLocation = @"c:\recursos\2.gif";
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;

            timer1.Start();
            
            hilosonido();
        }

        int ra;

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //a.timer1.Start();
            //Music m = new Music();
            //m.adesac();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            ra = r.Next(1, 4);
            if (ra == 1)
            {
                panel2.BackColor = Color.Red;
                panel1.BackColor = Color.Blue;
                panel3.BackColor = Color.Blue;
                panel4.BackColor = Color.Red;

                panel5.BackColor = Color.Red;
                panel6.BackColor = Color.Red;
                panel7.BackColor = Color.Blue;
                panel8.BackColor = Color.Red;
            }
            else if (ra == 2)
            {

                panel4.BackColor = Color.Red;
                panel3.BackColor = Color.Blue;
                panel2.BackColor = Color.Blue;
                panel1.BackColor = Color.Red;

                panel8.BackColor = Color.Red;
                panel7.BackColor = Color.Blue;
                panel6.BackColor = Color.Blue;
                panel5.BackColor = Color.Red;
            }
            else if (ra == 3)
            {
                panel3.BackColor = Color.Red;
                panel4.BackColor = Color.Blue;
                panel1.BackColor = Color.Blue;
                panel2.BackColor = Color.Red;

                panel7.BackColor = Color.Red;
                panel5.BackColor = Color.Blue;
                panel6.BackColor = Color.Red;
                panel8.BackColor = Color.Red;


            }
            else if (ra == 4)
            {


                panel1.BackColor = Color.Red;
                panel2.BackColor = Color.Blue;
                panel3.BackColor = Color.Blue;
                panel4.BackColor = Color.Red;

                panel8.BackColor = Color.Red;
                panel5.BackColor = Color.Blue;
                panel7.BackColor = Color.Blue;
                panel6.BackColor = Color.Red;

            }
        }


    }
}
