#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static string BFS()
	{
		int R = 0;

		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			R++;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}

		return R == N ? "Connected." : "Not connected.";
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
			V = new bool[N];
			L = new List<int>[N];
			for (int i = 2; i <= M * 2; i += 2)
			{
				int left = int.Parse(S[i]);
				int right = int.Parse(S[i + 1]);
				(L[left] ??= new List<int>()).Add(right);
				(L[right] ??= new List<int>()).Add(left);
			}
			Q.Clear();
			Q.Enqueue(0);
			V[0] = true;

			sb.AppendLine(BFS());
		}

		Console.WriteLine(sb.ToString());
	}
}