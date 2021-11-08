using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace hannooi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public stack a;
        public stack b;

        public stack c;

        Form1 forma;

        private void Form1_Load(object sender, EventArgs e)
        {
            a = new stack(1, 0, this);
            b = new stack(2, 300, this);
            c = new stack(3, 600, this);
            forma= this;
        }
        public void hanoi(int n, stack a, stack b, stack c) 
        {
            Button T = new Button();
            if (n == 1)
            {

                T = a.pop(a);
                c.PUSH(T, c);

            }

            else
            {
                hanoi(n - 1, a, c, b);
                hanoi(1, a, b, c);

                hanoi(n - 1, b, a, c);
            }

        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            try {
                int y = Convert.ToInt32(textBox1.Text);


                if (y < 1)
                    MessageBox.Show("At least 1 ring is required");

                if (y > 10)
                    MessageBox.Show("No more than 10 rings are allowed");


                else {
                    button1.Enabled = false;
                    a.gg(y, forma, a);
                    hanoi(a.num, a, b, c);
                    button2.Enabled = true;
                }
            } catch (Exception ex) { MessageBox.Show("Please give a valid number!"); }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            for (int i = 1; i <= a; i++)
            {
                c.pop(c).Dispose();
            }

            button2.Enabled = false; button1.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e) {
            Application.Restart();
        }
    }



    public class stack
    {

        public int num; 
        public Button[] data = new Button[9]; 
        public Button BASE;

        public Button ALTURA; 
        public Form1 forma;

        public stack(int n, int x, Form F)
        {
            BASE = new Button(); 
            BASE.Visible = true;

            BASE.Location = new Point(50 + x, 350); 
            BASE.Width = 200;



            BASE.Height =7 ; 
            BASE.Left = 50 + x;

            BASE.Parent = F;
            ALTURA = new Button();


            ALTURA.Parent = F;

            ALTURA.Width = 7;

            ALTURA.Height = 200;


            ALTURA.Location = new Point(50 + x + 100, 151);



            ALTURA.Left = 50 + x + 100;

            ALTURA.SendToBack();


            BASE.SendToBack();
            num = 0;
        }



        public void PUSH(Button e, stack n) 
        {

            n.num++;
            n.data[n.num] = e;

            if (n.data[n.num].Left + n.data[n.num].Width / 2 < n.ALTURA.Left)
            {
                while (n.data[n.num].Left + n.data[n.num].Width / 2 < n.ALTURA.Left)
                {
                    n.data[n.num].Left = n.data[n.num].Left + 10;

                    Application.DoEvents();


                    Thread.Sleep(1);
                }
            }


            if (n.data[n.num].Left + n.data[n.num].Width / 2 > n.ALTURA.Left)
            {
                while (n.data[n.num].Left + n.data[n.num].Width / 2 > n.ALTURA.Left)
                {
                    n.data[n.num].Left = n.data[n.num].Left - 10;
                    Application.DoEvents();
                    Thread.Sleep(1);
                }
            }


            if (n.data[n.num].Top <= n.BASE.Top - (n.num * 20) - 3)

            {


                while (n.data[n.num].Top <= n.BASE.Top - (n.num * 20) - 3)
                {
                    n.data[n.num].Top = n.data[n.num].Top + 10;
                    Application.DoEvents();
                    Thread.Sleep(1);
                }
            }

        }

        public Button pop(stack f)
        {
            while (f.data[f.num].Top > 50)
            {
                f.data[f.num].Top = f.data[f.num].Top - 10;
                Application.DoEvents();
                Thread.Sleep(1);
            }
            return f.data[f.num--];
        }


        public void gg(int n, Form F, stack T)

        {

            for (int i = 1; i <= n; i++)


            {
                T.data[i] = new Button();

                T.data[i].Parent = F;
                T.data[i].Height = 20;

                T.data[i].Width = 200 - 20 * i; 
                T.data[i].Location = new Point(50, 50);
                T.data[i].Left = 50;
                T.data[i].Top = 50;


                T.data[i].BringToFront();
                PUSH(T.data[i], T);
            }
        }

    }
}