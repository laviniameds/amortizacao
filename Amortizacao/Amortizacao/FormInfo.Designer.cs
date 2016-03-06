namespace Amortizacao
{
    partial class FormInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
            this.comboBoxAmortizacao = new System.Windows.Forms.ComboBox();
            this.textBoxParcelas = new System.Windows.Forms.TextBox();
            this.textBoxJuros = new System.Windows.Forms.TextBox();
            this.textBoxMontante = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonExportarTabela = new System.Windows.Forms.Button();
            this.ButtonGerarTabela = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxAmortizacao
            // 
            this.comboBoxAmortizacao.FormattingEnabled = true;
            this.comboBoxAmortizacao.Items.AddRange(new object[] {
            "SAC",
            "PRICE",
            "AMERICANO"});
            this.comboBoxAmortizacao.Location = new System.Drawing.Point(31, 271);
            this.comboBoxAmortizacao.Name = "comboBoxAmortizacao";
            this.comboBoxAmortizacao.Size = new System.Drawing.Size(133, 21);
            this.comboBoxAmortizacao.TabIndex = 20;
            // 
            // textBoxParcelas
            // 
            this.textBoxParcelas.Location = new System.Drawing.Point(31, 203);
            this.textBoxParcelas.Name = "textBoxParcelas";
            this.textBoxParcelas.Size = new System.Drawing.Size(133, 20);
            this.textBoxParcelas.TabIndex = 19;
            // 
            // textBoxJuros
            // 
            this.textBoxJuros.Location = new System.Drawing.Point(31, 122);
            this.textBoxJuros.Name = "textBoxJuros";
            this.textBoxJuros.Size = new System.Drawing.Size(133, 20);
            this.textBoxJuros.TabIndex = 18;
            // 
            // textBoxMontante
            // 
            this.textBoxMontante.Location = new System.Drawing.Point(31, 45);
            this.textBoxMontante.Name = "textBoxMontante";
            this.textBoxMontante.Size = new System.Drawing.Size(133, 20);
            this.textBoxMontante.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Selecione o sistema de amortização:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Insira a quantidade de parcelas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Insira a taxa de juros:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Insira o montante:";
            // 
            // ButtonExportarTabela
            // 
            this.ButtonExportarTabela.Location = new System.Drawing.Point(396, 299);
            this.ButtonExportarTabela.Name = "ButtonExportarTabela";
            this.ButtonExportarTabela.Size = new System.Drawing.Size(75, 23);
            this.ButtonExportarTabela.TabIndex = 12;
            this.ButtonExportarTabela.Text = "Exportar";
            this.ButtonExportarTabela.UseVisualStyleBackColor = true;
            // 
            // ButtonGerarTabela
            // 
            this.ButtonGerarTabela.Location = new System.Drawing.Point(302, 299);
            this.ButtonGerarTabela.Name = "ButtonGerarTabela";
            this.ButtonGerarTabela.Size = new System.Drawing.Size(75, 23);
            this.ButtonGerarTabela.TabIndex = 11;
            this.ButtonGerarTabela.Text = "Gerar";
            this.ButtonGerarTabela.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(314, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 334);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxAmortizacao);
            this.Controls.Add(this.textBoxParcelas);
            this.Controls.Add(this.textBoxJuros);
            this.Controls.Add(this.textBoxMontante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonExportarTabela);
            this.Controls.Add(this.ButtonGerarTabela);
            this.Name = "FormInfo";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAmortizacao;
        private System.Windows.Forms.TextBox textBoxParcelas;
        private System.Windows.Forms.TextBox textBoxJuros;
        private System.Windows.Forms.TextBox textBoxMontante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonExportarTabela;
        private System.Windows.Forms.Button ButtonGerarTabela;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

