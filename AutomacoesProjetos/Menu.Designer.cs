namespace AutomacoesProjetos
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnMoedas = new Button();
            btnTradutor = new Button();
            btnTemperatura = new Button();
            lstResultados = new ListView();
            btnCampeonato = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 19F);
            label1.Location = new Point(176, 22);
            label1.Name = "label1";
            label1.Size = new Size(362, 38);
            label1.TabIndex = 0;
            label1.Text = "Menu de automações";
            label1.Click += label1_Click;
            // 
            // btnMoedas
            // 
            btnMoedas.BackColor = Color.FromArgb(126, 190, 178);
            btnMoedas.ForeColor = Color.Snow;
            btnMoedas.Location = new Point(12, 128);
            btnMoedas.Name = "btnMoedas";
            btnMoedas.Size = new Size(140, 51);
            btnMoedas.TabIndex = 1;
            btnMoedas.Text = "Conversor Moedas";
            btnMoedas.UseVisualStyleBackColor = false;
            btnMoedas.Click += ConverterMoeda;
            // 
            // btnTradutor
            // 
            btnTradutor.BackColor = Color.FromArgb(209, 243, 219);
            btnTradutor.ForeColor = Color.Black;
            btnTradutor.Location = new Point(191, 128);
            btnTradutor.Name = "btnTradutor";
            btnTradutor.Size = new Size(140, 51);
            btnTradutor.TabIndex = 2;
            btnTradutor.Text = "Tradutor";
            btnTradutor.UseVisualStyleBackColor = false;
            btnTradutor.Click += Tradutor;
            // 
            // btnTemperatura
            // 
            btnTemperatura.BackColor = Color.FromArgb(125, 20, 76);
            btnTemperatura.ForeColor = SystemColors.ButtonFace;
            btnTemperatura.Location = new Point(370, 128);
            btnTemperatura.Name = "btnTemperatura";
            btnTemperatura.Size = new Size(140, 51);
            btnTemperatura.TabIndex = 3;
            btnTemperatura.Text = "Temperatura";
            btnTemperatura.UseVisualStyleBackColor = false;
            btnTemperatura.Click += PegarTemperatura;
            // 
            // lstResultados
            // 
            lstResultados.Location = new Point(12, 231);
            lstResultados.Name = "lstResultados";
            lstResultados.Size = new Size(706, 207);
            lstResultados.TabIndex = 5;
            lstResultados.UseCompatibleStateImageBehavior = false;
            // 
            // btnCampeonato
            // 
            btnCampeonato.BackColor = Color.FromArgb(188, 25, 83);
            btnCampeonato.ForeColor = Color.White;
            btnCampeonato.Location = new Point(561, 128);
            btnCampeonato.Name = "btnCampeonato";
            btnCampeonato.Size = new Size(135, 51);
            btnCampeonato.TabIndex = 6;
            btnCampeonato.Text = "Campeonato";
            btnCampeonato.UseVisualStyleBackColor = false;
            btnCampeonato.Click += PegarCampeonato;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(730, 450);
            Controls.Add(btnCampeonato);
            Controls.Add(lstResultados);
            Controls.Add(btnTemperatura);
            Controls.Add(btnTradutor);
            Controls.Add(btnMoedas);
            Controls.Add(label1);
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Automação";
            Click += Menu_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnMoedas;
        private Button btnTradutor;
        private Button btnTemperatura;
        private ListView lstResultados;
        private Button btnCampeonato;
    }
}
