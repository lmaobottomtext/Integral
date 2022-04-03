using System;

public interface ICalculator
{
	double Calculate(double splitCount, double upLim, double lowLim, Func<double, double> integral, out double time);
}
