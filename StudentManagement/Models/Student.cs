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
                    Name = "张三",
                    Major = "一年级"
                },
                 new Student()
                {
                    Id = 2,
                    Name = "李四",
                    Major = "二年级"
                }
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
