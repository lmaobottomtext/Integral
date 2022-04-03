using System;

public class SimpsonCalculate : ICalculator
{
    double ICalculator.Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time)
    {
        /*double h = (upLim - lowLim) / splitCount;//0.2
        time = 0;
        double sum1 = 0.0;
        double sum2 = 0.0;
        for (int i = 0; i < splitCount; i+=2)
        {
            sum1 += integral(lowLim + i * h)*h;
            sum2 += integral(lowLim + i+1 * h)*h;
        }
        //0.6666*(0+4*1.2+2*6.6)
        return h / 3.0 * (integral(lowLim) + 4 * sum1 + 2 * sum2);
        //return sum2;*/
        double h = (double)((upLim - lowLim) / splitCount);
        double sum1 = 0.0;
        double sum2 = 0.0;
        time = 0.0;

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

        double result = h / 3.0 * (0.5 * integral(lowLim+0.0000001) + sum1 + 2 * sum2 + 0.5 * integral(upLim));
        return result;
    }
}
