namespace cryptioALGO
{
    partial class Form1
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
            txtAliciMail = new TextBox();
            btnEpostaGonder = new Button();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            txtCikti = new TextBox();
            txtGirdi = new TextBox();
            groupBox2 = new GroupBox();
            btnEpostaIndir = new Button();
            groupBox3 = new GroupBox();
            txtAnahtar2 = new TextBox();
            txtAnahtar1 = new TextBox();
            btnCoz = new Button();
            btnSifrele = new Button();
            label6 = new Label();
            label5 = new Label();
            cmbYontem = new ComboBox();
            label4 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(15, 24);
            label1.Name = "label1";
            label1.Size = new Size(105, 21);
            label1.TabIndex = 0;
            label1.Text = "Alıcı E-Posta";
            // 
            // txtAliciMail
            // 
            txtAliciMail.Location = new Point(138, 24);
            txtAliciMail.Name = "txtAliciMail";
            txtAliciMail.Size = new Size(154, 23);
            txtAliciMail.TabIndex = 1;
            // 
            // btnEpostaGonder
            // 
            btnEpostaGonder.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnEpostaGonder.Location = new Point(15, 52);
            btnEpostaGonder.Name = "btnEpostaGonder";
            btnEpostaGonder.Size = new Size(79, 38);
            btnEpostaGonder.TabIndex = 2;
            btnEpostaGonder.Text = "Gönder";
            btnEpostaGonder.UseVisualStyleBackColor = true;
            btnEpostaGonder.Click += btnEpostaGonder_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(96, 21);
            label2.TabIndex = 4;
            label2.Text = "Girdi Metni";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(6, 101);
            label3.Name = "label3";
            label3.Size = new Size(99, 21);
            label3.TabIndex = 6;
            label3.Text = "Çıktı Mesajı";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCikti);
            groupBox1.Controls.Add(txtGirdi);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(24, 142);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(519, 190);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "METİN İŞLEMLERİ";
            // 
            // txtCikti
            // 
            txtCikti.Location = new Point(15, 125);
            txtCikti.Multiline = true;
            txtCikti.Name = "txtCikti";
            txtCikti.Size = new Size(481, 50);
            txtCikti.TabIndex = 7;
            // 
            // txtGirdi
            // 
            txtGirdi.Location = new Point(15, 43);
            txtGirdi.Multiline = true;
            txtGirdi.Name = "txtGirdi";
            txtGirdi.Size = new Size(479, 55);
            txtGirdi.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnEpostaIndir);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtAliciMail);
            groupBox2.Controls.Add(btnEpostaGonder);
            groupBox2.Location = new Point(24, 21);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(519, 100);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "E-POSTA İŞLEMLERİ";
            // 
            // btnEpostaIndir
            // 
            btnEpostaIndir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnEpostaIndir.Location = new Point(417, 52);
            btnEpostaIndir.Name = "btnEpostaIndir";
            btnEpostaIndir.Size = new Size(79, 38);
            btnEpostaIndir.TabIndex = 3;
            btnEpostaIndir.Text = "indir";
            btnEpostaIndir.UseVisualStyleBackColor = true;
            
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtAnahtar2);
            groupBox3.Controls.Add(txtAnahtar1);
            groupBox3.Controls.Add(btnCoz);
            groupBox3.Controls.Add(btnSifrele);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(cmbYontem);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(24, 347);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(519, 176);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "ŞİFRELEME AYARLARI VE İŞLEMLER";
            // 
            // txtAnahtar2
            // 
            txtAnahtar2.Location = new Point(354, 76);
            txtAnahtar2.Name = "txtAnahtar2";
            txtAnahtar2.Size = new Size(140, 23);
            txtAnahtar2.TabIndex = 8;
            // 
            // txtAnahtar1
            // 
            txtAnahtar1.Location = new Point(105, 72);
            txtAnahtar1.Name = "txtAnahtar1";
            txtAnahtar1.Size = new Size(140, 23);
            txtAnahtar1.TabIndex = 4;
            // 
            // btnCoz
            // 
            btnCoz.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCoz.Location = new Point(417, 123);
            btnCoz.Name = "btnCoz";
            btnCoz.Size = new Size(79, 38);
            btnCoz.TabIndex = 4;
            btnCoz.Text = "Çöz";
            btnCoz.UseVisualStyleBackColor = true;
            btnCoz.Click += btnCoz_Click;
            // 
            // btnSifrele
            // 
            btnSifrele.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSifrele.Location = new Point(18, 121);
            btnSifrele.Name = "btnSifrele";
            btnSifrele.Size = new Size(84, 38);
            btnSifrele.TabIndex = 4;
            btnSifrele.Text = "Şifrele";
            btnSifrele.UseVisualStyleBackColor = true;
            btnSifrele.Click += btnSifrele_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(260, 74);
            label6.Name = "label6";
            label6.Size = new Size(88, 21);
            label6.TabIndex = 7;
            label6.Text = " Anahtar 2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(15, 74);
            label5.Name = "label5";
            label5.Size = new Size(84, 21);
            label5.TabIndex = 6;
            label5.Text = "Anahtar 1";
            // 
            // cmbYontem
            // 
            cmbYontem.FormattingEnabled = true;
            cmbYontem.Location = new Point(192, 33);
            cmbYontem.Name = "cmbYontem";
            cmbYontem.Size = new Size(121, 23);
            cmbYontem.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(15, 33);
            label4.Name = "label4";
            label4.Size = new Size(171, 21);
            label4.TabIndex = 4;
            label4.Text = "Şifreleme Yöntemleri";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 587);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtAliciMail;
        private Button btnEpostaGonder;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnEpostaIndir;
        private GroupBox groupBox3;
        private TextBox txtAnahtar2;
        private TextBox txtAnahtar1;
        private Button btnCoz;
        private Button btnSifrele;
        private Label label6;
        private Label label5;
        private ComboBox cmbYontem;
        private Label label4;
        private TextBox txtCikti;
        private TextBox txtGirdi;
    }
}
