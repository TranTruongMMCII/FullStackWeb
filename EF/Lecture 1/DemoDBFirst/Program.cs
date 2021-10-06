using System;
using System.Linq;
using System.Text;

namespace DemoDBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int option;
            Person person;
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Xem");
                Console.WriteLine("2. Thêm");
                Console.WriteLine("3. Xem sinh viên");
                Console.WriteLine("4. Xem giảng viên");
                Console.WriteLine("5. Xem giáo vụ");
                Console.WriteLine("6. Thoát");
                Console.Write("Chọn lựa chọn: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Danh sách đã lưu: ");
                        using (var db = new DemoDBFirstEntities())
                        {
                            var lstPeople = from s in db.People select s;
                            foreach (var item in lstPeople)
                            {
                                Console.WriteLine("ID = {0}", item.ID);
                                Console.WriteLine("Name = {0}", item.Name);
                                Console.WriteLine("Gender = {0}", item.Gender);
                                Console.WriteLine("Address = {0}", item.Address);
                                Console.WriteLine("Type = {0}", item.Type == 1 ? "Sinh viên" : item.Type == 2 ? "Giảng viên" : "Giáo vụ");
                                Console.WriteLine("------------");
                            }
                        }
                        break;
                    case 2:
                        Console.Write("Bạn muốn nhập 1: sinh viên, 2: giảng viên, 3: giáo vụ? ");
                        option = Convert.ToInt32(Console.ReadLine());
                        person = new Student();
                        switch (option)
                        {
                            case 1:
                                person = new Student();
                                person.Type = 1;
                                break;
                            case 2:
                                person = new Trainer();
                                person.Type = 2;
                                break;
                            case 3:
                                person = new Officer();
                                person.Type = 3;
                                break;
                        }
                        Console.Write("Nhập họ tên: ");
                        person.Name = Console.ReadLine();
                        Console.Write("Nhập giới tính: ");
                        person.Gender = Console.ReadLine();
                        Console.Write("Nhập địa chỉ: ");
                        person.Address = Console.ReadLine();
                        using (var db = new DemoDBFirstEntities())
                        {
                            db.People.Add(person);
                            db.SaveChanges();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Danh sách sinh viên: ");
                        using (var db = new DemoDBFirstEntities())
                        {
                            var lstStudents = from s in db.Students select s;
                            foreach (var item in lstStudents)
                            {
                                Console.WriteLine("ID = {0}", item.ID);
                                Console.WriteLine("Name = {0}", item.Name);
                                Console.WriteLine("Gender = {0}", item.Gender);
                                Console.WriteLine("Address = {0}", item.Address);
                                Console.WriteLine("Type = {0}", "Sinh viên");
                                Console.WriteLine("------------");
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Danh sách giảng viên: ");
                        using (var db = new DemoDBFirstEntities())
                        {
                            var lstTrainers = from s in db.Trainers select s;
                            foreach (var item in lstTrainers)
                            {
                                Console.WriteLine("ID = {0}", item.ID);
                                Console.WriteLine("Name = {0}", item.Name);
                                Console.WriteLine("Gender = {0}", item.Gender);
                                Console.WriteLine("Address = {0}", item.Address);
                                Console.WriteLine("Type = {0}", "Giảng viên");
                                Console.WriteLine("------------");
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Danh sách giáo vụ: ");
                        using (var db = new DemoDBFirstEntities())
                        {
                            var lstOfficers = from s in db.Officers select s;
                            foreach (var item in lstOfficers)
                            {
                                Console.WriteLine("ID = {0}", item.ID);
                                Console.WriteLine("Name = {0}", item.Name);
                                Console.WriteLine("Gender = {0}", item.Gender);
                                Console.WriteLine("Address = {0}", item.Address);
                                Console.WriteLine("Type = {0}", "Giáo vụ");
                                Console.WriteLine("------------");
                            }
                        }
                        break;
                    case 6:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
