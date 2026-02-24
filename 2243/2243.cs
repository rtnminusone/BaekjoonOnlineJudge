#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public const int MAX = 1000000;
	public static int[] tree = new int[4 * MAX];

	public static void Update(int node, int start, int end, int idx, int diff)
	{
		if (idx < start || idx > end) return;

		tree[node] += diff;
		if (start == end) return;

		int mid = (start + end) / 2;
		Update(node * 2, start, mid, idx, diff);
		Update(node * 2 + 1, mid + 1, end, idx, diff);
	}

	public static int Query(int node, int start, int end, int k)
	{
		if (start == end) return start;

		int mid = (start + end) / 2;
		if (tree[node * 2] >= k) return Query(node * 2, start, mid, k);
		else return Query(node * 2 + 1, mid + 1, end, k - tree[node * 2]);
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int N = int.Parse(Console.ReadLine());
		while (N-- > 0)
		{
			string[] S = Console.ReadLine().Split();
			int type = int.Parse(S[0]);
			if (type == 1)
			{
				int k = int.Parse(S[1]);
				int taste = Query(1, 1, MAX, k);
				sb.AppendLine(taste.ToString());
				Update(1, 1, MAX, taste, -1);
			}
			else
			{
				int taste = int.Parse(S[1]);
				int cnt = int.Parse(S[2]);
				Update(1, 1, MAX, taste, cnt);
			}
		}

		Console.WriteLine(sb.ToString());
	}
}