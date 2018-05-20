using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace LinqHomework
{
	partial class Program
	{
		private static readonly StreamWriter Writer =
			new StreamWriter("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\result.txt");

		private static void Main(string[] args)
		{
			try
			{
				LinqBegin16();
				Console.WriteLine("---");
				LinqBegin17();
				Console.WriteLine("---");
				LinqBegin18();
				Console.WriteLine("---");
				LinqBegin19();
				Console.WriteLine("---");
				LinqBegin20();
				Console.WriteLine("---");
				LinqBegin44();
				Console.WriteLine("---");
				LinqBegin45();
				Console.WriteLine("---");

				var dataForClients = ReadClassFromFile();
				TasksForClient(dataForClients);
				Writer.Close();
				WriterForClient.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error! Can't open the file");
				throw;
			}
		}

		private static void LinqBegin16()
		{
			var numbers = File.ReadAllLines("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\tasks(16-18,20).txt");
			var positive = numbers.Where(num => Convert.ToInt32(num) > 0);
			var enumerable = positive.ToList();

			foreach (var i in enumerable)
			{
				Console.WriteLine(i);
			}

			Writer.WriteLine("Task 16");
			foreach (var item in enumerable)
			{
				Writer.Write($"{item} ");
			}

			Writer.WriteLine();
		}

		private static void LinqBegin17()
		{
			var numbers = File.ReadAllLines("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\tasks(16-18,20).txt");
			var oddNumbers = numbers.Where(num => Convert.ToInt32(num) % 2 != 0).Distinct();
			var enumerable = oddNumbers.ToList();
			foreach (var i in enumerable)
			{
				Console.WriteLine(i);
			}

			Writer.WriteLine("Task 17");
			foreach (var item in enumerable)
			{
				Writer.Write($"{item} ");
			}

			Writer.WriteLine();
		}

		private static void LinqBegin18()
		{
			var numbers = File.ReadAllLines("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\tasks(16-18,20).txt");
			var newNumbers = numbers.Where(num => Convert.ToInt32(num) > 9 && Convert.ToInt32(num) < 100)
				.OrderBy(num => Convert.ToInt32(num));

			var enumerable = newNumbers.ToList();
			foreach (var i in enumerable)
			{
				Console.WriteLine(i);
			}

			Writer.WriteLine("Task 18");
			foreach (var item in enumerable)
			{
				Writer.Write($"{item} ");
			}

			Writer.WriteLine();
		}

		private static void LinqBegin19()
		{
			var words = File.ReadAllLines("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\task19.txt");
			var sortedWords = words.OrderBy(word => word.Length).ThenByDescending(word => word);

			foreach (var i in sortedWords)
			{
				Console.WriteLine(i);
			}

			Writer.WriteLine("Task 19");
			foreach (var item in sortedWords)
			{
				Writer.Write($"{item} ");
			}

			Writer.WriteLine();
		}

		private static void LinqBegin20()
		{
			var numbers = File.ReadAllLines("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\tasks(16-18,20).txt");
			const int d = 172;
			var newNumbers = numbers.SkipWhile(num => Convert.ToInt32(num) < d)
				.Where(num => Convert.ToInt32(num) % 2 != 0 && Convert.ToInt32(num) > 0).Reverse();

			var enumerable = newNumbers.ToList();
			foreach (var i in enumerable)
			{
				Console.WriteLine(i);
			}

			Writer.WriteLine("Task 20");
			foreach (var item in enumerable)
			{
				Writer.Write($"{item} ");
			}

			Writer.WriteLine();
		}

		private static void LinqBegin44()
		{
			var numbersA = File.ReadAllLines("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\task44A.txt");
			var numbersB = File.ReadAllLines("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\task44B.txt");

			const int k1 = 60;
			const int k2 = 144;

			var result = numbersA.Where(num => Convert.ToInt32(num) > k1)
				.Concat(numbersB.Where(num => Convert.ToInt32(num) < k2))
				.OrderBy(num => Convert.ToInt32(num)).DefaultIfEmpty();

			foreach (var i in result)
			{
				Console.WriteLine(i);
			}

			Writer.WriteLine("Task 44");
			foreach (var item in result)
			{
				Writer.Write($"{item} ");
			}

			Writer.WriteLine();
		}

		private static void LinqBegin45()
		{
			var wordsA = File.ReadAllLines("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\task45A.txt");
			var wordsB = File.ReadAllLines("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\task45B.txt");

			const int l1 = 3;
			const int l2 = 5;

			var result = wordsA.Where(word => word.Length == l1).Concat(wordsB.Where(word => word.Length == l2))
				.OrderByDescending(word => word)
				.DefaultIfEmpty();

			var enumerable = result.ToList();
			foreach (var i in enumerable)
			{
				Console.WriteLine(i);
			}

			Writer.WriteLine("Task 45");
			foreach (var item in enumerable)
			{
				Writer.Write($"{item} ");
			}
		}
	}
}