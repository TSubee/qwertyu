//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CPKIO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ordder
    {
        public string IDOrder { get; set; }
        public string DateOrder { get; set; }
        public Nullable<System.TimeSpan> TimeOrder { get; set; }
        public string CodeClient { get; set; }
        public Nullable<int> IDService { get; set; }
        public string StatusOrder { get; set; }
        public Nullable<System.DateTime> DateReady { get; set; }
        public string Time { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Service Service { get; set; }
    }
}
