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
    
    public partial class TB_Gene_Locus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Gene_Locus()
        {
            this.TB_Experiment_Info = new HashSet<TB_Experiment_Info>();
            this.TB_Gene_Locus_Result_Relation = new HashSet<TB_Gene_Locus_Result_Relation>();
            this.TB_Sample_Gene = new HashSet<TB_Sample_Gene>();
        }
    
        public int ID { get; set; }
        public string Gene_Name { get; set; }
        public Nullable<int> Locus_ID_In_Software { get; set; }
        public bool Is_Effective { get; set; }
        public System.DateTime Add_Time { get; set; }
        public System.DateTime Updated_Time { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Experiment_Info> TB_Experiment_Info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Gene_Locus_Result_Relation> TB_Gene_Locus_Result_Relation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Sample_Gene> TB_Sample_Gene { get; set; }
    }
}
