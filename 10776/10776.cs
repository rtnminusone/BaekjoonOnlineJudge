#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K;
	public static int[,] dist;
	public static List<(int, int, int)>[] L;
	public static PriorityQueue<(int, int, int), int> PQ = new PriorityQueue<(int, int, int), int>();

	public static void Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (q, t, w) = PQ.Dequeue();

			if (w > dist[q, t]) continue;

			if (L[q] == null) continue;
			foreach (var (nextq, nextt, nextw) in L[q])
			{
				if (t - nextt <= 0) continue;
				if (dist[nextq, t - nextt] > w + nextw)
				{
					PQ.Enqueue((nextq, t - nextt, w + nextw), w + nextw);
					dist[nextq, t - nextt] = w + nextw;
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
		L = new List<(int, int, int)>[N];
		dist = new int[N, K + 1];
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j <= K; j++)
			{
				dist[i, j] = int.MaxValue;
			}
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			int t = int.Parse(S[3]);
			(L[left] ??= new List<(int, int, int)>()).Add((right, t, w));
			(L[right] ??= new List<(int, int, int)>()).Add((left, t, w));
		}
		S = Console.ReadLine().Split();
		int start = int.Parse(S[0]) - 1;
		int end = int.Parse(S[1]) - 1;

		PQ.Enqueue((start, K, 0), 0);
		dist[start, K] = 0;

		Dijkstra();

		int r = int.MaxValue;
		for (int i = 0; i <= K; i++)
		{
			if (dist[end, i] == int.MaxValue) continue;
			if (dist[end, i] < r) r = dist[end, i];
		}

		Console.WriteLine(r == int.MaxValue ? -1 : r);
	}
}