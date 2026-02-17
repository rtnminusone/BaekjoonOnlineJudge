#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

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

	public static int N;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= N) return false;
		if (V[x, y] || T[x, y] == 1) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static int BFS()
	{
		int R = 0;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			R++;

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
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
		int t = int.Parse(Console.ReadLine());
		while (t-- > 0)
		{
			N = int.Parse(Console.ReadLine());
			T = new int[N, N];
			V = new bool[N, N];
			for (int i = 0; i < N; i++)
			{
				string S = Console.ReadLine();
				for (int j = 0; j < N; j++)
				{
					if (S[j] == '#') T[i, j] = 1;
					else T[i, j] = 0;
				}
			}
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j += N - 1)
				{
					if (T[i, j] == 0 && !V[i, j])
					{
						Q.Enqueue(new Pos(i, j));
						V[i, j] = true;
					}
					if (T[j, i] == 0 && !V[j, i])
					{
						Q.Enqueue(new Pos(j, i));
						V[j, i] = true;
					}
				}
			}

			Console.WriteLine((N * N) - BFS());
		}
	}
}