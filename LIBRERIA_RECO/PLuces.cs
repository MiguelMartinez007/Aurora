using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRERIA_RECO
{
    public partial class PLuces : UserControl
    {
        public PLuces()
        {
            InitializeComponent();
        }


        /* Metodos de los controles */

        private void switchInfinity21_Click(object sender, EventArgs e)
        {
            controladorSwitch.controlSwitch("1", "2", switchICochera); // Llamada a la función que manda los comandos a la placa arduino
        }
    }
}
