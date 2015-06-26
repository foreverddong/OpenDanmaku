﻿using System;using System.Collections.Generic;using System.ComponentModel;using System.Data;using System.Drawing;using System.Linq;using System.Text;using System.Windows.Forms;using System.Runtime.InteropServices;using System.Threading;using System.Collections;using DanmakuClass;namespace DanmakuClass{        public partial class DanmakuForm : Form    {        Random random;        Point p;                ArrayList dustinArray;        ArrayList danmakuArray;        System.Windows.Forms.Timer ltimer;        public DanmakuForm()        {            random = new Random();            p = new Point(400, 400);            danmakuArray = new ArrayList();            ltimer = new System.Windows.Forms.Timer();            ltimer.Interval = 10;            ltimer.Tick += ltimer_Tick;            ltimer.Start();            InitializeComponent();        }        public void AddDanmaku(Danmaku danmaku)        {            Label danmakuLabel = new Label();            danmakuLabel.Location = new Point(Screen.GetWorkingArea(this).Width, (int)(Screen.GetWorkingArea(this).Height * (random.NextDouble() + 0.1)));            danmaku.DanmakuBox = danmakuLabel;            danmakuLabel.Text = danmaku.DanmakuString;            danmakuLabel.ForeColor = Color.Red;            this.danmakuArray.Add(danmaku);            this.Controls.Add(danmakuLabel);        }        void addDustin()        {            dustinPerson person;            person.speed = random.Next(6, 10);            person.dustinBox = new PictureBox();            // person.dustinBox.Image = dustin;            person.dustinBox.Width = 84;            person.dustinBox.Height = 98;            person.dustinBox.Location = new Point(Screen.GetWorkingArea(this).Width, (int)(Screen.GetWorkingArea(this).Height * (random.NextDouble() + 0.1)));            this.Controls.Add(person.dustinBox);            this.dustinArray.Add(person);        }        void ltimer_Tick(object sender, EventArgs e)        {            ArrayList danmakuToRemove = new ArrayList();            foreach (Danmaku thisDanmaku in danmakuArray)            {                Point a = new Point(thisDanmaku.DanmakuBox.Location.X, thisDanmaku.DanmakuBox.Location.Y);                a.X -= 10;                thisDanmaku.DanmakuBox.Location = a;                if (thisDanmaku.DanmakuBox.Location.X <= 0)                {                    danmakuToRemove.Add(thisDanmaku);                }            }            foreach (Danmaku removeDanmaku in danmakuToRemove)            {                this.Controls.Remove(removeDanmaku.DanmakuBox);                danmakuArray.Remove(removeDanmaku);            }        }        private void DanmakuForm_Load(object sender, EventArgs e)        {            Rectangle rect = new Rectangle();            rect = Screen.GetWorkingArea(this);            this.Height = rect.Height;            this.Width = rect.Width;            this.Left = 0;            this.Top = 0;            this.TransparencyKey = Color.White;            this.BackColor = Color.White;          //  this.TopMost = true;            this.FormBorderStyle = FormBorderStyle.None;            this.DoubleBuffered = true;            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);        }        void atimer_Tick(object sender, EventArgs e)        {            if (dustinArray.Count <= 30)            {                addDustin();            }        }        void dtimer_Tick(object sender, EventArgs e)        {            ArrayList dustinToRemove = new ArrayList();            foreach (dustinPerson person in dustinArray)            {                Point a = new Point(person.dustinBox.Location.X, person.dustinBox.Location.Y);                a.X -= person.speed;                person.dustinBox.Location = a;                if (person.dustinBox.Location.X <= 0)                {                    dustinToRemove.Add(person);                }            }            foreach (dustinPerson person in dustinToRemove)            {                this.Controls.Remove(person.dustinBox);                dustinArray.Remove(person);            }        }    }}