#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		int[] T = new int[N + 1];
		for (int i = 1; i <= N; i++)
		{
			T[i] = int.Parse(Console.ReadLine());
		}
		if (N == 1)
		{
			Console.WriteLine(T[1]);
			Environment.Exit(0);
		}
		int[] DP = new int[N + 1];
		DP[1] = T[1];
		DP[2] = T[1] + T[2];
		for (int i = 3; i <= N; i++)
		{
			DP[i] = Math.Max(DP[i - 3] + T[i - 1] + T[i], DP[i - 2] + T[i]);
		}

		Console.WriteLine(DP[N]);
	}
}