using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rotatingcube
{

    public partial class Art : Form
    {
        private Timer timer;
        private float rotationSpeed;
        private Graphics graphics;
        public Art()
        {
            InitializeComponent();


            rotationSpeed = 0f;

            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            rotationSpeed++;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            graphics = e.Graphics;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int width = ClientSize.Width;
            int height = ClientSize.Height;

            float cubeSize = Math.Min(width, height) / 2f;
            float halfCubeSize = cubeSize / 2f;
            float halfHalfCubeSize = halfCubeSize / 2f;

            // Center the cube in the form
            float centerX = width / 2f;
            float centerY = height / 2f;

            // Apply rotation transformation
            g.TranslateTransform(centerX, centerY);
            g.RotateTransform(rotationSpeed);
            g.TranslateTransform(-centerX, -centerY);

            // Draw the cube
            Pen cubePen = new Pen(Color.White, 8f);
            PointF[] cubePoints = new PointF[]
            {
                new PointF(centerX - halfCubeSize, centerY - halfCubeSize),   // Front top-left
                new PointF(centerX + halfCubeSize, centerY - halfCubeSize),   // Front top-right
                new PointF(centerX + halfCubeSize, centerY + halfCubeSize),   // Front bottom-right
                new PointF(centerX - halfCubeSize, centerY + halfCubeSize),   // Front bottom-left
                new PointF(centerX - halfCubeSize, centerY - halfCubeSize),   // Back top-left
                new PointF(centerX + halfCubeSize, centerY - halfCubeSize),   // Back top-right
                new PointF(centerX + halfCubeSize, centerY + halfCubeSize),   // Back bottom-right
                new PointF(centerX - halfCubeSize, centerY + halfCubeSize)    // Back bottom-left
            };
            g.DrawLines(cubePen, cubePoints);

            // Connect the corresponding points of front and back faces
            g.DrawLine(cubePen, cubePoints[0], cubePoints[4]);
            g.DrawLine(cubePen, cubePoints[1], cubePoints[5]);
            g.DrawLine(cubePen, cubePoints[2], cubePoints[6]);
            g.DrawLine(cubePen, cubePoints[3], cubePoints[7]);

            Pen cube2Pen = new Pen(Color.Aqua, 4f);
            PointF[] cube2Points = new PointF[]
            {
                new PointF(centerX - halfHalfCubeSize, centerY - halfHalfCubeSize),
                new PointF(centerX + halfHalfCubeSize, centerY - halfHalfCubeSize),
                new PointF(centerX + halfHalfCubeSize, centerY + halfHalfCubeSize),
                new PointF(centerX - halfHalfCubeSize, centerY + halfHalfCubeSize)
            };
            g.DrawLine(cube2Pen, cube2Points[0], cube2Points[1]);
            g.DrawLine(cube2Pen, cube2Points[1], cube2Points[2]);
            g.DrawLine(cube2Pen, cube2Points[2], cube2Points[3]);
            g.DrawLine(cube2Pen, cube2Points[3], cube2Points[0]);
            DrawCube(centerX, centerY, halfCubeSize * 2, 16f, Color.Aqua);
            DrawCube(centerX, centerY, halfHalfCubeSize / 2, 2f, Color.White);
            DrawCube(centerX, centerY, halfHalfCubeSize / 4, 1f, Color.Aqua);
            DrawCube(centerX, centerY, halfHalfCubeSize / 8, 0.5f, Color.White);
        }
       
        private void DrawCube(float centerX,float centerY, float Size, float penWidth, Color color)
        {
            Pen cube2Pen = new Pen(color, penWidth);
            PointF[] cube2Points = new PointF[]
            {
                new PointF(centerX - Size, centerY - Size),
                new PointF(centerX + Size, centerY - Size),
                new PointF(centerX + Size, centerY + Size),
                new PointF(centerX - Size, centerY + Size)
            };
            graphics.DrawLine(cube2Pen, cube2Points[0], cube2Points[1]);
            graphics.DrawLine(cube2Pen, cube2Points[1], cube2Points[2]);
            graphics.DrawLine(cube2Pen, cube2Points[2], cube2Points[3]);
            graphics.DrawLine(cube2Pen, cube2Points[3], cube2Points[0]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rotationSpeed = -5f;
        }
    }

}
