using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace AlperenPolat_19219046
{
    public partial class Form1 : Form
    {
        List<Button> buttonList = new List<Button>();
        List<int> path = new List<int>();
        List<int> playerPath = new List<int>();

        Random rand = new Random();

        int levelDiceCount = 3, level = 1, score = 0;
        int turn = -1;
        int time = 0, nextTime = 5;
        int colorQueue = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            buttonList.Add(button1);
            buttonList.Add(button2);
            buttonList.Add(button3);
            buttonList.Add(button4);
            buttonList.Add(button5);
            buttonList.Add(button6);
            buttonList.Add(button7);
            buttonList.Add(button8);
            buttonList.Add(button9);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Play();
        }
        void Play()
        {
            DisableButtons();
            timer1.Interval = 100;
            timer1.Start();
            tabControl1.SelectedTab = tabPage2;
            for (int i = 0; i < levelDiceCount; i++)
            {
                int number = GetDice();
                path.Add(number);
                listBox2.Items.Add(path[i]);
            }
        }
        int GetDice()
        {
            int dice = rand.Next(1, 10);
            return dice;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            ColorIt(colorQueue);
        }
        void ColorIt(int colorQ)
        {
            if (colorQueue >= path.Count)
            {
                timer1.Stop();
                EnableButtons();
            }
            else if (time < nextTime && colorQueue < path.Count)
            {
                buttonList[path[colorQ] - 1].BackColor = Color.LightSkyBlue;
            }
            else if (time > nextTime && colorQueue < path.Count)
            {
                colorQueue++;
                time = 0;
                ClearColors();
            }
        }
        void ClearColors()
        {
            for (int i = 0; i < path.Count; i++)
            {
                buttonList[path[i] - 1].BackColor = Color.LightYellow;
            }
        }
        void Compare(int x)
        {
            if (playerPath[x] == path[x])
            {
                score++;
            }
            else if (playerPath[x] != path[x])
            {
                GameOver();
                Restart();
            }
            LevelControl();
        }
        void LevelControl()
        {
            if (level == 1 && score == 3)
            {
                LevelUp();
            }
            else if (level == 2 && score == 7)
            {
                LevelUp();
            }
            else if (level == 3 && score == 12)
            {
                LevelUp();
            }
            else if (level == 4 && score == 17)
            {
                LevelUp();
            }
            else if (level == 5 && score == 22)
            {
                Win();
                Restart();
            }
            label4.Text = "LEVEL " + level.ToString();
        }
        void LevelUp()
        {
            level++;
            levelDiceCount++;
            if (levelDiceCount >= 5)
            {
                levelDiceCount = 5;
                nextTime--;
            }
            Clean();
            Play();
        }
        void Win()
        {
            MessageBox.Show("KAZANDIN");
            listBox1.Items.Add(textBox1.Text + " | Score -> " + score);
        }
        void GameOver()
        {
            MessageBox.Show("Kaybettin :(");
            listBox1.Items.Add(textBox1.Text + " | Score -> " + score);
        }
        void Restart()
        {
            textBox1.Text = "";
            tabControl1.SelectedTab = tabPage1;
            level = 1;
            score = 0;
            levelDiceCount = 3;
            nextTime = 5;
            Clean();
        }
        void Clean()
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].Text = "";
            }
            turn = -1;
            time = 0;
            colorQueue = 0;
            path.Clear();
            listBox2.Items.Clear();
            playerPath.Clear();
        }
        void EnableButtons()
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].Enabled = true;
            }
        }
        void DisableButtons()
        {
            for (int i = 0; i < buttonList.Count; i++)
            {
                buttonList[i].Enabled = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            playerPath.Add(1);
            turn++;
            Compare(turn);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            playerPath.Add(2);
            turn++;
            Compare(turn);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            playerPath.Add(3);
            turn++;
            Compare(turn);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            playerPath.Add(4);
            turn++;
            Compare(turn);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            playerPath.Add(5);
            turn++;
            Compare(turn);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            playerPath.Add(6);
            turn++;
            Compare(turn);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            playerPath.Add(7);
            turn++;
            Compare(turn);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            playerPath.Add(8);
            turn++;
            Compare(turn);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            playerPath.Add(9);
            turn++;
            Compare(turn);
        }
    }
}
