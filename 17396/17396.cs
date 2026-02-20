#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static int[] T;
	public static long[] dist;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, long), long> PQ = new PriorityQueue<(int, long), long>();

	public static void BFS()
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (L[q] == null) continue;
			foreach (var (nextq, nextw) in L[q])
			{
				if (T[nextq] == 1 && nextq != N - 1) continue;
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
		T = new int[N];
		dist = new long[N];
		Array.Fill(dist, long.MaxValue);
		L = new List<(int, int)>[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]);
			int right = int.Parse(S[1]);
			int w = int.Parse(S[2]);
			(L[left] ??= new List<(int, int)>()).Add((right, w));
			(L[right] ??= new List<(int, int)>()).Add((left, w));
		}
		PQ.Enqueue((0, 0), 0);
		dist[0] = 0;

		BFS();

		Console.WriteLine(dist[N - 1] == long.MaxValue ? -1 : dist[N - 1]);
	}
}