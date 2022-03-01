using System;

namespace EmployeeAplication
{
	public class TestClass
	{
		public static void Main(string[] args)
		{
			int ans = 1;

			do
			{
				Menu();

			} while (ans == 1);
		}

		public static void Menu()
		{
			int days, id;
			string name, specialization;

			Console.WriteLine("\n\nMENU\n[1]Doctor\n[2]Programmer\n[3]Exit\n");
			Console.WriteLine("Enter choice: ");
			int choice = int.Parse(Console.ReadLine());

			switch (choice)
			{
				case 1:
					Console.Write("\nEnter ID Number	: ");
					id = int.Parse(Console.ReadLine());

					Console.Write("Enter Name	: ");
					name = Console.ReadLine();

					Console.Write("Enter Field of Specialization	: ");
					specialization = Console.ReadLine();

					Doctor doctor = new Doctor(id, name, specialization);
					Console.Write("Number of days worked	: ");
					days = int.Parse(Console.ReadLine());
					if (days <= 30)
					{
						doctor.calculateSalary(days);
					}
					else
					{
						Console.WriteLine("No. of days must not exceed 30.");
						Menu();
					}
					Console.WriteLine("\nDoctor's Information: ");
					doctor.display();
					break;
				case 2:
					Console.Write("\nEnter ID Number	: ");
					id = int.Parse(Console.ReadLine());

					Console.Write("Enter Name	: ");
					name = Console.ReadLine();

					Console.Write("Enter Field of Specialization	: ");
					specialization = Console.ReadLine();

					Programmer programmer = new Programmer(id, name, specialization);
					Console.Write("Number of days worked: ");
					days = int.Parse(Console.ReadLine());
					if (days <= 30)
					{
						programmer.calculateSalary(days);
					}
					else
					{
						Console.WriteLine("No. of days must not exceed 30.");
						Menu();
					}
					Console.WriteLine("\nProgrammer's Information: ");
					programmer.display();
					break;
				case 3:
					Environment.Exit(0);
					break;
				default:
					break;
			}
		}
	}
}
