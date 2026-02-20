#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

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
		if (T[x, y] == 1 || V[x, y]) return false;

		pos = new Pos(x, y, w);

		return true;
	}

	public static int BFS()
	{
		int R = int.MinValue;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.w > R) R = p.w;

			for (int i = 0; i < 8; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], p.w + 1, out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
				}
			}
		}

		return R;
	}

	public static int N, M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[1]);
		M = int.Parse(S[0]);
		int x = int.Parse(S[3]) - 1;
		int y = int.Parse(S[2]) - 1;
		T = new int[N, M];
		V = new bool[N, M];
		for (int i = N - 1; i >= 0; i--)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				if (S[0][j] == '*') T[i, j] = 1;
				else T[i, j] = 0;
			}
		}
		Q.Enqueue(new Pos(x, y, 0));
		V[x, y] = true;

		Console.WriteLine(BFS());
	}
}