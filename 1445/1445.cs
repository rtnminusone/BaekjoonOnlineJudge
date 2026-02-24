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

	public static int N, M;
	public static int[,] T, dist, dist2;
	public static PriorityQueue<(Pos, int, int), (int, int)> PQ = new PriorityQueue<(Pos, int, int), (int, int)>();

	public static int[] dx = { -1, 0, 1 ,0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static int Calw(Pos pos)
	{
		if (T[pos.x, pos.y] != 0) return 0;

		for (int i = 0; i < 4; i++)
		{
			int nextx = pos.x + dx[i];
			int nexty = pos.y + dy[i];
			if (nextx < 0 || nextx >= N || nexty < 0 || nexty >= M) continue;
			if (T[nextx, nexty] == 1) return 1;
		}

		return 0;
	}

	public static string Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (p, w1, w2) = PQ.Dequeue();

			if (w1 > dist[p.x, p.y]) continue;
			if (T[p.x, p.y] == 2) return w1 + " " + w2;

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					int nextw1 = T[pos.x, pos.y] == 1 ? 1 : 0;
					int nextw2 = Calw(pos);
					if (dist[pos.x, pos.y] > w1 + nextw1 || (dist[pos.x, pos.y] == w1 + nextw1 && dist2[pos.x, pos.y] > w2 + nextw2))
					{
						PQ.Enqueue((pos, w1 + nextw1, w2 + nextw2), (w1 + nextw1, w2 + nextw2));
						dist[pos.x, pos.y] = w1 + nextw1;
						dist2[pos.x, pos.y] = w2 + nextw2;
					}
				}
			}
		}

		return "-1";
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		dist = new int[N, M];
		dist2 = new int[N, M];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				dist[i, j] = int.MaxValue;
				dist2[i, j] = int.MaxValue;
				if (S[0][j] == 'g') T[i, j] = 1;
				else
				{
					T[i, j] = 0;
					if (S[0][j] == 'S')
					{
						PQ.Enqueue((new Pos(i, j), 0, 0), (0, 0));
						dist[i, j] = 0;
						dist2[i, j] = 0;
					}
					else if (S[0][j] == 'F') T[i, j] = 2;
				}
			}
		}

		Console.WriteLine(Dijkstra());
	}
}