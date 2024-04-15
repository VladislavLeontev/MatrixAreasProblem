//Create a C# console application that accepts a matrix of values 0 and 1. The application should
//output only one value into the console – number of areas formed of number 1./
class Program
{
	//main with args
	public static int Main(string[] args)
	{
		if (args.Length == 0)
		{
			Console.WriteLine("Please provide a matrix as input");
			return 0;
		}

		var matrix = ParseMatrix(args[0]);
		if(matrix.Length > 100 || matrix[0].Length > 100)
		{
			Console.WriteLine("Matrix is too big");
		}

		return CountAreas(matrix);
	}

	static int CountAreas(int[][] matrix)
	{
		int rows = matrix.Length;
		int cols = matrix[0].Length;
		int count = 0;

		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				if (matrix[i][j] == 1)
				{
					RecursiveFill(matrix, i, j);
					count++;
				}
			}
		}

		return count;
	}

	static int[][] ParseMatrix(string input)
	{
		var rows = input.Split(';');
		var matrix = new int[rows.Length][];
		for (int i = 0; i < rows.Length; i++)
		{
			var cols = rows[i].Split(',');
			matrix[i] = Array.ConvertAll(cols, int.Parse);
		}

		return matrix;
	}

	static void RecursiveFill(int[][] matrix, int row, int col)
	{
		int rows = matrix.Length;
		int cols = matrix[0].Length;

		// if current item is out of bounds
		if(row < 0 || col < 0 || row >= rows || col >= cols)
		{
			return;
		}
		// or if current item was not in any area initially or was filled previousely.
		// end recursion
		if (matrix[row][col] == 0)
		{
			return;
		}

		matrix[row][col] = 0;

		// as per requirments of the task, areas are determined only up-down-left-right, no diagonales
		// visit neighbour cells recursively
		RecursiveFill(matrix, row + 1, col); //to the right
		RecursiveFill(matrix, row - 1, col); //to the left
		RecursiveFill(matrix, row, col + 1); //down
		RecursiveFill(matrix, row, col - 1); //up
	}
}