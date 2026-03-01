#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, K, C;
	public static char[] T, P;
	public static bool[] V;
	public static StringBuilder sb = new StringBuilder();

	public static void DFS(int depth)
	{
		if (C == K) return;
		if (depth == N)
		{
			C++;
			if (C == K) sb.AppendLine(string.Join("", P));
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if (V[i]) continue;
			P[depth] = T[i];
			V[i] = true;
			DFS(depth + 1);
			V[i] = false;
		}
	}

	public static void Main()
	{
		string line = null;
		while ((line = Console.ReadLine()) != null)
		{
			sb.Append(line + " = ");
			string[] S = line.Split();
			N = S[0].Length;
			T = new char[N];
			P = new char[N];
			V = new bool[N];
			for (int i = 0; i < N; i++)
			{
				T[i] = S[0][i];
			}
			K = int.Parse(S[1]);

			C = 0;
			Array.Sort(T);

			DFS(0);

			if (C < K) sb.AppendLine("No permutation");
		}

		Console.WriteLine(sb.ToString());
	}
}