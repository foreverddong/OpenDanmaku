using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections;
namespace DanmakuClass
{
    struct dustinPerson
    {
       public int speed;
       public PictureBox dustinBox;
    }
    public partial class Form1 : Form
    {
        Random random;
        Point p;
        Label testLabel;
        Image dustin;
        
        ArrayList dustinArray;
        public Form1()
        {
            random = new Random();
            p = new Point(400, 400);
            dustinArray = new ArrayList();
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);
            this.Height = rect.Height;
            this.Width = rect.Width;
            this.Left = 0;
            this.Top = 0;
            this.TransparencyKey = Color.White;
            this.BackColor = Color.White;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);

            //add a test dustin which is able to move
            dustin = Image.FromFile("dustin.png");
            System.Windows.Forms.Timer dtimer = new System.Windows.Forms.Timer();
            dtimer.Tick += dtimer_Tick;
            dtimer.Interval = 10;
            dtimer.Start();

            System.Windows.Forms.Timer atimer = new System.Windows.Forms.Timer();
            atimer.Tick += atimer_Tick;
            atimer.Interval = 100;
            atimer.Start();

        }

        void atimer_Tick(object sender, EventArgs e)
        {
            if (dustinArray.Count <= 30)
            {
                addDustin();
            }
        }
        void addDustin()
        {
            dustinPerson person;
            
            person.speed = random.Next(6, 10);
            person.dustinBox = new PictureBox();
            person.dustinBox.Image = dustin;
            person.dustinBox.Width = 84;
            person.dustinBox.Height = 98;
            person.dustinBox.Location = new Point(Screen.GetWorkingArea(this).Width, (int)(Screen.GetWorkingArea(this).Height * (random.NextDouble() + 0.1)));
            this.Controls.Add(person.dustinBox);
            this.dustinArray.Add(person);
        }
        void dtimer_Tick(object sender, EventArgs e)
        {
            ArrayList dustinToRemove = new ArrayList();
            foreach (dustinPerson person in dustinArray)
            {
                Point a = new Point(person.dustinBox.Location.X, person.dustinBox.Location.Y);
                a.X -= person.speed;
                person.dustinBox.Location = a;
                if (person.dustinBox.Location.X <= 0)
                {
                    dustinToRemove.Add(person);
                }
            }
            foreach (dustinPerson person in dustinToRemove)
            {
                this.Controls.Remove(person.dustinBox);
                dustinArray.Remove(person);
            }

        }
    }
}
