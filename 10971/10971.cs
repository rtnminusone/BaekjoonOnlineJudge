#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, V = 0, R = int.MaxValue;
	public static int[,] T;

	public static void DFS(int depth, int cur, int cost)
	{
		if (depth == N)
		{
			if (T[cur, 0] != 0)
			{
				if (R > cost + T[cur, 0]) R = cost + T[cur, 0];
			}
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if ((V & (1 << i)) != 0) continue;
			if (T[cur, i] == 0) continue;

			V |= (1 << i);
			DFS(depth + 1, i, cost + T[cur, i]);
			V &= ~(1 << i);
		}
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N, N];
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}

		V |= (1 << 0);
		DFS(1, 0, 0);

		Console.WriteLine(R);
	}
}