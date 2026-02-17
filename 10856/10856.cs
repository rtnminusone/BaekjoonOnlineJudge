#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N;
	public static bool[] V;
	public static List<string>[] L;
	public static Queue<string> Q = new Queue<string>();
	public static Dictionary<string, int> D = new Dictionary<string, int>();

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			string s = Q.Dequeue();

			if (L[D[s]] == null) continue;
			foreach (string l in L[D[s]])
			{
				if (V[D[l]]) continue;
				Q.Enqueue(l);
				V[D[l]] = true;
			}
		}
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		V = new bool[N];
		L = new List<string>[N];
		int idx = 0;
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			string key = S[0];
			if (!D.ContainsKey(key)) D[key] = idx++;
			int J = int.Parse(S[1]);
			S = Console.ReadLine().Split();
			for (int j = 0; j < J; j++)
			{
				if (!D.ContainsKey(S[j])) D[S[j]] = idx++;
				if (L[D[S[j]]] == null) L[D[S[j]]] = new List<string>();
				L[D[S[j]]].Add(key);
			}
		}
		foreach (string key in D.Keys)
		{
			string[] tmp = key.Split("::");
			if (tmp[1].Equals("PROGRAM"))
			{
				Q.Enqueue(key);
				V[D[key]] = true;
			}
		}
		BFS();
		int R = 0;
		for (int i = 0; i < N; i++)
		{
			if (!V[i]) R++;
		}

		Console.WriteLine(R);
	}
}