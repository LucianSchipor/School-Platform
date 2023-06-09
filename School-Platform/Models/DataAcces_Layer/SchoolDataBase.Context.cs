﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace School_Platform.Models.DataAcces_Layer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SchoolEntities : DbContext
    {
        public SchoolEntities()
            : base("name=SchoolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Absence> Absences { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<Specializations_Subjects> Specializations_Subjects { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Subjects_Theisis> Subjects_Theisis { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Teacher_Subjects> Teacher_Subjects { get; set; }
    
        public virtual int AdaugaDiriginte(Nullable<int> profesorID, Nullable<int> clasaID)
        {
            var profesorIDParameter = profesorID.HasValue ?
                new ObjectParameter("ProfesorID", profesorID) :
                new ObjectParameter("ProfesorID", typeof(int));
    
            var clasaIDParameter = clasaID.HasValue ?
                new ObjectParameter("ClasaID", clasaID) :
                new ObjectParameter("ClasaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AdaugaDiriginte", profesorIDParameter, clasaIDParameter);
        }
    
        public virtual int Admin_AddMasterToClass(Nullable<int> profesorID, Nullable<int> clasaID)
        {
            var profesorIDParameter = profesorID.HasValue ?
                new ObjectParameter("ProfesorID", profesorID) :
                new ObjectParameter("ProfesorID", typeof(int));
    
            var clasaIDParameter = clasaID.HasValue ?
                new ObjectParameter("ClasaID", clasaID) :
                new ObjectParameter("ClasaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Admin_AddMasterToClass", profesorIDParameter, clasaIDParameter);
        }
    
        public virtual int Admin_AddSubjectToTeacher(Nullable<int> teacherID, string subjectName)
        {
            var teacherIDParameter = teacherID.HasValue ?
                new ObjectParameter("TeacherID", teacherID) :
                new ObjectParameter("TeacherID", typeof(int));
    
            var subjectNameParameter = subjectName != null ?
                new ObjectParameter("SubjectName", subjectName) :
                new ObjectParameter("SubjectName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Admin_AddSubjectToTeacher", teacherIDParameter, subjectNameParameter);
        }
    
        public virtual int Admin_ChangeClassSpecialization(string class_Name, Nullable<int> year_Of_Study, string specialization)
        {
            var class_NameParameter = class_Name != null ?
                new ObjectParameter("Class_Name", class_Name) :
                new ObjectParameter("Class_Name", typeof(string));
    
            var year_Of_StudyParameter = year_Of_Study.HasValue ?
                new ObjectParameter("Year_Of_Study", year_Of_Study) :
                new ObjectParameter("Year_Of_Study", typeof(int));
    
            var specializationParameter = specialization != null ?
                new ObjectParameter("Specialization", specialization) :
                new ObjectParameter("Specialization", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Admin_ChangeClassSpecialization", class_NameParameter, year_Of_StudyParameter, specializationParameter);
        }
    
        public virtual int Admin_ChangeStudentClass(Nullable<int> year_Of_Study, string class_Letter, Nullable<int> studentID)
        {
            var year_Of_StudyParameter = year_Of_Study.HasValue ?
                new ObjectParameter("Year_Of_Study", year_Of_Study) :
                new ObjectParameter("Year_Of_Study", typeof(int));
    
            var class_LetterParameter = class_Letter != null ?
                new ObjectParameter("Class_Letter", class_Letter) :
                new ObjectParameter("Class_Letter", typeof(string));
    
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Admin_ChangeStudentClass", year_Of_StudyParameter, class_LetterParameter, studentIDParameter);
        }
    
        public virtual int Admin_CreateStudent(string name, string username, string password)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Admin_CreateStudent", nameParameter, usernameParameter, passwordParameter);
        }
    
        public virtual int Admin_DeleteStudent(Nullable<int> student_ID)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Admin_DeleteStudent", student_IDParameter);
        }
    
        public virtual ObjectResult<Admin_GetAllClasses_Result> Admin_GetAllClasses()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Admin_GetAllClasses_Result>("Admin_GetAllClasses");
        }
    
        public virtual ObjectResult<Admin_GetAllMasters_Result> Admin_GetAllMasters()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Admin_GetAllMasters_Result>("Admin_GetAllMasters");
        }
    
        public virtual ObjectResult<Admin_GetAllStudents_Result> Admin_GetAllStudents()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Admin_GetAllStudents_Result>("Admin_GetAllStudents");
        }
    
        public virtual ObjectResult<Admin_GetAllTeachers_Result> Admin_GetAllTeachers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Admin_GetAllTeachers_Result>("Admin_GetAllTeachers");
        }
    
        public virtual ObjectResult<User> Admin_GetAllUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("Admin_GetAllUsers");
        }
    
        public virtual ObjectResult<User> Admin_GetAllUsers(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("Admin_GetAllUsers", mergeOption);
        }
    
        public virtual ObjectResult<Admin_GetTeacherSubjects_Result> Admin_GetTeacherSubjects(Nullable<int> teacherID)
        {
            var teacherIDParameter = teacherID.HasValue ?
                new ObjectParameter("TeacherID", teacherID) :
                new ObjectParameter("TeacherID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Admin_GetTeacherSubjects_Result>("Admin_GetTeacherSubjects", teacherIDParameter);
        }
    
        public virtual ObjectResult<Class> Master_ViewClassHierarchyByGrade(Nullable<int> year_Of_Study, string class_Letter)
        {
            var year_Of_StudyParameter = year_Of_Study.HasValue ?
                new ObjectParameter("Year_Of_Study", year_Of_Study) :
                new ObjectParameter("Year_Of_Study", typeof(int));
    
            var class_LetterParameter = class_Letter != null ?
                new ObjectParameter("Class_Letter", class_Letter) :
                new ObjectParameter("Class_Letter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Class>("Master_ViewClassHierarchyByGrade", year_Of_StudyParameter, class_LetterParameter);
        }
    
        public virtual ObjectResult<Class> Master_ViewClassHierarchyByGrade(Nullable<int> year_Of_Study, string class_Letter, MergeOption mergeOption)
        {
            var year_Of_StudyParameter = year_Of_Study.HasValue ?
                new ObjectParameter("Year_Of_Study", year_Of_Study) :
                new ObjectParameter("Year_Of_Study", typeof(int));
    
            var class_LetterParameter = class_Letter != null ?
                new ObjectParameter("Class_Letter", class_Letter) :
                new ObjectParameter("Class_Letter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Class>("Master_ViewClassHierarchyByGrade", mergeOption, year_Of_StudyParameter, class_LetterParameter);
        }
    
        public virtual ObjectResult<Absence> Master_ViewSpecialCases(Nullable<int> year_Of_Study, string class_Letter)
        {
            var year_Of_StudyParameter = year_Of_Study.HasValue ?
                new ObjectParameter("Year_Of_Study", year_Of_Study) :
                new ObjectParameter("Year_Of_Study", typeof(int));
    
            var class_LetterParameter = class_Letter != null ?
                new ObjectParameter("Class_Letter", class_Letter) :
                new ObjectParameter("Class_Letter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Absence>("Master_ViewSpecialCases", year_Of_StudyParameter, class_LetterParameter);
        }
    
        public virtual ObjectResult<Absence> Master_ViewSpecialCases(Nullable<int> year_Of_Study, string class_Letter, MergeOption mergeOption)
        {
            var year_Of_StudyParameter = year_Of_Study.HasValue ?
                new ObjectParameter("Year_Of_Study", year_Of_Study) :
                new ObjectParameter("Year_Of_Study", typeof(int));
    
            var class_LetterParameter = class_Letter != null ?
                new ObjectParameter("Class_Letter", class_Letter) :
                new ObjectParameter("Class_Letter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Absence>("Master_ViewSpecialCases", mergeOption, year_Of_StudyParameter, class_LetterParameter);
        }
    
        public virtual ObjectResult<Class> Master_ViewStudentGrades(Nullable<int> student_ID)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Class>("Master_ViewStudentGrades", student_IDParameter);
        }
    
        public virtual ObjectResult<Class> Master_ViewStudentGrades(Nullable<int> student_ID, MergeOption mergeOption)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Class>("Master_ViewStudentGrades", mergeOption, student_IDParameter);
        }
    
        public virtual ObjectResult<Absence> Student_ViewAbsences(Nullable<int> student_ID)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Absence>("Student_ViewAbsences", student_IDParameter);
        }
    
        public virtual ObjectResult<Absence> Student_ViewAbsences(Nullable<int> student_ID, MergeOption mergeOption)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Absence>("Student_ViewAbsences", mergeOption, student_IDParameter);
        }
    
        public virtual ObjectResult<Class> Student_ViewAverages(Nullable<int> student_ID)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Class>("Student_ViewAverages", student_IDParameter);
        }
    
        public virtual ObjectResult<Class> Student_ViewAverages(Nullable<int> student_ID, MergeOption mergeOption)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Class>("Student_ViewAverages", mergeOption, student_IDParameter);
        }
    
        public virtual ObjectResult<Specializations_Subjects> Teacher_AddAbsence(Nullable<int> student_ID, string subject_Name, Nullable<System.DateTime> absence_Date)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            var absence_DateParameter = absence_Date.HasValue ?
                new ObjectParameter("Absence_Date", absence_Date) :
                new ObjectParameter("Absence_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Specializations_Subjects>("Teacher_AddAbsence", student_IDParameter, subject_NameParameter, absence_DateParameter);
        }
    
        public virtual ObjectResult<Specializations_Subjects> Teacher_AddAbsence(Nullable<int> student_ID, string subject_Name, Nullable<System.DateTime> absence_Date, MergeOption mergeOption)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            var absence_DateParameter = absence_Date.HasValue ?
                new ObjectParameter("Absence_Date", absence_Date) :
                new ObjectParameter("Absence_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Specializations_Subjects>("Teacher_AddAbsence", mergeOption, student_IDParameter, subject_NameParameter, absence_DateParameter);
        }
    
        public virtual int Teacher_AddGrade(string subject_Name, Nullable<int> student_ID, Nullable<double> grade_Value)
        {
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            var grade_ValueParameter = grade_Value.HasValue ?
                new ObjectParameter("Grade_Value", grade_Value) :
                new ObjectParameter("Grade_Value", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Teacher_AddGrade", subject_NameParameter, student_IDParameter, grade_ValueParameter);
        }
    
        public virtual ObjectResult<Student> Teacher_CalculateClassAverage(string subject_Name, string class_Letter, Nullable<int> year_Of_Study)
        {
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            var class_LetterParameter = class_Letter != null ?
                new ObjectParameter("Class_Letter", class_Letter) :
                new ObjectParameter("Class_Letter", typeof(string));
    
            var year_Of_StudyParameter = year_Of_Study.HasValue ?
                new ObjectParameter("Year_Of_Study", year_Of_Study) :
                new ObjectParameter("Year_Of_Study", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Student>("Teacher_CalculateClassAverage", subject_NameParameter, class_LetterParameter, year_Of_StudyParameter);
        }
    
        public virtual ObjectResult<Student> Teacher_CalculateClassAverage(string subject_Name, string class_Letter, Nullable<int> year_Of_Study, MergeOption mergeOption)
        {
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            var class_LetterParameter = class_Letter != null ?
                new ObjectParameter("Class_Letter", class_Letter) :
                new ObjectParameter("Class_Letter", typeof(string));
    
            var year_Of_StudyParameter = year_Of_Study.HasValue ?
                new ObjectParameter("Year_Of_Study", year_Of_Study) :
                new ObjectParameter("Year_Of_Study", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Student>("Teacher_CalculateClassAverage", mergeOption, subject_NameParameter, class_LetterParameter, year_Of_StudyParameter);
        }
    
        public virtual int Teacher_DeleteGrade(string subject_Name, Nullable<int> student_ID, Nullable<System.DateTime> grade_Date)
        {
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            var grade_DateParameter = grade_Date.HasValue ?
                new ObjectParameter("Grade_Date", grade_Date) :
                new ObjectParameter("Grade_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Teacher_DeleteGrade", subject_NameParameter, student_IDParameter, grade_DateParameter);
        }
    
        public virtual int Teacher_JustifyAbsence(Nullable<int> student_ID, string subject_Name, Nullable<System.DateTime> absence_Date)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            var absence_DateParameter = absence_Date.HasValue ?
                new ObjectParameter("Absence_Date", absence_Date) :
                new ObjectParameter("Absence_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Teacher_JustifyAbsence", student_IDParameter, subject_NameParameter, absence_DateParameter);
        }
    
        public virtual ObjectResult<Student> Teacher_ViewGrades(string subject_Name, Nullable<int> student_ID)
        {
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Student>("Teacher_ViewGrades", subject_NameParameter, student_IDParameter);
        }
    
        public virtual ObjectResult<Student> Teacher_ViewGrades(string subject_Name, Nullable<int> student_ID, MergeOption mergeOption)
        {
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Student>("Teacher_ViewGrades", mergeOption, subject_NameParameter, student_IDParameter);
        }
    
        public virtual ObjectResult<Admin_GetAllStudents_Result> Admin_GetAllStudentsFromClass(Nullable<int> year_Of_Study, string class_Letter)
        {
            var year_Of_StudyParameter = year_Of_Study.HasValue ?
                new ObjectParameter("Year_Of_Study", year_Of_Study) :
                new ObjectParameter("Year_Of_Study", typeof(int));
    
            var class_LetterParameter = class_Letter != null ?
                new ObjectParameter("Class_Letter", class_Letter) :
                new ObjectParameter("Class_Letter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Admin_GetAllStudents_Result>("Admin_GetAllStudentsFromClass", year_Of_StudyParameter, class_LetterParameter);
        }
    
        public virtual int Admin_CreateClass(Nullable<int> year_Of_Study, string class_Letter, string specialization)
        {
            var year_Of_StudyParameter = year_Of_Study.HasValue ?
                new ObjectParameter("Year_Of_Study", year_Of_Study) :
                new ObjectParameter("Year_Of_Study", typeof(int));
    
            var class_LetterParameter = class_Letter != null ?
                new ObjectParameter("Class_Letter", class_Letter) :
                new ObjectParameter("Class_Letter", typeof(string));
    
            var specializationParameter = specialization != null ?
                new ObjectParameter("Specialization", specialization) :
                new ObjectParameter("Specialization", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Admin_CreateClass", year_Of_StudyParameter, class_LetterParameter, specializationParameter);
        }
    
        public virtual int Admin_DeleteClass(Nullable<int> year_Of_Study, string class_Letter)
        {
            var year_Of_StudyParameter = year_Of_Study.HasValue ?
                new ObjectParameter("Year_Of_Study", year_Of_Study) :
                new ObjectParameter("Year_Of_Study", typeof(int));
    
            var class_LetterParameter = class_Letter != null ?
                new ObjectParameter("Class_Letter", class_Letter) :
                new ObjectParameter("Class_Letter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Admin_DeleteClass", year_Of_StudyParameter, class_LetterParameter);
        }
    
        public virtual int Admin_CreateTeacher(string name, string username, string password)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Admin_CreateTeacher", nameParameter, usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<string> Admin_GetAllSubjects()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Admin_GetAllSubjects");
        }
    
        public virtual int Admin_AddTeacherToTeachSubject(Nullable<int> teacher_Id, string subject_Name, Nullable<int> class_ID)
        {
            var teacher_IdParameter = teacher_Id.HasValue ?
                new ObjectParameter("Teacher_Id", teacher_Id) :
                new ObjectParameter("Teacher_Id", typeof(int));
    
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            var class_IDParameter = class_ID.HasValue ?
                new ObjectParameter("Class_ID", class_ID) :
                new ObjectParameter("Class_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Admin_AddTeacherToTeachSubject", teacher_IdParameter, subject_NameParameter, class_IDParameter);
        }
    
        public virtual ObjectResult<Teacher_ViewAbsences_Result> Teacher_ViewAbsences(Nullable<int> student_ID, string subject_Name)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Teacher_ViewAbsences_Result>("Teacher_ViewAbsences", student_IDParameter, subject_NameParameter);
        }
    
        public virtual ObjectResult<Admin_GetTeacherClasses_Result> Admin_GetTeacherClasses(Nullable<int> teacher_ID)
        {
            var teacher_IDParameter = teacher_ID.HasValue ?
                new ObjectParameter("Teacher_ID", teacher_ID) :
                new ObjectParameter("Teacher_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Admin_GetTeacherClasses_Result>("Admin_GetTeacherClasses", teacher_IDParameter);
        }
    
        public virtual ObjectResult<Student_ViewGrades_Result> Student_ViewGrades(Nullable<int> student_ID, string subject_Name)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            var subject_NameParameter = subject_Name != null ?
                new ObjectParameter("Subject_Name", subject_Name) :
                new ObjectParameter("Subject_Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Student_ViewGrades_Result>("Student_ViewGrades", student_IDParameter, subject_NameParameter);
        }
    
        public virtual ObjectResult<Subject> importSubjectsForStudent(Nullable<int> student_ID)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Subject>("importSubjectsForStudent", student_IDParameter);
        }
    
        public virtual ObjectResult<Subject> importSubjectsForStudent(Nullable<int> student_ID, MergeOption mergeOption)
        {
            var student_IDParameter = student_ID.HasValue ?
                new ObjectParameter("Student_ID", student_ID) :
                new ObjectParameter("Student_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Subject>("importSubjectsForStudent", mergeOption, student_IDParameter);
        }
    }
}
