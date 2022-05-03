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
using OxyPlot;
using OxyPlot.Series;

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

        private void buttonGraph_Click(object sender, RoutedEventArgs e)
        {
            int splits = Convert.ToInt32(splitCounter.Text);
            int upLim = Convert.ToInt32(upperLimit.Text);
            int lowLim = Convert.ToInt32(lowerLimit.Text);
            ICalculator graph = GetCalculator();
            var pm = new PlotModel()
            {
                Title = "Зависимость времени расчета от количества разбиений"
            };
            var lineSeries = new LineSeries();
            for (int i = 1; i < splits; i++)
            {
                double time = 0;
                double result = graph.Calculate(i, upLim, lowLim, x => 322 * x * x + Math.Log(x) + 2, out time);
                lineSeries.Points.Add(new DataPoint(i, time));
            }
            pm.Series.Add(lineSeries);
            Graph.Model = pm;

        }
        
        private ICalculator GetCalculator()
        {
            return method.SelectedIndex switch
            {
                1 => new SimpsonCalculate(),
                0 => new RectangleCalculate(),
                _ => throw new NotImplementedException(),
            };
        }

        private void DoCalculate()
        {
            double splits = Convert.ToDouble(splitCounter.Text);
            double upLim = Convert.ToDouble(upperLimit.Text);
            double lowLim = Convert.ToDouble(lowerLimit.Text);
            double time = 0;

            ICalculator calcult = GetCalculator();
            double result = calcult.Calculate(splits, upLim, lowLim, x => 322 * x * x + Math.Log(x) + 2, out time);
            if(result != -1)
            {
                MessageBox.Show($"Результат вычислений = {result.ToString()}");
            }
            
        }
    }
}
