#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M;
	public static int[] T;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static string BFS()
	{
		Q.Clear();
		T = new int[N];
		V = new bool[N];

		for (int i = 0; i < N; i++)
		{
			if (!V[i])
			{
				Q.Enqueue(i);
				T[i] = 1;
				V[i] = true;

				while (Q.Count > 0)
				{
					int q = Q.Dequeue();

					if (L[q] == null) continue;
					foreach (int l in L[q])
					{
						if (V[l])
						{
							if (T[l] != 3 - T[q]) return "NO";
						}
						else
						{
							Q.Enqueue(l);
							T[l] = 3 - T[q];
							V[l] = true;
						}
					}
				}
			}
		}

		return "YES";
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