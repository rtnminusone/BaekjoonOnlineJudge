#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static int[] dist;
	public static List<int>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static void BFS()
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (q + 1 < N && dist[q + 1] > w + 1)
			{
				PQ.Enqueue((q + 1, w + 1), w + 1);
				dist[q + 1] = w + 1;
			}
			if (q - 1 >= 0 && dist[q - 1] > w + 1)
			{
				PQ.Enqueue((q - 1, w + 1), w + 1);
				dist[q - 1] = w + 1;
			}
			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (dist[l] > w + 1)
				{
					PQ.Enqueue((l, w + 1), w + 1);
					dist[l] = w + 1;
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
		L = new List<int>[N];
		S = Console.ReadLine().Split();
		int x = int.Parse(S[0]) - 1;
		int y = int.Parse(S[1]) - 1;
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			(L[left] ??= new List<int>()).Add(right);
			(L[right] ??= new List<int>()).Add(left);
		}
		PQ.Enqueue((x, 0), 0);
		dist[x] = 0;

		BFS();

		Console.WriteLine(dist[y]);
	}
}