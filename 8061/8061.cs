#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

using System.Text;

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

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			T[p.x, p.y] = p.w;

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], p.w + 1, out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
				}
			}
		}
	}

	public static int N, M;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

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
				if (S[0][j] == '1')
				{
					Q.Enqueue(new Pos(i, j, 0));
					V[i, j] = true;
				}
			}
		}
		BFS();
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				sb.Append(T[i, j] + " ");
			}
			sb.AppendLine();
		}

		Console.WriteLine(sb.ToString());
	}
}