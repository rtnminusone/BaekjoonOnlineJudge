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

	public static int N, M, R;
	public static char[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, int w, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (T[x, y] == '#' || V[x, y]) return false;

		pos = new Pos(x, y, w);

		return true;
	}

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.y == M - 1) return R - p.w;

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], p.w + 1, out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
				}
			}
		}

		return -1;
	}

	public static void Main()
	{
		N = 2;
		R = 0;
		M = int.Parse(Console.ReadLine());
		T = new char[N, M];
		V = new bool[N, M];
		for (int i = 0; i < N; i++)
		{
			string S = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = S[j];
				if (S[j] == '.') R++;
			}
		}
		for (int i = 0; i < 2; i++)
		{
			if (T[i, 0] == '.')
			{
				Q.Enqueue(new Pos(i, 0, 1));
				V[i, 0] = true;
			}
		}

		Console.WriteLine(BFS());
	}
}