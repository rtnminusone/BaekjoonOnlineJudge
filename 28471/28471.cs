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

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= N) return false;
		if (V[x, y]) return false;
		if (T[x, y] == 1) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static int BFS()
	{
		int R = -1;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			R++;

			for (int i = 0; i < 7; i++)
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

	public static int N;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 1 };

	public static void Main()
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
				else
				{
					T[i, j] = 0;
					if (S[j] == 'F')
					{
						Q.Enqueue(new Pos(i, j));
						V[i, j] = true;
					}
				}
			}
		}

		Console.WriteLine(BFS());
	}
}