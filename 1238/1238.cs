#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K;
	public static int[,] dist;
	public static List<(int, int)>[,] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static void BFS(int idx)
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[idx, q]) continue;

			if (L[idx, q] == null) continue;
			foreach (var (nextq, nextw) in L[idx, q])
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
		K = int.Parse(S[2]) - 1;
		L = new List<(int, int)>[2, N];
		dist = new int[2, N];
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < N; j++)
			{
				dist[i, j] = int.MaxValue;
			}
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			(L[0, left] ??= new List<(int, int)>()).Add((right, int.Parse(S[2])));
			(L[1, right] ??= new List<(int, int)>()).Add((left, int.Parse(S[2])));
		}
		int[] A = new int[N];
		for (int i = 0; i < 2; i++)
		{
			PQ.Clear();
			PQ.Enqueue((K, 0), 0);
			dist[i, K] = 0;

			BFS(i);
			for (int j = 0; j < N; j++)
			{
				A[j] += dist[i, j];
			}
		}
		Array.Sort(A);

		Console.WriteLine(A[N - 1]);
	}
}