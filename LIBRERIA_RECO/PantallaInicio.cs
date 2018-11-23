using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRERIA_RECO
{
    public partial class PantallaInicio : Form
    {
        public PantallaInicio()
        {
            InitializeComponent();
        }

        ASISTENTE asistente;

        private void animacion_Tick(object sender, EventArgs e)
        {
            this.Opacity -= .1;
            if (this.Opacity == 0)
            {
                this.Hide();
                animacion2.Enabled = false;
                asistente = new ASISTENTE();
                asistente.ShowDialog();
                this.Close();
            }
        }

        private void animacion1_Tick(object sender, EventArgs e)
        {
            this.Opacity += .1;
            if (this.Opacity == 1)
            {
                espera.Enabled = true;
                animacion1.Enabled = false;
            }
        }

        private void espera_Tick(object sender, EventArgs e)
        {
            animacion2.Enabled = true;
            espera.Enabled = false;
        }
    }
}
