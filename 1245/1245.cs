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

	public static int N, M, R = 0;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static void BFS()
	{
		bool isTop = true;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			for (int i = 0; i < 8; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					if (T[p.x, p.y] == T[pos.x, pos.y] && !V[pos.x, pos.y])
					{
						Q.Enqueue(pos);
						V[pos.x, pos.y] = true;
					}
					else if (T[p.x, p.y] < T[pos.x, pos.y]) isTop = false;
				}
			}
		}

		if (isTop) R++;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[N, M];
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (!V[i, j])
				{
					Q.Enqueue(new Pos(i, j));
					V[i, j] = true;

					BFS();
				}
			}
		}

		Console.WriteLine(R);
	}
}