using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEA1_WindowApp
{
    public partial class Form1 : Form
    {
        Button chooseFile = new Button();
        Button bfButton = new Button();
        Button BnBbutton = new Button();
        public Form1()
        {
            this.Controls.Add(chooseFile);
            this.Controls.Add(bfButton);
            this.Controls.Add(BnBbutton);
            bfButton.Top = 30;
            BnBbutton.Top = 60;
            bfButton.Width = 120;
            BnBbutton.Width = 120;
            chooseFile.Text = "Wybierz plik";
            bfButton.Text = "Algorytm BruteForce";
            BnBbutton.Text = "Algorytm Branch & Bound";
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
