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
		if (T[x, y] == 0 || T[x, y] == 2) return false;

		pos = new Pos(x, y, w);

		return true;
	}

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == 4) return p.w;

			for (int i = 0; i < 8; i++)
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

	public static void CalDxDy()
	{
		dx = new int[8];
		dy = new int[8];

		dx[0] = -1 * M1;
		dy[0] = -1 * M2;
		dx[1] = -1 * M2;
		dy[1] = -1 * M1;
		dx[2] = -1 * M1; 
		dy[2] = 1 * M2;
		dx[3] = -1 * M2;
		dy[3] = 1 * M1;
		dx[4] = 1 * M1;
		dy[4] = -1 * M2;
		dx[5] = 1 * M2;
		dy[5] = -1 * M1;
		dx[6] = 1 * M1;
		dy[6] = 1 * M2;
		dx[7] = 1 * M2;
		dy[7] = 1 * M1;
	}

	public static int N, M, M1, M2;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx;
	public static int[] dy;

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		M1 = int.Parse(S[2]);
		M2 = int.Parse(S[3]);
		T = new int[N, M];
		V = new bool[N, M];
		CalDxDy();
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
				if (T[i, j] == 3)
				{
					Q.Enqueue(new Pos(i, j, 0));
					V[i, j] = true;
				}
			}
		}

		Console.WriteLine(BFS());
	}
}