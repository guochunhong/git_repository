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
    
    public partial class TB_OpEnvironment_Run_Log
    {
        public int ID { get; set; }
        public Nullable<int> OpEnvironment_ID { get; set; }
        public Nullable<decimal> Votage_12V { get; set; }
        public Nullable<decimal> Votage3_3V { get; set; }
        public Nullable<decimal> Votage_5V { get; set; }
        public Nullable<decimal> Votage2_8V { get; set; }
        public Nullable<decimal> Votage2_5V { get; set; }
        public Nullable<decimal> Votage1_8V { get; set; }
        public Nullable<decimal> Motor_Votage { get; set; }
        public string Small_Fan_Temp_Sensor_Status { get; set; }
        public Nullable<decimal> Small_Fan_Temp { get; set; }
        public string Heater_Temp_Sensor_State { get; set; }
        public Nullable<decimal> Heater_Temp { get; set; }
        public string Left_Slot_Temp_Sensor_Status { get; set; }
        public Nullable<decimal> Left_Slot_Temp { get; set; }
        public string Right_Slot_Temp_Sensor_Status { get; set; }
        public Nullable<decimal> Right_Slot_Temp { get; set; }
        public string Board_Temp_Sensor_Status { get; set; }
        public Nullable<decimal> Board_Sensor_Temp { get; set; }
        public Nullable<decimal> Board_TM275_Temp { get; set; }
        public string Camara_Status { get; set; }
        public Nullable<decimal> Votage_2_6V { get; set; }
        public Nullable<decimal> Votage_Vout { get; set; }
        public Nullable<decimal> Current_6_9 { get; set; }
        public Nullable<decimal> Votage_0_V { get; set; }
        public Nullable<System.DateTime> Add_Time { get; set; }
    
        public virtual TB_OpEnvironment TB_OpEnvironment { get; set; }
    }
}
