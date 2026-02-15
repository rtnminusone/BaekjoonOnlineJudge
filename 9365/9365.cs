#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

using System.Text;

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

	public static int N, M, X, Y;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, int height, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (T[x, y] < height) return false;
		if (V[x, y]) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static int BFS()
	{
		int R = 0;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == 0 || p.x == N - 1 || p.y == 0 || p.y == M - 1) R++;

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], T[p.x, p.y], out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
				}
			}
		}

		return R;
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());

		for (int p = 1; p <= t; p++)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			M = int.Parse(S[1]);
			T = new int[N, M];
			V = new bool[N, M];
			S = Console.ReadLine().Split();
			X = int.Parse(S[0]) - 1;
			Y = int.Parse(S[1]) - 1;
			for (int i = 0; i < N; i++)
			{
				S = Console.ReadLine().Split();
				for (int j = 0; j < M; j++)
				{
					T[i, j] = int.Parse(S[j]);
				}
			}
			Q.Clear();
			Q.Enqueue(new Pos(X, Y));
			V[X, Y] = true;

			sb.AppendLine("Case #" + p + ": " + BFS());
		}

		Console.WriteLine(sb.ToString());
	}
}