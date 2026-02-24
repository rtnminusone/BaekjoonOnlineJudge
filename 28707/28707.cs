#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static int[] T;
	public static string A;
	public static List<(int, int, int)> L = new List<(int, int, int)>();
	public static Dictionary<string, int> D = new Dictionary<string, int>();
	public static PriorityQueue<(int[], int), int> PQ = new PriorityQueue<(int[], int), int>();

	public static void BFS()
	{
		while (PQ.Count > 0)
		{
			var (t, w) = PQ.Dequeue();

			string s = string.Join(" ", t);
			if (D.ContainsKey(s) && w > D[s]) continue;

			foreach (var (i, j, nextw) in L)
			{
				int[] nextt = (int[])t.Clone();
				int tmp = nextt[i];
				nextt[i] = nextt[j];
				nextt[j] = tmp;
				string nexts = string.Join(" ", nextt);
				if (!D.ContainsKey(nexts) || D[nexts] > w + nextw)
				{
					PQ.Enqueue((nextt, w + nextw), w + nextw);
					D[nexts] = w + nextw;
				}
			}
		}
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N];
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}
		M = int.Parse(Console.ReadLine());
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			int w = int.Parse(S[2]);
			L.Add((left, right, w));
		}
		PQ.Enqueue(((int[])T.Clone(), 0), 0);
		D[string.Join(" ", T)] = 0;
		Array.Sort(T);
		A = string.Join(" ", T);
		BFS();

		if (D.ContainsKey(A)) Console.WriteLine(D[A]);
		else Console.WriteLine(-1);
	}
}