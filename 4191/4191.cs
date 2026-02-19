#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M, K;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static int BFS()
	{
		int R = 0;

		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			R++;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}

		return R;
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());
		while (t-- > 0)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			M = int.Parse(S[1]);
			K = int.Parse(S[2]);
			V = new bool[N];
			L = new List<int>[N];
			Q.Clear();
			for (int i = 0; i < M; i++)
			{
				S = Console.ReadLine().Split();
				int left = int.Parse(S[0]) - 1;
				int right = int.Parse(S[1]) - 1;
				(L[left] ??= new List<int>()).Add(right);
			}
			for (int i = 0; i < K; i++)
			{
				int k = int.Parse(Console.ReadLine()) - 1;
				if (V[k]) continue;
				Q.Enqueue(k);
				V[k] = true;
			}
			sb.AppendLine(BFS().ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}