using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAplication
{
	public class Programmer : Employee
	{
		private string programmingLanguage;

		public Programmer() { }
		public Programmer(int employeeID, string name, string programmingLanguage)
		{
			base.setEmployeeID(employeeID);
			base.setName(name);
			this.programmingLanguage = programmingLanguage;
		}

		public string getProgrammingLanguage() { return programmingLanguage; }
		public void setProgrammingLanguage(string programmingLanguage) { this.programmingLanguage = programmingLanguage; }

		public new void display()
		{
			Console.WriteLine(base.display() + "\nSpecialization: " + getProgrammingLanguage() + "\nSalary: " + Math.Round(base.getSalary(), 2) + "\nDeduction: " + Math.Round(base.getDeduction(), 2) + "\nNet Pay: " + Math.Round(calculateNetPay(), 2));

		}

		public override double calculateSalary(double num_days)
		{
			double sal = 950 * num_days;

			base.setSalary(sal);
			return calculateDeduction ();

			//return sal;
		}

		public override double calculateDeduction()
		{
			double salary = base.getSalary();

			double sss = salary * 0.05;
			double pagibig = salary * 0.03;
			double wtax = salary * 0.08;
			double philHealth = salary * 0.03;

			double ded = sss + pagibig + wtax + philHealth;

			base.setDeduction(ded);
			return calculateNetPay();

			//return ded;
		}

		public override double calculateNetPay()
		{
			double x = base.getSalary() - base.getDeduction();
			return x;
		}
	}
}
