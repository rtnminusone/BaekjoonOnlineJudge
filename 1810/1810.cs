#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, K;
	public static double[] dist;
	public static Dictionary<(int, int), int> D = new Dictionary<(int, int), int>();
	public static PriorityQueue<((int, int), double), double> PQ = new PriorityQueue<((int, int), double), double>();

	public static int Dijkstra()
	{
		int r = int.MaxValue;

		while (PQ.Count > 0)
		{
			var ((x, y), w) = PQ.Dequeue();

			if (w > dist[D[(x, y)]]) continue;

			if (y == K)
			{
				r = Math.Min(r, (int)Math.Round(w));
				continue;
			}

			for (int i = -2; i <= 2; i++)
			{
				for (int j = -2; j <= 2; j++)
				{
					if (i == 0 && j == 0) continue;
					if (D.ContainsKey((x + i, y + j)))
					{
						int nextx = x + i;
						int nexty = y + j;
						double nextw = w + Math.Sqrt(i * i + j * j);
						if (dist[D[(nextx, nexty)]] > nextw)
						{
							PQ.Enqueue(((nextx, nexty), nextw), nextw);
							dist[D[(nextx, nexty)]] = nextw;
						}
					}
				}
			}
		}

		return r == int.MaxValue ? -1 : r;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		int idx = 0;
		D[(0, 0)] = idx++;
		dist = new double[N + 1];
		Array.Fill(dist, double.MaxValue);
		dist[0] = 0;
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			D[(int.Parse(S[0]), int.Parse(S[1]))] = idx++;
		}
		PQ.Enqueue(((0, 0), 0), 0);
		dist[0] = 0;

		Console.WriteLine(Dijkstra());
	}
}