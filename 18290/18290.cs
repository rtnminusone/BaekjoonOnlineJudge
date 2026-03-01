#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K, R = int.MinValue;
	public static int[,] T;
	public static bool[,] V;

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void visited(int x, int y, bool flg, List<(int, int)> history)
	{
		V[x, y] = flg;

		if (flg)
		{
			for (int i = 0; i < 4; i++)
			{
				int nextx = x + dx[i];
				int nexty = y + dy[i];

				if (nextx < 0 || nextx >= N || nexty < 0 || nexty >= M) continue;
				if (!V[nextx, nexty])
				{
					V[nextx, nexty] = true;
					history.Add((nextx, nexty));
				}
			}
		}
		else
		{
			foreach (var (nextx, nexty) in history)
			{
				V[nextx, nexty] = false;
			}
		}
	}

	public static void DFS(int depth, int startx, int starty, int cur)
	{
		if (depth == K)
		{
			if (R < cur) R = cur;
			return;
		}

		for (int i = startx; i < N; i++)
		{
			for (int j = i == startx ? starty : 0; j < M; j++)
			{
				if (V[i, j]) continue;
				List<(int, int)> history = new List<(int, int)>();
				visited(i, j, true, history);
				if (j + 1 < M) DFS(depth + 1, i, j + 1, cur + T[i, j]);
				else DFS(depth + 1, i + 1, 0, cur + T[i, j]);
				visited(i, j, false, history);
			}
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		K = int.Parse(S[2]);
		T = new int[N, M];
		V = new bool[N, M];
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}

		DFS(0, 0, 0, 0);

		Console.WriteLine(R);
	}
}