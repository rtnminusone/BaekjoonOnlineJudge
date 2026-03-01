#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static PriorityQueue<int, int> PQL = new PriorityQueue<int, int>();
	public static PriorityQueue<int, int> PQR = new PriorityQueue<int, int>();

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());
		while (t-- > 0)
		{
			int N = int.Parse(Console.ReadLine());
			int[] R = new int[N / 2 + 1];
			int idx = 0;
			int c = N / 10 + 1;
			while (c-- > 0)
			{
				string[] S = Console.ReadLine().Split();
				for (int i = 0; i < S.Length; i++)
				{
					int k = int.Parse(S[i]);
					if (PQL.Count == 0 && PQR.Count == 0)
					{
						PQL.Enqueue(k, -k);
						R[idx++] = k;
					}
					else if (PQL.Count > PQR.Count)
					{
						if (PQL.Peek() > k)
						{
							int p = PQL.Dequeue();
							PQR.Enqueue(p, p);
							PQL.Enqueue(k, -k);
						}
						else
						{
							PQR.Enqueue(k, k);
						}
					}
					else if (PQL.Count == PQR.Count)
					{
						if (PQR.Peek() < k)
						{
							int p = PQR.Dequeue();
							PQL.Enqueue(p, -p);
							PQR.Enqueue(k, k);
						}
						else
						{
							PQL.Enqueue(k, -k);
						}
						R[idx++] = PQL.Peek();
					}
				}
			}

			sb.Append(idx.ToString());
			for (int i = 0; i < idx; i++)
			{
				if (i % 10 == 0) sb.AppendLine();
				sb.Append(R[i] + " ");
			}
			sb.AppendLine();

			PQL.Clear();
			PQR.Clear();
		}

		Console.WriteLine(sb.ToString());
	}
}