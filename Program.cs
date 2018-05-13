using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace LinqHomework
{
	class Program
	{
		static void Main(string[] args)
		{
			LinqBegin45();
		}

		public static void LinqBegin16()
		{
			if (!uint.TryParse(Input("Enter size of A list > "), out var size))
				throw new InvalidDataException("invalid list size");

			var numbers = new List<int>();
			Console.WriteLine("Enter list A:");
			for (var i = 0; i < size; i++)
			{
				numbers.Add(Convert.ToInt32(Input("Enter number > ")));
			}

			var positive = numbers.Where(num => num > 0);
			OutPut(numbers, positive);
		}

		public static void LinqBegin17()
		{
			if (!uint.TryParse(Input("Enter size of A list > "), out var size))
				throw new InvalidDataException("invalid list size");

			var numbers = new List<int>();
			Console.WriteLine("Enter list A:");
			for (var i = 0; i < size; i++)
			{
				numbers.Add(Convert.ToInt32(Input("Enter number > ")));
			}

			var oddNumbers = numbers.Where(num => num % 2 != 0).Distinct();
			OutPut(numbers, oddNumbers);
		}

		public static void LinqBegin18()
		{
			if (!uint.TryParse(Input("Enter size of A list > "), out var size))
				throw new InvalidDataException("invalid list size");

			var numbers = new List<int>();
			Console.WriteLine("Enter list A:");
			for (var i = 0; i < size; i++)
			{
				numbers.Add(Convert.ToInt32(Input("Enter number > ")));
			}

			var newNumbers = numbers.Where(num => num > 9 && num < 100).OrderBy(num => num);
			OutPut(numbers, newNumbers);
		}

		public static void LinqBegin19()
		{
			if (!uint.TryParse(Input("Enter size of A list > "), out var size))
				throw new InvalidDataException("invalid list size");

			var words = new List<string>();
			Console.WriteLine("Enter list A:");
			for (var i = 0; i < size; i++)
			{
				words.Add(Input("Enter words > "));
			}

			var sortedWords = words.OrderBy(word => word.Length).ThenByDescending(word => word);
			OutPut(words, sortedWords);
		}

		public static void LinqBegin20()
		{
			if (!uint.TryParse(Input("Enter size of A list > "), out var size))
				throw new InvalidDataException("invalid list size");
			if (!int.TryParse(Input("Enter integer number D > "), out var d))
				throw new InvalidDataException("invalid list size");

			var numbers = new List<int>();
			Console.WriteLine("Enter list A:");
			for (var i = 0; i < size; i++)
			{
				numbers.Add(Convert.ToInt32(Input("Enter number > ")));
			}

			var newNumbers = numbers.SkipWhile(num => num < d).Where(num => num % 2 != 0 && num > 0).Reverse();
			OutPut(numbers, newNumbers);
		}

		public static void LinqBegin44()
		{
			if (!uint.TryParse(Input("Enter size of A list > "), out var sizeOfA))
				throw new InvalidDataException("invalid list size");
			if (!uint.TryParse(Input("Enter size of B list > "), out var sizeOfB))
				throw new InvalidDataException("invalid list size");
			if (!int.TryParse(Input("Enter k1 > "), out var k1))
				throw new ArgumentException("invalid type of argument");
			if (!int.TryParse(Input("Enter k2 > "), out var k2))
				throw new ArgumentException("invalid type of argument");

			var numbersA = new List<int>();
			var numbersB = new List<int>();
			Console.WriteLine("Enter list A:");
			for (var i = 0; i < sizeOfA; i++)
			{
				numbersA.Add(Convert.ToInt32(Input("Enter number > ")));
			}

			Console.WriteLine("Enter list B:");
			for (var i = 0; i < sizeOfB; i++)
			{
				numbersB.Add(Convert.ToInt32(Input("Enter number > ")));
			}

			var result = numbersA.Where(num => num > k1).Concat(numbersB.Where(num => num < k2)).OrderBy(num => num)
				.DefaultIfEmpty();
			OutPut(numbersA, numbersB, result);
		}

		public static void LinqBegin45()
		{
			if (!uint.TryParse(Input("Enter size of A list > "), out var sizeOfA))
				throw new InvalidDataException("invalid list size");
			if (!uint.TryParse(Input("Enter size of B list > "), out var sizeOfB))
				throw new InvalidDataException("invalid list size");
			if (!int.TryParse(Input("Enter L1 > "), out var l1))
				throw new ArgumentException("invalid type of argument");
			if (!int.TryParse(Input("Enter L2 > "), out var l2))
				throw new ArgumentException("invalid type of argument");

			var wordsA = new List<string>();
			var wordsB = new List<string>();
			Console.WriteLine("Enter list A:");
			for (var i = 0; i < sizeOfA; i++)
			{
				wordsA.Add(Input("Enter word > "));
			}

			Console.WriteLine("Enter list B:");
			for (var i = 0; i < sizeOfB; i++)
			{
				wordsB.Add(Input("Enter word > "));
			}

			var result = wordsA.Where(word => word.Length == l1).Concat(wordsB.Where(word => word.Length == l2))
				.OrderByDescending(num => num)
				.DefaultIfEmpty();
			OutPut(wordsA, wordsB, result);
		}

		private static string Input(string hint = "")
		{
			Console.Write(hint);
			return Console.ReadLine();
		}


		private static void OutPut<T>(IEnumerable<T> list, IEnumerable<T> newList)
		{
			Console.WriteLine("old list");
			foreach (var element in list)
			{
				Console.Write($"{element} ");
			}

			Console.WriteLine();
			Console.WriteLine("new list");
			foreach (var element in newList)
			{
				Console.Write($"{element} ");
			}
		}

		private static void OutPut<T>(IEnumerable<T> oldList1, IEnumerable<T> oldList2, IEnumerable<T> newList)
		{
			Console.WriteLine("first old list");
			foreach (var element in oldList1)
			{
				Console.Write($"{element} ");
			}

			Console.WriteLine("second old list");
			foreach (var element in oldList2)
			{
				Console.Write($"{element} ");
			}

			Console.WriteLine();
			Console.WriteLine("new list");
			foreach (var element in newList)
			{
				Console.Write($"{element} ");
			}
		}
	}
}