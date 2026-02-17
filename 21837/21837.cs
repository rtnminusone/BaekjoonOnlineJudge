#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N;
	public static Queue<(string, int)> Q = new Queue<(string, int)>();
	public static Dictionary<string, int> R = new Dictionary<string, int>();
	public static Dictionary<string, bool> V = new Dictionary<string, bool>();
	public static Dictionary<string, List<string>> D = new Dictionary<string, List<string>>();
	public static Dictionary<string, List<string>> DB = new Dictionary<string, List<string>>();

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			R[q] = w;

			if (!D.ContainsKey(q) || D[q] == null) continue;
			foreach (string d in D[q])
			{
				if (!V.ContainsKey(d)) V[d] = false;
				if (V.ContainsKey(d) && V[d]) continue;
				Q.Enqueue((d, w + 1));
				V[d] = true;
			}
		}
	}

	public static void MakeConn()
	{
		foreach (string d in DB.Keys)
		{
			foreach (string l in DB[d])
			{
				if (!D.ContainsKey(l)) D[l] = new List<string>();
				D[l].Add(d);
			}
		}
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());

		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			if (i == 0)
			{
				Q.Enqueue((S[0], 1));
				V[S[0]] = true;
			}
			DB[S[0]] = new List<string>();
			if (S.Length > 4)
			{
				for (int j = 4; j < S.Length; j++)
				{
					DB[S[0]].Add(S[j]);
				}
			}
		}

		MakeConn();

		BFS();

		foreach (string d in DB.Keys)
		{
			if ((V.ContainsKey(d) && !V[d]) || !V.ContainsKey(d)) R[d] = 0;
		}

		int[] result = R.OrderBy(kv => kv.Key, StringComparer.Ordinal).Select(kv => kv.Value).ToArray();

		Console.WriteLine(string.Join("\n", result));
	}
}