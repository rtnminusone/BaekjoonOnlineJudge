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

	public static int N;
	public static int[,] T;
	public static int[,,] dist;
	public static PriorityQueue<(Pos, int, int), int> PQ = new PriorityQueue<(Pos, int, int), int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= N) return false;
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

			if (T[p.x, p.y] == 2)
			{
				r = r > w ? w : r;
				continue;
			}

			if (w > dist[p.x, p.y, d]) continue;

			int nextx = p.x + dx[d];
			int nexty = p.y + dy[d];

			if (Create(nextx, nexty, out Pos pos))
			{
				if (T[nextx, nexty] == 3)
				{
					for (int i = 0; i < 4; i++)
					{
						if (i == (d + 2) % 4) continue;
						int nextw = i != d ? w + 1 : w;
						if (dist[nextx, nexty, i] > nextw)
						{
							PQ.Enqueue((pos, i, nextw), nextw);
							dist[nextx, nexty, i] = nextw;
						}
					}
				}
				else
				{
					if (dist[nextx, nexty, d] > w)
					{
						PQ.Enqueue((pos, d, w), w);
						dist[nextx, nexty, d] = w;
					}
				}
			}
		}

		return r;
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N, N];
		dist = new int[N, N, 4];
		for (int i = 0; i < N; i++)
		{
			string S = Console.ReadLine();
			for (int j = 0; j < N; j++)
			{
				for (int k = 0; k < 4; k++)
				{
					dist[i, j, k] = int.MaxValue;
				}
				if (S[j] == '*') T[i, j] = 1;
				else if (S[j] == '!') T[i, j] = 3;
				else
				{
					T[i, j] = 0;
					if (S[j] == '#' && PQ.Count == 0)
					{
						for (int k = 0; k < 4; k++)
						{
							PQ.Enqueue((new Pos(i, j), k, 0), 0);
							dist[i, j, k] = 0;
						}
					}
					else if (S[j] == '#') T[i, j] = 2;
				}
			}
		}

		Console.WriteLine(BFS());
	}
}