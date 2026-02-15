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

	public static bool Create(int x, int y, int w, int direction, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M || T[x, y] == 1 || V[x, y]) return false;
		if (T[x, y] != 0 && T[x, y] != direction) return false;
		if (w > K) return false;

		pos = new Pos(x, y, w);
		return true;
	}

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == 0 || p.x == N - 1 || p.y == 0 || p.y == M - 1) return p.w.ToString();

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], p.w + 1, i + 2, out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
				}
			}
		}

		return "NOT POSSIBLE";
	}

	public static int N, M, K;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		K = int.Parse(S[0]);
		N = int.Parse(S[1]);
		M = int.Parse(S[2]);
		T = new int[N, M];
		V = new bool[N, M];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				if (S[0][j] == '1') T[i, j] = 1;
				else if (S[0][j] == 'D') T[i, j] = 2;
				else if (S[0][j] == 'R') T[i, j] = 3;
				else if (S[0][j] == 'U') T[i, j] = 4;
				else if (S[0][j] == 'L') T[i, j] = 5;
				else
				{
					T[i, j] = 0;
					if (S[0][j] == 'S')
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