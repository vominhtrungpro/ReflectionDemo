using System.Reflection;
namespace Reflection
{
    public class Program
    {
        private static void Main()
        {
            Student1 student1 = new Student1();

            Student2 student2 = new Student2();
            //gọi type của student1
            var student1Type = typeof(Student1);
            //gọi các properties của student 1
            var student1Properties = student1Type.GetProperties();
            //gọi type của student 2
            var student2Type = typeof(Student2);
            //gọi properties của student 2
            var student2Properties = student2Type.GetProperties();

            foreach (var student1prop in student1Properties)
            {
                foreach (var student2prop in student2Properties)
                {
                    if (student1prop.Name == student2prop.Name && student1prop.PropertyType.Name == student2prop.PropertyType.Name)
                    {
                        //chuyển value từ student 1 sang student 2
                        student2prop.SetValue(student2, student1prop.GetValue(student1));
                        break;
                    }
                }
            }
            Console.WriteLine("Value after changing");
            foreach (var prop in student2Properties)
            {
                Console.WriteLine(prop.PropertyType.Name + " " + prop.Name + " " + prop.GetValue(student2));
            }
        }
    }
    public class Student1
    {
        public int Id { get; set; } = 1;

        public string FirstName { get; set; } = "Trung";

        public string LastName { get; set; } = "Vo";

        public string Address { get; set; } = "TienGiang";

        public string City { get; set; } = "MyTho";

        public int Age { get; set; } = 25;


        public static void Method1()
        {
            Console.WriteLine("Hello World!");
        }


        public void Method2()
        {
            Console.WriteLine("Goodbye World!");
        }

    }
}
public class Student2
{
    public int Id { get; set; } 

    public string FirstName { get; set; } 

    public string LastName { get; set; } 

    public string Address { get; set; } 

    public string City { get; set; } 

    public int Age { get; set; } 


    public static void Method1()
    {
        
    }


    public void Method2()
    {
        
    }

}
