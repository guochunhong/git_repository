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
    
    public partial class TB_USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_USER()
        {
            this.TB_Login_Log = new HashSet<TB_Login_Log>();
        }
    
        public int ID { get; set; }
        public string User_Name { get; set; }
        public string Nick_Name { get; set; }
        public string Password { get; set; }
        public string Equipment_ID { get; set; }
        public bool Is_Effective { get; set; }
        public Nullable<System.DateTime> Add_Time { get; set; }
        public Nullable<System.DateTime> Update_Time { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_Login_Log> TB_Login_Log { get; set; }
    }
}
