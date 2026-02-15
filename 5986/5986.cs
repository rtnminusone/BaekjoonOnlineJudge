#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

class Program
{
	public struct Pos
	{
		public int x;
		public int y;
		public int z;

		public Pos(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}

	public static bool Create(int x, int y, int z, out Pos pos)
	{
		if (x < 0 || x >= N || y < 0 || y >= N || z < 0 || z >= N || T[x, y, z] == 0 || V[x, y, z])
		{
			pos = default;
			return false;
		}

		pos = new Pos(x, y, z);
		return true;
	}

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			for (int i = 0; i < 6; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], p.z + dz[i], out Pos pos))
				{
					Q.Enqueue(pos);
					V[pos.x, pos.y, pos.z] = true;
				}
			}
		}
	}

	public static int N;
	public static int[,,] T;
	public static bool[,,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int[] dx = { -1, 0, 1, 0, 0, 0 };
	public static int[] dy = { 0, -1, 0, 1, 0, 0 };
	public static int[] dz = { 0, 0, 0, 0, -1, 1 };

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N, N, N];
		V = new bool[N, N, N];
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				string S = Console.ReadLine();
				for (int k = 0; k < N; k++)
				{
					if (S[k] == '*') T[i, j, k] = 1;
					else T[i, j, k] = 0;
				}
			}
		}
		int R = 0;
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				for (int k = 0; k < N; k++)
				{
					if (T[i, j, k] == 1 && !V[i, j, k])
					{
						Q.Enqueue(new Pos(i, j, k));
						V[i, j, k] = true;
						BFS();
						R++;
					}
				}
			}
		}

		Console.WriteLine(R);
	}
}