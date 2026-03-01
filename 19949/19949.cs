#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N = 10, R = 0;
	public static int[] T = new int[N];

	public static void DFS(int depth, int cur, int before, bool flg)
	{
		if (depth == N)
		{
			if (cur >= 5) R++;
			return;
		}

		for (int i = 1; i <= 5; i++)
		{
			if (flg && i == before) continue;
			DFS(depth + 1, cur + (i == T[depth] ? 1 : 0), i, before == i);
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		DFS(0, 0, 0, false);

		Console.WriteLine(R);
	}
}