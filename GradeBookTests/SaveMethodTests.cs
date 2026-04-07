using System.IO;
using GradeBook;
using GradeBook.Enums;
using GradeBook.GradeBooks;
using Xunit;

namespace GradeBookTests
{
    public class SaveMethodTests
    {
        [Fact(DisplayName = "AddStudent Calls Save")]
        public void AddStudentCallsSaveTest()
        {
            var book = new StandardGradeBook("TestAddStudent", true);
            var student = new Student("Tom", StudentType.Standard, EnrollmentType.Campus);
            
            var fileName = "TestAddStudent.gdbk";
            if (File.Exists(fileName)) File.Delete(fileName);
            
            book.AddStudent(student);
            
            Assert.True(File.Exists(fileName), "Save was not called after adding a student.");
            
            if (File.Exists(fileName)) File.Delete(fileName);
        }

        [Fact(DisplayName = "RemoveStudent Calls Save")]
        public void RemoveStudentCallsSaveTest()
        {
            var book = new StandardGradeBook("TestRemoveStudent", true);
            var student = new Student("Tom", StudentType.Standard, EnrollmentType.Campus);
            book.Students.Add(student);
            
            var fileName = "TestRemoveStudent.gdbk";
            if (File.Exists(fileName)) File.Delete(fileName);
            
            book.RemoveStudent("Tom");
            
            Assert.True(File.Exists(fileName), "Save was not called after removing a student.");
            
            if (File.Exists(fileName)) File.Delete(fileName);
        }

        [Fact(DisplayName = "AddGrade Calls Save")]
        public void AddGradeCallsSaveTest()
        {
            var book = new StandardGradeBook("TestAddGrade", true);
            var student = new Student("Tom", StudentType.Standard, EnrollmentType.Campus);
            book.Students.Add(student);
            
            var fileName = "TestAddGrade.gdbk";
            if (File.Exists(fileName)) File.Delete(fileName);
            
            book.AddGrade("Tom", 95.0);
            
            Assert.True(File.Exists(fileName), "Save was not called after adding a grade.");
            
            if (File.Exists(fileName)) File.Delete(fileName);
        }

        [Fact(DisplayName = "RemoveGrade Calls Save")]
        public void RemoveGradeCallsSaveTest()
        {
            var book = new StandardGradeBook("TestRemoveGrade", true);
            var student = new Student("Tom", StudentType.Standard, EnrollmentType.Campus);
            student.Grades.Add(95.0);
            book.Students.Add(student);
            
            var fileName = "TestRemoveGrade.gdbk";
            if (File.Exists(fileName)) File.Delete(fileName);
            
            book.RemoveGrade("Tom", 95.0);
            
            Assert.True(File.Exists(fileName), "Save was not called after removing a grade.");
            
            if (File.Exists(fileName)) File.Delete(fileName);
        }
    }
}
