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

		pos = new Pos(x, y, w);

		return true;
	}

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == N - 1 && p.y == M - 1) return p.w;

			for (int i = T[p.x, p.y]; i > 0; i--)
			{
				if (Create(p.x + i, p.y, p.w + 1, out Pos pos1))
				{
					Q.Enqueue(pos1);
					V[pos1.x, pos1.y] = true;
				}
				if (Create(p.x, p.y + i, p.w + 1, out Pos pos2))
				{
					Q.Enqueue(pos2);
					V[pos2.x, pos2.y] = true;
				}
			}
		}

		return -1;
	}

	public static int N, M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

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
		Q.Enqueue(new Pos(0, 0, 0));
		V[0, 0] = true;

		Console.WriteLine(BFS());
	}
}