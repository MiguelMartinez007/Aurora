namespace LIBRERIA_RECO
{
    partial class ASISTENTE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASISTENTE));
            this.menuPricipal = new System.Windows.Forms.Panel();
            this.luces = new Infinity.Controls.ButtonImageInfinity();
            this.general = new Infinity.Controls.ButtonImageInfinity();
            this.panel1 = new System.Windows.Forms.Panel();
            this.close = new Infinity.Controls.ButtonImageInfinity();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.barraSuperior = new System.Windows.Forms.Panel();
            this.barraInferior = new System.Windows.Forms.Panel();
            this.timerValoresFirebase = new System.Windows.Forms.Timer(this.components);
            this.pContenedor = new System.Windows.Forms.Panel();
            this.menuPricipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPricipal
            // 
            this.menuPricipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.menuPricipal.Controls.Add(this.luces);
            this.menuPricipal.Controls.Add(this.general);
            this.menuPricipal.Controls.Add(this.panel1);
            this.menuPricipal.Controls.Add(this.close);
            this.menuPricipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPricipal.Location = new System.Drawing.Point(0, 0);
            this.menuPricipal.Name = "menuPricipal";
            this.menuPricipal.Size = new System.Drawing.Size(60, 500);
            this.menuPricipal.TabIndex = 1;
            // 
            // luces
            // 
            this.luces.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.luces.ActiveIcon = ((System.Drawing.Bitmap)(resources.GetObject("luces.ActiveIcon")));
            this.luces.ActiveTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(251)))), ((int)(((byte)(232)))));
            this.luces.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.luces.BorderImage = 12;
            this.luces.ColorFondo = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.luces.Cursor = System.Windows.Forms.Cursors.Hand;
            this.luces.Dock = System.Windows.Forms.DockStyle.Top;
            this.luces.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luces.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(25)))));
            this.luces.HoverIcon = ((System.Drawing.Bitmap)(resources.GetObject("luces.HoverIcon")));
            this.luces.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(251)))), ((int)(((byte)(232)))));
            this.luces.Icon = ((System.Drawing.Bitmap)(resources.GetObject("luces.Icon")));
            this.luces.Location = new System.Drawing.Point(0, 180);
            this.luces.Name = "luces";
            this.luces.PositionImage = true;
            this.luces.Size = new System.Drawing.Size(60, 60);
            this.luces.SizeImage = 35;
            this.luces.TabIndex = 8;
            this.luces.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.luces.Click += new System.EventHandler(this.luces_Click);
            // 
            // general
            // 
            this.general.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.general.ActiveIcon = ((System.Drawing.Bitmap)(resources.GetObject("general.ActiveIcon")));
            this.general.ActiveTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(251)))), ((int)(((byte)(232)))));
            this.general.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.general.BorderImage = 12;
            this.general.ColorFondo = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.general.Cursor = System.Windows.Forms.Cursors.Hand;
            this.general.Dock = System.Windows.Forms.DockStyle.Top;
            this.general.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.general.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(25)))));
            this.general.HoverIcon = ((System.Drawing.Bitmap)(resources.GetObject("general.HoverIcon")));
            this.general.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(251)))), ((int)(((byte)(232)))));
            this.general.Icon = ((System.Drawing.Bitmap)(resources.GetObject("general.Icon")));
            this.general.Location = new System.Drawing.Point(0, 120);
            this.general.Name = "general";
            this.general.PositionImage = true;
            this.general.Size = new System.Drawing.Size(60, 60);
            this.general.SizeImage = 35;
            this.general.TabIndex = 7;
            this.general.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.general.Click += new System.EventHandler(this.general_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 60);
            this.panel1.TabIndex = 6;
            // 
            // close
            // 
            this.close.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.close.ActiveIcon = ((System.Drawing.Bitmap)(resources.GetObject("close.ActiveIcon")));
            this.close.ActiveTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(251)))), ((int)(((byte)(232)))));
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.close.BorderImage = 12;
            this.close.ColorFondo = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(29)))), ((int)(((byte)(38)))));
            this.close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close.Dock = System.Windows.Forms.DockStyle.Top;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(25)))));
            this.close.HoverIcon = ((System.Drawing.Bitmap)(resources.GetObject("close.HoverIcon")));
            this.close.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(251)))), ((int)(((byte)(232)))));
            this.close.Icon = ((System.Drawing.Bitmap)(resources.GetObject("close.Icon")));
            this.close.Location = new System.Drawing.Point(0, 0);
            this.close.Name = "close";
            this.close.PositionImage = true;
            this.close.Size = new System.Drawing.Size(60, 60);
            this.close.SizeImage = 35;
            this.close.TabIndex = 5;
            this.close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(60, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 40);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(60, 460);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(690, 40);
            this.panel4.TabIndex = 4;
            // 
            // barraSuperior
            // 
            this.barraSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(149)))), ((int)(((byte)(18)))));
            this.barraSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior.Location = new System.Drawing.Point(60, 40);
            this.barraSuperior.Name = "barraSuperior";
            this.barraSuperior.Size = new System.Drawing.Size(690, 40);
            this.barraSuperior.TabIndex = 5;
            // 
            // barraInferior
            // 
            this.barraInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(38)))), ((int)(((byte)(119)))));
            this.barraInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraInferior.Location = new System.Drawing.Point(60, 457);
            this.barraInferior.Name = "barraInferior";
            this.barraInferior.Size = new System.Drawing.Size(690, 3);
            this.barraInferior.TabIndex = 6;
            // 
            // timerValoresFirebase
            // 
            this.timerValoresFirebase.Enabled = true;
            this.timerValoresFirebase.Interval = 3000;
            this.timerValoresFirebase.Tick += new System.EventHandler(this.timerValoresFirebase_Tick);
            // 
            // pContenedor
            // 
            this.pContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pContenedor.Location = new System.Drawing.Point(60, 80);
            this.pContenedor.Name = "pContenedor";
            this.pContenedor.Size = new System.Drawing.Size(690, 377);
            this.pContenedor.TabIndex = 7;
            // 
            // ASISTENTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 500);
            this.Controls.Add(this.pContenedor);
            this.Controls.Add(this.barraInferior);
            this.Controls.Add(this.barraSuperior);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuPricipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ASISTENTE";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASISTENTE";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Load += new System.EventHandler(this.ASISTENTE_Load);
            this.menuPricipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPricipal;
        private Infinity.Controls.ButtonImageInfinity luces;
        private Infinity.Controls.ButtonImageInfinity general;
        private System.Windows.Forms.Panel panel1;
        private Infinity.Controls.ButtonImageInfinity close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel barraSuperior;
        private System.Windows.Forms.Panel barraInferior;
        private System.Windows.Forms.Timer timerValoresFirebase;
        private System.Windows.Forms.Panel pContenedor;
    }
}