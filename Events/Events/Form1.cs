using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Events
{
    public partial class Form1 : Form
    {
        static int counter = 0;
        static Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            this.MouseEnter += (object sender, EventArgs e) => {
                this.Text = ("My Form " + counter++);
                this.BackColor = Form.DefaultBackColor;
            };
            this.MouseClick += (object sender, MouseEventArgs e) => {
                this.BackColor = Color.Red;
            };
            this.MouseDoubleClick += (object sender, MouseEventArgs e) => {
                this.Size = new Size(rand.Next(100, 1000), rand.Next(100, 1000));
            };
        }

    }
}
