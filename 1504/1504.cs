#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, V1, V2;
	public static long[,] dist;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static void BFS(int idx)
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[idx, q]) continue;

			if (L[q] == null) continue;
			foreach (var (nextq, nextw) in L[q])
			{
				if (dist[idx, nextq] > w + nextw)
				{
					PQ.Enqueue((nextq, w + nextw), w + nextw);
					dist[idx, nextq] = w + nextw;
				}
			}
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		L = new List<(int, int)>[N];
		dist = new long[3, N];
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < N; j++)
			{
				dist[i, j] = long.MaxValue;
			}
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			(L[left] ??= new List<(int, int)>()).Add((right, int.Parse(S[2])));
			(L[right] ??= new List<(int, int)>()).Add((left, int.Parse(S[2])));
		}
		S = Console.ReadLine().Split();
		V1 = int.Parse(S[0]) - 1;
		V2 = int.Parse(S[1]) - 1;
		PQ.Enqueue((0, 0), 0);
		dist[0, 0] = 0;
		BFS(0);

		PQ.Clear();
		PQ.Enqueue((V1, 0), 0);
		dist[1, V1] = 0;
		BFS(1);

		PQ.Clear();
		PQ.Enqueue((V2, 0), 0);
		dist[2, V2] = 0;
		BFS(2);

		long R = long.MaxValue;
		if (dist[0, V1] != long.MaxValue && dist[1, V2] != long.MaxValue && dist[2, N - 1] != long.MaxValue) R = dist[0, V1] + dist[1, V2] + dist[2, N - 1];
		if (dist[0, V2] != long.MaxValue && dist[2, V1] != long.MaxValue && dist[1, N - 1] != long.MaxValue)
		{
			R = Math.Min(R, dist[0, V2] + dist[2, V1] + dist[1, N - 1]);
		}

		Console.WriteLine(R == long.MaxValue ? -1 : R);
	}
}