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

		public double Exponential(double a)
		{
			return Math.Exp(a);
		}

		public double Logarithm(double a)
		{
			if (a > 0)
			{
				return Math.Log10(a);
			}
			throw new ArgumentException("Log base 10 requires a positive argument.");
		}

		public double NaturalLogarithm(double a)
		{
			if (a > 0)
			{
				return Math.Log(a);
			}
			throw new ArgumentException("Natural log requires a positive argument");
		}

		public class Matrix
		{
			public double[,] Value { get; set; }

			public Matrix(double[,] value)
			{
				Value = value;
			}

			public Matrix Add(Matrix other)
			{
				var rows = Value.GetLength(0);
				var cols = Value.GetLength(1);
				var result = new double[rows, cols];
				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < cols; j++)
					{
						result[i, j] = Value[i, j] + other.Value[i, j];
					}
				}
				return new Matrix(result);
			}

			public Matrix Subtract(Matrix other)
			{
				var rows = Value.GetLength(0);
				var cols = Value.GetLength(1);
				var result = new double[rows, cols];
				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < cols; j++)
					{
						result[i, j] = Value[i, j] - other.Value[i, j];
					}
				}
				return new Matrix(result);
			}

			public Matrix Multiply(Matrix other)
			{
				var rowsA = Value.GetLength(0);
				var rowsB = other.Value.GetLength(0);
				var colsA = Value.GetLength(1);
				var colsB = other.Value.GetLength(1);

				if (colsA != rowsB)
				{
					throw new InvalidOperationException("Non-conformable matrices.");
				}

				var result = new double[rowsA, colsB];
				for(int i = 0; i < rowsA; i++)
				{
					for (int j = 0; j < colsB; j++)
					{
						for (int k = 0; k < colsA; k++)
						{
							result[i, j] += Value[i, k] * other.Value[k, j];
						}
					}
				}
				return new Matrix(result);
			}
		}
	}
}

