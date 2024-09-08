namespace proyectostegna
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
            menuStrip1 = new MenuStrip();
            abrirToolStripMenuItem = new ToolStripMenuItem();
            abrirToolStripMenuItem1 = new ToolStripMenuItem();
            guardarToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            imagenEscondidaToolStripMenuItem = new ToolStripMenuItem();
            abrirToolStripMenuItem2 = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            pictureBox3 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            textBox1 = new TextBox();
            button4 = new Button();
            button5 = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { abrirToolStripMenuItem, imagenEscondidaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1187, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // abrirToolStripMenuItem
            // 
            abrirToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrirToolStripMenuItem1, guardarToolStripMenuItem, salirToolStripMenuItem });
            abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            abrirToolStripMenuItem.Size = new Size(76, 20);
            abrirToolStripMenuItem.Text = "imagen ori";
            // 
            // abrirToolStripMenuItem1
            // 
            abrirToolStripMenuItem1.Name = "abrirToolStripMenuItem1";
            abrirToolStripMenuItem1.Size = new Size(115, 22);
            abrirToolStripMenuItem1.Text = "abrir";
            abrirToolStripMenuItem1.Click += abrirToolStripMenuItem1_Click;
            // 
            // guardarToolStripMenuItem
            // 
            guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            guardarToolStripMenuItem.Size = new Size(115, 22);
            guardarToolStripMenuItem.Text = "guardar";
            guardarToolStripMenuItem.Click += guardarToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(115, 22);
            salirToolStripMenuItem.Text = "salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // imagenEscondidaToolStripMenuItem
            // 
            imagenEscondidaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrirToolStripMenuItem2 });
            imagenEscondidaToolStripMenuItem.Name = "imagenEscondidaToolStripMenuItem";
            imagenEscondidaToolStripMenuItem.Size = new Size(116, 20);
            imagenEscondidaToolStripMenuItem.Text = "imagen escondida";
            // 
            // abrirToolStripMenuItem2
            // 
            abrirToolStripMenuItem2.Name = "abrirToolStripMenuItem2";
            abrirToolStripMenuItem2.Size = new Size(98, 22);
            abrirToolStripMenuItem2.Text = "abrir";
            abrirToolStripMenuItem2.Click += abrirToolStripMenuItem2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(12, 47);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(351, 346);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ActiveCaptionText;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.Location = new Point(393, 47);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(365, 346);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Cyan;
            button1.Location = new Point(266, 408);
            button1.Name = "button1";
            button1.Size = new Size(126, 42);
            button1.TabIndex = 3;
            button1.Text = "ocultar imagen";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.ActiveCaptionText;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.Location = new Point(795, 47);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(365, 346);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaptionText;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Cyan;
            button2.Location = new Point(414, 408);
            button2.Name = "button2";
            button2.Size = new Size(126, 42);
            button2.TabIndex = 5;
            button2.Text = "revelar imagen";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaptionText;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Cyan;
            button3.Location = new Point(557, 428);
            button3.Name = "button3";
            button3.Size = new Size(126, 42);
            button3.TabIndex = 6;
            button3.Text = "margen sobel";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.InactiveCaptionText;
            textBox1.ForeColor = Color.Cyan;
            textBox1.Location = new Point(66, 447);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(162, 23);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaptionText;
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.Cyan;
            button4.Location = new Point(266, 456);
            button4.Name = "button4";
            button4.Size = new Size(126, 42);
            button4.TabIndex = 8;
            button4.Text = "ocultar texto";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ActiveCaptionText;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.Cyan;
            button5.Location = new Point(414, 456);
            button5.Name = "button5";
            button5.Size = new Size(126, 42);
            button5.TabIndex = 9;
            button5.Text = "revelar texto";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1187, 502);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(pictureBox3);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem abrirToolStripMenuItem;
        private ToolStripMenuItem abrirToolStripMenuItem1;
        private ToolStripMenuItem guardarToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem imagenEscondidaToolStripMenuItem;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button1;
        private ToolStripMenuItem abrirToolStripMenuItem2;
        private PictureBox pictureBox3;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Button button4;
        private Button button5;
    }
}
