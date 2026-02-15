#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

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

	public static bool Create(int x, int y, out Pos p)
	{
		if (x < 0 || x >= N || y < 0 || y >= M || T[x, y] == 0 || V[x, y])
		{
			p = default;
			return false;
		}

		p = new Pos(x, y);
		return true;
	}

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			for (int i = 0; i < 8; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos next))
				{
					Q.Enqueue(next);
					V[next.x, next.y] = true;
				}
			}
		}
	}

	public static int N, M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0, -1, -1, 1, 1 };
	public static int[] dy = { 0, -1, 0, 1, -1, 1, -1, 1 };

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
		int R = 0;
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				if (T[i, j] != 0 && !V[i, j])
				{
					Q.Enqueue(new Pos(i, j));
					BFS();
					R++;
				}
			}
		}

		Console.WriteLine(R);
	}
}