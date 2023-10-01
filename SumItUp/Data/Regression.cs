using System;
namespace SumItUp.Data
{
	public class Regression
	{
		public static double CalculateSlope(double[] xValues, double[] yValues)
		{
			int count = xValues.Length;
			double xSum = 0, ySum = 0, xySum = 0, xSquareSum = 0;

			for (int i = 0; i < count; i++)
			{
				xSum += xValues[i];
				ySum += yValues[i];
				xySum += xValues[i] * yValues[i];
				xSquareSum += xValues[i] * xValues[i];
			}

			double slope = (count * xySum - xSum * ySum) / (count * xSquareSum - xSum * xSum);
			return slope;
		}

		public static double CalculateIntercept(double[] xValues, double[] yValues, double slope)
		{
			int count = xValues.Length;
			double xSum = 0, ySum = 0;

			for (int i = 0; i < count; i++)
			{
				xSum += xValues[i];
				ySum += yValues[i];
			}

			double intercept = (ySum - slope * xSum) / count;
			return intercept;
		}

		public static double[] Predict(double[] xValues, double slope, double intercept)
		{
			double[] predictions = new double[xValues.Length];

			for (int i = 0; i < xValues.Length; i++)
			{
				predictions[i] = slope * xValues[i] + intercept;
			}

			return predictions;
		}
	}
}

