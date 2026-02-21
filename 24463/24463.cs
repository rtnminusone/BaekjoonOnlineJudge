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

	public static int N, M, X, Y, x, y;
	public static char[,] T;
	public static bool[,] V;
	public static Pos[,] P;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (T[x, y] == '+' || V[x, y]) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static void BFS()
	{
		Pos key = new Pos(0, 0);
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.x == X && p.y == Y)
			{
				key = p;
				T[p.x, p.y] = '.';
				break;
			}

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
					P[pos.x, pos.y] = p;
				}
			}
		}

		while (true)
		{
			key = P[key.x, key.y];
			T[key.x, key.y] = '.';
			if (x == key.x && y == key.y) break;
		}
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = new char[N, M];
		V = new bool[N, M];
		P = new Pos[N, M];
		bool flg = true;
		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				if (S[0][j] == '.') T[i, j] = '@';
				else T[i, j] = '+';

				if (flg && T[i, j] == '@' && (i == 0 || i == N - 1 || j == 0 || j == M - 1))
				{
					x = i;
					y = j;
					Q.Enqueue(new Pos(i, j));
					V[i, j] = true;
					flg = false;
				}
				else if (T[i, j] == '@' && (i == 0 || i == N - 1 || j == 0 || j == M - 1))
				{
					X = i;
					Y = j;
				}
			}
		}

		BFS();

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				sb.Append(T[i, j]);
			}
			sb.AppendLine();
		}

		Console.WriteLine(sb.ToString());
	}
}