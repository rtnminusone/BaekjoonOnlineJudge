#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, A, B;
	public static int[] dist, T;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static void Dijkstra()
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
		A = int.Parse(S[0]);
		B = int.Parse(S[1]);
		T = new int[A];
		S = Console.ReadLine().Split();
		for (int i = 0; i < A; i++)
		{
			T[i] = int.Parse(S[i]) - 1;
		}
		Array.Sort(T);
		S = Console.ReadLine().Split();
		for (int i = 0; i < B; i++)
		{
			int tmp = int.Parse(S[i]) - 1;
			PQ.Enqueue((tmp, 0), 0);
			dist[tmp] = 0;
		}

		Dijkstra();

		int r = -1;
		int val = int.MaxValue;
		for (int i = 0; i < A; i++)
		{
			if (dist[T[i]] == int.MaxValue) continue;
			if (val > dist[T[i]])
			{
				r = T[i] + 1;
				val = dist[T[i]];
			}
		}

		Console.WriteLine(r);
	}
}