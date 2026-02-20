#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static int[] dist;
	public static List<int>[] L;
	public static Dictionary<(int, int), int> D = new Dictionary<(int, int), int>();
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static int BFS()
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (q + 1 <= N && dist[q + 1] > w + 1)
			{
				PQ.Enqueue((q + 1, w + 1), w + 1);
				dist[q + 1] = w + 1;
			}
			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (l > N) continue;
				if (dist[l] > w + D[(q, l)])
				{
					PQ.Enqueue((l, w + D[(q, l)]), w + D[(q, l)]);
					dist[l] = w + D[(q, l)];
				}
			}
		}

		return dist[N];
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[1]);
		M = int.Parse(S[0]);
		dist = new int[N + 1];
		Array.Fill(dist, int.MaxValue);
		L = new List<int>[N + 1];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]);
			int right = int.Parse(S[1]);
			int w = int.Parse(S[2]);
			if (left >= N) continue;
			(L[left] ??= new List<int>()).Add(right);
			if (!D.ContainsKey((left, right))) D[(left, right)] = int.MaxValue;
			D[(left, right)] = Math.Min(D[(left, right)], w);
		}
		PQ.Enqueue((0, 0), 0);
		dist[0] = 0;

		Console.WriteLine(BFS());
	}
}