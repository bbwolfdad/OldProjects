namespace FinalProject
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.FPSLabel = new System.Windows.Forms.Label();
            this.BallX = new System.Windows.Forms.NumericUpDown();
            this.BallY = new System.Windows.Forms.NumericUpDown();
            this.BallZ = new System.Windows.Forms.NumericUpDown();
            this.BounceBallButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.LightSourceIntensityNum = new System.Windows.Forms.NumericUpDown();
            this.AmbientLightNumber = new System.Windows.Forms.NumericUpDown();
            this.LightSourceBlueInput = new System.Windows.Forms.NumericUpDown();
            this.LightSourceGreenInput = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDownEyePositionZ = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEyePositionY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEyePositionX = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxBallColor = new System.Windows.Forms.PictureBox();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.checkBoxGrayScale = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxBallColor = new System.Windows.Forms.CheckBox();
            this.checkBoxMapImage = new System.Windows.Forms.CheckBox();
            this.FloorColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBoxSky = new System.Windows.Forms.PictureBox();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.buttonImageSelect = new System.Windows.Forms.Button();
            this.MapGroup = new System.Windows.Forms.GroupBox();
            this.pictureBoxMapImage = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.BallX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BallY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BallZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceIntensityNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbientLightNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceBlueInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceGreenInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEyePositionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEyePositionY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEyePositionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBallColor)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FloorColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSky)).BeginInit();
            this.MapGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMapImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // FPSLabel
            // 
            this.FPSLabel.AutoSize = true;
            this.FPSLabel.Location = new System.Drawing.Point(9, 61);
            this.FPSLabel.Name = "FPSLabel";
            this.FPSLabel.Size = new System.Drawing.Size(30, 13);
            this.FPSLabel.TabIndex = 2;
            this.FPSLabel.Text = "FPS:";
            // 
            // BallX
            // 
            this.BallX.Location = new System.Drawing.Point(36, 19);
            this.BallX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.BallX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.BallX.Name = "BallX";
            this.BallX.Size = new System.Drawing.Size(74, 20);
            this.BallX.TabIndex = 4;
            this.BallX.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.BallX.ValueChanged += new System.EventHandler(this.BallX_ValueChanged);
            // 
            // BallY
            // 
            this.BallY.Location = new System.Drawing.Point(36, 45);
            this.BallY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.BallY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.BallY.Name = "BallY";
            this.BallY.Size = new System.Drawing.Size(74, 20);
            this.BallY.TabIndex = 5;
            this.BallY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BallY.ValueChanged += new System.EventHandler(this.BallY_ValueChanged);
            // 
            // BallZ
            // 
            this.BallZ.Location = new System.Drawing.Point(36, 71);
            this.BallZ.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.BallZ.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.BallZ.Name = "BallZ";
            this.BallZ.Size = new System.Drawing.Size(74, 20);
            this.BallZ.TabIndex = 6;
            this.BallZ.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.BallZ.ValueChanged += new System.EventHandler(this.BallZ_ValueChanged);
            // 
            // BounceBallButton
            // 
            this.BounceBallButton.Location = new System.Drawing.Point(15, 35);
            this.BounceBallButton.Name = "BounceBallButton";
            this.BounceBallButton.Size = new System.Drawing.Size(75, 23);
            this.BounceBallButton.TabIndex = 7;
            this.BounceBallButton.Text = "Bounce Ball";
            this.BounceBallButton.UseVisualStyleBackColor = true;
            this.BounceBallButton.Click += new System.EventHandler(this.BounceBallButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Y";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Z";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(36, 19);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(74, 20);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // LightSourceIntensityNum
            // 
            this.LightSourceIntensityNum.Location = new System.Drawing.Point(36, 19);
            this.LightSourceIntensityNum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LightSourceIntensityNum.Name = "LightSourceIntensityNum";
            this.LightSourceIntensityNum.Size = new System.Drawing.Size(74, 20);
            this.LightSourceIntensityNum.TabIndex = 14;
            this.LightSourceIntensityNum.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LightSourceIntensityNum.ValueChanged += new System.EventHandler(this.LightSourceIntensityNum_ValueChanged);
            // 
            // AmbientLightNumber
            // 
            this.AmbientLightNumber.Location = new System.Drawing.Point(36, 19);
            this.AmbientLightNumber.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AmbientLightNumber.Name = "AmbientLightNumber";
            this.AmbientLightNumber.Size = new System.Drawing.Size(74, 20);
            this.AmbientLightNumber.TabIndex = 16;
            this.AmbientLightNumber.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AmbientLightNumber.ValueChanged += new System.EventHandler(this.AmbientLightNumber_ValueChanged);
            // 
            // LightSourceBlueInput
            // 
            this.LightSourceBlueInput.Location = new System.Drawing.Point(36, 71);
            this.LightSourceBlueInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LightSourceBlueInput.Name = "LightSourceBlueInput";
            this.LightSourceBlueInput.Size = new System.Drawing.Size(74, 20);
            this.LightSourceBlueInput.TabIndex = 17;
            this.LightSourceBlueInput.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LightSourceBlueInput.ValueChanged += new System.EventHandler(this.LightSourceBlueInput_ValueChanged);
            // 
            // LightSourceGreenInput
            // 
            this.LightSourceGreenInput.Location = new System.Drawing.Point(36, 45);
            this.LightSourceGreenInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LightSourceGreenInput.Name = "LightSourceGreenInput";
            this.LightSourceGreenInput.Size = new System.Drawing.Size(74, 20);
            this.LightSourceGreenInput.TabIndex = 18;
            this.LightSourceGreenInput.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LightSourceGreenInput.ValueChanged += new System.EventHandler(this.LightSourceGreenInput_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "R";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "B";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "G";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Z";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "Y";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "X";
            // 
            // numericUpDownEyePositionZ
            // 
            this.numericUpDownEyePositionZ.Location = new System.Drawing.Point(36, 71);
            this.numericUpDownEyePositionZ.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownEyePositionZ.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownEyePositionZ.Name = "numericUpDownEyePositionZ";
            this.numericUpDownEyePositionZ.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownEyePositionZ.TabIndex = 25;
            this.numericUpDownEyePositionZ.ValueChanged += new System.EventHandler(this.numericUpDownEyePositionZ_ValueChanged);
            // 
            // numericUpDownEyePositionY
            // 
            this.numericUpDownEyePositionY.Location = new System.Drawing.Point(36, 45);
            this.numericUpDownEyePositionY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownEyePositionY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownEyePositionY.Name = "numericUpDownEyePositionY";
            this.numericUpDownEyePositionY.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownEyePositionY.TabIndex = 24;
            this.numericUpDownEyePositionY.ValueChanged += new System.EventHandler(this.numericUpDownEyePositionY_ValueChanged);
            // 
            // numericUpDownEyePositionX
            // 
            this.numericUpDownEyePositionX.Location = new System.Drawing.Point(36, 19);
            this.numericUpDownEyePositionX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownEyePositionX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownEyePositionX.Name = "numericUpDownEyePositionX";
            this.numericUpDownEyePositionX.Size = new System.Drawing.Size(74, 20);
            this.numericUpDownEyePositionX.TabIndex = 23;
            this.numericUpDownEyePositionX.ValueChanged += new System.EventHandler(this.numericUpDownEyePositionX_ValueChanged);
            // 
            // pictureBoxBallColor
            // 
            this.pictureBoxBallColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBallColor.Enabled = false;
            this.pictureBoxBallColor.Location = new System.Drawing.Point(87, 28);
            this.pictureBoxBallColor.Name = "pictureBoxBallColor";
            this.pictureBoxBallColor.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxBallColor.TabIndex = 29;
            this.pictureBoxBallColor.TabStop = false;
            this.pictureBoxBallColor.Click += new System.EventHandler(this.pictureBoxBallColor_Click);
            // 
            // checkBoxGrayScale
            // 
            this.checkBoxGrayScale.AutoSize = true;
            this.checkBoxGrayScale.Checked = true;
            this.checkBoxGrayScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGrayScale.Location = new System.Drawing.Point(6, 38);
            this.checkBoxGrayScale.Name = "checkBoxGrayScale";
            this.checkBoxGrayScale.Size = new System.Drawing.Size(75, 17);
            this.checkBoxGrayScale.TabIndex = 31;
            this.checkBoxGrayScale.Text = "GrayScale";
            this.checkBoxGrayScale.UseVisualStyleBackColor = true;
            this.checkBoxGrayScale.CheckedChanged += new System.EventHandler(this.checkBoxGrayScale_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxBallColor);
            this.groupBox1.Controls.Add(this.checkBoxMapImage);
            this.groupBox1.Controls.Add(this.checkBoxGrayScale);
            this.groupBox1.Controls.Add(this.pictureBoxBallColor);
            this.groupBox1.Location = new System.Drawing.Point(9, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 117);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ball Color";
            // 
            // checkBoxBallColor
            // 
            this.checkBoxBallColor.AutoSize = true;
            this.checkBoxBallColor.Location = new System.Drawing.Point(6, 61);
            this.checkBoxBallColor.Name = "checkBoxBallColor";
            this.checkBoxBallColor.Size = new System.Drawing.Size(76, 17);
            this.checkBoxBallColor.TabIndex = 33;
            this.checkBoxBallColor.Text = "Solid Color";
            this.checkBoxBallColor.UseVisualStyleBackColor = true;
            this.checkBoxBallColor.CheckedChanged += new System.EventHandler(this.checkBoxBallColor_CheckedChanged);
            // 
            // checkBoxMapImage
            // 
            this.checkBoxMapImage.AutoSize = true;
            this.checkBoxMapImage.Location = new System.Drawing.Point(6, 81);
            this.checkBoxMapImage.Name = "checkBoxMapImage";
            this.checkBoxMapImage.Size = new System.Drawing.Size(79, 17);
            this.checkBoxMapImage.TabIndex = 32;
            this.checkBoxMapImage.Text = "Map Image";
            this.checkBoxMapImage.UseVisualStyleBackColor = true;
            this.checkBoxMapImage.CheckedChanged += new System.EventHandler(this.checkBoxMapImage_CheckedChanged);
            // 
            // FloorColorPictureBox
            // 
            this.FloorColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FloorColorPictureBox.Location = new System.Drawing.Point(12, 114);
            this.FloorColorPictureBox.Name = "FloorColorPictureBox";
            this.FloorColorPictureBox.Size = new System.Drawing.Size(50, 50);
            this.FloorColorPictureBox.TabIndex = 0;
            this.FloorColorPictureBox.TabStop = false;
            this.FloorColorPictureBox.Click += new System.EventHandler(this.FloorColorPictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Floor Color";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(81, 95);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Sky Color";
            // 
            // pictureBoxSky
            // 
            this.pictureBoxSky.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSky.Location = new System.Drawing.Point(81, 114);
            this.pictureBoxSky.Name = "pictureBoxSky";
            this.pictureBoxSky.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxSky.TabIndex = 33;
            this.pictureBoxSky.TabStop = false;
            this.pictureBoxSky.Click += new System.EventHandler(this.pictureBoxSky_Click);
            // 
            // buttonImageSelect
            // 
            this.buttonImageSelect.Location = new System.Drawing.Point(7, 41);
            this.buttonImageSelect.Name = "buttonImageSelect";
            this.buttonImageSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonImageSelect.TabIndex = 35;
            this.buttonImageSelect.Text = "Image";
            this.buttonImageSelect.UseVisualStyleBackColor = true;
            this.buttonImageSelect.Click += new System.EventHandler(this.buttonImageSelect_Click);
            // 
            // MapGroup
            // 
            this.MapGroup.Controls.Add(this.pictureBoxMapImage);
            this.MapGroup.Controls.Add(this.buttonImageSelect);
            this.MapGroup.Location = new System.Drawing.Point(9, 295);
            this.MapGroup.Name = "MapGroup";
            this.MapGroup.Size = new System.Drawing.Size(153, 100);
            this.MapGroup.TabIndex = 36;
            this.MapGroup.TabStop = false;
            this.MapGroup.Text = "Map Image To Ball";
            // 
            // pictureBoxMapImage
            // 
            this.pictureBoxMapImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxMapImage.Location = new System.Drawing.Point(88, 29);
            this.pictureBoxMapImage.Name = "pictureBoxMapImage";
            this.pictureBoxMapImage.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxMapImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMapImage.TabIndex = 36;
            this.pictureBoxMapImage.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BallX);
            this.groupBox2.Controls.Add(this.BallY);
            this.groupBox2.Controls.Add(this.BallZ);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(9, 401);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 100);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ball Location";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Location = new System.Drawing.Point(9, 504);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(153, 61);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ball Radius";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LightSourceGreenInput);
            this.groupBox4.Controls.Add(this.LightSourceIntensityNum);
            this.groupBox4.Controls.Add(this.LightSourceBlueInput);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(9, 573);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(153, 100);
            this.groupBox4.TabIndex = 39;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Light Source Color";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.AmbientLightNumber);
            this.groupBox5.Location = new System.Drawing.Point(9, 679);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(153, 56);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ambient Light Intensity";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.numericUpDownEyePositionX);
            this.groupBox6.Controls.Add(this.numericUpDownEyePositionY);
            this.groupBox6.Controls.Add(this.numericUpDownEyePositionZ);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Location = new System.Drawing.Point(9, 741);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(153, 100);
            this.groupBox6.TabIndex = 41;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Eye Location";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 1059);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.MapGroup);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.pictureBoxSky);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BounceBallButton);
            this.Controls.Add(this.FPSLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FloorColorPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Final Project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BallX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BallY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BallZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceIntensityNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmbientLightNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceBlueInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightSourceGreenInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEyePositionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEyePositionY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEyePositionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBallColor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FloorColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSky)).EndInit();
            this.MapGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMapImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label FPSLabel;
        private System.Windows.Forms.NumericUpDown BallX;
        private System.Windows.Forms.NumericUpDown BallY;
        private System.Windows.Forms.NumericUpDown BallZ;
        private System.Windows.Forms.Button BounceBallButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown LightSourceIntensityNum;
        private System.Windows.Forms.NumericUpDown AmbientLightNumber;
        private System.Windows.Forms.NumericUpDown LightSourceBlueInput;
        private System.Windows.Forms.NumericUpDown LightSourceGreenInput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDownEyePositionZ;
        private System.Windows.Forms.NumericUpDown numericUpDownEyePositionY;
        private System.Windows.Forms.NumericUpDown numericUpDownEyePositionX;
        private System.Windows.Forms.PictureBox pictureBoxBallColor;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.CheckBox checkBoxGrayScale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox FloorColorPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBoxSky;
        private System.Windows.Forms.ColorDialog colorDialog3;
        private System.Windows.Forms.Button buttonImageSelect;
        private System.Windows.Forms.GroupBox MapGroup;
        private System.Windows.Forms.PictureBox pictureBoxMapImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBoxMapImage;
        private System.Windows.Forms.CheckBox checkBoxBallColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}

