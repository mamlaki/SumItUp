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

		public double Sine(double a)
		{
			return Math.Sin(a);
		}

		public double Cosine(double a)
		{
			return Math.Cos(a);
		}

		public double Tangent(double a)
		{
			const double TOLERANCE = 1e-10;

			if (Math.Abs(Math.Cos(a)) < TOLERANCE)
			{
				throw new InvalidOperationException("Undefined tangent.");
			}
			return Math.Tan(a);
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

			public Matrix Invert()
			{
				int n = Value.GetLength(0);
				double[,] a = (double[,])Value.Clone();
				double[,] result = new double[n, n];

				for (int i = 0; i < n; ++i)
				{
					result[i, i] = 1;
				}

				for (int i = 0; i < n; ++i)
				{
					double diag = a[i, i];

					if (Math.Abs(diag) < 1e-10)
					{
						throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
					}

					for (int j = 0; j < n; ++j)
					{
						a[i, j] /= diag;
						result[i, j] /= diag;
					}

					for (int k = 0; k < n; ++k)
					{
						if (k != i)
						{
							double factor = a[k, i];

							for (int j = 0; j < n; ++j)
							{
								a[k, j] -= factor * a[i, j];
								result[k, j] -= factor * result[i, j];
							}
						}
					}
				}

				return new Matrix(result);
			}

			public double Determinant()
			{
				int n = Value.GetLength(0);

				if (n == 2)
				{
					double determinant = (Value[0, 0] * Value[1, 1]) - (Value[0, 1] * Value[1, 0]);
					Console.WriteLine($"2x2 determinant: {determinant}");
					return determinant;
				}

				double[,] a = (double[,])Value.Clone();
				double det = 1;

				for (int i = 0; i < n; ++i)
				{
					double max = 0;
					int maxRow = 0;

					for (int k = i; k < n; ++k)
					{
						if (Math.Abs(a[k, i]) > max)
						{
							max = Math.Abs(a[k, i]);
							maxRow = k;
						}
					}

					if (maxRow != i)
					{
						for (int k = 0; k < n; ++k)
						{
							double temp = a[i, k];
							a[i, k] = a[maxRow, k];
							a[maxRow, k] = temp;
						}
						det *= -1;
					}

                    det *= a[i, i];

                    for (int j = i + 1; j < n; ++j)
					{
						double c = a[j, i] / a[i, i];
						for (int k = 0; k < n; ++k)
						{
							a[j, k] -= c * a[i, k];
						}
					}
					
				}

                return det;
            }
		}
	}
}

