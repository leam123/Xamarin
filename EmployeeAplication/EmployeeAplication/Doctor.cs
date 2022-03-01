using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAplication
{
	public class Doctor : Employee
	{
		private string specialization;

		public Doctor(int employeeID, string name, string specialization)
		{
			base.setEmployeeID(employeeID);
			base.setName(name);
			this.specialization = specialization;
		}

		public string getSpecialization() { return specialization; }
		public void setSpecialization(string specialization) { this.specialization = specialization; }

		public new void display()
		{
		Console.WriteLine(base.display() + "\nSpecialization: " + getSpecialization() + "\nSalary: " + Math.Round(base.getSalary(), 2) + "\nDeduction: " + Math.Round(base.getDeduction(), 2) + "\nNet Pay: " + Math.Round(calculateNetPay(), 2));

		}

		public override double calculateSalary(double num_days)
		{
			double sal = 0.0;

			if (getSpecialization().Equals("Pediatrician", StringComparison.CurrentCultureIgnoreCase))
			{
				sal = 2050 * num_days;
			}
			else if (getSpecialization().Equals("Ob-Gynecologist", StringComparison.CurrentCultureIgnoreCase))
			{
				sal = 2650 * num_days;
			}
			else if (getSpecialization().Equals("Neurologist", StringComparison.CurrentCultureIgnoreCase))
			{
				sal = 6575 * num_days;
			}
			else
			{
				sal = 0 * num_days;
			}

			base.setSalary(sal);
			return calculateDeduction();

			//return sal;
		}

		public override double calculateDeduction()
		{
			double salary = base.getSalary();
			double sss = 0.0, pagibig = 0.0, wtax = 0.0, philHealth = 0.0, ded = 0.0;

			if (salary <= 10000)
			{
				sss = salary * 0.03;
				pagibig = salary * 0.02;
				wtax = salary * 0.05;
				philHealth = salary * 0.01;
			}
			else if (salary > 10000 && salary <= 20000)
			{
				sss = salary * 0.05;
				pagibig = salary * 0.04;
				wtax = salary * 0.10;
				philHealth = salary * 0.025;
			}
			else if (salary > 20000 && salary <= 30000)
			{
				sss = salary * 0.07;
				pagibig = salary * 0.07;
				wtax = salary * 0.15;
				philHealth = salary * 0.05;
			}
			else if (salary > 30000)
			{
				sss = salary * 0.10;
				pagibig = salary * 0.10;
				wtax = salary * 0.30;
				philHealth = salary * 0.08;
			}

			ded = sss + pagibig + wtax + philHealth;
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
