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
    
    public partial class TB_Hospital
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Hospital()
        {
            this.TB_Equipment = new HashSet<TB_Equipment>();
            this.TB_Patient = new HashSet<TB_Patient>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Area_ID { get; set; }
        public string Hospital_Name { get; set; }
        public string Hospital_Addr { get; set; }
        public string Hospital_Tel { get; set; }
        public Nullable<System.DateTime> Add_Time { get; set; }
    
        public virtual TB_Area TB_Area { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Equipment> TB_Equipment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Patient> TB_Patient { get; set; }
    }
}
