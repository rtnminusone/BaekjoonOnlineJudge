#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K;
	public static long[] E, dist1, distN;
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
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		K = int.Parse(S[2]);
		E = new long[N];
		dist1 = new long[N];
		distN = new long[N];
		Array.Fill(dist1, long.MaxValue);
		Array.Fill(distN, long.MaxValue);
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
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			E[i] = long.Parse(S[i]);
		}
		PQ.Enqueue((0, 0), 0);
		dist1[0] = 0;

		Dijkstra(dist1);

		PQ.Enqueue((N - 1, 0), 0);
		distN[N - 1] = 0;

		Dijkstra(distN);

		long r = long.MaxValue;
		for (int i = 0; i < N; i++)
		{
			if (dist1[i] == long.MaxValue || distN[i] == long.MaxValue || E[i] == -1) continue;
			if (r > dist1[i] + distN[i] + E[i] * (K - 1)) r = dist1[i] + distN[i] + E[i] * (K - 1);
		}

		Console.WriteLine(r == long.MaxValue ? -1 : r);
	}
}