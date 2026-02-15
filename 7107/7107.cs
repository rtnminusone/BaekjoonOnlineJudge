#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

class Program
{
	public struct Pos
	{
		public int x;
		public int y;
		public int w;

		public Pos(int x, int y, int w)
		{
			this.x = x;
			this.y = y;
			this.w = w;
		}
	}

	public static bool Create(int x, int y, int w, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (V[x, y]) return false;

		pos = new Pos(x, y, w);

		return true;
	}

	public static string BFS(Pos goal)
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == goal.x && p.y == goal.y) return p.w.ToString();

			for (int i = 0; i < 8; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], p.w + 1, out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
				}
			}
		}

		return "NEVAR";
	}

	public static int N, M;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -2, -1, 1, 2, -2, -1, 1, 2 };
	public static int[] dy = { -1, -2, -2, -1, 1, 2, 2, 1 };

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[1]);
		M = int.Parse(S[0]);
		V = new bool[N, M];
		Q.Enqueue(new Pos(0, 0, 0));
		V[0, 0] = true;

		Console.WriteLine(BFS(new Pos(int.Parse(S[3]) - 1, int.Parse(S[2]) - 1, 0)));
	}
}