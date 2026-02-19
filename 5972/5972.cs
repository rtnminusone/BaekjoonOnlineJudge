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

			if (L[q] == null) continue;
			foreach (int nextq in L[q])
			{
				if (!D.ContainsKey((q, nextq))) continue;
				int nextw = D[(q, nextq)];
				if (dist[nextq] > w + nextw)
				{
					PQ.Enqueue((nextq, w + nextw), w + nextw);
					dist[nextq] = w + nextw;
				}
			}
		}

		return dist[N - 1] == int.MaxValue ? -1 : dist[N - 1];
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		dist = new int[N];
		Array.Fill(dist, int.MaxValue);
		L = new List<int>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			(L[left] ??= new List<int>()).Add(right);
			(L[right] ??= new List<int>()).Add(left);
			if (!D.ContainsKey((left, right))) D[(left, right)] = w;
			else D[(left, right)] = Math.Min(D[(left, right)], w);
			if (!D.ContainsKey((right, left))) D[(right, left)] = w;
			else D[(right, left)] = Math.Min(D[(right, left)], w);
		}
		PQ.Enqueue((0, 0), 0);
		dist[0] = 0;

		Console.WriteLine(BFS());
	}
}