#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

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

	public static bool Create(int x, int y, int key, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (V[x, y]) return false;
		if (T[x, y] != key) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static bool BFS()
	{
		int R = 0;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			R++;

			for (int i = 0; i < 8; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], T[p.x, p.y], out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
				}
			}
		}

		return R >= P;
	}

	public static int N, M, K, P;
	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();
	public static Dictionary<string, int> D = new Dictionary<string, int>();

	public static int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
	public static int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		StringBuilder tmp = new StringBuilder();

		while (true)
		{
			D.Clear();
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			M = int.Parse(S[1]);
			K = int.Parse(S[2]);
			P = int.Parse(S[3]);
			if (N == 0 && M == 0 && K == 0 && P == 0) break;
			T = new int[N, M];
			V = new bool[N, M];
			int key = 0;
			for (int i = 0; i < N; i++)
			{
				S = Console.ReadLine().Split();
				for (int j = 0; j < M * 3; j += 3)
				{
					tmp.Clear();
					for (int k = 0; k < 3; k++)
					{
						tmp.Append((int.Parse(S[j + k]) / K) + " ");
					}
					string s = tmp.ToString();
					if (D.ContainsKey(s)) T[i, j / 3] = D[s];
					else
					{
						T[i, j / 3] = key;
						D[s] = key++;
					}
				}
			}
			int R = 0;
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					if (!V[i, j])
					{
						Q.Enqueue(new Pos(i, j));
						V[i, j] = true;
						if (BFS()) R++;
					}
				}
			}
			sb.AppendLine(R.ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}