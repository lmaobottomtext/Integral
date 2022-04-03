using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Integrtals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            DoCalculate();
        }
        
        private ICalculator GetCalculator()
        {
            /*return new RectangleCalculate();*/
            return method.SelectedIndex switch
            {
                1 => new SimpsonCalculate(),
                0 => new RectangleCalculate(),
                _ => throw new NotImplementedException(),
            };
        }

        private void DoCalculate()
        {
            int splits = Convert.ToInt32(splitCounter.Text);
            int upLim = Convert.ToInt32(upperLimit.Text);
            int lowLim = Convert.ToInt32(lowerLimit.Text);
            double time = 0;

            ICalculator calcult = GetCalculator();
            double result = calcult.Calculate(splits, upLim, lowLim, x => 322 * x * x + Math.Log(x) + 2, out time);
            MessageBox.Show($"Результат вычислений = {result.ToString()}");
        }
    }
}
