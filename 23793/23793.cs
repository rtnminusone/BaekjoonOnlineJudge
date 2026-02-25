#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, X, Y, Z;
	public static int[] distx, distx2, disty;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static void Dijkstra(int[] dist, bool flg)
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (L[q] == null) continue;
			foreach (var (nextq, nextw) in L[q])
			{
				if (flg && nextq == Y) continue;
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
		distx = new int[N];
		distx2 = new int[N];
		disty = new int[N];
		Array.Fill(distx, int.MaxValue);
		Array.Fill(distx2, int.MaxValue);
		Array.Fill(disty, int.MaxValue);
		L = new List<(int, int)>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			(L[left] ??= new List<(int, int)>()).Add((right, w));
		}
		S = Console.ReadLine().Split();
		X = int.Parse(S[0]) - 1;
		Y = int.Parse(S[1]) - 1;
		Z = int.Parse(S[2]) - 1;

		PQ.Enqueue((X, 0), 0);
		distx[X] = 0;

		Dijkstra(distx, false);

		PQ.Enqueue((X, 0), 0);
		distx2[X] = 0;

		Dijkstra(distx2, true);

		PQ.Enqueue((Y, 0), 0);
		disty[Y] = 0;

		Dijkstra(disty, false);

		int r1 = -1;
		if (distx[Y] != int.MaxValue && disty[Z] != int.MaxValue)
		{
			r1 = distx[Y] + disty[Z];
		}
		int r2 = -1;
		if (distx2[Z] != int.MaxValue) r2 = distx2[Z];

		Console.WriteLine(r1 + " " + r2);
	}
}