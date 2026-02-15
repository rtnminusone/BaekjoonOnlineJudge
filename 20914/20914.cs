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
		if (x < 0 || x >= 3 || y < 0 || y >= 10 || T[x, y] == ' ' || V[T[x, y] - 'A'])
		{
			pos = default;
			return false;
		}

		pos = new Pos(x, y, w);
		return true;
	}

	public static int BFS(string s)
	{
		int idx = 0;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (s[idx] == T[p.x, p.y])
			{
				if (++idx == s.Length) return p.w + 1;
				Q.Clear();
				V = new bool[ALP];
				Q.Enqueue(new Pos(p.x, p.y, p.w + 1));
				V[T[p.x, p.y] - 'A'] = true;
				continue;
			}

			for (int i = 0; i < 6; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], p.w + 2, out Pos pos))
				{
					Q.Enqueue(pos);
					V[T[pos.x, pos.y] - 'A'] = true;
				}
			}
		}

		return -1;
	}

	public static int ALP = 'Z' - 'A' + 1;
	public static char[,] T = {
		{'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'},
		{'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', ' '},
		{'Z', 'X', 'C', 'V', 'B', 'N', 'M', ' ', ' ', ' '}
	};
	public static int[] K;
	public static bool[] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, -1, 0, 0, 1, 1 };
	public static int[] dy = { 0, 1, -1, 1, -1, 0 };

	public static void Main()
	{
		int num = int.Parse(Console.ReadLine());
		K = new int[num];
		for (int t = 0; t < num; t++)
		{
			string S = Console.ReadLine();
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					if (T[i, j] == S[0])
					{
						Q.Clear();
						V = new bool[ALP];
						Q.Enqueue(new Pos(i, j, 0));
						V[T[i, j] - 'A'] = true;
						K[t] = BFS(S);
						break;
					}
				}
			}
		}

		Console.WriteLine(string.Join("\n", K));
	}
}