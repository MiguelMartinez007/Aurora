namespace LIBRERIA_RECO
{
    partial class PantallaInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.animacion2 = new System.Windows.Forms.Timer(this.components);
            this.animacion1 = new System.Windows.Forms.Timer(this.components);
            this.espera = new System.Windows.Forms.Timer(this.components);
            this.interfazInicio1 = new LIBRERIA_RECO.interfazInicio();
            this.SuspendLayout();
            // 
            // animacion2
            // 
            this.animacion2.Tick += new System.EventHandler(this.animacion_Tick);
            // 
            // animacion1
            // 
            this.animacion1.Enabled = true;
            this.animacion1.Tick += new System.EventHandler(this.animacion1_Tick);
            // 
            // espera
            // 
            this.espera.Interval = 2000;
            this.espera.Tick += new System.EventHandler(this.espera_Tick);
            // 
            // interfazInicio1
            // 
            this.interfazInicio1.Location = new System.Drawing.Point(27, 37);
            this.interfazInicio1.Name = "interfazInicio1";
            this.interfazInicio1.Size = new System.Drawing.Size(690, 377);
            this.interfazInicio1.TabIndex = 0;
            // 
            // PantallaInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.interfazInicio1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PantallaInicio";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PantallaInicio";
            this.ResumeLayout(false);

        }

        #endregion

        private interfazInicio interfazInicio1;
        private System.Windows.Forms.Timer animacion2;
        private System.Windows.Forms.Timer animacion1;
        private System.Windows.Forms.Timer espera;
    }
}