#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public static int N, M;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static string BFS()
	{
		StringBuilder sb = new StringBuilder();
		List<int> R = new List<int>();
		int idx = 1;

		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (w < idx) R.Add(q + 1);
			else
			{
				R.Sort();
				sb.AppendLine(string.Join(" ", R));
				R.Clear();
				R.Add(q + 1);
				idx++;
			}

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}

		if (R.Count != 0)
		{
			R.Sort();
			sb.AppendLine(string.Join(" ", R));
		}

		return sb.ToString();
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]) - 1;
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				if (S[j][0] == '1')
				{
					(L[i] ??= new List<int>()).Add(j);
				}
			}
		}
		Q.Enqueue((M, 0));
		V[M] = true;

		Console.WriteLine(BFS());
	}
}