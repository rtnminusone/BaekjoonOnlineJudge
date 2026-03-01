#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, K, R = int.MinValue;
	public static int[] T, P;
	public static bool[] V;

	public static void DFS(int depth)
	{
		if (depth == N)
		{
			int r = int.Parse(string.Join("", P));
			if (r < K && R < r) R = r;
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if (V[i]) continue;
			if (depth == 0 && T[i] == 0) continue;
			V[i] = true;
			P[depth] = T[i];
			DFS(depth + 1);
			V[i] = false;
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		T = new int[S[0].Length];
		for (int i = 0; i < S[0].Length; i++)
		{
			T[i] = S[0][i] - '0';
		}
		N = S[0].Length;
		P = new int[N];
		V = new bool[N];

		DFS(0);

		Console.WriteLine(R == int.MinValue ? -1 : R);
	}
}