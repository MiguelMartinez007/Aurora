namespace LIBRERIA_RECO
{
    partial class AsistenteInterfaz
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.segundero = new System.Windows.Forms.Timer(this.components);
            this.Intervalo1 = new System.Windows.Forms.Label();
            this.Responde = new System.Windows.Forms.Label();
            this.Escucha = new System.Windows.Forms.Label();
            this.NivelAudio1 = new System.Windows.Forms.Label();
            this.NivelAudio = new System.Windows.Forms.Label();
            this.Intervalo = new System.Windows.Forms.Label();
            this.Mic = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // segundero
            // 
            this.segundero.Enabled = true;
            this.segundero.Tick += new System.EventHandler(this.segundero_Tick);
            // 
            // Intervalo1
            // 
            this.Intervalo1.AutoSize = true;
            this.Intervalo1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Intervalo1.ForeColor = System.Drawing.Color.Gray;
            this.Intervalo1.Location = new System.Drawing.Point(51, 27);
            this.Intervalo1.Name = "Intervalo1";
            this.Intervalo1.Size = new System.Drawing.Size(62, 17);
            this.Intervalo1.TabIndex = 29;
            this.Intervalo1.Text = "Intervalo";
            this.Intervalo1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Responde
            // 
            this.Responde.AutoSize = true;
            this.Responde.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Responde.ForeColor = System.Drawing.Color.Gray;
            this.Responde.Location = new System.Drawing.Point(51, 77);
            this.Responde.MaximumSize = new System.Drawing.Size(600, 0);
            this.Responde.Name = "Responde";
            this.Responde.Size = new System.Drawing.Size(62, 17);
            this.Responde.TabIndex = 28;
            this.Responde.Text = "Relleno 1";
            this.Responde.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Escucha
            // 
            this.Escucha.AutoSize = true;
            this.Escucha.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Escucha.ForeColor = System.Drawing.Color.Gray;
            this.Escucha.Location = new System.Drawing.Point(51, 52);
            this.Escucha.MaximumSize = new System.Drawing.Size(600, 0);
            this.Escucha.Name = "Escucha";
            this.Escucha.Size = new System.Drawing.Size(62, 17);
            this.Escucha.TabIndex = 27;
            this.Escucha.Text = "Relleno 1";
            this.Escucha.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NivelAudio1
            // 
            this.NivelAudio1.AutoSize = true;
            this.NivelAudio1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NivelAudio1.ForeColor = System.Drawing.Color.Gray;
            this.NivelAudio1.Location = new System.Drawing.Point(51, 2);
            this.NivelAudio1.Name = "NivelAudio1";
            this.NivelAudio1.Size = new System.Drawing.Size(76, 17);
            this.NivelAudio1.TabIndex = 26;
            this.NivelAudio1.Text = "Nivel audio";
            this.NivelAudio1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NivelAudio
            // 
            this.NivelAudio.AutoSize = true;
            this.NivelAudio.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NivelAudio.ForeColor = System.Drawing.Color.Gray;
            this.NivelAudio.Location = new System.Drawing.Point(608, 2);
            this.NivelAudio.Name = "NivelAudio";
            this.NivelAudio.Size = new System.Drawing.Size(22, 17);
            this.NivelAudio.TabIndex = 32;
            this.NivelAudio.Text = "65";
            this.NivelAudio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Intervalo
            // 
            this.Intervalo.AutoSize = true;
            this.Intervalo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Intervalo.ForeColor = System.Drawing.Color.Gray;
            this.Intervalo.Location = new System.Drawing.Point(608, 27);
            this.Intervalo.Name = "Intervalo";
            this.Intervalo.Size = new System.Drawing.Size(22, 17);
            this.Intervalo.TabIndex = 31;
            this.Intervalo.Text = "65";
            this.Intervalo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Mic
            // 
            this.Mic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(184)))), ((int)(((byte)(7)))));
            this.Mic.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.Mic.ForeColor = System.Drawing.Color.White;
            this.Mic.Location = new System.Drawing.Point(556, 59);
            this.Mic.Name = "Mic";
            this.Mic.Size = new System.Drawing.Size(72, 26);
            this.Mic.TabIndex = 34;
            this.Mic.Text = "Mic: ON";
            this.Mic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AsistenteInterfaz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Mic);
            this.Controls.Add(this.NivelAudio);
            this.Controls.Add(this.Intervalo);
            this.Controls.Add(this.Intervalo1);
            this.Controls.Add(this.Responde);
            this.Controls.Add(this.Escucha);
            this.Controls.Add(this.NivelAudio1);
            this.Name = "AsistenteInterfaz";
            this.Size = new System.Drawing.Size(690, 105);
            this.Load += new System.EventHandler(this.AsistenteInterfaz_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer segundero;
        private System.Windows.Forms.Label Intervalo1;
        public System.Windows.Forms.Label Responde;
        public System.Windows.Forms.Label Escucha;
        private System.Windows.Forms.Label NivelAudio1;
        public System.Windows.Forms.Label NivelAudio;
        public System.Windows.Forms.Label Intervalo;
        private System.Windows.Forms.Label Mic;
    }
}
