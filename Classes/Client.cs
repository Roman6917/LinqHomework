using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LinqHomework
{
	public partial class Program
	{
		private static readonly StreamWriter WriterForClient =
			new StreamWriter("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\objectResults.txt");

		private class Client
		{
			private string _year;
			private string _mounth;

			public Client(string id = " ", string y = " ", string m = " ", string o = " ")
			{
				Id = id;
				Year = y;
				Mounth = m;
				Occupation = o;
			}

			public string Id { get; set; }

			public string Year
			{
				get => _year;
				set
				{
					if (Convert.ToInt32(_year) > 0)
					{
						_year = value;
					}
				}
			}

			public string Mounth
			{
				get => _mounth;
				set
				{
					if (Convert.ToInt32(_mounth) > 0)
					{
						_mounth = value;
					}
				}
			}

			public string Occupation { get; set; }
		}

		private static Client ReadFromFile(TextReader streamReader)
		{
			var dataForClient = new Client
			{
				Id = streamReader.ReadLine(),
				Year = streamReader.ReadLine(),
				Mounth = streamReader.ReadLine(),
				Occupation = streamReader.ReadLine()
			};
			return dataForClient;
		}

		private static List<Client> ReadClassFromFile()
		{
			var clients = new List<Client>();
			var streamReader = new StreamReader("C:\\Users\\Roman\\RiderProjects\\LinqHomework\\LinqHomework\\objectData.txt");
			var amount = Convert.ToInt32(streamReader.ReadLine());

			for (var i = 0; i < amount; i++)
			{
				clients.Add(ReadFromFile(streamReader));
			}

			return clients;
		}

		private static void TasksForClient(IReadOnlyCollection<Client> clients)
		{
			var minOcupation = clients.Min(i => i.Occupation);
			WriterForClient.WriteLine("Minimal occupation in hours:");
			WriterForClient.WriteLine(minOcupation);

			var maxOcupation = clients.Max(occup => occup.Occupation);
			WriterForClient.WriteLine("Maximal occupation in hours:");
			WriterForClient.WriteLine(maxOcupation);

			WriterForClient.WriteLine("Maximal occupation year:");
			var groupedByYears = clients.GroupBy(year => year.Year);

			IEnumerable<IGrouping<string, Client>> sorted = groupedByYears
				.OrderByDescending(group => group.Sum(occup => Convert.ToInt32(occup.Occupation)))
				.ThenBy(item => item.Min(year => year.Year));

			WriterForClient.WriteLine(sorted.First().Key);
			WriterForClient.WriteLine("Sum of occupations for all years: ");

			var groupedById = clients.GroupBy(id => id.Id);
			var durations = new SortedDictionary<string, string>();

			foreach (var group in groupedById)
			{
				var sum = group.Sum(ocur => Convert.ToInt32(ocur.Occupation));
				durations.Add(Convert.ToString(sum), group.Key);
			}

			foreach (var group in durations)
			{
				WriterForClient.WriteLine("Occupation : {0} ,Id: {1}", group.Key, group.Value);
			}

			WriterForClient.WriteLine("Count of amount: ");
			var groupedByCode2 = clients.GroupBy(id => id.Id);
			var months = new SortedDictionary<int, int>();

			foreach (var group in groupedByCode2)
			{
				var count = group.Count();
				months.Add(Convert.ToInt32(group.Key), count);
			}

			foreach (var group in months)
			{
				WriterForClient.WriteLine("Id : {0} ,Occupation: {1}", group.Key, group.Value);
			}
		}
	}
}