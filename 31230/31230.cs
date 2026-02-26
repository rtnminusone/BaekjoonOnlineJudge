#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, A, B;
	public static long[] distA, distB;
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
		A = int.Parse(S[2]) - 1;
		B = int.Parse(S[3]) - 1;
		distA = new long[N];
		distB = new long[N];
		Array.Fill(distA, long.MaxValue);
		Array.Fill(distB, long.MaxValue);
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
		PQ.Enqueue((A, 0), 0);
		distA[A] = 0;

		Dijkstra(distA);

		PQ.Enqueue((B, 0), 0);
		distB[B] = 0;

		Dijkstra(distB);

		List<int> r = new List<int>();
		long val = long.MaxValue;
		for (int i = 0; i < N; i++)
		{
			if (distA[i] == long.MaxValue || distB[i] == long.MaxValue) continue;
			if (val == distA[i] + distB[i]) r.Add(i + 1);
			if (val > distA[i] + distB[i])
			{
				r.Clear();
				r.Add(i + 1);
				val = distA[i] + distB[i];
			}
		}

		Console.WriteLine(r.Count + "\n" + string.Join(" ", r));
	}
}