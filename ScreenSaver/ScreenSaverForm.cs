using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace ScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);


        //Clas level variables---------------------------------------------------------------------------------
        private Point mouselocation;
        private Random rand = new Random();
        private bool previewMode = false;
        private bool songLoaded = false;

        //PictureBox[] hearts; //init later once random is init

        //Point moveLinkTo;
        //constructor for screen saver not preview mode
        public ScreenSaverForm(Rectangle bounds)
        {
            InitializeComponent();
            this.Bounds = bounds;
            InitHearts();
        }

        // Constructor for preview
        public ScreenSaverForm(IntPtr PreviewWndHandle)
        {
            InitializeComponent();

            // Set the preview window as the parent of this window
            SetParent(this.Handle, PreviewWndHandle);

            // Make this a child window so it will close when the parent dialog closes
            // GWL_STYLE = -16, WS_CHILD = 0x40000000
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);


            previewMode = true;
        }
        
        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
            //get timer running
            moveTimer.Interval = 3000;
            moveTimer.Tick += new EventHandler(moveTimer_Tick);
            moveTimer.Start();

            //start song if not in preview mode
            if (!previewMode && !songLoaded)
            {
                WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();
                wmp.URL = "Content/hero.mp3";
                wmp.controls.play();
                songLoaded = true;
            }
        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if(!previewMode)
                Application.Exit();
        }

       
        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouselocation.IsEmpty)
            {
                //terminalte tif mouse is moved a signifigant distance
                if (!previewMode && Math.Abs(mouselocation.X - e.X) > 10 ||
                    Math.Abs(mouselocation.Y - e.Y) > 10)
                {
                    Application.Exit();
                }
            }
                mouselocation= e.Location;
        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!previewMode)
                Application.Exit();
        }

        private void moveTimer_Tick(object sender, System.EventArgs e)
        {
            // Move text to new location
            
            //moveLinkTo = FindClosestHeart();
            MoveLink();
            
        }

        private void MoveLink()
        {
            if (heart.Bounds.Contains(Link.Bounds.X, Link.Bounds.Y)) 
            {
                Link.Load("content/pickup.gif");
                InitHearts();
            }
            
            //figure out how to tell if he needs to go left right up or down then move him eth erght direction
            double radian, degree;
            int dx = 0;
            int dy = 0;
            radian = Math.Atan2(
                heart.Bounds.Y - Link.Bounds.Y, 
                heart.Bounds.X - Link.Bounds.X);
            degree = Calculate.RadianToDegree(radian);
            if (degree < 0) //always get a positive degree
                degree += 360;
            if (degree == 0)
            {
                dx = -1;
                dy = 0;
                Link.Load("content/left.gif");
            }
            if (degree == 45)
            {
                dx = -1;
                dy = -1;
                Link.Load("content/back.gif");
            }
            if (degree == 90)
            {
                dx = 0;
                dy = -1;
                Link.Load("content/back.gif");
            }
            if (degree == 135)
            {
                dx = 1;
                dy = -1;
                 Link.Load("content/back.gif");
            }
            if (degree == 180)
            {
                dx = 1;
                dy = 0;
                 Link.Load("content/right.gif");
            }
            if (degree == 225)
            {
                dx = 1;
                dy = 1;
                Link.Load("content/front.gif");
            }
            if (degree == 270)
            {
                dx = 0;
                dy = 1;
                Link.Load("content/front.gif");
            }

            Link.Left = 5 * dy;
            Link.Top = 5 * dx;
        }

        private Point FindClosestHeart()
        {
           List<PictureBox> heartLocs = this.Controls.OfType<PictureBox>().ToList();
           Point closestLoc = new Point(0,0);
           double closestDistance = 0.0;
           double lastDisatnce = 0.0;

            foreach(PictureBox heart in heartLocs)
            {
                if(heart.Location != Link.Location)
                {
                    lastDisatnce = GetDistance(heart.Location);
                    if (closestDistance < lastDisatnce)
                    {
                        closestDistance = lastDisatnce;
                        closestLoc = heart.Location;
                    }
                }
            }
            return closestLoc;
        }

        private double GetDistance(Point location)
        {
            var distance = Math.Abs(Math.Sqrt(
                Math.Pow(
                (Link.Location.X - location.X), 2) + 
                Math.Pow((Link.Location.Y - location.Y), 2))) / 35; //use 35 as the herat size to divide it by, link is a slittle smaller but it will be ok
            return distance;
        }
        
        private void InitHearts()
        {
          //
            //Initialize the heart PictureBox ina random location
            //hearts[i] = new System.Windows.Forms.PictureBox();
            heart.Load("content/heart.png");
            heart.Location = new System.Drawing.Point(rand.Next(Bounds.Top, Bounds.Bottom), rand.Next(Bounds.Left, Bounds.Right));
            //heart.Location = new Point(200, 200);
            heart.Size = new System.Drawing.Size(35, 35);
            heart.TabIndex = 1;
            heart.TabStop = false;
        }
    }
}
