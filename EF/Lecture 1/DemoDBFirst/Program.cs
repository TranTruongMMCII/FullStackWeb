using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int option;
            int id;
            Student student = new Student();
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Xem");
                Console.WriteLine("2. Thêm");
                Console.WriteLine("3. Xóa");
                Console.WriteLine("4. Sửa");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn lựa chọn: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Danh sách sinh viên: ");
                        using(var db = new DemoDBFirstEntities())
                        {
                            var lstStudents = from s in db.Students select s;
                            foreach (var item in lstStudents)
                            {
                                Console.WriteLine("ID = {0}", item.StudentID);
                                Console.WriteLine("StudentName = {0}", item.StudentName);
                                Console.WriteLine("StudentGender = {0}", item.StudentGender);
                                Console.WriteLine("Address = {0}", item.Address);
                                Console.WriteLine("------------");
                            }
                        }
                        break;
                    case 2:
                        student = new Student();
                        Console.Write("Nhập họ tên: ");
                        student.StudentName = Console.ReadLine();
                        Console.Write("Nhập giới tính: ");
                        student.StudentGender = Console.ReadLine();
                        Console.Write("Nhập địa chỉ: ");
                        student.Address = Console.ReadLine();
                        using(var db = new DemoDBFirstEntities())
                        {
                            db.Students.Add(student);
                            db.SaveChanges();
                        }
                        break;
                    case 3:
                        Console.Write("Nhập mã sinh viên cần xóa: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        using (var db = new DemoDBFirstEntities())
                        {
                            student = (from s in db.Students where s.StudentID == id select s).FirstOrDefault();
                            db.Students.Remove(student);
                            db.SaveChanges();
                        }
                        break;
                    case 4:
                        student = new Student();
                        Console.Write("Nhập mã sinh viên cần sửa: ");
                        id = Convert.ToInt32(Console.ReadLine());             
                        using (var db = new DemoDBFirstEntities())
                        {
                            student = (from s in db.Students where s.StudentID == id select s).FirstOrDefault();
                            Console.Write("Nhập họ tên: ");
                            student.StudentName = Console.ReadLine();
                            Console.Write("Nhập giới tính: ");
                            student.StudentGender = Console.ReadLine();
                            Console.Write("Nhập địa chỉ: ");
                            student.Address = Console.ReadLine();
                            db.SaveChanges();
                        }
                        break;
                    case 5:
                        return;
                    default:
                        break;
                }
            }  
        }
    }
}
