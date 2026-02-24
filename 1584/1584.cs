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

	public static int[,] T = new int[501, 501], dist = new int[501, 501];
	public static PriorityQueue<(Pos, int), int> PQ = new PriorityQueue<(Pos, int), int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x > 500 || y < 0 || y > 500) return false;
		if (T[x, y] == -1) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static int Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (p, w) = PQ.Dequeue();

			if (p.x == 500 && p.y == 500) return w;

			for (int i = 0; i < 4; i++)
			{
				int nextx = p.x + dx[i];
				int nexty = p.y + dy[i];
				if (Create(nextx, nexty, out Pos pos))
				{
					int nextw = T[nextx, nexty] == 1 ? w + 1 : w;
					if (dist[nextx, nexty] > nextw)
					{
						PQ.Enqueue((pos, nextw), nextw);
						dist[nextx, nexty] = nextw;
					}
				}
			}
		}

		return -1;
	}

	public static void Main()
	{
		for (int i = 0; i <= 500; i++)
		{
			for (int j = 0; j <= 500; j++)
			{
				dist[i, j] = int.MaxValue;
			}
		}
		int n = int.Parse(Console.ReadLine());
		for (int i = 0; i < n; i++)
		{
			string[] S = Console.ReadLine().Split();
			int x1 = Math.Min(int.Parse(S[0]), int.Parse(S[2]));
			int y1 = Math.Min(int.Parse(S[1]), int.Parse(S[3]));
			int x2 = Math.Max(int.Parse(S[0]), int.Parse(S[2]));
			int y2 = Math.Max(int.Parse(S[1]), int.Parse(S[3]));
			for (int j = x1; j <= x2; j++)
			{
				for (int k = y1; k <= y2; k++)
				{
					T[j, k] = 1;
				}
			}
		}
		n = int.Parse(Console.ReadLine());
		for (int i = 0; i < n; i++)
		{
			string[] S = Console.ReadLine().Split();
			int x1 = Math.Min(int.Parse(S[0]), int.Parse(S[2]));
			int y1 = Math.Min(int.Parse(S[1]), int.Parse(S[3]));
			int x2 = Math.Max(int.Parse(S[0]), int.Parse(S[2]));
			int y2 = Math.Max(int.Parse(S[1]), int.Parse(S[3]));
			for (int j = x1; j <= x2; j++)
			{
				for (int k = y1; k <= y2; k++)
				{
					T[j, k] = -1;
				}
			}
		}

		PQ.Enqueue((new Pos(0, 0), 0), 0);
		dist[0, 0] = 0;

		Console.WriteLine(Dijkstra());
	}
}