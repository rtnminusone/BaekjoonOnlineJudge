#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static void Main()
	{
		string line = null;
		while ((line = Console.ReadLine()) != null)
		{
			string[] S = line.Split();
			int n = int.Parse(S[0]);
			if (n == 0) break;

			long[] h = new long[n + 1];
			for (int i = 0; i < n; i++)
			{
				h[i] = long.Parse(S[i + 1]);
			}
			h[n] = 0;

			Stack<int> st = new Stack<int>();
			long ans = 0;

			for (int i = 0; i <= n; i++)
			{
				while (st.Count > 0 && h[st.Peek()] > h[i])
				{
					long height = h[st.Pop()];
					int width = st.Count == 0 ? i : i - st.Peek() - 1;
					ans = Math.Max(ans, height * width);
				}
				st.Push(i);
			}

			Console.WriteLine(ans);
		}
	}
}