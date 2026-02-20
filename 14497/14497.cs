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

	public static bool Create(int x, int y, out Pos pos)
	{
		if (x < 0 || x >= N || y < 0 || y >= M)
		{
			pos = default;
			return false;
		}

		pos = new Pos(x, y);

		return true;
	}

	public static void BFS()
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q.x, q.y]) continue;

			//if (q.x == X && q.y == Y) return;

			for (int i = 0; i < 4; i++)
			{
				if (Create(q.x + dx[i], q.y + dy[i], out Pos pos))
				{
					if (T[pos.x, pos.y] == 1 && dist[pos.x, pos.y] > w + 1)
					{
						PQ.Enqueue((pos, w + 1), w + 1);
						dist[pos.x, pos.y] = w + 1;
					}
					if (T[pos.x, pos.y] == 0 && dist[pos.x, pos.y] > w)
					{
						PQ.Enqueue((pos, w), w);
						dist[pos.x, pos.y] = w;
					}
				}
			}
		}
	}

	public static int N, M, X, Y;
	public static int[,] T, dist;
	public static PriorityQueue<(Pos, int), int> PQ = new PriorityQueue<(Pos, int), int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		dist = new int[N, M];
		S = Console.ReadLine().Split();
		int x1 = int.Parse(S[0]) - 1;
		int y1 = int.Parse(S[1]) - 1;
		X = int.Parse(S[2]) - 1;
		Y = int.Parse(S[3]) - 1;
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				dist[i, j] = int.MaxValue;
				if (S[0][j] == '0') T[i, j] = 0;
				else T[i, j] = 1;
			}
		}
		PQ.Enqueue((new Pos(x1, y1), 0), 0);
		dist[x1, y1] = 0;

		BFS();

		Console.WriteLine(dist[X, Y]);
	}
}