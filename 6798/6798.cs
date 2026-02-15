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

	public static bool Create(int x, int y, int w, out Pos p)
	{
		if (x < 0 || x >= N || y < 0 || y >= N || V[x, y])
		{
			p = default;
			return false;
		}

		p = new Pos(x, y, w);

		return true;
	}

	public static int BFS(Pos goal)
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == goal.x && p.y == goal.y) return p.w;

			for (int i = 0; i < 8; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], p.w + 1, out Pos next))
				{
					Q.Enqueue(next);
					V[next.x, next.y] = true;
				}
			}
		}

		return -1;
	}

	public static int N = 8;
	public static bool[,] V = new bool[N, N];
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -2, -1, 1, 2, -2, -1, 1, 2 };
	public static int[] dy = { -1, -2, -2, -1, 1, 2, 2, 1 };

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		int a = int.Parse(S[0]) - 1;
		int b = int.Parse(S[1]) - 1;

		Q.Enqueue(new Pos(a, b, 0));
		V[a, b] = true;

		S = Console.ReadLine().Split();
		a = int.Parse(S[0]) - 1;
		b = int.Parse(S[1]) - 1;

		Console.WriteLine(BFS(new Pos(a, b, 0)));
	}
}