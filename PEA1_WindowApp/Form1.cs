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
        private ReadData rd = new ReadData();

        MainMenu mainMenu = new MainMenu();
        MenuItem menuItem1 = new MenuItem("Plik");
        MenuItem menuItem2 = new MenuItem("O programie");
        MenuItem menuItem3 = new MenuItem("Zamknij");
        MenuItem menuItem4 = new MenuItem("Wybierz plik");
        MenuItem menuItem5 = new MenuItem("Opis");

        Button chooseFile = new Button();
        Button bfButton = new Button();
        Button BnBbutton = new Button();

        public Form1()
        {
            mainMenu.MenuItems.Add(menuItem1);
            menuItem1.MenuItems.Add(menuItem4);
            mainMenu.MenuItems.Add(menuItem2);
            menuItem2.MenuItems.Add(menuItem5);
            mainMenu.MenuItems.Add(menuItem3);
            
            this.Controls.Add(chooseFile);
            this.Controls.Add(bfButton);
            this.Controls.Add(BnBbutton);
            this.Menu = mainMenu;

            chooseFile.Width = 120;
            chooseFile.Top = 60;
            chooseFile.Left = 350;

            bfButton.Top = 90;
            bfButton.Left = 350;

            BnBbutton.Top = 120;
            BnBbutton.Left = 350;

            bfButton.Width = 120;
            BnBbutton.Width = 120;

            chooseFile.Text = "Wybierz plik";
            bfButton.Text = "Algorytm BruteForce";
            BnBbutton.Text = "Algorytm Branch & Bound";

            EventHandler ev = new EventHandler(this.chooseFile_click);
            chooseFile.Click += ev;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void chooseFile_click(object sender, EventArgs e)
        {
            rd.ReadFromFile();
        }
    }
}
