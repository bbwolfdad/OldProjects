/*
 * 
 * Austin Downing
 * downia1@unlv.nevada.edu
 * CS-480-1001
 * Final Project
 * Due 11/18/2020
 * 
 *      Take raytracing homework and add a lazer and walls for lazer to bounce from.
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Size userSpace;
        private Size screenSpace;
        private Point drawingLocation;
        public Ball ball;
        public Eye eye;
        public Floor floor;
        public LightSource lightSource;
        public Color skyColor;
        public double ambientLight = 25;
        public Timer bounceTimer;
        public double bounceHeight = .05;
        public double bounceTop = 1;
        public double bounceTotal;
        public bool upBounce;
        public int interval; // speed of funcion call
        public bool paintingFloor;
        public LightBeam lightBeam;
        public double ambientMix;
        public Stopwatch stopwatch;
        public Bitmap defaultImage;

        public BufferedGraphics bufferedGraphics;
        public BufferedGraphicsContext bufferedGraphicsContext;
        public int bufferCount;

        public Bitmap imageToMap;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            screenSpace = new Size(600, 600);
            drawingLocation = new Point(250, 20);
            skyColor = Color.Cyan;


            // buffer Setup
            bufferedGraphicsContext = BufferedGraphicsManager.Current;
            bufferedGraphicsContext.MaximumBuffer = new Size(screenSpace.Width + 1, screenSpace.Height + 1);
            bufferedGraphics = bufferedGraphicsContext.Allocate(this.CreateGraphics(), new Rectangle(drawingLocation.X, drawingLocation.Y, screenSpace.Width, screenSpace.Height));
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            ball = new Ball(
                            1.0,                           // radius
                            new Point3D(7.0, 1.0, 2.0),    // center point
                            Color.White                    // color of ball
                            );
            eye = new Eye(5.0, 3.0, -10.0);
            userSpace = new Size(10, 10);
            floor = new Floor(20.0, 20.0, 20.0, ball.bottomPoint(), Color.Purple);
            FloorColorPictureBox.BackColor = Color.Purple;
            lightSource = new LightSource(new Point3D(2.0, 8.0, 2.0), 255, 255, 255); // position, red, green, blue
            interval = intervalFromFPS(30);
            stopwatch = new Stopwatch();
            ambientMix = ambientLight / 255.0;

            pictureBoxBallColor.BackColor = ball.color;

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream ioStream = assembly.GetManifestResourceStream("FinalProject.Default.png");
            defaultImage = new Bitmap(ioStream);
            pictureBoxMapImage.Image = defaultImage;
            imageToMap = (Bitmap)defaultImage.Clone();

            // set numeric up downs to initial values
            BallX.Value = (int)ball.centerPoint.X;
            BallY.Value = (int)ball.centerPoint.Y;
            BallZ.Value = (int)ball.centerPoint.Z;

            numericUpDownEyePositionX.Value = (int)eye.position.X;
            numericUpDownEyePositionY.Value = (int)eye.position.Y;
            numericUpDownEyePositionZ.Value = (int)eye.position.Z;

            lightBeam = new LightBeam(ball.centerPoint, lightSource.position, Color.Red);

            AmbientLightNumber.Value = (decimal)ambientLight;
            LightSourceIntensityNum.Value = (decimal)lightSource.redIntensity;
            LightSourceGreenInput.Value = (decimal)lightSource.greenIntensity;
            LightSourceBlueInput.Value = (decimal)lightSource.blueIntensity;

            pictureBoxSky.BackColor = skyColor;
            

            stopwatch.Start();
            paintScene(bufferedGraphics.Graphics);
            stopwatch.Stop();
            setFPSLabel(stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            bufferedGraphics.Render();
            //pictureBox1.Image = newBitmap;
            this.Refresh();

            this.Update();

        }
        // -------------------------------------------- Functions --------------------------------------------

        public void setFPSLabel(long elapsedMilliseconds)
        {

            FPSLabel.Text = "FPS: " + (1000.0 / elapsedMilliseconds);

            this.Update();
        }

        private void setupTimer()
        {

            BounceBallButton.Enabled = false;
            bounceTimer = new Timer();
            bounceTimer.Interval = interval;
            bounceTimer.Tick += new EventHandler(bounce);

            //jumpSound.Play();
            upBounce = true;

            // Buffer setup
            bufferCount = 0;
            paintScene(bufferedGraphics.Graphics);

            bounceTimer.Start();

        }


        public void bounce(Object jumpObject, EventArgs eventArgs)
        {
            //System.Console.WriteLine("Bounce call");
            if (!upBounce)
            {
                if (bounceTotal <= 0)
                {
                    bounceTimer.Stop();
                    bounceTimer.Dispose();
                    BounceBallButton.Enabled = true;
                    //landSound.Play();
                    //leftArm.printAngles();
                    //rightArm.printAngles();
                    System.Console.WriteLine("End Bounce");
                    return;
                }
                else
                {
                    bounceTotal = bounceTotal - bounceHeight;
                    ball.moveDown(bounceHeight);
                    lightBeam.setBeam(ball.centerPoint, lightSource.position);
                }
            }
            else
            {
                bounceTotal = bounceTotal + bounceHeight;
                if (bounceTotal >= bounceTop)
                {
                    upBounce = false;
                }
                ball.moveUp(bounceHeight);
                lightBeam.setBeam(ball.centerPoint, lightSource.position);
            }
            stopwatch.Start();
            paintScene(bufferedGraphics.Graphics);
            stopwatch.Stop();
            setFPSLabel(stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
        }


        public void paintScene(Graphics graphics)
        {
            int screenX;
            int screenY;
            Ray ray;
            Bitmap newBitmap = new Bitmap(screenSpace.Width, screenSpace.Height);
            bool ballFirst = false;

            for (screenY = 0; screenY < screenSpace.Height; screenY++)
            {
                paintingFloor = false;
                for (screenX = 0; screenX < screenSpace.Width; screenX++)
                {
                    ray = new Ray(eye.position, new Point3D(screenX, screenY, 0, "currentPoint"));
                    if (ray.seeBall(
                                    ball,
                                    screenSpace,
                                    userSpace
                                    )
                        )
                    {
                        if( screenX == 0)
                        {
                            ballFirst = true;
                        }
                        // paint ball color
                        if (ray.discriminant >= 0)
                        {
                            // trace ray to light source

                            Ray ballToLightRay = new Ray(ray.intersectionPoint, lightSource.position);
                            //System.Console.WriteLine("discriminant = " + ballToLightRay.discriminant);
                            ball.makeNormalRay(ray.intersectionPoint);
                            Color pixelColor = findColorBalance(ball.color, ballToLightRay, ball.normalRay, ball.grayScale, true);
                            newBitmap.SetPixel(screenX, screenY, pixelColor);
                        }
                    }
                    else
                    {
                        // paint sky color or floor
                        if (screenX == 0 || ballFirst)
                        {
                            ballFirst = false;
                            if (ray.yIncrease())
                            {
                                paintingFloor = false;
                            }
                            else
                            {
                                paintingFloor = true;
                            }
                        }
                        if (!paintingFloor)
                        {
                            // paint sky
                            newBitmap.SetPixel(screenX, screenY, skyColor);
                        }
                        else
                        {
                            // Paint Floor
                            // get intersect with floor
                            Point3D floorIntersectionPoint = ray.intersectWithFloor();
                            Ray floorToLight = new Ray(floorIntersectionPoint, lightSource.position);
                            floorToLight.secondIsUser = true;
                            floorToLight.seeBall(ball, screenSpace, userSpace);
                            if (floorToLight.discriminant > 0)
                            {
                                // case were light is blocked by the ball
                                //System.Console.WriteLine("Floor discriminant = " + floorToLight.discriminant);
                                newBitmap.SetPixel(screenX, screenY, Color.FromArgb(floor.color.A, (int)(floor.color.R * ambientMix), (int)(floor.color.G * ambientMix), (int)(floor.color.B * ambientMix)));
                            }
                            else
                            {
                                // find the color balance for the floor
                                //  newBitmap.SetPixel(screenX, screenY, floor.color);
                                Ray floorNormalRay;
                                floorNormalRay = new Ray(floorIntersectionPoint, new Point3D(floorIntersectionPoint.X, floorIntersectionPoint.Y + 1.0, floorIntersectionPoint.Z));
                                floorNormalRay.isNormalized = true;
                                newBitmap.SetPixel(screenX, screenY, findColorBalance(floor.color, floorToLight, floorNormalRay, false, false));
                            }
                        }
                    }
                }
            }
            graphics.DrawImage(newBitmap, drawingLocation.X, drawingLocation.Y, newBitmap.Width, newBitmap.Height);
            bufferedGraphics.Render();
            //pictureBox1.Image = newBitmap;
            //this.Refresh();

            this.Update();
        }
        public double getCosTheta(Vector3D arrowOne, Vector3D arrowTwo)
        {
            return     (arrowOne.X * arrowTwo.X) +
                       (arrowOne.Y * arrowTwo.Y) +
                       (arrowOne.Z * arrowTwo.Z)
                       ;
        }
        public Color findColorBalance(Color color, Ray lightRay, Ray normalRay, bool greyScale, bool paintingBall)
        {
            Color returnColor;
            double cosTheta;
            Vector3D arrowCI, arrowIL;
            double cI, iL;
            //                ->   ->
            // cos(theta) = ( CI * IL )/ ( sqrt((CI)^2) * sqrt((IL)^2) )
            //      where: 
            //              arrow CI = magnitude
            //              arrow IL = magnitude
            //              CI       = radius?
            //              IL       = distance from light to ball Intersection



            cI = lightRay.getMagnitude(lightRay.origin, lightRay.secondPoint);
            arrowCI = new Vector3D(lightRay.origin, lightRay.secondPoint);
            if (!lightRay.isNormalized)
            {
                arrowCI = arrowCI.normalizedVector(cI);
            }
            //System.Console.WriteLine("here");
            iL = normalRay.getMagnitude(normalRay.origin, normalRay.secondPoint);
            arrowIL = new Vector3D(normalRay.origin, normalRay.secondPoint);
            if (!normalRay.isNormalized)
            {
                arrowIL = arrowIL.normalizedVector(iL);
            }
            //arrowCI.printVector();
            //arrowIL.printVector();
            cosTheta = getCosTheta(arrowCI, arrowIL);
            //cosTheta = (arrowCI.X * arrowIL.X) +
            //           (arrowCI.Y * arrowIL.Y) +
            //           (arrowCI.Z * arrowIL.Z)
            //           ;
            //System.Console.WriteLine("CosTheta = " + cosTheta);
            //System.Console.WriteLine("cI = " + cI + " iL = " + iL);
            if (checkBoxMapImage.Checked && paintingBall)
            {
                // Map image to ball...
                int imageX = 0;
                int imageY = 0;
                // get x
                imageX = (int)((pictureBoxMapImage.Image.Width) * (getCosTheta(arrowIL, new Vector3D(-1.0, 0.0, 0.0)) - 0.0 ));
                //System.Console.WriteLine("X = " + imageX);
                if ( imageX > 0)
                {
                    imageX = imageX + (pictureBoxMapImage.Image.Width / 2);
                }
                if (imageX < 0)
                {
                    ////System.Console.WriteLine("pictureCoordinates = " + imageX + ", " + imageY);
                    //imageX = Math.Abs(imageX);// + (pictureBoxMapImage.Image.Width / 2);
                    imageX = (pictureBoxMapImage.Image.Width / 2) + imageX;
                    if (imageX < 0)
                    {
                        imageX = pictureBoxMapImage.Image.Width + imageX;
                    }
                }
                if (imageX >= pictureBoxMapImage.Image.Width)
                {
                    imageX = imageX % pictureBoxMapImage.Image.Width ;
                }
                // get y
                imageY = (int)((pictureBoxMapImage.Image.Height) * (getCosTheta(arrowIL, new Vector3D(0.0, 1.0, 0.0)) - 0.0));
                //System.Console.WriteLine("Y = " + imageY);
                if (imageY > 0)
                {
                    imageY = imageY + (pictureBoxMapImage.Image.Height / 2);
                }
                if (imageY < 0)
                {
                    ////System.Console.WriteLine("pictureCoordinates = " + imageY + ", " + imageY);
                    //imageY = Math.Abs(imageY);// + (pictureBoxMapImage.Image.Height / 2);
                    imageY = (pictureBoxMapImage.Image.Height / 2) + imageY;
                    if (imageY < 0)
                    {
                        imageY = pictureBoxMapImage.Image.Height + imageY;
                    }
                }
                if (imageY >= pictureBoxMapImage.Image.Height)
                {
                    imageY = imageY % pictureBoxMapImage.Image.Height;
                }
                //System.Console.WriteLine("pictureCoordinates = " + imageX + ", " + imageY);
                if(imageX == 0)
                {
                    imageX = (pictureBoxMapImage.Image.Width / 2);
                }
                if (imageY == 0)
                {
                    imageY = (pictureBoxMapImage.Image.Height / 2);
                }
                color = ((Bitmap)pictureBoxMapImage.Image).GetPixel(imageX, imageY);
            }
            if (cosTheta > 0)
            {
                byte A, R, G, B;
                //A = color.A;
                //R = color.R;
                //G = color.G;
                //B = color.B;
                double greyValue;
                if (greyScale)
                {
                    int hightestIntensity = Math.Max(lightSource.redIntensity, Math.Max(lightSource.greenIntensity, lightSource.blueIntensity));
                    greyValue = (double)((cosTheta * hightestIntensity) + ambientLight);
                    if (greyValue > 255)
                    {
                        greyValue = 255;
                    }
                    A = 255;
                    R = (byte)greyValue;
                    G = R;
                    B = R;
                }
                else if(checkBoxBallColor.Checked)
                {
                    A = 255;
                    R = (byte)(((double)color.R) * ((cosTheta * lightSource.redIntensity) / 255.0));
                    G = (byte)(((double)color.G) * ((cosTheta * lightSource.greenIntensity) / 255.0));
                    B = (byte)(((double)color.B) * ((cosTheta * lightSource.blueIntensity) / 255.0));
                    R = mixWithAmbientLight(R, color.R);
                    G = mixWithAmbientLight(G, color.G);
                    B = mixWithAmbientLight(B, color.B);
                }
                else
                {

                    A = 255;
                    R = (byte)(((double)color.R) * ((cosTheta * lightSource.redIntensity) / 255.0));
                    G = (byte)(((double)color.G) * ((cosTheta * lightSource.greenIntensity) / 255.0));
                    B = (byte)(((double)color.B) * ((cosTheta * lightSource.blueIntensity) / 255.0));
                    R = mixWithAmbientLight(R, color.R);
                    G = mixWithAmbientLight(G, color.G);
                    B = mixWithAmbientLight(B, color.B);
                }
                // System.Console.WriteLine(" A = " + A + " R = " + R + " G = " + G + " B = " + B);

                returnColor = Color.FromArgb(A, R, G, B);

            }
            else
            {
                //returnColor = Color.FromArgb(floor.color.A, (int)(ball.color.R * ambientLight), (int)(ball.color.G * ambientLight), (int)(ball.color.B * ambientLight));
                //returnColor = Color.FromArgb(floor.color.A, (int)ambientLight, (int)ambientLight, (int)ambientLight);
                returnColor = Color.FromArgb(color.A, (int)((double)color.R * ambientMix), (int)((double)color.G * ambientMix), (int)((double)color.B * ambientMix));
            }


            return returnColor;
        }

        public byte mixWithAmbientLight( byte colorValue, byte originalColor)
        {
            byte originalAmbientMix = (byte)((double)originalColor * ambientMix);
            if(colorValue > originalAmbientMix)
            {
                return colorValue;
            }
            else
            {
                return originalAmbientMix;
            }
        }

        public int intervalFromFPS(int FPS)
        {
            int returnInterval;

            // interval is in 1000ms/1s
            // fps is Frames per Second
            // interval = 1s/FPS * 1000ms/1s
            returnInterval = (int)(1000.0 / (double)FPS);

            System.Console.WriteLine("interval = " + returnInterval + " from givin FPS = " + FPS);
            return returnInterval;
        }
        // -------------------------------------------- Objects --------------------------------------------

        public class Ball : userSpaceObject
        {
            public double radius;
            public Point3D centerPoint;
            public Point3D intersectionPoint;
            public Color color;
            public double discriminant;
            public Ray normalRay;
            public bool grayScale;

            public Ball(double radius, Point3D centerPoint, Color color)
            {
                this.radius = radius;
                this.centerPoint = centerPoint;
                this.color = color;
                this.grayScale = true;
            }

            public Point3D bottomPoint()
            {
                Point3D bottom;
                double bottomX, bottomY, bottomZ;

                bottomX = this.centerPoint.X;
                bottomY = this.centerPoint.Y - radius;
                bottomZ = this.centerPoint.Z;

                bottom = new Point3D(bottomX, bottomY, bottomZ);
                return bottom;
            }

            public void makeNormalRay(Point3D intersectionPoint)
            {
                this.intersectionPoint = intersectionPoint;
                this.normalRay = new Ray(this.centerPoint, this.intersectionPoint);
            }

            // equation of sphere from center
            //  (x - a)^2 + (y - b)^2 + (z-c)^2 = r^2
            public void moveUp(double moveAmount)
            {
                this.centerPoint = new Point3D(centerPoint.X, centerPoint.Y + moveAmount, centerPoint.Z);
                
            }
            public void moveDown(double moveAmount)
            {
                this.centerPoint = new Point3D(centerPoint.X, centerPoint.Y - moveAmount, centerPoint.Z);
            }

        }

        public class userSpaceObject
        {
            public Point3D position;
            public string name;

            public double getX()
            {
                return (double)position.X;
            }
            public double getY()
            {
                return (double)position.Y;
            }
            public double getZ()
            {
                return (double)position.Z;
            }
        }

        public class Eye : userSpaceObject
        {

            public Eye(Point3D position)
            {
                this.position = position;
            }
            public Eye(double X, double Y, double Z)
            {
                this.position = new Point3D(X, Y, Z);
            }
        }

        public class LightSource : userSpaceObject
        {
            public int redIntensity;
            public int greenIntensity;
            public int blueIntensity;
            public LightSource(Point3D position, int red, int green, int blue)
            {
                this.redIntensity = red;
                this.greenIntensity = green;
                this.blueIntensity = blue;
                this.position = position;
            }
            public LightSource(int X, int Y, int Z, int red, int green, int blue)
            {
                this.redIntensity = red;
                this.greenIntensity = green;
                this.blueIntensity = blue;
                this.position = new Point3D(X, Y, Z);
            }
        }

        public class Floor : userSpaceObject
        {
            //  Height  Depth(Z)
            //  Y    Z________
            //  |   /        /
            //  |  /   cP   /
            //  | /        /
            //  |/________/ X Width

            public double width;    // X dimension
            public double depth;    // Z dimension
            public double height;   // Y dimension
            public Color color;

            public Floor(double width, double depth, double height, Point3D centerPoint, Color color)
            {
                this.position = centerPoint; // is the 3D point center of the top plane
                this.width = width;
                this.depth = depth;
                this.height = height;
                this.color = color;
            }


        }

        public class Point3D
        {
            public double X;
            public double Y;
            public double Z;
            public string name;
            public Point3D(double X, double Y, double Z, string name)
            {
                this.name = name;
                initalize(X, Y, Z);
            }
            public Point3D(double X, double Y, double Z)
            {
                this.name = "double point";
                initalize(X, Y, Z);
            }
            public Point3D(int X, int Y, int Z)
            {
                this.name = "no name";
                initalize(X, Y, Z);
            }
            public Point3D(int X, int Y, int Z, string name)
            {
                this.name = name;
                initalize(X, Y, Z);
            }
            public void initalize(double X, double Y, double Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }
            public Point3D userToScreen(Size screenSpace, Size userSpace)
            {
                int screenX;
                int screenY;
                int screenZ = (int)Math.Floor(Z);

                // convert using ratio of userSpace
                //  Xp = userSpace
                //  Xs = screenSpace
                //  Xp = userSpaceMax * Xs / screenSpaceMax
                //  Xs = screenSpaceMax * Xp / userSpaceMax
                screenX = (int)((double)screenSpace.Width * (double)this.X / (double)userSpace.Width);
                //  Yp = userSpace
                //  Ys = screenSpace
                //  Yp = userSpaceMax - (Ys / screenSpaceMax)
                //  Ys = UserMax + (((user-userMin)*(screenMin-screenMax))/(userMax-userMin))
                screenY = (int)((double)screenSpace.Width + (double)((double)(this.Y - 0) * (double)(0 - screenSpace.Width) / (double)(userSpace.Width - 0)));


                return new Point3D(screenX, screenY, screenZ, "Screen from user");
            }

            public Point3D screenToUser(Size screenSpace, Size userSpace)
            {
                double userX;
                double userY;
                double userZ = 0;

                // convert using ratio of userSpace
                //  Xp = userSpace
                //  Xs = screenSpace (this)
                //  Xp = userMin + [(Xs-sMin)*(UMax-UMin)/(SMax-SMin)]
                userX = (0.0 + ((this.X - 0.0) * ((double)userSpace.Width - 0.0) / ((double)screenSpace.Width - 0.0)));
                //  Yp = userSpace
                //  Ys = screenSpace (this)
                //  Yp = UserMin + ((Ys - SMax)*(Umax-UMin)/(SMin-SMax))
                userY = (0.0 + ((double)(this.Y - (double)screenSpace.Height) * (double)((double)userSpace.Height - 0.0) / (double)(0.0 - (double)screenSpace.Height)));


                return new Point3D(userX, userY, userZ, "User from Screen");
            }

            public void printCoordinates()
            {
                System.Console.WriteLine(this.name + " -> (" + this.X + ", " + this.Y + ", " + this.Z + ")");
            }

        }

        public class Ray
        {
            public Point3D origin;
            public Point3D secondPoint;
            public bool originIsUser;
            public bool secondIsUser;
            public Point3D intersectionPoint;   // Point where ray intersects with some passed object
            public double xPoint;
            public double yPoint;
            public double a, b, c;  // center point of sphere
            public double d, e, f;  // Eye coordinates
            public double A, B, C;
            public double discriminant;
            public bool magnitudeSet;
            public double magnitude;
            public bool isNormalized;

            public Ray(Point3D origin, Point3D secondPoint)
            {
                this.origin = origin;
                this.secondPoint = secondPoint;
                this.originIsUser = true;
                this.secondIsUser = false;
                magnitudeSet = false;
                this.isNormalized = false;
            }

            public bool seeBall(Ball ball, Size screenSpace, Size userSpace)
            {
                bool isVisible = false;

                double A;
                double B;
                double C;
                double result;

                // set a, b, c
                a = ball.centerPoint.X;
                b = ball.centerPoint.Y;
                c = ball.centerPoint.Z;

                // set d, e, f
                d = origin.X;
                e = origin.Y;
                f = origin.Z;

                // convert screenPoint to user coordinates
                if (!secondIsUser)
                {
                    secondPoint = secondPoint.screenToUser(screenSpace, userSpace);
                }
                //userScreen.printCoordinates();

                // A= [(𝑑−𝑥𝑝)^2+(𝑒−𝑦𝑝)^2+𝑓^2 ]
                A = Math.Pow((d - (double)secondPoint.X), 2.0)
                    +
                    Math.Pow((e - (double)secondPoint.Y), 2.0)
                    +
                    Math.Pow(f, 2.0)
                    ;
                // B= [(𝑑−𝑥𝑝)(𝑑−𝑎)+(𝑒−𝑦𝑝)(𝑒−𝑏) +𝑓(𝑓−𝑐)]
                B = ((d - (double)secondPoint.X)
                    *
                    (d - a))
                    +
                    ((e - (double)secondPoint.Y)
                    *
                    (e - b))
                    +
                    (f
                    *
                    (f - c))
                    ;
                // C= [ (𝑑−𝑎)^2 + (𝑒−𝑏)^2 + (𝑓−𝑐)^2 − 𝑟^2 ]

                C = Math.Pow(d - a, 2.0)
                    +
                    Math.Pow(e - b, 2.0)
                    +
                    Math.Pow(f - c, 2.0)
                    -
                    Math.Pow((double)ball.radius, 2.0)
                    ;

                //  𝐷 = 4𝐵^2 − 4𝐴∗𝐶
                result = (4.0 * Math.Pow(B, 2.0))
                         -
                         (4 * A * C)
                         ;

                if (result >= 0)
                {
                    isVisible = true;
                    this.discriminant = result;
                    if (result > 1.0)
                    {
                        // find closest point of intersection
                        double IntersectionX, IntersectionY, IntersectionZ;
                        double t, t1, t2;
                        t1 = (
                            (B + Math.Sqrt(Math.Pow(B, 2.0) - (A * C)))
                            /
                            A)
                            ;
                        t2 = (
                            (B - Math.Sqrt(Math.Pow(B, 2.0) - (A * C)))
                            /
                            A)
                            ;
                        t = Math.Min(t1, t2);
                        IntersectionX = (d * (1 - t))
                                        +
                                        ((double)secondPoint.X * t)
                                        ;
                        IntersectionY = (e * (1 - t))
                                        +
                                        ((double)secondPoint.Y * t)
                                        ;
                        IntersectionZ = (f * (1 - t))
                                        +
                                        ((double)secondPoint.Z * t)
                                        ;
                        this.intersectionPoint = new Point3D(IntersectionX, IntersectionY, IntersectionZ);
                    }
                    else
                    {
                        // find point of intersection
                        double IntersectionX, IntersectionY, IntersectionZ;
                        double t = B / A;
                        IntersectionX = (d * (1 - t))
                                        +
                                        ((double)secondPoint.X * t)
                                        ;
                        IntersectionY = (e * (1 - t))
                                        +
                                        ((double)secondPoint.Y * t)
                                        ;
                        IntersectionZ = (f * (1 - t))
                                        +
                                        ((double)secondPoint.Z * t)
                                        ;
                        this.intersectionPoint = new Point3D(IntersectionX, IntersectionY, IntersectionZ);
                    }

                    //System.Console.WriteLine("here -> (" + userScreen.X + ", " + userScreen.Y +")" + " -> (" + screenPoint.X + ", " + screenPoint.Y +")");
                    //System.Console.WriteLine("A = " + A +" B = " + B +" C = " + C);
                    //System.Console.WriteLine(result);
                }
                else
                {
                    //System.Console.WriteLine("A = " + A +" B = " + B +" C = " + C);
                    //System.Console.WriteLine(result);
                    //System.Console.WriteLine(result);
                    isVisible = false;
                }


                return isVisible;
            }
            public Point3D intersectWithFloor()
            {
                Point3D floorIntersectionPoint;
                double t;
                double floorX, floorY, floorZ;

                // t = e/(e-yp)
                t = e / (e - (double)secondPoint.Y);
                // X(t) = d*(1-t) + xp*t
                floorX = (d * (1 - t)) +
                         ((double)secondPoint.X * t)
                         ;
                // Y(t) = 0
                floorY = 0.0;
                // Z(t) = f*(1-t)
                floorZ = f * (1 - t);

                floorIntersectionPoint = new Point3D(floorX, floorY, floorZ);
                return floorIntersectionPoint;
            }
            public bool yIncrease()
            {
                bool increase;
                double y1;
                double y2;
                y1 = yFunction(0.1);
                y2 = yFunction(.5);
                //System.Console.WriteLine("y1 = " + y1 + " y2 = " + y2 + " e = " + e);
                if (y1 < y2)
                {
                    increase = true;
                }
                else
                {
                    increase = false;
                }

                return increase;
            }
            public double yFunction(double t)
            {
                double yT;

                // Y(t) = e*(1-t) + Yp*t
                yT = (e * (1.0 - t))
                    +
                    ((double)secondPoint.Y * t)
                    ;
                return yT;
            }
            public bool matchIntersection(Point3D otherIntersectionPoint)
            {
                if (this.intersectionPoint.X != otherIntersectionPoint.X ||
                   this.intersectionPoint.Y != otherIntersectionPoint.Y ||
                   this.intersectionPoint.Z != otherIntersectionPoint.Z)
                {
                    System.Console.WriteLine("thispoint = " + this.intersectionPoint.X + " " + this.intersectionPoint.Y + " " + this.intersectionPoint.Z);
                    System.Console.WriteLine("otherIntersectionPoint = " + otherIntersectionPoint.X + " " + otherIntersectionPoint.Y + " " + otherIntersectionPoint.Z);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public double getMagnitude(Point3D pointOne, Point3D pointTwo)
            {
                if (this.magnitudeSet == false)
                {
                    //System.Console.WriteLine("pointOne = " + pointOne.X + " p2 = " + pointTwo.X);
                    //calc magnitude
                    // distance formula sqrt( (p1.X - p2.X)^2 + (p1.Y - p2.Y)^2 + (p1.Z - p2.Z)^2 )
                    this.magnitude = Math.Sqrt(
                                                Math.Pow(pointOne.X - pointTwo.X, 2) +
                                                Math.Pow(pointOne.Y - pointTwo.Y, 2) +
                                                Math.Pow(pointOne.Z - pointTwo.Z, 2)
                                                );
                    this.magnitudeSet = true;
                    //System.Console.WriteLine("magnitude = " + this.magnitude);
                    return this.magnitude;
                }
                else
                {
                    //System.Console.WriteLine("preSet magnitude = " + this.magnitude);
                    return this.magnitude;
                }
            }
        }
        public class LightBeam : Ray
        {
            Color color;
            Vector3D vector;

            public LightBeam(Point3D origin, Point3D secondPoint) : base(origin, secondPoint)
            {
                this.color = Color.Red;
            }
            public LightBeam(Point3D origin, Point3D secondPoint, Color color) : base(origin, secondPoint)
            {
                this.color = color;
            }
            public void setBeam(Point3D origin, Point3D secondPoint)
            {
                this.origin = origin;
                this.secondPoint = secondPoint;
            }
            public void seeBeam(Ray eyeRay)
            {
                Vector3D eyeVector = new Vector3D(eyeRay.origin, eyeRay.secondPoint);
                vector = new Vector3D(this.origin, this.secondPoint);
                // Equation of the ray eye to screen
                //  X(t) = d(1 - t) + xp * t
                //  Y(t) = e * (1 - t) + yp * t
                //  Z(t) = f * (1 - t) + 0 * t = f * (1 - t)
                // Equation of 3D line (our beam)
                //  magnitude = sqrt((X2 - X1)^2 + (Y2 - Y1)^2 + (Z2 - Z1)^2)

            }

        }
        public class Vector3D
        {
            public double X, Y, Z;

            public Vector3D(double X, double Y, double Z)
            {
                setXYZ(X, Y, Z);
            }
            public Vector3D(Point3D pointOne, Point3D pointTwo)
            {
                //setXYZ(
                //       Math.Abs(pointOne.X - pointTwo.X),
                //       Math.Abs(pointOne.Y - pointTwo.Y),
                //       Math.Abs(pointOne.Z - pointTwo.Z)
                //       );
                setXYZ(
                       (pointOne.X - pointTwo.X),
                       (pointOne.Y - pointTwo.Y),
                       (pointOne.Z - pointTwo.Z)
                       );
            }
            public void setXYZ(double X, double Y, double Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }
            public Vector3D normalizedVector(double magnitude)
            {
                Vector3D normalVector;
                double normalX, normalY, normalZ;

                normalX = X / magnitude;
                normalY = Y / magnitude;
                normalZ = Z / magnitude;

                normalVector = new Vector3D(normalX, normalY, normalZ);

                return normalVector;
            }
            public void printVector()
            {
                System.Console.WriteLine("x = " + this.X + " y = " + this.Y + " z = " + this.Z);
            }
        }

        // -------------------------------------------- Clicks --------------------------------------------
        private void FloorColorPictureBox_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            floor.color = colorDialog1.Color;
            FloorColorPictureBox.BackColor = floor.color;
            this.Update();
            paintScene(bufferedGraphics.Graphics);
        }

        private void pictureBoxSky_Click(object sender, EventArgs e)
        {
            colorDialog3.ShowDialog();
            skyColor = colorDialog3.Color;
            pictureBoxSky.BackColor = skyColor;
            this.Update();
            stopwatch.Start();
            paintScene(bufferedGraphics.Graphics);
            stopwatch.Stop();
        }

        private void buttonImageSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF; *.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.Console.WriteLine("file chosen: \t" + openFileDialog1.FileName);
                imageToMap = new Bitmap(openFileDialog1.FileName);
                pictureBoxMapImage.Image = imageToMap;
                stopwatch.Start();
                paintScene(bufferedGraphics.Graphics);
                stopwatch.Stop();
                System.Console.WriteLine("Size of image = " + imageToMap.Size);
            }
        }

        private void BallX_ValueChanged(object sender, EventArgs e)
        {
            if (BounceBallButton.Enabled)
            {
                ball.centerPoint.X = (double)BallX.Value;
                lightBeam.setBeam(ball.centerPoint, lightSource.position);
                paintScene(bufferedGraphics.Graphics);
            }
        }

        private void BallY_ValueChanged(object sender, EventArgs e)
        {
            if (BounceBallButton.Enabled)
            {
                ball.centerPoint.Y = (double)BallY.Value;
                if (ball.centerPoint.Y < ball.radius)
                {
                    ball.centerPoint.Y = ball.radius;
                    BallY.Value = (decimal)ball.centerPoint.Y;
                }
                lightBeam.setBeam(ball.centerPoint, lightSource.position);
                paintScene(bufferedGraphics.Graphics);
            }
        }

        private void BallZ_ValueChanged(object sender, EventArgs e)
        {
            if (BounceBallButton.Enabled)
            {
                ball.centerPoint.Z = (double)BallZ.Value;
                paintScene(bufferedGraphics.Graphics);
                lightBeam.setBeam(ball.centerPoint, lightSource.position);
            }
        }

        private void numericUpDownEyePositionX_ValueChanged(object sender, EventArgs e)
        {
            if (BounceBallButton.Enabled)
            {
                eye.position.X = (double)numericUpDownEyePositionX.Value;
                stopwatch.Start();
                paintScene(bufferedGraphics.Graphics);
                stopwatch.Stop();
            }
        }

        private void numericUpDownEyePositionY_ValueChanged(object sender, EventArgs e)
        {
            if (BounceBallButton.Enabled)
            {
                eye.position.Y = (double)numericUpDownEyePositionY.Value;
                stopwatch.Start();
                paintScene(bufferedGraphics.Graphics);
                stopwatch.Stop();
            }
        }

        private void numericUpDownEyePositionZ_ValueChanged(object sender, EventArgs e)
        {
            if (BounceBallButton.Enabled)
            {
                eye.position.Z = (double)numericUpDownEyePositionZ.Value;
                stopwatch.Start();
                paintScene(bufferedGraphics.Graphics);
                stopwatch.Stop();
            }
        }

        private void BounceBallButton_Click(object sender, EventArgs e)
        {
            if (BounceBallButton.Enabled)
            {
                setupTimer();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine("Why?");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (BounceBallButton.Enabled)
            {
                ball.radius = (double)numericUpDown1.Value;
                if(ball.centerPoint.Y < ball.radius)
                {
                    ball.centerPoint.Y = ball.radius;
                    BallY.Value = (decimal)ball.centerPoint.Y;
                }
                paintScene(bufferedGraphics.Graphics);
            }
        }

        private void LightSourceIntensityNum_ValueChanged(object sender, EventArgs e)
        {
            lightSource.redIntensity = (int)LightSourceIntensityNum.Value;
            stopwatch.Start();
            paintScene(bufferedGraphics.Graphics);
            stopwatch.Stop();
        }

        private void LightSourceGreenInput_ValueChanged(object sender, EventArgs e)
        {
            lightSource.greenIntensity = (int)LightSourceGreenInput.Value;
            stopwatch.Start();
            paintScene(bufferedGraphics.Graphics);
            stopwatch.Stop();
        }

        private void LightSourceBlueInput_ValueChanged(object sender, EventArgs e)
        {
            lightSource.blueIntensity = (int)LightSourceBlueInput.Value;
            stopwatch.Start();
            paintScene(bufferedGraphics.Graphics);
            stopwatch.Stop();
        }

        private void AmbientLightNumber_ValueChanged(object sender, EventArgs e)
        {
            ambientLight = (double)AmbientLightNumber.Value;
            ambientMix = ambientLight / 255.0;
            stopwatch.Start();
            paintScene(bufferedGraphics.Graphics);
            stopwatch.Stop();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            // Accidental double click...
            System.Console.WriteLine("a;sldkfja;sldkfj");
        }

        private void pictureBoxBallColor_Click(object sender, EventArgs e)
        {
            if (pictureBoxBallColor.Enabled)
            {
                colorDialog2.ShowDialog();
                ball.color = colorDialog2.Color;
                pictureBoxBallColor.BackColor = ball.color;
                this.Update();
                stopwatch.Start();
                paintScene(bufferedGraphics.Graphics);
                stopwatch.Stop();
            }
            else
            {
                System.Console.WriteLine("pictureBoxBallColor.Enabled = " + pictureBoxBallColor.Enabled);
            }
        }

        private void checkBoxGrayScale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGrayScale.Checked)
            {
                checkBoxMapImage.Checked = false;
                checkBoxBallColor.Checked = false;
                pictureBoxBallColor.Enabled = false;
                pictureBoxBallColor.BackColor = Color.Gray;
                ball.grayScale = true;
            }
            else
            {
                if (!checkBoxBallColor.Checked && !checkBoxGrayScale.Checked && !checkBoxMapImage.Checked)
                {
                    checkBoxGrayScale.Checked = true;
                }
                pictureBoxBallColor.Enabled = true;
                ball.grayScale = false;
            }
            stopwatch.Start();
            paintScene(bufferedGraphics.Graphics);
            stopwatch.Stop();
        }

        private void checkBoxBallColor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBallColor.Checked)
            {
                checkBoxMapImage.Checked = false;
                checkBoxGrayScale.Checked = false;
            }
            else
            {
                if (!checkBoxBallColor.Checked && !checkBoxGrayScale.Checked && !checkBoxMapImage.Checked)
                {
                    checkBoxGrayScale.Checked = true;
                }
            }
        }

        private void checkBoxMapImage_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMapImage.Checked)
            {
                System.Console.WriteLine("Size of image = " + imageToMap.Size);
                checkBoxGrayScale.Checked = false;
                checkBoxBallColor.Checked = false;
            }
            else
            {
                if (!checkBoxBallColor.Checked && !checkBoxGrayScale.Checked && !checkBoxMapImage.Checked)
                {
                    checkBoxGrayScale.Checked = true;
                }
            }
            stopwatch.Start();
            paintScene(bufferedGraphics.Graphics);
            stopwatch.Stop();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
