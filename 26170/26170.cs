#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

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

	public static int[,] T = new int[5, 5];
	public static bool[,] V = new bool[5, 5];
	public static List<int> R = new List<int>();

	public static int[] dx = { -1, 0, 1, 0 };
	public static int[] dy = { 0, -1, 0, 1 }; 

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;

		if (x < 0 || x >= 5 || y < 0 || y >= 5) return false;
		if (T[x, y] == -1 || V[x, y]) return false;

		pos = new Pos(x, y);

		return true;
	}

	public static void DFS(int depth, Pos p, int cur)
	{
		if (cur == 3)
		{
			R.Add(depth);
			return;
		}

		for (int i = 0; i < 4; i++)
		{
			if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
			{
				V[pos.x, pos.y] = true;
				DFS(depth + 1, pos, cur + T[pos.x, pos.y]);
				V[pos.x, pos.y] = false;
			}
		}
	}

	public static void Main()
	{
		string[] S = null;
		for (int i = 0; i < 5; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < 5; j++)
			{
				T[i, j] = int.Parse(S[j]);
			}
		}
		S = Console.ReadLine().Split();
		int x = int.Parse(S[0]);
		int y = int.Parse(S[1]);

		V[x, y] = true;
		DFS(0, new Pos(x, y), T[x, y]);

		R.Sort();

		Console.WriteLine(R.Count == 0 ? -1 : R[0]);
	}
}