#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N;
	public static HashSet<int> D = new HashSet<int>();

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());

		for (int i = 0; i <= N; i++)
		{
			for (int j = 0; j + i <= N; j++)
			{
				for (int k = 0; k + j + i <= N; k++)
				{
					int l = N - (i + j + k);
					D.Add(i * 1 + j * 5 + k * 10 + l * 50);
				}
			}
		}

		Console.WriteLine(D.Count);
	}
}