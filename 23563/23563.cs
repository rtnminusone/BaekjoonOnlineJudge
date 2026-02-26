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
	public static char[,] T;
	public static int[,] dist;
	public static PriorityQueue<(Pos, int), int> PQ = new PriorityQueue<(Pos, int), int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (T[x, y] == '#') return false;

		pos = new Pos(x, y);

		return true;
	}

	public static bool Wall(Pos pos)
	{
		for (int i = 0; i < 4; i++)
		{
			int nextx = pos.x + dx[i];
			int nexty = pos.y + dy[i];
			if (nextx < 0 || nextx >= N || nexty < 0 || nexty >= M) continue;
			if (T[nextx, nexty] == '#') return true;
		}

		return false;
	}

	public static int Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (p, w) = PQ.Dequeue();

			if (w > dist[p.x, p.y]) continue;

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					int nextw = Wall(p) && Wall(pos) ? w : w + 1;
					if (dist[pos.x, pos.y] > nextw)
					{
						PQ.Enqueue((pos, nextw), nextw);
						dist[pos.x, pos.y] = nextw;
					}
				}
			}
		}

		return dist[X, Y] == int.MaxValue ? -1 : dist[X, Y];
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new char[N, M];
		dist = new int[N, M];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				dist[i, j] = int.MaxValue;
				T[i, j] = S[0][j];
				if (T[i, j] == 'S')
				{
					PQ.Enqueue((new Pos(i, j), 0), 0);
					dist[i, j] = 0;
				}
				else if (T[i, j] == 'E')
				{
					T[i, j] = '.';
					X = i;
					Y = j;
				}
			}
		}

		Console.WriteLine(Dijkstra());
	}
}