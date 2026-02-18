#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N;
	public static Queue<(string, int)> Q = new Queue<(string, int)>();
	public static Dictionary<string, bool> V = new Dictionary<string, bool>();
	public static Dictionary<string, List<string>> D = new Dictionary<string, List<string>>();

	public static string BFS()
	{
		bool f = false;
		string goal = "";

		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (!f)
			{
				goal = q;
				f = true;
			}
			else if (q == goal) return w.ToString();

			if (!D.ContainsKey(q) || D[q] == null) continue;
			foreach (string s in D[q])
			{
				if (V.ContainsKey(s) && V[s]) continue;
				Q.Enqueue((s, w + 1));
				V[s] = true;
			}
		}

		return "NO BLACK HOLE";
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		Q.Enqueue((Console.ReadLine(), 0));
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			if (!D.ContainsKey(S[0])) D[S[0]] = new List<string>();
			D[S[0]].Add(S[1]);
		}

		Console.WriteLine(BFS());
	}
}