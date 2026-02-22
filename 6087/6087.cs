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
	public static int[,] T;
	public static int[,,] dist;
	public static PriorityQueue<(Pos, int, int), int> PQ = new PriorityQueue<(Pos, int, int), int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (T[x, y] == 1) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static int BFS()
	{
		int r = int.MaxValue;

		while (PQ.Count > 0)
		{
			var (p, d, w) = PQ.Dequeue();

			if (w > dist[p.x, p.y, d]) continue;
			if (T[p.x, p.y] == 2) r = r > dist[p.x, p.y, d] ? dist[p.x, p.y, d] : r;

			for (int i = 0; i < 4; i++)
			{
				int nextx = p.x + dx[i];
				int nexty = p.y + dy[i];
				int nextw = d == i ? w : w + 1;
				if (Create(nextx, nexty, out Pos pos))
				{
					if (dist[nextx, nexty, i] > nextw)
					{
						PQ.Enqueue((pos, i, nextw), nextw);
						dist[nextx, nexty, i] = nextw;
					}
				}
			}
		}

		return r;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[1]);
		M = int.Parse(S[0]);
		T = new int[N, M];
		dist = new int[N, M, 4];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				for (int k = 0; k < 4; k++)
				{
					dist[i, j, k] = int.MaxValue;
				}
				if (S[0][j] == '*') T[i, j] = 1;
				else
				{
					T[i, j] = 0;
					if (PQ.Count == 0 && S[0][j] == 'C')
					{
						for (int k = 0; k < 4; k++)
						{
							PQ.Enqueue((new Pos(i, j), k, 0), 0);
							dist[i, j, k] = 0;
						}
					}
					else if (S[0][j] == 'C') T[i, j] = 2;
				}
			}
		}

		Console.WriteLine(BFS());
	}
}