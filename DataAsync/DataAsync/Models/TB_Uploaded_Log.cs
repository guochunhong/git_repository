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
    
    public partial class TB_Uploaded_Log
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Uploaded_Log()
        {
            this.TB_Experiment = new HashSet<TB_Experiment>();
        }
    
        public long ID { get; set; }
        public string File_Name { get; set; }
        public string Equipment_Code { get; set; }
        public System.DateTime Created_Time { get; set; }
        public System.DateTime Updated_Time { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Experiment> TB_Experiment { get; set; }
    }
}