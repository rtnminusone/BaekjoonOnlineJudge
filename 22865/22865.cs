#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static long[] dist;
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

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		dist = new long[N];
		Array.Fill(dist, long.MaxValue);
		L = new List<(int, int)>[N];
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < 3; i++)
		{
			int f = int.Parse(S[i]) - 1;
			PQ.Enqueue((f, 0), 0);
			dist[f] = 0;
		}
		M = int.Parse(Console.ReadLine());
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			(L[left] ??= new List<(int, int)>()).Add((right, w));
			(L[right] ??= new List<(int, int)>()).Add((left, w));
		}

		Dijkstra();

		int r = -1;
		long val = long.MinValue;
		for (int i = 0; i < N; i++)
		{
			if (dist[i] == long.MaxValue) continue;
			if (val < dist[i])
			{
				r = i + 1;
				val = dist[i];
			}
		}

		Console.WriteLine(r);
	}
}