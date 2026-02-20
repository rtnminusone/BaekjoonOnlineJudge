#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();
	public static Dictionary<int, int> D = new Dictionary<int, int>();

	public static string BFS()
	{
		D.Clear();
		Q.Clear();
		for (int i = 0; i < N; i++)
		{
			if (!D.ContainsKey(i))
			{
				Q.Enqueue(i);
				D[i] = 0;

				while (Q.Count > 0)
				{
					int q = Q.Dequeue();

					if (L[q] == null) continue;
					foreach (int l in L[q])
					{
						if (!D.ContainsKey(l))
						{
							Q.Enqueue(l);
							D[l] = 1 - D[q];
						}
						else if (D[l] == D[q]) return "impossible";
					}
				}
			}
		}

		return "possible";
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
			L = new List<int>[N];
			for (int i = 0; i < M; i++)
			{
				S = Console.ReadLine().Split();
				int left = int.Parse(S[0]) - 1;
				int right = int.Parse(S[1]) - 1;
				(L[left] ??= new List<int>()).Add(right);
				(L[right] ??= new List<int>()).Add(left);
			}
			sb.AppendLine(BFS());
		}

		Console.WriteLine(sb.ToString());
	}
}