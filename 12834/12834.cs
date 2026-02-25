#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K;
	public static int[] G = new int[2];
	public static int[] T, dist1, dist2;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static void Dijkstra(int[] dist)
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

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		K = int.Parse(S[0]);
		N = int.Parse(S[1]);
		M = int.Parse(S[2]);
		T = new int[K];
		dist1 = new int[N];
		dist2 = new int[N];
		Array.Fill(dist1, int.MaxValue);
		Array.Fill(dist2, int.MaxValue);
		L = new List<(int, int)>[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < 2; i++)
		{
			G[i] = int.Parse(S[i]) - 1;
		}
		S = Console.ReadLine().Split();
		for (int i = 0; i < K; i++)
		{
			T[i] = int.Parse(S[i]) - 1;
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			(L[left] ??= new List<(int, int)>()).Add((right, w));
			(L[right] ??= new List<(int, int)>()).Add((left, w ));
		}
		PQ.Enqueue((G[0], 0), 0);
		dist1[G[0]] = 0;

		Dijkstra(dist1);

		PQ.Enqueue((G[1], 0), 0);
		dist2[G[1]] = 0;

		Dijkstra(dist2);

		int r = 0;
		for (int i = 0; i < K; i++)
		{
			int d1 = dist1[T[i]] == int.MaxValue ? -1 : dist1[T[i]];
			int d2 = dist2[T[i]] == int.MaxValue ? -1 : dist2[T[i]];
			r += d1 + d2;
		}

		Console.WriteLine(r);
	}
}