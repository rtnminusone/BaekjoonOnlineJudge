#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N;
	public static Queue<string> Q = new Queue<string>();
	public static Dictionary<string, bool> V = new Dictionary<string, bool>();
	public static Dictionary<string, string> P = new Dictionary<string, string>();
	public static Dictionary<string, List<string>> D = new Dictionary<string, List<string>>();

	public static void BFS(string goal)
	{
		while (Q.Count > 0)
		{
			string q = Q.Dequeue();

			if (q.Equals(goal))
			{
				List<string> A = new List<string>();
				A.Add(q);
				while (P.ContainsKey(q))
				{
					string p = P[q];
					A.Add(p);
					q = p;
				}
				A.Reverse();
				Console.WriteLine(string.Join(" ", A));
				return;
			}

			if (!D.ContainsKey(q) || D[q] == null) continue;
			foreach (string s in D[q])
			{
				if (V.ContainsKey(s) && V[s]) continue;
				Q.Enqueue(s);
				P[s] = q;
				V[s] = true;
			}
		}

		Console.WriteLine("no route found");
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		string[] S;
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			if (!D.ContainsKey(S[0])) D[S[0]] = new List<string>();
			for (int j = 1; j < S.Length; j++)
			{
				if (!D.ContainsKey(S[j])) D[S[j]] = new List<string>();
				D[S[0]].Add(S[j]);
				D[S[j]].Add(S[0]);
			}
		}

		S = Console.ReadLine().Split();
		Q.Enqueue(S[0]);
		V[S[0]] = true;

		BFS(S[1]);
	}
}