using SotsRestApi.Models;
using System;
using System.Collections.Generic;

namespace SotsRestApi.DAL
{
    public class SotsInitializer : System.Data.Entity.CreateDatabaseIfNotExists<SotsContext>
    {
        protected override void Seed(SotsContext context)
        {
            List<Student> students = new List<Student>
            {
                new Student{FirstName="Patryk", LastName="Kopeć", AlbumNo=265663, ActualSemester=5, Login="patkop", Password="123", CourseID=1 },
                new Student{FirstName="Maciej", LastName="Małek", AlbumNo=265675, ActualSemester=5, Login="macmal", Password="123", CourseID=1 },
                new Student{FirstName="Patryk", LastName="Olszowy", AlbumNo=265432, ActualSemester=5, Login="patols", Password="123", CourseID=1 },
                new Student{FirstName="Maciej", LastName="Stolarczyk", AlbumNo=242132, ActualSemester=5, Login="macsto", Password="123", CourseID=1 },
                new Student{FirstName="Wiktor", LastName="Pastwa", AlbumNo=242145, ActualSemester=4, Login="wikpas", Password="123", CourseID=1 }
            };

            students.ForEach(s => context.Student.Add(s));
            context.SaveChanges();
            List<Course> courses = new List<Course>
            {
                new Course {Name="Informatyka"},
                new Course {Name="Elektronika"},
                new Course {Name="Energetyka"},
                new Course {Name="Mechatronika"}
            };

            courses.ForEach(c => context.Course.Add(c));
            context.SaveChanges();
            List<Class> classes = new List<Class>
            {
                new Class{Name="Programowanie Mikrokontrolerów", ECTSValue=3, CourseID=1, SemesterID=5,TeacherID=1},
                new Class{Name="Podstawy Programowania", ECTSValue=5, CourseID=1, SemesterID=1, TeacherID=2},
                new Class{Name="Elektronika", ECTSValue=4, CourseID=1, SemesterID=2, TeacherID=3},
                new Class{Name="Obwody Elektryczne", ECTSValue=6, CourseID=1, SemesterID=1, TeacherID=4},
                new Class{Name="Analogowe Przetwarzanie Sygnałów", ECTSValue=5, CourseID=1, SemesterID=2, TeacherID=4},
            };

            classes.ForEach(c => context.Class.Add(c));
            context.SaveChanges();
            List<Grade> grades = new List<Grade>
            {
                new Grade{Value=3.5F, ClassID=1,CourseID=1, StudentID=1},
                new Grade{Value=5.0F, ClassID=2,CourseID=1, StudentID=1},
                new Grade{Value=4.0F, ClassID=3,CourseID=1, StudentID=1},
                new Grade{Value=4.0F, ClassID=3,CourseID=1, StudentID=2},
                new Grade{Value=4.0F, ClassID=3,CourseID=1, StudentID=3}
            };

            grades.ForEach(g => context.Grade.Add(g));
            context.SaveChanges();
            List<Semester> semesters = new List<Semester>
            {
                new Semester{BeginningDate=new DateTime(2016,10,1),EndDate=new DateTime(2017,3,1)},
                new Semester{BeginningDate=new DateTime(2017,3,2),EndDate=new DateTime(2017,9,30)},
                new Semester{BeginningDate=new DateTime(2017,10,1),EndDate=new DateTime(2018,3,1)},
                new Semester{BeginningDate=new DateTime(2018,3,2),EndDate=new DateTime(2018,9,30)},
                new Semester{BeginningDate=new DateTime(2018,10,1),EndDate=new DateTime(2019,3,1)},
                new Semester{BeginningDate=new DateTime(2019,3,2),EndDate=new DateTime(2019,9,30)},
                new Semester{BeginningDate=new DateTime(2020,10,1),EndDate=new DateTime(2020,3,1)}
            };
            semesters.ForEach(s => context.Semester.Add(s));
            context.SaveChanges();
            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher{FirstName="Marian", LastName="Hyla", Login="marhyl", Password="123"},
                new Teacher{FirstName="Artur", LastName="Pasierbek", Login="artpas", Password="123"},
                new Teacher{FirstName="Jerzy", LastName="Roj", Login="jerroj", Password="123"},
                new Teacher{FirstName="Stefan", LastName="Paszek", Login="stepas", Password="123"},
            };
            teachers.ForEach(t => context.Teacher.Add(t));
            context.SaveChanges();
        }
    }
}

