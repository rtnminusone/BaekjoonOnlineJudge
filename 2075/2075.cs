#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static PriorityQueue<int, int> PQ = new PriorityQueue<int, int>();

	public static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				int k = int.Parse(S[j]);
				if (PQ.Count < N) PQ.Enqueue(k, k);
				else
				{
					if (PQ.Peek() < k)
					{
						PQ.Dequeue();
						PQ.Enqueue(k, k);
					}
				}
			}
		}

		Console.WriteLine(PQ.Peek());
	}
}