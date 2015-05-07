namespace FaceCap
{
    partial class FaceCap
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
            this.faceImageBox = new Emgu.CV.UI.ImageBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelmin = new System.Windows.Forms.Label();
            this.textBoxWinSiz = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelscal = new System.Windows.Forms.Label();
            this.comboBoxMinNeigh = new System.Windows.Forms.ComboBox();
            this.comboBoxScIncRte = new System.Windows.Forms.ComboBox();
            this.txtPicName = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.btnRecog = new System.Windows.Forms.Button();
            this.btnPicRecog = new System.Windows.Forms.Button();
            this.btnYale = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.faceImageBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // faceImageBox
            // 
            this.faceImageBox.Location = new System.Drawing.Point(3, 12);
            this.faceImageBox.Name = "faceImageBox";
            this.faceImageBox.Size = new System.Drawing.Size(364, 319);
            this.faceImageBox.TabIndex = 2;
            this.faceImageBox.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(441, 399);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(409, 243);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(75, 23);
            this.btnCapture.TabIndex = 4;
            this.btnCapture.Text = "Register";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(521, 190);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(74, 40);
            this.btnBrowse.TabIndex = 18;
            this.btnBrowse.Text = "Load Image From Folder";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Scale Increase Rate:";
            // 
            // labelmin
            // 
            this.labelmin.AutoSize = true;
            this.labelmin.Location = new System.Drawing.Point(15, 58);
            this.labelmin.Name = "labelmin";
            this.labelmin.Size = new System.Drawing.Size(78, 13);
            this.labelmin.TabIndex = 11;
            this.labelmin.Text = "Min Neighbors:";
            // 
            // textBoxWinSiz
            // 
            this.textBoxWinSiz.Location = new System.Drawing.Point(130, 81);
            this.textBoxWinSiz.Name = "textBoxWinSiz";
            this.textBoxWinSiz.Size = new System.Drawing.Size(64, 20);
            this.textBoxWinSiz.TabIndex = 15;
            this.textBoxWinSiz.Text = "25";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelmin);
            this.groupBox1.Controls.Add(this.textBoxWinSiz);
            this.groupBox1.Controls.Add(this.labelscal);
            this.groupBox1.Controls.Add(this.comboBoxMinNeigh);
            this.groupBox1.Controls.Add(this.comboBoxScIncRte);
            this.groupBox1.Location = new System.Drawing.Point(503, 53);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(206, 119);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tune Detection Parameters:";
            // 
            // labelscal
            // 
            this.labelscal.AutoSize = true;
            this.labelscal.Location = new System.Drawing.Point(14, 81);
            this.labelscal.Name = "labelscal";
            this.labelscal.Size = new System.Drawing.Size(101, 26);
            this.labelscal.TabIndex = 12;
            this.labelscal.Text = "Min.detection Scale\r\n(Window Size)";
            // 
            // comboBoxMinNeigh
            // 
            this.comboBoxMinNeigh.FormattingEnabled = true;
            this.comboBoxMinNeigh.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxMinNeigh.Location = new System.Drawing.Point(130, 58);
            this.comboBoxMinNeigh.Name = "comboBoxMinNeigh";
            this.comboBoxMinNeigh.Size = new System.Drawing.Size(64, 21);
            this.comboBoxMinNeigh.TabIndex = 14;
            this.comboBoxMinNeigh.Text = "2";
            // 
            // comboBoxScIncRte
            // 
            this.comboBoxScIncRte.FormattingEnabled = true;
            this.comboBoxScIncRte.Items.AddRange(new object[] {
            "1.1",
            "1.2",
            "1.3",
            "1.4"});
            this.comboBoxScIncRte.Location = new System.Drawing.Point(130, 28);
            this.comboBoxScIncRte.Name = "comboBoxScIncRte";
            this.comboBoxScIncRte.Size = new System.Drawing.Size(64, 21);
            this.comboBoxScIncRte.TabIndex = 13;
            this.comboBoxScIncRte.Text = "1.1";
            // 
            // txtPicName
            // 
            this.txtPicName.Location = new System.Drawing.Point(521, 246);
            this.txtPicName.Name = "txtPicName";
            this.txtPicName.Size = new System.Drawing.Size(100, 20);
            this.txtPicName.TabIndex = 20;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(384, 282);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 21;
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(384, 54);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(100, 100);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 22;
            this.imageBox1.TabStop = false;
            // 
            // btnRecog
            // 
            this.btnRecog.Location = new System.Drawing.Point(409, 190);
            this.btnRecog.Name = "btnRecog";
            this.btnRecog.Size = new System.Drawing.Size(75, 23);
            this.btnRecog.TabIndex = 23;
            this.btnRecog.Text = "Recognize";
            this.btnRecog.UseVisualStyleBackColor = true;
            this.btnRecog.Click += new System.EventHandler(this.btnRecog_Click);
            // 
            // btnPicRecog
            // 
            this.btnPicRecog.Location = new System.Drawing.Point(520, 282);
            this.btnPicRecog.Name = "btnPicRecog";
            this.btnPicRecog.Size = new System.Drawing.Size(75, 23);
            this.btnPicRecog.TabIndex = 24;
            this.btnPicRecog.Text = "Match";
            this.btnPicRecog.UseVisualStyleBackColor = true;
            this.btnPicRecog.Click += new System.EventHandler(this.btnPicRecog_Click);
            // 
            // btnYale
            // 
            this.btnYale.Location = new System.Drawing.Point(545, 399);
            this.btnYale.Name = "btnYale";
            this.btnYale.Size = new System.Drawing.Size(75, 23);
            this.btnYale.TabIndex = 25;
            this.btnYale.Text = "Yale";
            this.btnYale.UseVisualStyleBackColor = true;
            this.btnYale.Visible = false;
            this.btnYale.Click += new System.EventHandler(this.btnYale_Click);
            // 
            // FaceCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 343);
            this.Controls.Add(this.btnYale);
            this.Controls.Add(this.btnPicRecog);
            this.Controls.Add(this.btnRecog);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtPicName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.faceImageBox);
            this.Name = "FaceCap";
            this.Text = "FaceCap";
            this.Load += new System.EventHandler(this.FaceCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.faceImageBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox faceImageBox;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelmin;
        private System.Windows.Forms.TextBox textBoxWinSiz;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelscal;
        private System.Windows.Forms.ComboBox comboBoxMinNeigh;
        private System.Windows.Forms.ComboBox comboBoxScIncRte;
        private System.Windows.Forms.TextBox txtPicName;
        private System.Windows.Forms.TextBox textBox1;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button btnRecog;
        private System.Windows.Forms.Button btnPicRecog;
        private System.Windows.Forms.Button btnYale;
    }
}

