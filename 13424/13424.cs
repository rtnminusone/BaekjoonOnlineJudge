#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K;
	public static int[] dist, R;
	public static bool[] flg;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static void BFS()
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (L[q] == null) continue;
			foreach (var (nextq, nextw) in L[q])
			{
				if (dist[nextq] > w + nextw)
				{
					PQ.Enqueue((nextq, w + nextw), nextw);
					dist[nextq] = w + nextw;
				}
			}
		}
	}

	public static void Main()
	{
		int t = int.Parse(Console.ReadLine());
		while (t-- > 0)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			M = int.Parse(S[1]);
			dist = new int[N];
			R = new int[N];
			flg = new bool[N];
			L = new List<(int, int)>[N];
			for (int i = 0; i < M; i++)
			{
				S = Console.ReadLine().Split();
				int left = int.Parse(S[0]) - 1;
				int right = int.Parse(S[1]) - 1;
				int w = int.Parse(S[2]);
				(L[left] ??= new List<(int, int)>()).Add((right, w));
				(L[right] ??= new List<(int, int)>()).Add((left, w));
			}
			K = int.Parse(Console.ReadLine());
			S = Console.ReadLine().Split();
			for (int i = 0; i < K; i++)
			{
				int k = int.Parse(S[i]) - 1;
				PQ.Clear();
				PQ.Enqueue((k, 0), 0);
				Array.Fill(dist, int.MaxValue);
				dist[k] = 0;
				BFS();
				for (int j = 0; j < N; j++)
				{
					if (!flg[j])
					{
						if (dist[j] == int.MaxValue)
						{
							flg[j] = true;
							continue;
						}
						R[j] += dist[j];
					}
				}
			}
			int r = -1;
			int val = int.MaxValue;
			for (int i = 0; i < N; i++)
			{
				if (flg[i]) continue;
				if (val > R[i])
				{
					val = R[i];
					r = i + 1;
				}
			}

			Console.WriteLine(r);
		}
	}
}