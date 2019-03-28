using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PEA1_WindowApp
{
    public partial class Form1 : Form
    {
        private ReadData rd = new ReadData();
        private SimulatedAnnealing sa;

        MainMenu mainMenu = new MainMenu();
        MenuItem menuItem1 = new MenuItem("Plik");
        MenuItem menuItem2 = new MenuItem("O programie");
        MenuItem menuItem3 = new MenuItem("Zamknij");
        MenuItem menuItem4 = new MenuItem("Wybierz plik");
        MenuItem menuItem5 = new MenuItem("Opis");

        Button chooseFile = new Button();
        Button bfButton = new Button();

        TextBox timeValue = new TextBox();
        TextBox coolingValue = new TextBox();

        TextBox pathResult = new TextBox();
        TextBox costResult = new TextBox();

        Label timeLabel = new Label();
        Label coolingLabel = new Label();

        Label result = new Label();
        Label path = new Label();
        Label cost = new Label();

        public Form1()
        {
            mainMenu.MenuItems.Add(menuItem1);
            menuItem1.MenuItems.Add(menuItem4);
            mainMenu.MenuItems.Add(menuItem2);
            menuItem2.MenuItems.Add(menuItem5);
            mainMenu.MenuItems.Add(menuItem3);
            
            this.Controls.Add(chooseFile);
            this.Controls.Add(bfButton);
            this.Menu = mainMenu;
            this.Controls.Add(timeValue);
            this.Controls.Add(timeLabel);
            this.Controls.Add(coolingValue);
            this.Controls.Add(coolingLabel);
            this.Controls.Add(pathResult);
            this.Controls.Add(costResult);
            this.Controls.Add(result);
            this.Controls.Add(path);
            this.Controls.Add(cost);

            timeLabel.Text = "Czas wykonywania algorytmu";
            coolingLabel.Text = "Współczynnik chłodzenia";

            result.Text = "Wynik algorytmu";
            path.Text = "Ścieżka";
            cost.Text = "Koszt";

            chooseFile.Top = 60;
            chooseFile.Left = 350;
            chooseFile.Width = 120;

            bfButton.Top = 90;
            bfButton.Left = 335;
            bfButton.Width = 150;

            timeValue.Top = 120;
            timeValue.Left = 350;
            timeValue.Width = 120;

            timeLabel.Top = 123;
            timeLabel.Left = 200;
            timeLabel.Width = 150;

            coolingValue.Top = 150;
            coolingValue.Left = 350;
            coolingValue.Width = 120;

            coolingLabel.Top = 153;
            coolingLabel.Left = 200;
            coolingLabel.Width = 150;

            pathResult.Top = 180;
            pathResult.Left = 350;
            pathResult.Width = 120;

            costResult.Top = 210;
            costResult.Left = 350;
            costResult.Width = 120;

            result.Top = 195;
            result.Left = 200;
            result.Width = 100;

            path.Top = 182;
            path.Left = 300;
            path.Width = 100;

            cost.Top = 212;
            cost.Left = 300;
            cost.Width = 100;

            chooseFile.Text = "Wybierz plik";
            bfButton.Text = "Symulowane Wyżarzanie";

            EventHandler ev = new EventHandler(this.chooseFile_click);
            chooseFile.Click += ev;

            EventHandler ev1 = new EventHandler(this.SaAlgorithm_click);
            bfButton.Click += ev1;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void chooseFile_click(object sender, EventArgs e)
        {
            rd.ReadFromFile();
            var msg = string.Join(Environment.NewLine, rd.list.ToArray());

            MessageBox.Show(msg);
        }

        public void SaAlgorithm_click(object sender, EventArgs e)
        {
            sa = new SimulatedAnnealing(rd);
            sa.time = int.Parse(timeValue.Text);
            sa.Cooling = float.Parse(coolingValue.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
            sa.SaAlgorithm();

            pathResult.Text = String.Join("->", sa.minPath);
            costResult.Text = sa.minCost.ToString();
        }
    }
}
