#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, K, R = int.MaxValue;
	public static int[] T;
	public static int[] A;
	public static bool[] V;

	public static void DFS(int depth)
	{
		if (depth == K)
		{
			int cur = int.Parse(string.Join("", A));
			if (cur > N && R > cur) R = cur;
			return;
		}

		for (int i = 0; i < K; i++)
		{
			if (V[i]) continue;
			if (depth == 0 && T[i] == 0) continue;
			V[i] = true;
			A[depth] = T[i];
			DFS(depth + 1);
			V[i] = false;
		}
	}

	public static void Main()
	{
		string S = Console.ReadLine();
		N = int.Parse(S);
		K = S.Length;
		A = new int[K];
		T = new int[K];
		V = new bool[K];
		for (int i = 0; i < K; i++)
		{
			T[i] = S[i] - '0';
		}

		DFS(0);

		Console.WriteLine(R == int.MaxValue ? 0 : R);
	}
}