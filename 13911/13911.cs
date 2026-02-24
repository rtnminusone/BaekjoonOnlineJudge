#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static int[] dist1, dist2;
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
		Array.Fill(dist1, int.MaxValue);
		dist2 = new int[N];
		Array.Fill(dist2, int.MaxValue);
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
		int m1 = int.Parse(S[0]);
		int m2 = int.Parse(S[1]);
		S = Console.ReadLine().Split();
		for (int i = 0; i < m1; i++)
		{
			int key = int.Parse(S[i]) - 1;
			PQ.Enqueue((key, 0), 0);
			dist1[key] = 0;
		}
		Dijkstra(dist1);
		S = Console.ReadLine().Split();
		int s1 = int.Parse(S[0]);
		int s2 = int.Parse(S[1]);
		S = Console.ReadLine().Split();
		for (int i = 0; i < s1; i++)
		{
			int key = int.Parse(S[i]) - 1;
			PQ.Enqueue((key, 0), 0);
			dist2[key] = 0;
		}
		Dijkstra(dist2);
		bool[] flg = new bool[N];
		int[] R = new int[N];
		for (int i = 0; i < N; i++)
		{
			if (!flg[i])
			{
				if (dist1[i] == 0 || dist1[i] == int.MaxValue || dist2[i] == 0 || dist2[i] == int.MaxValue || dist1[i] > m2 || dist2[i] > s2) flg[i] = true;
				else
				{
					R[i] = dist1[i] + dist2[i];
				}
			}
		}
		int r = int.MaxValue;
		for (int i = 0; i < N; i++)
		{
			if (flg[i]) continue;
			r = Math.Min(r, R[i]);
		}

		Console.WriteLine(r == int.MaxValue ? -1 : r);
	}
}