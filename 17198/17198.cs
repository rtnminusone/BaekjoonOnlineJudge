#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Reflection.Emit;

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

		if (x < 0 || x >= 10 || y < 0 || y >= 10) return false;
		if (V[x, y] || T[x, y] == 1) return false;

		pos = new Pos(x, y, w);

		return true;
	}

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (T[p.x, p.y] == 2) return p.w - 1;

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], p.w + 1, out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y] = true;
				}
			}
		}

		return -1;
	}

	public static int[,] T;
	public static bool[,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 };

	public static void Main()
	{
		T = new int[10, 10];
		V = new bool[10, 10];

		for (int i = 0; i < 10; i++)
		{
			string S = Console.ReadLine();
			for (int j = 0; j < 10; j++)
			{
				if (S[j] == 'B') T[i, j] = 2;
				else if (S[j] == 'R') T[i, j] = 1;
				else
				{
					T[i, j] = 0;
					if (S[j] == 'L')
					{
						Q.Enqueue(new Pos(i, j, 0));
						V[i, j] = true;
					}
				}
			}
		}

		Console.WriteLine(BFS());
	}
}