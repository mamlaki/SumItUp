using System;
namespace SumItUp.Data
{
	public class Calculator
	{
		public double Add(double a, double b)
		{
			return a + b;
		}

		public double Subtract(double a, double b)
		{
			return a - b;
		}

		public double Multiply(double a, double b)
		{
			return a * b;
		}

		public double Divide(double a, double b)
		{
			if (b != 0)
			{
				return a / b;
			}
			throw new DivideByZeroException("Cannot divide by zero.");
		}

		public double SquareRoot(double a)
		{
			return Math.Sqrt(a);
		}

		public double CubeRoot(double a)
		{
			return Math.Cbrt(a);
		}

		public double Power(double a, double b)
		{
			return Math.Pow(a, b);
		}
	}
}

