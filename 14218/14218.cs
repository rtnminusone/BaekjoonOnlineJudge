#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M, K;
	public static int[] T;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			T[q] = w;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}

		return string.Join(" ", T);
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		string line = Console.ReadLine().Trim();
		string[] S = line.Split();
		N = int.Parse(S[0].Trim());
		M = int.Parse(S[1].Trim());
		L = new List<int>[N];
		for (int i = 0; i < M; i++)
		{
			line = Console.ReadLine().Trim();
			S = line.Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			(L[left] ??= new List<int>()).Add(right);
			(L[right] ??= new List<int>()).Add(left);
		}

		K = int.Parse(Console.ReadLine().Trim());
		for (int i = 0; i < K; i++)
		{
			line = Console.ReadLine().Trim();
			S = line.Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			(L[left] ??= new List<int>()).Add(right);
			(L[right] ??= new List<int>()).Add(left);
			Q.Clear();
			T = new int[N];
			Array.Fill(T, -1);
			V = new bool[N];
			Q.Enqueue((0, 0));
			V[0] = true;

			sb.AppendLine(BFS());
		}

		Console.WriteLine(sb.ToString());
	}
}