using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAplication
{
	public abstract class Employee
	{
		private int employeeID;
		private string name;
		private double salary = 0.0, deduction = 0.0;

		public Employee() { }
		public Employee(int employeeID, String name)
		{
			this.employeeID = employeeID;
			this.name = name;
		}

		public int getEmployeeID() { return employeeID; }
		public string getName() { return name; }
		public double getSalary() { return salary; }
		public double getDeduction() { return deduction; }

		public void setEmployeeID(int employeeID) { this.employeeID = employeeID; }
		public void setName(string name) { this.name = name; }
		public void setSalary(double salary) { this.salary = salary; }
		public void setDeduction(double deduction) { this.deduction = deduction; }

		public string display()
		{
			return "Employee ID Number: " + getEmployeeID() + "\nName: " + getName(); // + "\nSalary: " + getSalary();
	
		}

		public abstract double calculateSalary(double numDays);
		public abstract double calculateDeduction();
		public abstract double calculateNetPay();
	}
}
