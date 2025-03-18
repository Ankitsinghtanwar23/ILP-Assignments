using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

class student
{

    public string name;
    public int RollNumber;
    public string course;
    public int Age;

    public student(string name, int RollNumber, string course, int Age)
    {
        this.name = name;
        this.RollNumber = RollNumber;
        this.course = course;
        this.Age = Age;
    }

    public void showDetails()
    {
        Console.WriteLine("Name : " + this.name);
        Console.WriteLine("Roll Number :" + this.RollNumber);
        Console.WriteLine("course :" + this.course);
        Console.WriteLine("Age :" + this.Age);

        


    }


}

class main
{
    public static void Main()
    {
        student s1 = new student("abhishek", 1, "web Development", 20);
        student s2 = new student("rahul", 2, "UI Designing", 21);
        student s3 = new student("ajay", 3, "Machine Learning", 20);

        s1.showDetails();
        s2.showDetails();
        s3.showDetails();
    }
}

 
