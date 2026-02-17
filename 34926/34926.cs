#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, K;
	public static int[] T;
	public static bool[] V;
	public static Queue<int> Q = new Queue<int>();

	public static int Create(int x)
	{
		if (x < 0 || x >= N) return -1;
		if (T[x] == 1) return -1;
		if (V[x]) return -1;

		return x;
	}

	public static bool Push(int x)
	{
		if (x == -1) return false;

		Q.Enqueue(x);
		V[x] = true;

		return true;
	}

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			if (q == N - 1) return "YES";

			Push(Create(q + 1));
			Push(Create(q + K));
		}

		return "NO";
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		T = new int[N];
		V = new bool[N];
		S[0] = Console.ReadLine();
		for (int i = 0; i < N; i++)
		{
			if (S[0][i] == '_') T[i] = 0;
			else T[i] = 1;
		}
		Push(Create(0));

		Console.WriteLine(BFS());
	}
}