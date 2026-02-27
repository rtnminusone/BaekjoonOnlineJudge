#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N;
	public static int[] dist;
	public static List<(int, int)>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (L[q] == null) continue;
			foreach (var (nextq, nextw) in L[q])
			{
				if (dist[nextq] > w + nextw)
				{
					Q.Enqueue((nextq, w + nextw));
					dist[nextq] = w + nextw;
				}
			}
		}
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		dist = new int[N];
		L = new List<(int, int)>[N];
		for (int i = 0; i < N - 1; i++)
		{
			string[] S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			(L[left] ??= new List<(int, int)>()).Add((right, w));
			(L[right] ??= new List<(int, int)>()).Add((left, w));
		}

		Array.Fill(dist, int.MaxValue);
		Q.Enqueue((0, 0));
		dist[0] = 0;

		BFS();

		int r = -1;
		int val = int.MinValue;
		for (int i = 0; i < N; i++)
		{
			if (dist[i] == int.MaxValue) continue;
			if (val < dist[i])
			{
				val = dist[i];
				r = i;
			}
		}

		Array.Fill(dist, int.MaxValue);
		Q.Enqueue((r, 0));
		dist[r] = 0;

		BFS();

		val = int.MinValue;
		for (int i = 0; i < N; i++)
		{
			if (dist[i] == int.MaxValue) continue;
			if (val < dist[i])
			{
				val = dist[i];
			}
		}

		Console.WriteLine(val);
	}
}