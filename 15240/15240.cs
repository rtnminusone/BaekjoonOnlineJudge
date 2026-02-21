#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

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

	public static int N, M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, int t, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (T[x, y] != t || V[x, y]) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static void BFS(int before, int after)
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			T[p.x, p.y] = after;

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], before, out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
				}
			}
		}
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new int[N, M];
		V = new bool[N, M];
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				T[i, j] = S[0][j] - '0';
			}
		}
		S = Console.ReadLine().Split();
		int x = int.Parse(S[0]);
		int y = int.Parse(S[1]);
		Q.Enqueue(new Pos(x, y));
		V[x, y] = true;

		BFS(T[x, y], int.Parse(S[2]));

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				sb.Append(T[i, j].ToString());
			}
			sb.AppendLine();
		}

		Console.WriteLine(sb.ToString());
	}
}