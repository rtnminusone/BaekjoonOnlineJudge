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

	public static int N, M, X, Y;
	public static int[,] T, dist;
	public static PriorityQueue<(Pos, int), int> PQ = new PriorityQueue<(Pos, int), int>();

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (T[x, y] == 1) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static void BFS()
	{
		while (PQ.Count > 0)
		{
			var (p, w) = PQ.Dequeue();

			if (w > dist[p.x, p.y]) continue;

			for (int i = 0; i < 8; i++)
			{
				int nextx = p.x + dx[i];
				int nexty = p.y + dy[i];
				int nextw = 0;
				if (Create(nextx, nexty, out Pos pos))
				{
					if (i == 2 || i == 4 || i == 7) nextw = w;
					else nextw = w + 1;

					if (dist[nextx, nexty] > nextw)
					{
						PQ.Enqueue((pos, nextw), nextw);
						dist[nextx, nexty] = nextw;
					}
				}
			}
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		dist = new int[N, M];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				dist[i, j] = int.MaxValue;
				if (S[0][j] == '#') T[i, j] = 1;
				else
				{
					T[i, j] = 0;
					if (S[0][j] == 'K')
					{
						PQ.Enqueue((new Pos(i, j), 0), 0);
						dist[i, j] = 0;
					}
					else if (S[0][j] == '*')
					{
						X = i;
						Y = j;
					}
				}
			}
		}
		BFS();

		Console.WriteLine(dist[X, Y] == int.MaxValue ? -1 : dist[X, Y]);
	}
}