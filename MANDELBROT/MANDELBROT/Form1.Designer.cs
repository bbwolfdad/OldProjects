namespace MANDELBROT
{
    partial class Mandelbrotorm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mandelbrotorm));
            this.MandelbrotPictureBox = new System.Windows.Forms.PictureBox();
            this.DrawButton = new System.Windows.Forms.Button();
            this.backgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.MandelbrotColorPictureBox = new System.Windows.Forms.PictureBox();
            this.BackgroundColorDialog = new System.Windows.Forms.ColorDialog();
            this.PercentComplete = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.backgroundColorHex = new System.Windows.Forms.Label();
            this.DesignColorHex = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ZoomOutButton = new System.Windows.Forms.Button();
            this.ZoomInButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.xMaxLabel = new System.Windows.Forms.Label();
            this.xMinLabel = new System.Windows.Forms.Label();
            this.yMaxLabel = new System.Windows.Forms.Label();
            this.yMinLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ZoomUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.MandelbrotPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MandelbrotColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MandelbrotPictureBox
            // 
            this.MandelbrotPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MandelbrotPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MandelbrotPictureBox.Location = new System.Drawing.Point(254, 12);
            this.MandelbrotPictureBox.Name = "MandelbrotPictureBox";
            this.MandelbrotPictureBox.Size = new System.Drawing.Size(1000, 800);
            this.MandelbrotPictureBox.TabIndex = 0;
            this.MandelbrotPictureBox.TabStop = false;
            this.MandelbrotPictureBox.Click += new System.EventHandler(this.MandelbrotPictureBox_Click);
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(74, 33);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(75, 23);
            this.DrawButton.TabIndex = 1;
            this.DrawButton.Text = "Draw Set";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // backgroundPictureBox
            // 
            this.backgroundPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundPictureBox.Location = new System.Drawing.Point(27, 162);
            this.backgroundPictureBox.Name = "backgroundPictureBox";
            this.backgroundPictureBox.Size = new System.Drawing.Size(60, 60);
            this.backgroundPictureBox.TabIndex = 2;
            this.backgroundPictureBox.TabStop = false;
            this.backgroundPictureBox.Click += new System.EventHandler(this.backgroundPictureBox_Click);
            // 
            // MandelbrotColorPictureBox
            // 
            this.MandelbrotColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MandelbrotColorPictureBox.Location = new System.Drawing.Point(27, 278);
            this.MandelbrotColorPictureBox.Name = "MandelbrotColorPictureBox";
            this.MandelbrotColorPictureBox.Size = new System.Drawing.Size(60, 60);
            this.MandelbrotColorPictureBox.TabIndex = 3;
            this.MandelbrotColorPictureBox.TabStop = false;
            this.MandelbrotColorPictureBox.Click += new System.EventHandler(this.MandelbrotColorPictureBox_Click);
            // 
            // BackgroundColorDialog
            // 
            this.BackgroundColorDialog.AnyColor = true;
            this.BackgroundColorDialog.FullOpen = true;
            // 
            // PercentComplete
            // 
            this.PercentComplete.AutoEllipsis = true;
            this.PercentComplete.AutoSize = true;
            this.PercentComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PercentComplete.Location = new System.Drawing.Point(69, 75);
            this.PercentComplete.Name = "PercentComplete";
            this.PercentComplete.Size = new System.Drawing.Size(44, 26);
            this.PercentComplete.TabIndex = 4;
            this.PercentComplete.Text = "0%";
            this.PercentComplete.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Background Color";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(24, 238);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(67, 13);
            this.label.TabIndex = 6;
            this.label.Text = "Design Color";
            // 
            // backgroundColorHex
            // 
            this.backgroundColorHex.AutoSize = true;
            this.backgroundColorHex.Location = new System.Drawing.Point(24, 146);
            this.backgroundColorHex.Name = "backgroundColorHex";
            this.backgroundColorHex.Size = new System.Drawing.Size(19, 13);
            this.backgroundColorHex.TabIndex = 7;
            this.backgroundColorHex.Text = "----";
            // 
            // DesignColorHex
            // 
            this.DesignColorHex.AutoSize = true;
            this.DesignColorHex.Location = new System.Drawing.Point(24, 262);
            this.DesignColorHex.Name = "DesignColorHex";
            this.DesignColorHex.Size = new System.Drawing.Size(19, 13);
            this.DesignColorHex.TabIndex = 8;
            this.DesignColorHex.Text = "----";
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(74, 386);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(74, 416);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 10;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.Location = new System.Drawing.Point(71, 512);
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.Size = new System.Drawing.Size(75, 23);
            this.ZoomOutButton.TabIndex = 11;
            this.ZoomOutButton.Text = "Zoom Out";
            this.ZoomOutButton.UseVisualStyleBackColor = true;
            this.ZoomOutButton.Click += new System.EventHandler(this.ZoomOutButton_Click);
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.Location = new System.Drawing.Point(71, 483);
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.Size = new System.Drawing.Size(75, 23);
            this.ZoomInButton.TabIndex = 12;
            this.ZoomInButton.Text = "Zoom In";
            this.ZoomInButton.UseVisualStyleBackColor = true;
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 567);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "xMin = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 590);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "xMax = ";
            // 
            // xMaxLabel
            // 
            this.xMaxLabel.AutoSize = true;
            this.xMaxLabel.Location = new System.Drawing.Point(72, 590);
            this.xMaxLabel.Name = "xMaxLabel";
            this.xMaxLabel.Size = new System.Drawing.Size(37, 13);
            this.xMaxLabel.TabIndex = 16;
            this.xMaxLabel.Text = "----------";
            // 
            // xMinLabel
            // 
            this.xMinLabel.AutoSize = true;
            this.xMinLabel.Location = new System.Drawing.Point(72, 567);
            this.xMinLabel.Name = "xMinLabel";
            this.xMinLabel.Size = new System.Drawing.Size(37, 13);
            this.xMinLabel.TabIndex = 15;
            this.xMinLabel.Text = "----------";
            // 
            // yMaxLabel
            // 
            this.yMaxLabel.AutoSize = true;
            this.yMaxLabel.Location = new System.Drawing.Point(72, 647);
            this.yMaxLabel.Name = "yMaxLabel";
            this.yMaxLabel.Size = new System.Drawing.Size(37, 13);
            this.yMaxLabel.TabIndex = 20;
            this.yMaxLabel.Text = "----------";
            // 
            // yMinLabel
            // 
            this.yMinLabel.AutoSize = true;
            this.yMinLabel.Location = new System.Drawing.Point(72, 624);
            this.yMinLabel.Name = "yMinLabel";
            this.yMinLabel.Size = new System.Drawing.Size(37, 13);
            this.yMinLabel.TabIndex = 19;
            this.yMinLabel.Text = "----------";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 647);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "yMax = ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 624);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "yMin = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 460);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Zoom Level";
            // 
            // ZoomUpDown
            // 
            this.ZoomUpDown.Location = new System.Drawing.Point(99, 458);
            this.ZoomUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ZoomUpDown.Name = "ZoomUpDown";
            this.ZoomUpDown.Size = new System.Drawing.Size(120, 20);
            this.ZoomUpDown.TabIndex = 22;
            this.ZoomUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ZoomUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Mandelbrotorm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 821);
            this.Controls.Add(this.ZoomUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yMaxLabel);
            this.Controls.Add(this.yMinLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.xMaxLabel);
            this.Controls.Add(this.xMinLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ZoomInButton);
            this.Controls.Add(this.ZoomOutButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DesignColorHex);
            this.Controls.Add(this.backgroundColorHex);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PercentComplete);
            this.Controls.Add(this.MandelbrotColorPictureBox);
            this.Controls.Add(this.backgroundPictureBox);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.MandelbrotPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mandelbrotorm";
            this.Text = "MANDELBROT";
            this.Load += new System.EventHandler(this.Mandelbrotorm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MandelbrotPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MandelbrotColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MandelbrotPictureBox;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.PictureBox backgroundPictureBox;
        private System.Windows.Forms.PictureBox MandelbrotColorPictureBox;
        private System.Windows.Forms.ColorDialog BackgroundColorDialog;
        private System.Windows.Forms.Label PercentComplete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label backgroundColorHex;
        private System.Windows.Forms.Label DesignColorHex;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ZoomOutButton;
        private System.Windows.Forms.Button ZoomInButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label xMaxLabel;
        private System.Windows.Forms.Label xMinLabel;
        private System.Windows.Forms.Label yMaxLabel;
        private System.Windows.Forms.Label yMinLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ZoomUpDown;
    }
}

