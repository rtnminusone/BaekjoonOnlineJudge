#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public struct Pos
	{
		public int x;
		public int y;
		public int z;
		public int w;

		public Pos(int x, int y, int z, int w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
	}

	public static int N;
	public static int[] T;
	public static bool[,,] V;
	public static Queue<Pos> Q = new Queue<Pos>();

	public static int BFS()
	{
		int r = 0;

		while (Q.Count > 0)
		{
			Pos p = Q.Dequeue();

			if (p.w > r) r = p.w;
			if (r == N) break;

			int nextz = (p.z + 1) % 3;

			if (p.x < p.y && T[p.x] == nextz && !V[p.x + 1, p.y, nextz])
			{
				Q.Enqueue(new Pos(p.x + 1, p.y, nextz, p.w + 1));
				V[p.x + 1, p.y, nextz] = true;
			}
			if (p.x < p.y && T[p.y] == nextz && !V[p.x, p.y - 1, nextz])
			{
				Q.Enqueue(new Pos(p.x, p.y - 1, nextz, p.w + 1));
				V[p.x, p.y - 1, nextz] = true;
			}
			if (p.x == p.y && T[p.x] == nextz) Q.Enqueue(new Pos(p.x, p.y, 0, p.w + 1));
		}

		return r;
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine()) * 3;
		T = new int[N];
		V = new bool[N, N, 3];
		string S = Console.ReadLine();
		for (int i = 0; i < N; i++)
		{
			if (S[i] == 'B') T[i] = 0;
			else if (S[i] == 'L') T[i] = 1;
			else T[i] = 2;
		}

		Q.Enqueue(new Pos(0, N - 1, 2, 0));
		V[0, N - 1, 2] = true;

		Console.WriteLine(BFS());
	}
}