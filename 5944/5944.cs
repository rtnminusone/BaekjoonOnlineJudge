#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K, A1, A2;
	public static int[] dist1, dist2;
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
		N = int.Parse(S[1]);
		M = int.Parse(S[0]);
		K = int.Parse(S[2]) - 1;
		A1 = int.Parse(S[3]) - 1;
		A2 = int.Parse(S[4]) - 1;
		dist1 = new int[N];
		dist2 = new int[N];
		Array.Fill(dist1, int.MaxValue);
		Array.Fill(dist2, int.MaxValue);
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
		PQ.Enqueue((A1, 0), 0);
		dist1[A1] = 0;

		Dijkstra(dist1);

		PQ.Enqueue((A2, 0), 0);
		dist2[A2] = 0;

		Dijkstra(dist2);

		int r = -1;
		if (dist1[K] != int.MaxValue && dist1[A2] != int.MaxValue) r = dist1[K] + dist1[A2];
		if (dist2[K] != int.MaxValue && dist2[A1] != int.MaxValue) r = Math.Min(r, dist2[K] + dist2[A1]);

		Console.WriteLine(r);
	}
}