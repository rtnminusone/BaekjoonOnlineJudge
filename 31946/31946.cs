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

	public static int N, M, X;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static bool Create(int x, int y, int t, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (t != T[x, y]) return false;
		if (V[x, y]) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == N - 1 && p.y == M - 1) return "ALIVE";

			for (int dx = -X; dx <= X; dx++)
			{
				int m = X - Math.Abs(dx);
				for (int dy = -m; dy <= m; dy++)
				{
					if (Create(p.x + dx, p.y + dy, T[p.x, p.y], out Pos pos))
					{
						Q.Enqueue(pos);
						V[pos.x, pos.y] = true;
					}
				}
			}
		}

		return "DEAD";
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		M = int.Parse(Console.ReadLine());
		T = new int[N, M];
		V = new bool[N, M];
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}
		X = int.Parse(Console.ReadLine());

		Q.Enqueue(new Pos(0, 0));
		V[0, 0] = true;

		Console.WriteLine(BFS());
	}
}