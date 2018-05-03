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
    
    public partial class TB_Experiment_Info
    {
        public long ID { get; set; }
        public Nullable<int> Experiment_ID { get; set; }
        public Nullable<int> Slot { get; set; }
        public Nullable<int> Gene_Locus_ID { get; set; }
        public Nullable<int> Sample_ID { get; set; }
        public string Sample_Category { get; set; }
        public string Is_Sop { get; set; }
        public string Is_Immediately { get; set; }
        public string Save_Days { get; set; }
        public string Save_Condition { get; set; }
        public string Formula_No { get; set; }
        public string Formula_Person { get; set; }
        public Nullable<int> Freeze_Times { get; set; }
        public string Other_Condition { get; set; }
        public string Wipe_Paper_Save_Hours { get; set; }
        public string DNA_Concentration { get; set; }
        public Nullable<System.DateTime> Add_Time { get; set; }
        public Nullable<System.DateTime> Update_Time { get; set; }
        public Nullable<int> Sample_Gene_Result_ID { get; set; }
    
        public virtual TB_Experiment TB_Experiment { get; set; }
        public virtual TB_Gene_Locus TB_Gene_Locus { get; set; }
        public virtual TB_Gene_Result TB_Gene_Result { get; set; }
        public virtual TB_Sample_Gene TB_Sample_Gene { get; set; }
    }
}