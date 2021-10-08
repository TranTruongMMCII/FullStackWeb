using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirst.DB;
using EFCodeFirst.Model;

namespace EFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int luachon;
            int id;
            Employee e;
            using (var db = new EmployeeContext())
            {
                while (true)
                {
                    Console.WriteLine("1. Xem ");
                    Console.WriteLine("2. Thêm ");
                    Console.WriteLine("3. Xóa ");
                    Console.WriteLine("4. Sửa ");
                    Console.Write("Nhập lựa chọn: ");
                    luachon = Convert.ToInt32(Console.ReadLine());
                    switch (luachon)
                    {
                        case 1:
                            var lstEmployees = from s in db.Employees select s;
                            foreach (var item in lstEmployees)
                            {
                                Console.WriteLine("Mã: {0}", item.ID);
                                Console.WriteLine("Tên: {0}", item.Name);
                                Console.WriteLine("Lương: {0}", item.Salary);
                                Console.WriteLine("Ngày tạo: {0}", item.CreatedDate);
                                Console.WriteLine("Trạng thái: {0}", item.Status ? "true" : "false");
                                Console.WriteLine("------------------------------");
                            }
                            break;
                        case 2:
                            e = new Employee();
                            Console.Write("Nhập tên: ");
                            e.Name = Console.ReadLine();
                            Console.Write("Nhập lương: ");
                            e.Salary = float.Parse(Console.ReadLine());
                            Console.Write("Nhập trạng thái {true, false}: ");
                            e.Status = Console.ReadLine().Equals("true");
                            e.CreatedDate = DateTime.Now;
                            db.Employees.Add(e);
                            db.SaveChanges();
                            break;
                        case 3:
                            Console.Write("Nhập mã nhân viên muốn xóa: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            e = (from s in db.Employees where s.ID == id select s).FirstOrDefault();
                            if (e == null)
                            {
                                Console.WriteLine("Nhân viên mã {0} không tồn tại!", id);
                            }
                            else
                            {
                                db.Employees.Remove(e);
                                db.SaveChanges();
                            }
                            break;
                        case 4:
                            Console.Write("Nhập mã nhân viên muốn sửa: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            e = (from s in db.Employees where s.ID == id select s).FirstOrDefault();
                            if (e == null)
                            {
                                Console.WriteLine("Nhân viên mã {0} không tồn tại!", id);
                            }
                            else
                            {
                                Console.Write("Nhập tên: ");
                                e.Name = Console.ReadLine();
                                Console.Write("Nhập lương: ");
                                e.Salary = float.Parse(Console.ReadLine());
                                Console.Write("Nhập trạng thái {true, false}: ");
                                e.Status = Console.ReadLine().Equals("true");
                                e.CreatedDate = DateTime.Now;
                                db.SaveChanges();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
