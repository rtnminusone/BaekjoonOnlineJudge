#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static PriorityQueue<int, int> PQ = new PriorityQueue<int, int>();

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int N = int.Parse(Console.ReadLine());
		for (int i = 0; i < N; i++)
		{
			int s = int.Parse(Console.ReadLine());
			if (s == 0) sb.AppendLine(PQ.Count == 0 ? "0" : PQ.Dequeue().ToString());
			else PQ.Enqueue(s, -s);
		}

		Console.WriteLine(sb.ToString());
	}
}