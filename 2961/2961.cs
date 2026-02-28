#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, R = int.MaxValue;
	public static int[] T1, T2;

	public static void DFS(int depth, int t1, int t2, int choice)
	{
		if (depth == N)
		{
			if (R > Math.Abs(t1 - t2) && choice != 0) R = Math.Abs(t1 - t2);
			return;
		}

		DFS(depth + 1, t1 * T1[depth], t2 + T2[depth], choice + 1);
		DFS(depth + 1, t1, t2, choice);
	}

	public static void Main()
	{
		string[] S = null;
		N = int.Parse(Console.ReadLine());
		T1 = new int[N];
		T2 = new int[N];
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			T1[i] = int.Parse(S[0]);
			T2[i] = int.Parse(S[1]);
		}

		DFS(0, 1, 0, 0);

		Console.WriteLine(R);
	}
}