//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAsync.Helper
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_Experiment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Experiment()
        {
            this.TB_Experiment_Info = new HashSet<TB_Experiment_Info>();
            this.TB_Experiment_Result = new HashSet<TB_Experiment_Result>();
            this.TB_Fluorescence = new HashSet<TB_Fluorescence>();
            this.TB_Patient = new HashSet<TB_Patient>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Experiment_Summary_ID { get; set; }
        public Nullable<int> Equipment_ID { get; set; }
        public Nullable<int> Openvironment_ID { get; set; }
        public string Exper_Person { get; set; }
        public Nullable<System.DateTime> Exper_Time { get; set; }
        public Nullable<int> Exper_Type { get; set; }
        public Nullable<long> File_Path_ID { get; set; }
        public bool Is_Effective { get; set; }
        public Nullable<System.DateTime> Run_Time { get; set; }
        public Nullable<System.DateTime> Add_Time { get; set; }
        public Nullable<System.DateTime> Update_Time { get; set; }
    
        public virtual TB_Equipment TB_Equipment { get; set; }
        public virtual TB_Experiment_Summary TB_Experiment_Summary { get; set; }
        public virtual TB_Uploaded_Log TB_Uploaded_Log { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Experiment_Info> TB_Experiment_Info { get; set; }
        public virtual TB_OpEnvironment TB_OpEnvironment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Experiment_Result> TB_Experiment_Result { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Fluorescence> TB_Fluorescence { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Patient> TB_Patient { get; set; }
    }
}
