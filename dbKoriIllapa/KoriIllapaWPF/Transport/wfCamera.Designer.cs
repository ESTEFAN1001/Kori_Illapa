
namespace KoriIllapaWPF.Transport
{
    partial class wfCamera
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
            this.btnCapturar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.imgLive = new System.Windows.Forms.PictureBox();
            this.imgCaptura = new System.Windows.Forms.PictureBox();
            this.cbxCameras = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgLive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptura)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCapturar
            // 
            this.btnCapturar.BackColor = System.Drawing.Color.Black;
            this.btnCapturar.Font = new System.Drawing.Font("News706 BT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapturar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCapturar.Location = new System.Drawing.Point(471, 347);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(102, 41);
            this.btnCapturar.TabIndex = 0;
            this.btnCapturar.Text = "Capturar";
            this.btnCapturar.UseVisualStyleBackColor = false;
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Black;
            this.btnGuardar.Font = new System.Drawing.Font("News706 BT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardar.Location = new System.Drawing.Point(640, 347);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 39);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.Black;
            this.btnGrabar.Font = new System.Drawing.Font("News706 BT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGrabar.Location = new System.Drawing.Point(302, 350);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(102, 38);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // imgLive
            // 
            this.imgLive.Location = new System.Drawing.Point(61, 41);
            this.imgLive.Name = "imgLive";
            this.imgLive.Size = new System.Drawing.Size(297, 286);
            this.imgLive.TabIndex = 3;
            this.imgLive.TabStop = false;
            // 
            // imgCaptura
            // 
            this.imgCaptura.Location = new System.Drawing.Point(453, 41);
            this.imgCaptura.Name = "imgCaptura";
            this.imgCaptura.Size = new System.Drawing.Size(289, 286);
            this.imgCaptura.TabIndex = 4;
            this.imgCaptura.TabStop = false;
            // 
            // cbxCameras
            // 
            this.cbxCameras.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbxCameras.ForeColor = System.Drawing.SystemColors.Window;
            this.cbxCameras.FormattingEnabled = true;
            this.cbxCameras.Location = new System.Drawing.Point(61, 343);
            this.cbxCameras.Name = "cbxCameras";
            this.cbxCameras.Size = new System.Drawing.Size(169, 21);
            this.cbxCameras.TabIndex = 6;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.Font = new System.Drawing.Font("News706 BT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalir.Location = new System.Drawing.Point(760, -4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(41, 39);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "x";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // wfCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 409);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.cbxCameras);
            this.Controls.Add(this.imgCaptura);
            this.Controls.Add(this.imgLive);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCapturar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "wfCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "wfCamera";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.wfCamera_FormClosed);
            this.Load += new System.EventHandler(this.wfCamera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCapturar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.PictureBox imgLive;
        private System.Windows.Forms.PictureBox imgCaptura;
        private System.Windows.Forms.ComboBox cbxCameras;
        private System.Windows.Forms.Button btnSalir;
    }
}