using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace x_si_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[,] b = new Button[100, 100];
        int stare = 0, n,contor,jucator1=0,jucator2=0;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int conditie()
        {
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                {
                    if (b[i, j].Enabled == false)
                    {
                        if(i<=n-2)  if (b[i, j].Text == b[i + 1, j].Text && b[i + 1, j].Text == b[i + 2, j].Text) return 1;     //in jos
                        if(i>=3)    if (b[i, j].Text == b[i - 1, j].Text && b[i - 1, j].Text == b[i - 2, j].Text) return 1;     //in sus
                        if(j<=n-2)  if (b[i, j].Text == b[i, j + 1].Text && b[i, j + 1].Text == b[i, j + 2].Text) return 1;     //la dreapta
                        if(j>=3)    if (b[i, j].Text == b[i, j - 1].Text && b[i, j - 1].Text == b[i, j - 2].Text) return 1;     //la stanga
                        if(i>=3&&j>=3)      if (b[i, j].Text == b[i - 1, j - 1].Text && b[i - 1, j - 1].Text == b[i - 2, j - 2].Text) return 1;     //diagonala stanga sus
                        if(i>=3&&j<=n-2)    if (b[i, j].Text == b[i - 1, j + 1].Text && b[i - 1, j + 1].Text == b[i - 2, j + 2].Text) return 1;     //diagonala dreapta sus
                        if(i<=n-2&&j<=n-2)  if (b[i, j].Text == b[i + 1, j + 1].Text && b[i + 1, j + 1].Text == b[i + 2, j + 2].Text) return 1;     //diagonala drepta jos
                        if(i<=n-2&&j>=3)    if (b[i, j].Text == b[i + 1, j - 1].Text && b[i + 1, j - 1].Text == b[i + 2, j - 2].Text) return 1;     //diagonala stanga jos
                    }
                }
            return 0;
        }

        private void b_Click(object sender, EventArgs e)
        {
            if (stare % 2 == 0)
            {
                ((Button)sender).Text = "X";
                ((Button)sender).Enabled = false;
            }
            else
            {
                ((Button)sender).Text = "O";
                 ((Button)sender).Enabled = false;
            }
            stare++;
            if (conditie() == 1)
            {
                char k; if (stare % 2 == 0)
                {
                    jucator1++;
                    label8.Text = Convert.ToString(jucator1);
                    k = 'O';
                    MessageBox.Show("Jucatorul " + textBox3.Text + " care a jucat cu piesa " + k + " a castigat aceasta tura !");
                    stare = 0;
                }

                else
                {
                    jucator2++;
                    label7.Text = Convert.ToString(jucator2);
                    k = 'X';
                    MessageBox.Show("Jucatorul " + textBox2.Text + " care a jucat cu piesa " + k + " a castigat aceasta tura !");
                    stare = 0;
                }

                if(jucator1==contor)
                {
                    label8.Text = Convert.ToString(jucator1);
                    MessageBox.Show("Jucatorul " + textBox3.Text + " a castigat partida !");
                    Application.Exit();
                }

                if (jucator2 == contor)
                {
                    label7.Text = Convert.ToString(jucator2);
                    MessageBox.Show("Jucatorul " + textBox2.Text + " a castigat partida !");
                    Application.Exit();
                }

                for (int i = 1; i <= n; i++)
                    for (int j = 1; j <= n; j++)
                    {
                        b[i, j].Enabled = true;
                        b[i, j].Text = null;
                    }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                for (int i = 1; i <= n; i++)
                    for (int j = 1; j <= n; j++)
                        Controls.Remove(b[i, j]);

                        n = Convert.ToInt32(textBox1.Text);
                contor = Convert.ToInt32(textBox4.Text);
                label5.Text = textBox2.Text;
                label6.Text = textBox3.Text;
                label7.Text = label8.Text = "0";

            
                for (int i = 1; i <= n; i++)
                    for (int j = 1; j <= n; j++)
                    {
                        b[i, j] = new Button();
                        b[i, j].Top = i * 50 + 80;
                        b[i, j].Left = j * 50;
                        b[i, j].Width = 50;
                        b[i, j].Height = 50;
                        b[i, j].Click += new EventHandler(b_Click);
                        Controls.Add(b[i, j]);
                    }

            }
        }
    }
}
