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
    
    public partial class TB_Experiment_Model
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_Experiment_Model()
        {
            this.TB_Experiment_Model1 = new HashSet<TB_Experiment_Model>();
        }
    
        public int ID { get; set; }
        public string Model_Name { get; set; }
        public Nullable<int> Parent_ID { get; set; }
        public Nullable<System.DateTime> Add_Time { get; set; }
        public bool Is_Effective { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Experiment_Model> TB_Experiment_Model1 { get; set; }
        public virtual TB_Experiment_Model TB_Experiment_Model2 { get; set; }
    }
}
