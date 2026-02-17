#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public class Pos
	{
		public int x;
		public int y;

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static Pos Create(int x, int y)
	{
		if (x < 0 || x >= N || y < 0 || y >= M) return null;
		if (T[x, y] != 'T') return null;
		if (V[x, y]) return null;

		return new Pos(x, y);
	}

	public static bool Push(Pos pos)
	{
		if (pos == null) return false;

		Q.Enqueue(pos);
		V[pos.x, pos.y] = true;

		return true;
	}

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			T[p.x, p.y] = 'S';

			for (int i = 0; i < 4; i++)
			{
				Push(Create(p.x + dx[i], p.y + dy[i]));
			}
		}
	}

	public static int N, M;
	public static char[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q;

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();

		while (true)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[1]);
			M = int.Parse(S[0]);
			if (N == 0 && M == 0) break;
			T = new char[N, M];
			V = new bool[N, M];
			Q = new Queue<Pos>();
			for (int i = 0; i < N; i++)
			{
				S[0] = Console.ReadLine();
				for (int j = 0; j < M; j++)
				{
					T[i, j] = S[0][j];
				}
			}
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					if (T[i, j] == 'S')
					{
						Push(new Pos(i, j));
						BFS();
					}
				}
			}
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					sb.Append(T[i, j].ToString());
				}
				sb.AppendLine();
			}
		}

		Console.WriteLine(sb.ToString());
	}
}