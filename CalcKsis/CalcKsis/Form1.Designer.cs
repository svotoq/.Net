namespace CalcKsis
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Masks = new System.Windows.Forms.ComboBox();
            this.Result = new System.Windows.Forms.Button();
            this.Ips = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(435, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Masks
            // 
            this.Masks.FormattingEnabled = true;
            this.Masks.Items.AddRange(new object[] {
            "/32 (255.255.255.255)",
            "/31 (255.255.255.254)",
            "/30 (255.255.255.252)",
            "/29 (255.255.255.248)",
            "/28 (255.255.255.240)",
            "/27 (255.255.255.224)",
            "/26 (255.255.255.192)",
            "/25 (255.255.255.128)",
            "/24 (255.255.255.0)",
            "/23 (255.255.254.0)",
            "/22 (255.255.252.0)",
            "/21 (255.255.248.0)",
            "/20 (255.255.240.0)",
            "/19 (255.255.224.0)",
            "/18 (255.255.192.0)",
            "/17 (255.255.128.0)",
            "/16 (255.255.0.0)",
            "/15 (255.254.0.0)",
            "/14 (255.252.0.0)",
            "/13 (255.248.0.0)",
            "/12 (255.240.0.0)",
            "/11 (255.224.0.0)",
            "/10 (255.192.0.0)",
            "/9 (255.128.0.0)",
            "/8 (255.0.0.0)",
            "/7 (254.0.0.0)",
            "/6 (252.0.0.0)",
            "/5 (248.0.0.0)",
            "/4 (240.0.0.0)",
            "/3 (224.0.0.0)",
            "/2 (192.0.0.0)",
            "/1 (128.0.0.0)",
            "/0 (0.0.0.0)"});
            this.Masks.Location = new System.Drawing.Point(247, 62);
            this.Masks.Name = "Masks";
            this.Masks.Size = new System.Drawing.Size(121, 21);
            this.Masks.TabIndex = 1;
            this.Masks.Text = "Маска подсети";
            this.Masks.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(179, 117);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(75, 23);
            this.Result.TabIndex = 2;
            this.Result.Text = "Вычислить";
            this.Result.UseVisualStyleBackColor = true;
            this.Result.Click += new System.EventHandler(this.button1_Click);
            // 
            // Ips
            // 
            this.Ips.Location = new System.Drawing.Point(96, 62);
            this.Ips.Name = "Ips";
            this.Ips.Size = new System.Drawing.Size(100, 20);
            this.Ips.TabIndex = 3;
            this.Ips.Text = "192.168.50.1";
            this.Ips.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 184);
            this.Controls.Add(this.Ips);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.Masks);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox Masks;
        private System.Windows.Forms.Button Result;
        private System.Windows.Forms.TextBox Ips;
    }
}

