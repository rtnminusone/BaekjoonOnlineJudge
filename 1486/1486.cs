#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public struct Pos
	{
		public int x;
		public int y;

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static int N, M, D, K;
	public static int[,] T;
	public static Dictionary<(int, int), int> IDX = new Dictionary<(int, int), int>();
	public static PriorityQueue<Pos, int> PQ = new PriorityQueue<Pos, int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void MakeGraph(List<(Pos, int)>[] L, List<(Pos, int)>[] L2)
	{
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				int left = IDX[(i, j)];
				for (int k = 0; k < 4; k++)
				{
					int nextx = i + dx[k];
					int nexty = j + dy[k];
					if (nextx < 0 || nextx >= N || nexty < 0 || nexty >= M) continue;
					int diff = T[nextx, nexty] - T[i, j];
					if (Math.Abs(diff) > D) continue;
					diff = diff <= 0 ? 1 : diff * diff;
					(L[left] ??= new List<(Pos, int)>()).Add((new Pos(nextx, nexty), diff));
					(L2[IDX[(nextx, nexty)]] ??= new List<(Pos, int)>()).Add((new Pos(i, j), diff));
				}
			}
		}
	}

	public static void Dijkstra(List<(Pos, int)>[] L, int[,] dist)
	{
		while (PQ.Count > 0)
		{
			Pos p = PQ.Dequeue();

			int key = IDX[(p.x, p.y)];
			if (L[key] == null) continue;
			foreach (var (nextp, nextw) in L[key])
			{
				if (dist[nextp.x, nextp.y] > dist[p.x, p.y] + nextw)
				{
					PQ.Enqueue(nextp, dist[p.x, p.y] + nextw);
					dist[nextp.x, nextp.y] = dist[p.x, p.y] + nextw;
				}
			}
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		D = int.Parse(S[2]);
		K = int.Parse(S[3]);
		T = new int[N, M];
		int[,] dist1 = new int[N, M];
		int[,] dist2 = new int[N, M];
		int idx = 0;
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				if ('A' <= S[0][j] && S[0][j] <= 'Z') T[i, j] = S[0][j] - 'A';
				else T[i, j] = S[0][j] - 'a' + 26;
				dist1[i, j] = int.MaxValue;
				dist2[i, j] = int.MaxValue;
				IDX[(i, j)] = idx++;
			}
		}
		List<(Pos, int)>[] L = new List<(Pos, int)>[idx];
		List<(Pos, int)>[] L2 = new List<(Pos, int)>[idx];
		MakeGraph(L, L2);
		PQ.Enqueue(new Pos(0, 0), 0);
		dist1[0, 0] = 0;

		Dijkstra(L, dist1);

		PQ.Enqueue(new Pos(0, 0), 0);
		dist2[0, 0] = 0;

		Dijkstra(L2, dist2);

		int R = int.MinValue;
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (dist1[i, j] == int.MaxValue || dist2[i, j] == int.MaxValue) continue;
				if (dist1[i, j] + dist2[i, j] <= K) R = Math.Max(R, T[i, j]);
			}
		}

		Console.WriteLine(R);
	}
}