//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GabinetKosmetyczny
{
    using System;
    using System.Collections.Generic;
    
    public partial class zabiegi
    {
        public int id_zabiegu { get; set; }
        public Nullable<int> klient { get; set; }
        public Nullable<int> zabieg { get; set; }
        public Nullable<System.DateTime> termin { get; set; }
        public string wykonano { get; set; }
    
        public virtual klienci klienci { get; set; }
        public virtual typ_zabiegu typ_zabiegu { get; set; }
    }
}
