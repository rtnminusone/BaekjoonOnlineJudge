#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, K;
	public static int[] T, R;
	public static StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

	public static void DFS(int depth, int start)
	{
		if (depth == K)
		{
			sw.WriteLine(string.Join(" ", R));
			return;
		}

		for (int i = 0; i < N; i++)
		{
			R[depth] = T[i];
			DFS(depth + 1, i + 1);
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		T = new int[N];
		R = new int[K];
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}
		Array.Sort(T);

		
		DFS(0, 0);

		sw.Flush();
		sw.Dispose();
	}
}