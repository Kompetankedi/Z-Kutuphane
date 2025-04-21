namespace Z_Kutuphane
{
    partial class Giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.rjButton1 = new CustomControls.RJControls.RJButton();
            this.rjButton2 = new CustomControls.RJControls.RJButton();
            this.Close = new CustomControls.RJControls.RJButton();
            this.TrBooks = new CustomControls.RJControls.RJButton();
            this.EnBooks = new CustomControls.RJControls.RJButton();
            this.Odunc = new CustomControls.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 0;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(2, 0);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(528, 37);
            this.rjButton1.TabIndex = 0;
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rjButton1_MouseDown);
            this.rjButton1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rjButton1_MouseMove);
            this.rjButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rjButton1_MouseUp);
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton2.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 0;
            this.rjButton2.BorderSize = 1;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.ForeColor = System.Drawing.Color.White;
            this.rjButton2.Image = global::Z_Kutuphane.Properties.Resources.subtract_32px;
            this.rjButton2.Location = new System.Drawing.Point(447, 5);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(31, 27);
            this.rjButton2.TabIndex = 2;
            this.rjButton2.TextColor = System.Drawing.Color.White;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton2_Click);
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Close.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Close.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Close.BorderRadius = 0;
            this.Close.BorderSize = 1;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.ForeColor = System.Drawing.Color.White;
            this.Close.Image = global::Z_Kutuphane.Properties.Resources.close_32px;
            this.Close.Location = new System.Drawing.Point(484, 5);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(31, 27);
            this.Close.TabIndex = 1;
            this.Close.TextColor = System.Drawing.Color.White;
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // TrBooks
            // 
            this.TrBooks.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.TrBooks.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.TrBooks.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.TrBooks.BorderRadius = 15;
            this.TrBooks.BorderSize = 5;
            this.TrBooks.FlatAppearance.BorderSize = 0;
            this.TrBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TrBooks.ForeColor = System.Drawing.Color.White;
            this.TrBooks.Location = new System.Drawing.Point(46, 89);
            this.TrBooks.Name = "TrBooks";
            this.TrBooks.Size = new System.Drawing.Size(150, 40);
            this.TrBooks.TabIndex = 3;
            this.TrBooks.Text = "Türkçe Kitaplar";
            this.TrBooks.TextColor = System.Drawing.Color.White;
            this.TrBooks.UseVisualStyleBackColor = false;
            this.TrBooks.Click += new System.EventHandler(this.TrBooks_Click);
            // 
            // EnBooks
            // 
            this.EnBooks.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.EnBooks.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.EnBooks.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.EnBooks.BorderRadius = 15;
            this.EnBooks.BorderSize = 5;
            this.EnBooks.FlatAppearance.BorderSize = 0;
            this.EnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnBooks.ForeColor = System.Drawing.Color.White;
            this.EnBooks.Location = new System.Drawing.Point(328, 89);
            this.EnBooks.Name = "EnBooks";
            this.EnBooks.Size = new System.Drawing.Size(150, 40);
            this.EnBooks.TabIndex = 4;
            this.EnBooks.Text = "Yabancı Kitaplar";
            this.EnBooks.TextColor = System.Drawing.Color.White;
            this.EnBooks.UseVisualStyleBackColor = false;
            this.EnBooks.Click += new System.EventHandler(this.EnBooks_Click);
            // 
            // Odunc
            // 
            this.Odunc.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Odunc.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Odunc.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Odunc.BorderRadius = 15;
            this.Odunc.BorderSize = 5;
            this.Odunc.FlatAppearance.BorderSize = 0;
            this.Odunc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Odunc.ForeColor = System.Drawing.Color.White;
            this.Odunc.Location = new System.Drawing.Point(188, 163);
            this.Odunc.Name = "Odunc";
            this.Odunc.Size = new System.Drawing.Size(150, 40);
            this.Odunc.TabIndex = 5;
            this.Odunc.Text = "Ödünç İşlemleri";
            this.Odunc.TextColor = System.Drawing.Color.White;
            this.Odunc.UseVisualStyleBackColor = false;
            this.Odunc.Click += new System.EventHandler(this.Odunc_Click);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(527, 358);
            this.Controls.Add(this.Odunc);
            this.Controls.Add(this.EnBooks);
            this.Controls.Add(this.TrBooks);
            this.Controls.Add(this.rjButton2);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.rjButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Giris";
            this.Text = "Z-Kutuphane";
            this.Load += new System.EventHandler(this.Giris_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.RJControls.RJButton rjButton1;
        private CustomControls.RJControls.RJButton Close;
        private CustomControls.RJControls.RJButton rjButton2;
        private CustomControls.RJControls.RJButton TrBooks;
        private CustomControls.RJControls.RJButton EnBooks;
        private CustomControls.RJControls.RJButton Odunc;
    }
}

