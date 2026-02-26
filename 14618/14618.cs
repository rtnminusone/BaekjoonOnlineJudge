#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K;
	public static int[] A, B, dist;
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
		K = int.Parse(Console.ReadLine()) - 1;
		int t = int.Parse(Console.ReadLine());
		A = new int[t];
		B = new int[t];
		S = Console.ReadLine().Split();
		for (int i = 0; i < t; i++)
		{
			A[i] = int.Parse(S[i]) - 1;
		}
		S = Console.ReadLine().Split();
		for (int i = 0; i < t; i++)
		{
			B[i] = int.Parse(S[i]) - 1;
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			(L[left] ??= new List<(int, int)>()).Add((right, w));
			(L[right] ??= new List<(int, int)>()).Add((left, w));
		}
		PQ.Enqueue((K, 0), 0);
		dist[K] = 0;

		Dijkstra();

		int a = int.MaxValue;
		for (int i = 0; i < t; i++)
		{
			if (dist[A[i]] == int.MaxValue) continue;
			a = Math.Min(a, dist[A[i]]);
		}

		int b = int.MaxValue;
		for (int i = 0; i < t; i++)
		{
			if (dist[B[i]] == int.MaxValue) continue;
			b = Math.Min(b, dist[B[i]]);
		}

		if (a == int.MaxValue && b == int.MaxValue) Console.WriteLine(-1);
		else
		{
			if (a <= b) Console.WriteLine("A\n" + a);
			else Console.WriteLine("B\n" + b);
		}
	}
}