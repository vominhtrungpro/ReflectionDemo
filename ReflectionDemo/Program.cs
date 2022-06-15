using AutoMapper;
using System.Reflection;

public class Student1
{
    public string Firstname { get; set; } = "Trung";
    public string Lastname { get; set; } = "Vo";


}

public class Student2
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }

}


class Program
{
    static void Main(string[] args)
    {
        Student1 student1 = new Student1();
        Student2 student2 = new Student2();
        Type student1Type = student1.GetType();
        Type student2Type = student2.GetType();

        var student1Properties = student1Type.GetProperties();
        var student2Properties = student2Type.GetProperties();

        var commonproperties = from s1p in student1Properties
                               join s2p in student2Properties on new { s1p.Name, s1p.PropertyType } equals
                                   new { s2p.Name, s2p.PropertyType }
                               select new { s1p, s2p };



        foreach (var match in commonproperties)
        {
            match.s2p.SetValue(student2, match.s1p.GetValue(student1, null), null);
        }
        Console.WriteLine(student2.Firstname + " " + student2.Lastname);


    }
}