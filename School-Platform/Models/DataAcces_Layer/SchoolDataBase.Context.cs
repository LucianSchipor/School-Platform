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
    using School_Platform.Models.Entities_Layer;
    using School_Platform.Models.Dbos_Layer;

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
        public virtual DbSet<Teachers_Subjects> Teacher_Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
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
    
        public virtual int AddMasterToClass(Nullable<int> profesorID, Nullable<int> clasaID)
        {
            var profesorIDParameter = profesorID.HasValue ?
                new ObjectParameter("ProfesorID", profesorID) :
                new ObjectParameter("ProfesorID", typeof(int));
    
            var clasaIDParameter = clasaID.HasValue ?
                new ObjectParameter("ClasaID", clasaID) :
                new ObjectParameter("ClasaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddMasterToClass", profesorIDParameter, clasaIDParameter);
        }
    
        public virtual ObjectResult<Teacher> GetAllMasters()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Teacher>("GetAllMasters");
        }
    
        public virtual ObjectResult<Student> GetAllStudents()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Student>("GetAllStudents");
        }
    
        public virtual ObjectResult<Teacher> GetAllTeachers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Teacher>("GetAllTeachers");
        }
    
        public virtual ObjectResult<GetAllUsers_Result> GetAllUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllUsers_Result>("GetAllUsers");
        }
    }
}
