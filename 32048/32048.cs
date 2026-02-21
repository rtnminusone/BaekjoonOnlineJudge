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

	public static bool Create(int x, int y, int w, out Pos pos)
	{
		pos = default;
	
		if (x < 0 || x >= 2001 || y < 0 || y >= 2001) return false;
		if (V[x, y]) return false;

		pos = new Pos(x, y, w);

		return true;
	}

	public static void BFS()
	{
		int R = 0;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			for (int i = 0; i < N; i++)
			{
				if (T[i, 0] == p.x && T[i, 1] == p.y)
				{
					R++;
					A[i] = p.w;
					break;
				}
			}
			if (R == N) break;

			for (int i = 0; i < 6; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], p.w + 1, out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
				}
			}
		}
	}

	public static int N;
	public static int[] A;
	public static int[,] T = new int[2001, 2001];
	public static bool[,] V = new bool[2001, 2001];
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, -1, 1, 0, 1 };
	public static int[] dy = { 1, 1, 0, 0, -1, -1 };

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		A = new int[N];
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			T[i, 0] = int.Parse(S[0]) + 1000;
			T[i, 1] = int.Parse(S[1]) + 1000;
		}
		Q.Enqueue(new Pos(1000, 1000, 0));
		V[1000, 1000] = true;

		BFS();

		for (int i = 0; i < N; i++)
		{
			Console.WriteLine(A[i]);
		}
	}
}