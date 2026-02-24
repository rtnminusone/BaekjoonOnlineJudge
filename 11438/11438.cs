#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M;
	public static List<int>[] tree;
	public static int[,] parent;
	public static int[] depth;
	public static int LOG = 17;

	public static void DFS(int cur, int par)
	{
		parent[cur, 0] = par;
		foreach (var next in tree[cur])
		{
			if (next == par) continue;
			depth[next] = depth[cur] + 1;
			DFS(next, cur);
		}
	}

	public static int LCA(int a, int b)
	{
		if (depth[a] < depth[b])
		{
			int tmp = a;
			a = b;
			b = tmp;
		}

		for (int i = LOG; i >= 0; i--)
		{
			if (depth[a] - (1 << i) >= depth[b]) a = parent[a, i];
		}

		if (a == b) return a;

		for (int i = LOG; i >= 0; i--)
		{
			if (parent[a, i] != parent[b, i])
			{
				a = parent[a, i];
				b = parent[b, i];
			}
		}

		return parent[a, 0];
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		N = int.Parse(Console.ReadLine());
		tree = new List<int>[N + 1];
		for (int i = 1; i <= N; i++)
		{
			tree[i] = new List<int>();
		}
		for (int i = 0; i < N - 1; i++)
		{
			string[] S = Console.ReadLine().Split();
			int a = int.Parse(S[0]);
			int b = int.Parse(S[1]);
			tree[a].Add(b);
			tree[b].Add(a);
		}

		parent = new int[N + 1, LOG + 1];
		depth = new int[N + 1];

		DFS(1, 0);

		for (int j = 1; j <= LOG; j++)
		{
			for (int i = 1; i <= N; i++)
			{
				parent[i, j] = parent[parent[i, j - 1], j - 1];
			}
		}

		M = int.Parse(Console.ReadLine());
		for (int i = 0; i < M; i++)
		{
			string[] S = Console.ReadLine().Split();
			int a = int.Parse(S[0]);
			int b = int.Parse(S[1]);
			sb.AppendLine(LCA(a, b).ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}