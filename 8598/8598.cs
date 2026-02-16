#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

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
		if (T[x, y] == 1) return false;

		pos = new Pos(x, y, w);

		return true;
	}

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == 2) return p.w.ToString();

			for (int i = 0; i < 8; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], p.w + 1, out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
				}
			}
		}

		return "NIE";
	}

	public static int N, M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -2, -1, 1, 2, -2, -1, 1, 2 };
	public static int[] dy = { -1, -2, -2, -1, 1, 2, 2, 1 };

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[N, M];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				if (S[0][j] == 'x') T[i, j] = 1;
				else if (S[0][j] == 'n') T[i, j] = 2;
				else
				{
					T[i, j] = 0;
					if (S[0][j] == 'z')
					{
						Q.Enqueue(new Pos(i, j, 0));
						V[i, j] = true;
					}
				}
			}
		}

		Console.WriteLine(BFS());
	}
}