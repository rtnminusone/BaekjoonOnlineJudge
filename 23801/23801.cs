#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static int[] dist1, distn;
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
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		dist1 = new int[N];
		distn = new int[N];
		Array.Fill(dist1, int.MaxValue);
		Array.Fill(distn, int.MaxValue);
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
		int x = int.Parse(S[0]) - 1;
		int y = int.Parse(S[1]) - 1;

		PQ.Enqueue((x, 0), 0);
		dist1[x] = 0;

		Dijkstra(dist1);

		PQ.Enqueue((y, 0), 0);
		distn[y] = 0;

		Dijkstra(distn);

		int r = int.MaxValue;
		int K = int.Parse(Console.ReadLine());
		S = Console.ReadLine().Split();
		for (int i = 0; i < K; i++)
		{
			int tmp = int.Parse(S[i]) - 1;
			if (dist1[tmp] == int.MaxValue || distn[tmp] == int.MaxValue) continue;
			if (r > dist1[tmp] + distn[tmp])
			{
				r = dist1[tmp] + distn[tmp];
			}
		}

		Console.WriteLine(r);
	}
}