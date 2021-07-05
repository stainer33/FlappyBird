using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 6;
        int gravity = 5;
        int score = 0;
        bool start = false;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Stop();
            flappyBird.BackColor = Color.Transparent;
            pipeDown.BackColor = Color.Transparent;
            pipeUp.BackColor = Color.Transparent;
            lblScore.ForeColor = Color.Transparent;
            lblScore.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Transparent;
            

           
        }
        private void restart()
        {
            start = false;
            // this.Close();
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(null,EventArgs.Empty);



        }

        private void gameTimer(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeUp.Left -= pipeSpeed;
            pipeDown.Left -= pipeSpeed;
            lblScore.Text = "SCORE: "+score.ToString();
            if(pipeUp.Left<-75)
            {
                pipeUp.Left = random.Next(800,1000);
                pipeDown.Top += random.Next(1, 20);
                score++;

            }
            if (pipeDown.Left < -75)
            {
                pipeDown.Left = random.Next(900, 1100);
                pipeDown.Top -= random.Next(5,15);
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeUp.Bounds) || flappyBird.Bounds.IntersectsWith(pipeDown.Bounds) || flappyBird.Bounds.IntersectsWith(ground.Bounds))
                endGame();
            int target = 10;
            if (score > target)
            {
                pipeSpeed = pipeSpeed++;
                target += 10;
            }
            if (flappyBird.Top < -25)
                endGame();

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode==Keys.Space)
            {
                if(!start)
                {
                    panel1.Hide();
                    start = true;
                    timer.Start();
                }
                gravity = 8;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = -8;
            }
        }

        private void endGame()
        {
            timer.Stop();
            MessageBox.Show("Game Over");
            restart();
            
            
        }
    }
}
