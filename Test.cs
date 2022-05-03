using System;
using System.Diagnostics;
using System.Windows;

public static class Tests
{
    public static bool splitCountCheck(double splitCount)
    {
        if(splitCount<=0)
        {
            MessageBox.Show($"Введено неверное число разбиений");
            return false;
        }
        else
        {
            return true;
        }
    }

    public static bool limitCheck(double upLim, double lowLim)
    {
        if(upLim<lowLim)
        {
            MessageBox.Show($"Введенный верхний предел ниже введенного нижнего пердела");
            return false;
        }
        else
        {
            if(lowLim<=0)
            {
                MessageBox.Show($"Введен неправильный предел, функция не может принимать отрицательные значения и 0");
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public static bool testResultSimpson(double splitCount, double upLim, double lowLim, Func<double, double> integral, double testResult)
    {
        double h = (double)((upLim - lowLim) / splitCount);
        double sum1 = 0.0;
        double sum2 = 0.0;

        for (int i = 2; i <= splitCount+1; i++)
        {
            double xi = lowLim + i * h;
            if (i <= splitCount - 1)
            {
                sum1 += integral(xi);
            }

            double xi_1 = lowLim + (i - 1) * h;
            sum2 += integral((xi + xi_1) / 2);
        }

        double result = h / 3.0 * (0.5 * integral(lowLim) + sum1 + 2 * sum2 + 0.5 * integral(upLim));
        if(testResult==result)
        {
            return true;
        }
        else
        {
            MessageBox.Show($"Результат функции по методу симпсона не соответствует действительности");
            return false;
        }
    }

    public static bool testResultRectangle(double splitCount, double upLim, double lowLim, Func<double, double> integral, double testResult)
    {
         Stopwatch timer = new Stopwatch();
        timer.Start();
        double h = (upLim - lowLim) / splitCount;
        double result = 0.0;
        for (int i = 0; i < splitCount; i++)
        {
            result += integral(lowLim + h * i);
        }
        result = result * h;

        if(testResult==result)
        {
            return true;
        }
        else
        {
            MessageBox.Show($"Результат функции по методу прямоугольница не соответствует действительности");
            return false;
        }
    }

}