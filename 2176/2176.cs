#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, T = 1;
	public static int[] dist, DP;
	public static bool[] V;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static void Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (L[q] == null) continue;
			foreach (var (nextq, nextw) in L[q])
			{
				if (dist[nextq] > w + nextw)
				{
					PQ.Enqueue((nextq, w + nextw), w + nextw);
					dist[nextq] = w + nextw;
				}
			}
		}
	}

	public static int DFS(int q)
	{
		if (q == T) return 1;
		if (V[q]) return DP[q];

		V[q] = true;
		int r = 0;

		if (L[q] == null) return 0;
		foreach (var (nextq, _) in L[q])
		{
			if (dist[nextq] < dist[q]) r += DFS(nextq);
		}

		DP[q] = r;
		return r;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		V = new bool[N];
		DP = new int[N];
		dist = new int[N];
		Array.Fill(dist, int.MaxValue);
		L = new List<(int, int)>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			(L[left] ??= new List<(int, int)>()).Add((right, w));
			(L[right] ??= new List<(int, int)>()).Add((left, w));
		}
		PQ.Enqueue((T, 0), 0);
		dist[T] = 0;

		Dijkstra();

		Console.WriteLine(DFS(0));
	}
}