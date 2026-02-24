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
	public static int[,] T, dist;
	public static PriorityQueue<(Pos, int), int> PQ = new PriorityQueue<(Pos, int), int>();

	public static int[] dx = { 1, 0 };
	public static int[] dy = { 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= N) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static int Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (p, w) = PQ.Dequeue();

			if (w > dist[p.x, p.y]) continue;

			if (p.x == N - 1 && p.y == N - 1) return w;

			for (int i = 0; i < 2; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					int nextw = T[p.x, p.y] > T[pos.x, pos.y] ? w : w + T[pos.x, pos.y] - T[p.x, p.y] + 1;
					if (dist[pos.x, pos.y] > nextw)
					{
						PQ.Enqueue((pos, nextw), nextw);
						dist[pos.x, pos.y] = nextw;
					}
				}
			}
		}

		return -1;
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N, N];
		dist = new int[N, N];
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				T[i, j] = int.Parse(S[j]);
				dist[i, j] = int.MaxValue;
			}
		}
		PQ.Enqueue((new Pos(0, 0), 0), 0);
		dist[0, 0] = 0;

		Console.WriteLine(Dijkstra());
	}
}