#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static int[] dist;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int, int), int> PQ = new PriorityQueue<(int, int, int), int>();

	public static void Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (q, v, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (L[q] == null) continue;
			foreach (var (nextq, volt) in L[q])
			{
				int nextw = v == volt ? 0 : 1;
				if (dist[nextq] > w + nextw)
				{
					PQ.Enqueue((nextq, volt, w + nextw), w + nextw);
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
		dist = new int[N];
		Array.Fill(dist, int.MaxValue);
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
		int a = int.Parse(S[0]) - 1;
		int b = int.Parse(S[1]) - 1;

		PQ.Enqueue((a, -1, 0), 0);
		dist[a] = 0;

		Dijkstra();

		Console.WriteLine(dist[b] - 1);
	}
}