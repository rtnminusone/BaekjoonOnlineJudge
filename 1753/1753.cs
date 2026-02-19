#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K;
	public static int[] dist;
	public static List<int>[] L;
	public static Dictionary<(int, int), int> D = new Dictionary<(int, int), int>();
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static string BFS()
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (dist[l] > w + D[(q, l)])
				{
					PQ.Enqueue((l, w + D[(q, l)]), w + D[(q, l)]);
					dist[l] = w + D[(q, l)];
				}
			}
		}

		return string.Join("\n", dist.Select(x => x == int.MaxValue ? "INF" : x.ToString()));
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		dist = new int[N];
		Array.Fill(dist, int.MaxValue);
		L = new List<int>[N];
		K = int.Parse(Console.ReadLine()) - 1;
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			(L[left] ??= new List<int>()).Add(right);
			if (!D.ContainsKey((left, right))) D[(left, right)] = w;
			else D[(left, right)] = D[(left, right)] > w ? w : D[(left, right)];
		}
		PQ.Enqueue((K, 0), 0);
		dist[K] = 0;

		Console.WriteLine(BFS());
	}
}