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
    
    public partial class TB_Gene_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Gene_Type()
        {
            this.TB_Gene_Locus_Result_Relation = new HashSet<TB_Gene_Locus_Result_Relation>();
        }
    
        public int ID { get; set; }
        public string Gene_Type { get; set; }
        public Nullable<System.DateTime> Add_Time { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Gene_Locus_Result_Relation> TB_Gene_Locus_Result_Relation { get; set; }
    }
}
