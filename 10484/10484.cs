#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public struct Pos
	{
		public int x;
		public int y;

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = new Pos(x, y);

		return true;
	}

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			var (p, w) = Q.Dequeue();

			if (p.x == X && p.y == Y) return w;

			if (!D.ContainsKey(p) || L[D[p]] == null) continue;
			foreach (Pos l in L[D[p]])
			{
				if (V.ContainsKey(l)) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}

		return -1;
	}

	public static int N, X, Y;
	public static Queue<(Pos, int)> Q = new Queue<(Pos, int)>();
	public static List<Pos>[] L;
	public static Dictionary<Pos, int> D = new Dictionary<Pos, int>();
	public static Dictionary<Pos, bool> V = new Dictionary<Pos, bool>();

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());

		while (t-- > 0)
		{
			Console.ReadLine();
			X = 0;
			Y = 0;
			Q.Clear();
			D.Clear();
			V.Clear();
			N = int.Parse(Console.ReadLine());
			L = new List<Pos>[N + 1];
			int idx = 0;
			for (int i = 0; i < N; i++)
			{
				Pos p1 = new Pos(X, Y);
				string S = Console.ReadLine();
				if (S[0] == 'N') X--;
				else if (S[0] == 'W') Y--;
				else if (S[0] == 'S') X++;
				else Y++;
				Pos p2 = new Pos(X, Y);
				if (!D.ContainsKey(p1))
				{
					D[p1] = idx;
					L[idx++] = new List<Pos>();
				}
				L[D[p1]].Add(p2);
				if (!D.ContainsKey(p2))
				{
					D[p2] = idx;
					L[idx++] = new List<Pos>();
				}
				L[D[p2]].Add(p1);
			}
			Pos tmp = new Pos(0, 0);
			Q.Enqueue((tmp, 0));
			V[tmp] = true;

			sb.AppendLine(BFS().ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}