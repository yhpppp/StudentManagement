using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
        public string Email { get; set; }
    }

    public interface IStudentRepository
    {
        // 返回指定一位学生信息
        Student GetStudent(int id);
        // 返回全部学生信息
        IEnumerable<Student> GetAllStudents();
    }

    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentList;

        public MockStudentRepository()
        {
            _studentList = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Name = "刘一",
                    Major = "一年级",
                    Email = "11111111111@gmail.com",
                },
                 new Student()
                {
                    Id = 2,
                    Name = "陈二",
                    Major = "二年级",
                    Email = "2222222222@gmail.com"
                },
                  new Student()
                {
                    Id = 3,
                    Name = "张三",
                    Major = "3年级",
                    Email = "33333333333@gmail.com"
                },
                //   new Student()
                //{
                //    Id = 4,
                //    Name = "李四",
                //    Major = "4年级",
                //    Email = "44444444444@gmail.com"
                //},
                //   new Student()
                //{
                //    Id = 5,
                //    Name = "王五",
                //    Major = "5年级",
                //    Email = "555555555555555@gmail.com"
                //},
                //   new Student()
                //{
                //    Id = 6,
                //    Name = "赵六",
                //    Major = "6年级",
                //    Email = "6666666666666@gmail.com"
                //},
                //   new Student()
                //{
                //    Id = 7,
                //    Name = "孙七",
                //    Major = "7年级",
                //    Email = "777777777777@gmail.com"
                //},
                //   new Student()
                //{
                //    Id = 8,
                //    Name = "周八",
                //    Major = "8年级",
                //    Email = "888888888888@gmail.com"
                //},
                //   new Student()
                //{
                //    Id = 9,
                //    Name = "李四",
                //    Major = "9年级",
                //    Email = "99999999999@gmail.com"
                //},
                //   new Student()
                //{
                //    Id = 10,
                //    Name = "郑十",
                //    Major = "10年级",
                //    Email = "1010100101010@gmail.com"
                //}
            };
        }
        public Student GetStudent(int id)
        {
            return _studentList.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentList;
        }
    }
}
