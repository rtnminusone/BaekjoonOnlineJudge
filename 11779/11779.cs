#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static int[] dist;
	public static List<(int, int)>[] L;
	public static Dictionary<int, int> D = new Dictionary<int, int>();
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
					PQ.Enqueue((nextq, w + nextw), w + nextw);
					dist[nextq] = w + nextw;
					D[nextq] = q;
				}
			}
		}
	}

	public static void Main()
	{
		string[] S = null;
		int left, right;
		N = int.Parse(Console.ReadLine());
		M = int.Parse(Console.ReadLine());
		dist = new int[N];
		Array.Fill(dist, int.MaxValue);
		L = new List<(int, int)>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			left = int.Parse(S[0]) - 1;
			right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			(L[left] ??= new List<(int, int)>()).Add((right, w));
		}
		S = Console.ReadLine().Split();
		left = int.Parse(S[0]) - 1;
		right = int.Parse(S[1]) - 1;

		PQ.Enqueue((left, 0), 0);
		dist[left] = 0;

		BFS();

		Console.WriteLine(dist[right]);

		List<int> A = new List<int>();
		A.Add(right + 1);
		while (D.ContainsKey(right))
		{
			right = D[right];
			A.Add(right + 1);
		}
		A.Reverse();

		Console.WriteLine(A.Count);
		Console.WriteLine(string.Join(" ", A));
	}
}