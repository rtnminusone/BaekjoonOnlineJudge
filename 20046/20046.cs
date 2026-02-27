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
	public static int[,] T, dist;
	public static PriorityQueue<(Pos, int), int> PQ = new PriorityQueue<(Pos, int), int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (T[x, y] == -1) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static int Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (p, w) = PQ.Dequeue();

			if (w > dist[p.x, p.y]) continue;

			for (int i = 0; i < 4; i++)
			{
				int nextx = p.x + dx[i];
				int nexty = p.y + dy[i];
				if (Create(nextx, nexty, out Pos pos))
				{
					int nextw = w + T[pos.x, pos.y];
					if (dist[nextx, nexty] > nextw)
					{
						PQ.Enqueue((pos, nextw), nextw);
						dist[nextx, nexty] = nextw;
					}
				}
			}
		}

		return dist[N - 1, M - 1] == int.MaxValue ? -1 : dist[N - 1, M - 1];
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
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
				dist[i, j] = int.MaxValue;
			}
		}
		if (T[0, 0] == -1)
		{
			Console.WriteLine(-1);
			Environment.Exit(0);
		}
		PQ.Enqueue((new Pos(0, 0), T[0, 0]), T[0, 0]);
		dist[0, 0] = T[0, 0];

		Console.WriteLine(Dijkstra());
	}
}