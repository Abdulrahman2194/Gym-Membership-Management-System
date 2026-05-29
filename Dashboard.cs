using System;
using System.Drawing;
using System.Windows.Forms;

namespace GymGUI
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Text = "Taher's Gym Dashboard";
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            StyleButton(button1);
            StyleButton(button2);
            StyleButton(button3);
            StyleButton(button4);
            StyleButton(button5);
            StyleExit(btnExit);

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Width = 350;
            pictureBox1.Height = 350;
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2 - 40;

            int startY = this.ClientSize.Height / 2 - 140;

            button1.Location = new Point(80, startY);
            button2.Location = new Point(80, startY + 60);
            button3.Location = new Point(80, startY + 120);
            button4.Location = new Point(80, startY + 180);
            button5.Location = new Point(80, startY + 240);

            btnExit.Location = new Point(this.ClientSize.Width - 130, 30);
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void StyleExit(Button btn)
        {
            btn.BackColor = Color.DarkRed;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Width = 100;
            btn.Height = 40;
        }
        void StyleButton(Button btn)
        {
            btn.BackColor = Color.Goldenrod;
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Width = 120;
            btn.Height = 40;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Members f = new Members();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TrainerForm f = new TrainerForm();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlanForm f = new PlanForm();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Classes f = new Classes();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Nutrition f = new Nutrition();
            f.Show();
        }

    }
}