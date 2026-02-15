#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

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
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();
	public static Dictionary<int, Pos> D = new Dictionary<int, Pos>();

	public static int BFS()
	{
		int minX = int.MaxValue;
		int minY = int.MaxValue;
		int maxX = int.MinValue;
		int maxY = int.MinValue;

		while (Q.Count > 0)
		{
			int q = Q.Dequeue();
			Pos p = D[q];

			if (p.x < minX) minX = p.x;
			if (p.y < minY) minY = p.y;
			if (p.x > maxX) maxX = p.x;
			if (p.y > maxY) maxY = p.y;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}

		return ((maxX - minX) * 2 + (maxY - minY) * 2);
	}

	public static void Main(string[] args)
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			D[i] = new Pos(int.Parse(S[0]), int.Parse(S[1]));
		}
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			if (L[left] == null) L[left] = new List<int>();
			L[left].Add(right);
			if (L[right] == null) L[right] = new List<int>();
			L[right].Add(left);
		}
		int R = int.MaxValue;
		for (int i = 0; i < N; i++)
		{
			if (V[i]) continue;
			Q.Enqueue(i);
			V[i] = true;
			int r = BFS();
			if (r < R) R = r;
		}

		Console.WriteLine(R);
	}
}