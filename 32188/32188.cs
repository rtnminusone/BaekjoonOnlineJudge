#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static int[] dist;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static int Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (q == N - 1) return w;

			if (L[q] == null)
			{
				if (q + 1 < N && dist[q + 1] > w + 1)
				{
					PQ.Enqueue((q + 1, w + 1), w + 1);
					dist[q + 1] = w + 1;
				}
			}
			else
			{
				foreach (var (nextq, portal) in L[q])
				{
					if (dist[nextq] > w)
					{
						PQ.Enqueue((nextq, w), w);
						dist[nextq] = w;
					}
					if (portal == 1 && q + 1 < N)
					{
						if (dist[q + 1] > w + 1)
						{
							PQ.Enqueue((q + 1, w + 1), w + 1);
							dist[q + 1] = w + 1;
						}
					}
				}
			}
		}

		return -1;
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
			int left = int.Parse(S[1]);
			int right = int.Parse(S[2]);
			int w = int.Parse(S[0]);
			(L[left] ??= new List<(int, int)>()).Add((right, w));
		}
		PQ.Enqueue((0, 0), 0);
		dist[0] = 0;

		Console.WriteLine(Dijkstra());
	}
}