//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TB_OpEnvironment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_OpEnvironment()
        {
            this.TB_OpEnvironment_Run_Log = new HashSet<TB_OpEnvironment_Run_Log>();
            this.TB_OpEnvironment_Temperature = new HashSet<TB_OpEnvironment_Temperature>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Equipment_ID { get; set; }
        public Nullable<int> Experiment_ID { get; set; }
        public Nullable<System.DateTime> Run_Time { get; set; }
        public Nullable<int> Total_Run_Time_Of_Sec { get; set; }
        public Nullable<int> Run_Number { get; set; }
        public Nullable<int> Number_Of_Cycles { get; set; }
        public string Initial_Denaturation_Temp { get; set; }
        public string Initial_Denaturation_Time_Of_Sec { get; set; }
        public Nullable<decimal> Denaturation_Temp { get; set; }
        public string Denaturation_Time_Of_Sec { get; set; }
        public Nullable<decimal> Annealing_Temp { get; set; }
        public string Annealing_Time_Of_Sec { get; set; }
        public Nullable<decimal> Extension_Temp { get; set; }
        public string Extension_Time_Of_Sec { get; set; }
        public string Reverse_Transcription { get; set; }
        public string Melt_Curve { get; set; }
        public Nullable<decimal> Temperature_Dots { get; set; }
        public string Slot_Count { get; set; }
        public Nullable<bool> RT_Enabled { get; set; }
        public Nullable<bool> TC_Enabled { get; set; }
        public Nullable<bool> MC_Enabled { get; set; }
        public string RT_EP { get; set; }
        public string Run_Initialize_Time { get; set; }
        public Nullable<int> Param_ID { get; set; }
        public string Rar_File_Name { get; set; }
        public Nullable<decimal> Cut_Left { get; set; }
        public Nullable<decimal> Cut_Right { get; set; }
        public Nullable<System.DateTime> Add_Time { get; set; }
    
        public virtual TB_Equipment TB_Equipment { get; set; }
        public virtual TB_System_Param TB_System_Param { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_OpEnvironment_Run_Log> TB_OpEnvironment_Run_Log { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_OpEnvironment_Temperature> TB_OpEnvironment_Temperature { get; set; }
        public virtual TB_Experiment TB_Experiment { get; set; }
    }
}
