﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAsync.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GnexEntities : DbContext
    {
        public GnexEntities()
            : base("name=GnexEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_Area> TB_Area { get; set; }
        public virtual DbSet<TB_Dyestuff_Validation> TB_Dyestuff_Validation { get; set; }
        public virtual DbSet<TB_Equipment> TB_Equipment { get; set; }
        public virtual DbSet<TB_Experiment_Info> TB_Experiment_Info { get; set; }
        public virtual DbSet<TB_Experiment_Model> TB_Experiment_Model { get; set; }
        public virtual DbSet<TB_Experiment_Result> TB_Experiment_Result { get; set; }
        public virtual DbSet<TB_Experiment_Summary> TB_Experiment_Summary { get; set; }
        public virtual DbSet<TB_Fluorescence> TB_Fluorescence { get; set; }
        public virtual DbSet<TB_Gene_Locus> TB_Gene_Locus { get; set; }
        public virtual DbSet<TB_Gene_Locus_Result_Relation> TB_Gene_Locus_Result_Relation { get; set; }
        public virtual DbSet<TB_Gene_Result> TB_Gene_Result { get; set; }
        public virtual DbSet<TB_Gene_Type> TB_Gene_Type { get; set; }
        public virtual DbSet<TB_Hospital> TB_Hospital { get; set; }
        public virtual DbSet<TB_Login_Log> TB_Login_Log { get; set; }
        public virtual DbSet<TB_OpEnvironment> TB_OpEnvironment { get; set; }
        public virtual DbSet<TB_OpEnvironment_Run_Log> TB_OpEnvironment_Run_Log { get; set; }
        public virtual DbSet<TB_OpEnvironment_Temperature> TB_OpEnvironment_Temperature { get; set; }
        public virtual DbSet<TB_Patient> TB_Patient { get; set; }
        public virtual DbSet<TB_Sample_Gene> TB_Sample_Gene { get; set; }
        public virtual DbSet<TB_SSIS_Errors> TB_SSIS_Errors { get; set; }
        public virtual DbSet<TB_System_Param> TB_System_Param { get; set; }
        public virtual DbSet<TB_Uploaded_Log> TB_Uploaded_Log { get; set; }
        public virtual DbSet<TB_USER> TB_USER { get; set; }
        public virtual DbSet<TB_Experiment> TB_Experiment { get; set; }
    }
}
