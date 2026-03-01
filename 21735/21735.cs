#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, R = int.MinValue;
	public static int[] T;

	public static void DFS(int depth, int cur, int time)
	{
		if (time == M || depth >= N)
		{
			if (R < cur) R = cur;
			return;
		}

		if (depth < N) DFS(depth + 1, cur + T[depth], time + 1);
		if (depth + 1 < N) DFS(depth + 2, (cur / 2) + T[depth + 1], time + 1);
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		DFS(0, 1, 0);

		Console.WriteLine(R);
	}
}