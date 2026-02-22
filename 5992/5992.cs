#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static int BFS()
	{
		int R = int.MinValue;

		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (w > R) R = w;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}

		return R;
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine()) - 1;
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right1 = int.Parse(S[1]) - 1;
			int right2 = int.Parse(S[2]) - 1;
			if (right1 != -1) (L[left] ??= new List<int>()).Add(right1);
			if (right2 != -1) (L[left] ??= new List<int>()).Add(right2);
		}
		Q.Enqueue((0, 0));
		V[0] = true;

		Console.WriteLine(BFS() + 1);
	}
}