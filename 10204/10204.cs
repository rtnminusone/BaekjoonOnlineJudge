#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M;
	public static int[] dist;
	public static List<int>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static int BFS()
	{
		int R = 0;

		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (dist[l] > w + 1)
				{
					PQ.Enqueue((l, w + 1), w + 1);
					dist[l] = w + 1;
				}
			}
		}

		for (int i = 0; i < N; i++)
		{
			if (dist[i] <= 2) R++;
		}

		return R - 1;
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
			dist = new int[N];
			Array.Fill(dist, int.MaxValue);
			L = new List<int>[N];
			for (int i = 2; i < M * 2 + 2; i += 2)
			{
				int left = int.Parse(S[i].Substring(1)) - 1;
				int right = int.Parse(S[i + 1].Substring(1)) - 1;
				(L[left] ??= new List<int>()).Add(right);
				(L[right] ??= new List<int>()).Add(left);
			}
			int v = int.Parse(S[M * 2 + 2].Substring(1)) - 1;
			PQ.Clear();
			PQ.Enqueue((v, 0), 0);
			dist[v] = 0;

			sb.AppendLine("The number of supervillains in 2-hop neighborhood of v" + (v + 1) + " is " + BFS());
		}

		Console.WriteLine(sb.ToString());
	}
}