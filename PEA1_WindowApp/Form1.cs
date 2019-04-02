using System;
using System.Globalization;
using System.Windows.Forms;

namespace PEA1_WindowApp
{
    public partial class Form1 : Form
    {
        private ReadData rd = new ReadData();
        private SimulatedAnnealing sa;

        MainMenu mainMenu = new MainMenu();
        MenuItem menuItemFile = new MenuItem("Plik");
        MenuItem menuItemInfo = new MenuItem("O programie");
        MenuItem menuItemClose = new MenuItem("Zamknij");
        MenuItem menuItemChoose = new MenuItem("Wybierz plik");
        MenuItem menuItemDesc = new MenuItem("Opis");

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
            mainMenu.MenuItems.Add(menuItemFile);
            menuItemFile.MenuItems.Add(menuItemChoose);
            mainMenu.MenuItems.Add(menuItemInfo);
            menuItemInfo.MenuItems.Add(menuItemDesc);
            mainMenu.MenuItems.Add(menuItemClose);
            
            Controls.Add(chooseFile);
            Controls.Add(bfButton);
            Menu = mainMenu;
            Controls.Add(timeValue);
            Controls.Add(timeLabel);
            Controls.Add(coolingValue);
            Controls.Add(coolingLabel);
            Controls.Add(pathResult);
            Controls.Add(costResult);
            Controls.Add(result);
            Controls.Add(path);
            Controls.Add(cost);

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

            EventHandler ev = chooseFile_click;
            chooseFile.Click += ev;
            menuItemChoose.Click += ev;

            EventHandler ev1 = SaAlgorithm_click;
            bfButton.Click += ev1;

            EventHandler handleClose = Close_click;
            menuItemClose.Click += handleClose;

            EventHandler handleInfo = Info_click;
            menuItemDesc.Click += handleInfo;

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

            pathResult.Text = string.Join("->", sa.minPath);
            costResult.Text = sa.minCost.ToString();
        }

        public void Info_click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor Michał Polak");
        }

        public void Close_click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
