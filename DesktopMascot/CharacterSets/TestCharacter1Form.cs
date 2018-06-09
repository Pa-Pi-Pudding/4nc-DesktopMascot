﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopMascot
{
    public partial class TestCharacter1Form : Form
    {
        enum AnimationMode { DEFAULT, HELLO, WHAT };
        private AnimationMode mode;
        private int animeCounter;

        public TestCharacter1Form()
        {
            mode = AnimationMode.DEFAULT;
            animeCounter = 0;
            InitializeComponent();
        }

        public void setHelloAnimation()
        {
            mode = AnimationMode.HELLO;
            animeCounter = 0;
            return;
        }

        public void setWhatAnimation()
        {
            mode = AnimationMode.WHAT;
            animeCounter = 0;
            return;
        }

        private void TestCharacter1Form_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            setWhatAnimation();
        }

        private void timerLoop(object sender, EventArgs e)
        {
            if(mode != AnimationMode.DEFAULT)
            {
                animeCounter++;

                if(animeCounter > 10)
                {
                    animeCounter = 0;
                    mode = AnimationMode.DEFAULT;
                }
            }

            switch (mode)
            {
                case AnimationMode.DEFAULT:
                    this.pictureBox1.Image = Properties.Resources.TestCharacter1_default;
                    break;
                case AnimationMode.HELLO:
                    this.pictureBox1.Image = Properties.Resources.TestCharacter1_hello;
                    break;
                case AnimationMode.WHAT:
                    this.pictureBox1.Image = Properties.Resources.TestCharacter1_what;
                    break;
                default:
                    break;
            }

            return;
        }
    }
}