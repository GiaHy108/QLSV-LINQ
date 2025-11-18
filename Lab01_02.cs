using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Age: {Age}";
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        List<Student> students = new List<Student>()
        {
            new Student(1, "An", 16),
            new Student(2, "Bình", 14),
            new Student(3, "Anh Tuấn", 17),
            new Student(4, "Chi", 18),
            new Student(5, "Ánh", 15)
        };

        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("===== MENU QUẢN LÝ HỌC SINH LINQ =====");
            Console.WriteLine("1. In toàn bộ danh sách học sinh");
            Console.WriteLine("2. Học sinh có tuổi từ 15 đến 18");
            Console.WriteLine("3. Học sinh có tên bắt đầu bằng chữ 'A'");
            Console.WriteLine("4. Tính tổng tuổi tất cả học sinh");
            Console.WriteLine("5. Tìm học sinh lớn tuổi nhất");
            Console.WriteLine("6. Sắp xếp học sinh theo tuổi tăng dần");
            Console.WriteLine("0. Thoát");
            Console.Write("Nhập lựa chọn: ");

            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Danh sách học sinh:");
                    students.ForEach(s => Console.WriteLine(s));
                    break;

                case 2:
                    Console.WriteLine("Học sinh từ 15 đến 18 tuổi:");
                    var age15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
                    foreach (var s in age15to18) Console.WriteLine(s);
                    break;

                case 3:
                    Console.WriteLine("Học sinh có tên bắt đầu bằng chữ 'A':");
                    var startA = students.Where(s => s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase));
                    foreach (var s in startA) Console.WriteLine(s);
                    break;

                case 4:
                    int totalAge = students.Sum(s => s.Age);
                    Console.WriteLine("Tổng tuổi: " + totalAge);
                    break;

                case 5:
                    int maxAge = students.Max(s => s.Age);
                    var oldest = students.Where(s => s.Age == maxAge);
                    Console.WriteLine("Học sinh lớn tuổi nhất:");
                    foreach (var s in oldest) Console.WriteLine(s);
                    break;

                case 6:
                    Console.WriteLine("Sắp xếp theo tuổi tăng dần:");
                    var sorted = students.OrderBy(s => s.Age);
                    foreach (var s in sorted) Console.WriteLine(s);
                    break;

                case 0:
                    Console.WriteLine("Thoát chương trình...");
                    break;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }

            if (choice != 0)
            {
                Console.WriteLine("\nNhấn phím bất kỳ để quay lại MENU...");
                Console.ReadKey();
            }

        } while (choice != 0);
    }
}
