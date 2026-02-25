#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, D, E;
	public static int[] T;
	public static long[] dist1, dist2;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, long), long> PQ = new PriorityQueue<(int, long), long>();

	public static void Dijkstra(long[] dist)
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (L[q] == null) continue;
			foreach (var (nextq, nextw) in L[q])
			{
				if (dist[nextq] > w + nextw && T[q] < T[nextq])
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
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		D = int.Parse(S[2]);
		E = int.Parse(S[3]);
		T = new int[N];
		dist1 = new long[N];
		dist2 = new long[N];
		L = new List<(int, int)>[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
			dist1[i] = long.MaxValue;
			dist2[i] = long.MaxValue;
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			(L[left] ??= new List<(int, int)>()).Add((right, w));
			(L[right] ??= new List<(int, int)>()).Add((left, w));
		}
		PQ.Enqueue((0, 0), 0);
		dist1[0] = 0;

		Dijkstra(dist1);

		PQ.Enqueue((N - 1, 0), 0);
		dist2[N - 1] = 0;

		Dijkstra(dist2);

		long r = long.MinValue;
		for (int i = 1; i < N - 1; i++)
		{
			if (dist1[i] == long.MaxValue || dist2[i] == long.MaxValue) continue;
			if (T[i] * E - (dist1[i] + dist2[i]) * D > r) r = T[i] * E - (dist1[i] + dist2[i]) * D;
		}

		Console.WriteLine(r == long.MinValue ? "Impossible" : r);
	}
}