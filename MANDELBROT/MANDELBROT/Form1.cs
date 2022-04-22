//  Austin Downing
//  5000702338
//  HW#4 - Mandelbrot Set - Zoom
//  CS 480 - 1001

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MANDELBROT
{
 
    public partial class Mandelbrotorm : Form
    {
        public Bitmap bitMap;
        private List<BitmapCoordinateSet> bitMapList;
        public int width;
        public int height;
        public int zoomFactor;
        public int zoomBoxWidth;
        public int zoomBoxHeight;
        public double xMinCurrent;
        public double xMaxCurrent;
        public double yMinCurrent;
        public double yMaxCurrent;
        public double xMinTemp;
        public double xMaxTemp;
        public double yMinTemp;
        public double yMaxTemp;
        private bool drawing;
        private bool started;
        private bool zoomBoxMade;
        private Color backgroundColor;  // Diverge Color
        private Color mandelbrotColor;  // Converge Color
        private Pen zoomPen;



        public Mandelbrotorm()
        {
            InitializeComponent();
        }

        private void MandelbrotPictureBox_Click(object sender, EventArgs e)
        {
            double yMin, yMax, xMin, xMax;
            Bitmap tempBitmap = (Bitmap)bitMap.Clone();
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;
            zoomBoxHeight = height / zoomFactor;
            zoomBoxWidth = width / zoomFactor;
            Rectangle zoomRec = new Rectangle(mouseEventArgs.X - (zoomBoxWidth / 2), mouseEventArgs.Y - (zoomBoxHeight / 2), zoomBoxWidth, zoomBoxHeight);

            if (!drawing && started)
            {
                // draw square and save coordinates

                using (Graphics graphics = Graphics.FromImage(tempBitmap))
                {
                    graphics.DrawRectangle(zoomPen, zoomRec);
                    MandelbrotPictureBox.Image = tempBitmap;
                    //System.Console.WriteLine("X = " + mouseEventArgs.X + ", Y = " + mouseEventArgs.Y);
                }
                // allowed to draw
                //System.Console.WriteLine("Redrawing here: " + mouseEventArgs.X + ", " + mouseEventArgs.Y);
                // user to screen conversions
                //      X = (((S-Sl)(XM-Xm))/(Sr-Sl)) + Xm
                xMin = (((double)zoomRec.Left) * (xMaxCurrent - xMinCurrent) / (double)width) + xMinCurrent;
                xMax = (((double)zoomRec.Right) * (xMaxCurrent - xMinCurrent) / (double)width) + xMinCurrent;
                xMinTemp = xMin;
                xMaxTemp = xMax;
                yMin = (((double)zoomRec.Top) * (yMaxCurrent - yMinCurrent) / (double)height) + yMinCurrent;
                yMax = (((double)zoomRec.Bottom) * (yMaxCurrent - yMinCurrent) / (double)height) + yMinCurrent;
                yMinTemp = yMin;
                yMaxTemp = yMax;
                //System.Console.WriteLine("New xMin = " + xMinCurrent + " xMax = " + xMaxCurrent);
                //System.Console.WriteLine("New yMin = " + yMinCurrent + " yMax = " + yMaxCurrent);
                //System.Console.WriteLine("New xMinTemp = " + xMinTemp + " xMaxTemp = " + xMaxTemp);
                //System.Console.WriteLine("New yMinTemp = " + yMinTemp + " yMaxTemp = " + yMaxTemp);
                //  DrawMandelBrotSet(xMinCurrent, xMaxCurrent, yMinCurrent, yMaxCurrent);
                zoomBoxMade = true;
            }

        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            DrawButton.Enabled = false; // Dont want to call function while it is still running
            this.Update();              // alway have to update the form manualy...
            // Send to function that handles drawing Mandelbrot Set given the user coordinets.
            xMinCurrent = -2.0;
            xMaxCurrent = 2.0;
            yMinCurrent = -2.0;
            yMaxCurrent = 2.0;
            DrawMandelBrotSet(xMinCurrent, xMaxCurrent, yMinCurrent, yMaxCurrent);    // The arguments are going to matter later with the zoom... I think... havent gotten that far
            started = true;
        }

        private void DrawMandelBrotSet(double xMin, double xMax, double yMin, double yMax)
        {
            //  set the min max labels
            xMinLabel.Text = xMin.ToString();
            xMaxLabel.Text = xMax.ToString();
            yMinLabel.Text = yMin.ToString();
            yMaxLabel.Text = yMax.ToString();

            zoomBoxMade = false;
            PercentComplete.Visible = true;     // Make progress visible
            SaveButton.Enabled = false;         // Dont let them save an incomplete set
            ClearButton.Enabled = false;        // Dont let the clear an incomplete set (only because I dont know what would happen)
            this.Update();

            drawing = true;

            double xDiff = xMax - xMin;
            double yDiff = yMax - yMin;

            System.Console.WriteLine("xMin = " + xMin + ", xMax = " + xMax);
            System.Console.WriteLine("yMin = " + yMin + ", yMax = " + yMax);


            using (Graphics graphics = Graphics.FromImage(bitMap))
            {
                // Clear Box
                graphics.Clear(Color.Empty);

                // Draw The Mandelbrot set now

                // Declare variables
                Color designColor = mandelbrotColor;
                int n, t;
                double c0, c1, userX, userY, nextX, nextY, tempX;
                bool converge;  // used in for loops to find if pixel converges

                n = 100; // number of iterations
                t = 50;  // upper threshold

                //  (-2.0 + deltaX, 2)
                //  deltaX = 4/width
                //deltaX = 4.0 / width;
                //deltaY = 4.0 / height;
                //  Outside loop is Y axis
                for (int y = 0; y < height; y++)
                {

                    PercentComplete.Text = (int)(((double)y / (double)height) * 100.0) + "%";   // writes the percent of rows complete
                    this.Update();  // updates the percent text on the form

                    //  Inside loop is X axis
                    for (int x = 0; x < width; x++)
                    {
                        // convert pixel coordinates to user coordinates
                        //userX = -2.0 + (double)x * deltaX;
                        //userY = -2.0 + (double)y * deltaY;
                        userX = ( (double)x * xDiff / (double)width ) + xMin;
                        userY = ((double)y * yDiff / (double)height) + yMin;

                        // set c0 and c1 to the user coordinets
                        c0 = userX;
                        c1 = userY;

                        // set X0 and Y0 to zero
                        nextX = 0;
                        nextY = 0;

                        //  Set to true before we iterate
                        converge = true;
                        for (int z = 0; z < n; z++)
                        {
                            //  X+1 = X^2 - Y^2 + C0
                            tempX = Math.Pow(nextX, 2.0) - Math.Pow(nextY, 2.0) + c0;
                            //  Y+1 = 2*X*Y + C1
                            nextY = (2.0 * nextX * nextY) + c1;
                            //  use tempX so that the Y+1 calc is not effected by the X+1 calc
                            nextX = tempX;
                            if (Math.Pow(nextX, 2.0) + Math.Pow(nextY, 2.0) > t) // convergence test
                            {
                                converge = false; // if the pixel diverges end the loop
                                break;
                            }

                        }
                        if (converge)
                        {
                            bitMap.SetPixel(x, y, designColor);
                        }
                        else
                        {
                            bitMap.SetPixel(x, y, backgroundColor);
                        }
                    }
                    MandelbrotPictureBox.Image = bitMap; // Makes the pictureBox the current bitmap to see progress.
                }

                MandelbrotPictureBox.Image = bitMap;    // sets the final bitmap to the picture box image to display
                bitMapList.Add( new BitmapCoordinateSet( (Bitmap)bitMap.Clone(), xMin, xMax, yMin, yMax )); // Save latest bitmap
                System.Console.WriteLine("current count of bitmaps = " + bitMapList.Count);
                System.Console.Beep();  // I like the beeps.
                PercentComplete.Visible = false;    //  no progress to show now
                SaveButton.Enabled = true;          //  Allow saving when picture is complete
                ClearButton.Enabled = true;         //  allow clearing when picture is complete
                this.Update();                      //  Always have to update the form manualy

                drawing = false;
            }

        }

        private void Mandelbrotorm_Load(object sender, EventArgs e)
        {
            started = false;
            zoomFactor = (int)ZoomUpDown.Value;
            width = MandelbrotPictureBox.Size.Width;
            height = MandelbrotPictureBox.Size.Height;
            bitMap = new Bitmap(width, height);
            mandelbrotColor = Color.Black;
            MandelbrotColorPictureBox.BackColor = mandelbrotColor;
            DesignColorHex.Text = mandelbrotColor.ToString();
            backgroundColor = Color.White;
            backgroundPictureBox.BackColor = backgroundColor;
            backgroundColorHex.Text = backgroundColor.ToString();
            bitMapList = new List<BitmapCoordinateSet>();
            zoomPen = new Pen(Color.Blue, 2.0F);
            zoomBoxHeight = height / zoomFactor;
            zoomBoxWidth = width / zoomFactor;
        }

        private void backgroundPictureBox_Click(object sender, EventArgs e)
        {

            BackgroundColorDialog.ShowDialog();
            backgroundPictureBox.BackColor = BackgroundColorDialog.Color;
            backgroundColor = BackgroundColorDialog.Color;
            backgroundColorHex.Text = backgroundColor.ToString();

        }

        private void MandelbrotColorPictureBox_Click(object sender, EventArgs e)
        {

            BackgroundColorDialog.ShowDialog();
            MandelbrotColorPictureBox.BackColor = BackgroundColorDialog.Color;
            mandelbrotColor = BackgroundColorDialog.Color;
            DesignColorHex.Text = mandelbrotColor.ToString();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            // save picture
            var fileDialog = new SaveFileDialog();
            fileDialog.Filter = "JPG(*Jpg)|*.jpg";
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bitMap.Save(fileDialog.FileName, ImageFormat.Jpeg);
            }
            System.Console.Beep();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            started = false;
            using (Graphics graphics = Graphics.FromImage(bitMap))
            {
                graphics.Clear(Color.Empty);
                System.Console.Beep();
                MandelbrotPictureBox.Image = bitMap;
            }
            bitMapList = new List<BitmapCoordinateSet>();
            DrawButton.Enabled = true;
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            BitmapCoordinateSet bitmapCoordinateSet;
            System.Console.WriteLine("Zoom out called");
            if(bitMapList.Count >= 2)
            {
                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    bitmapCoordinateSet = bitMapList[bitMapList.Count - 2];
                    System.Console.WriteLine("bitMap #" + (bitMapList.Count - 2) + " replacing current");
                    MandelbrotPictureBox.Image = bitmapCoordinateSet.bitmap;
                    bitMap = (Bitmap)bitmapCoordinateSet.bitmap.Clone();
                    xMinCurrent = bitmapCoordinateSet.xMin;
                    xMaxCurrent = bitmapCoordinateSet.xMax;
                    yMinCurrent = bitmapCoordinateSet.yMin;
                    yMaxCurrent = bitmapCoordinateSet.yMax;
                    //  set the min max labels
                    xMinLabel.Text = xMinCurrent.ToString();
                    xMaxLabel.Text = xMaxCurrent.ToString();
                    yMinLabel.Text = yMinCurrent.ToString();
                    yMaxLabel.Text = yMaxCurrent.ToString();
                    bitMapList.RemoveAt(bitMapList.Count - 1);
                }
            }
            else
            {
                System.Console.WriteLine("Too few items to remove any from list");
            }
        }

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            if (zoomBoxMade)
            {
                xMinCurrent = xMinTemp;
                xMaxCurrent = xMaxTemp;
                yMinCurrent = yMinTemp;
                yMaxCurrent = yMaxTemp;
                DrawMandelBrotSet(xMinCurrent, xMaxCurrent, yMinCurrent, yMaxCurrent);
            }
            else
            {
                System.Console.WriteLine("Zoom box not made");
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            zoomFactor = (int)ZoomUpDown.Value;

        }
    }
    class BitmapCoordinateSet
    {
        public Bitmap bitmap;
        public double xMin;
        public double xMax;
        public double yMin;
        public double yMax;

        public BitmapCoordinateSet(Bitmap bitmap, double xMin, double xMax, double yMin, double yMax)
        {
            this.bitmap = bitmap;
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
        }
    }
}
