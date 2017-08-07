using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace myExercise
{
    
    public partial class Form1 : Form
    {
        int all ;
        int done ;

        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            fread();
            genbtn();
            
        }

     


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                flowLayoutPanel1.Controls.Clear();
                fwrite();
                fread();
                genbtn();
            }else
            { MessageBox.Show("You must enter a numeric value in the TextBox"); }
        }


        private void genbtn()
        {
            if (done <= all)
            {
                for (int i = 1; i <= all; i++)
                {

                    Button b = new Button();
                    if (i <= done)
                    {
                        b.BackColor = Color.Red;
                    }
                    else
                    { b.BackColor = System.Drawing.Color.Green; }
                    b.Text = Convert.ToString(i);
                    b.Font = new Font(b.Font.Name, 10.00f, FontStyle.Bold);
                    // b.Location = new System.Drawing.Point(txtBoxStartPositionx, txtBoxStartPositiony);
                    b.Size = new Size(50, 50);
                    b.Click += (se, ee) =>
                    {
                        if (b.BackColor == Color.Green)
                        {
                            b.BackColor = Color.Red;
                            done++;
                            System.IO.File.WriteAllText("Filedone.txt", Convert.ToString(done));
                        }
                        else if(b.BackColor == Color.Red)
                        {
                            b.BackColor = Color.Green;
                            done--;
                            System.IO.File.WriteAllText("Filedone.txt", Convert.ToString(done));
                        }
                    };
                    flowLayoutPanel1.Controls.Add(b);

                }
            }
        }

        private void fwrite()
        {
            int a=Convert.ToInt32(textBox1.Text);
            System.IO.File.WriteAllText("Fileall.txt", a.ToString());
            System.IO.File.WriteAllText("Filedone.txt", Convert.ToString(0));
        }

        private void fread()
        {
            if (File.Exists("Filedone.txt")&& File.Exists("Fileall.txt"))
            {
                 all = Convert.ToInt32(File.ReadAllText("Fileall.txt"));
                done = Convert.ToInt32(File.ReadAllText("Filedone.txt"));
            }
            else { MessageBox.Show("not able to read"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("Filedone.txt", Convert.ToString(0));
            fread();
            flowLayoutPanel1.Controls.Clear();
            genbtn();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            
        }
    }
}
