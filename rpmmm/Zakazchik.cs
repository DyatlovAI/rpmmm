//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rpmmm
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zakazchik
    {
        public int ID_zakazchik { get; set; }
        public Nullable<int> Id_zakaz { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Reyt { get; set; }
        public string Rekvezit { get; set; }
        public string Loginad { get; set; }
        public string passwordd { get; set; }
    
        public virtual Zakaz Zakaz { get; set; }
    }
}
