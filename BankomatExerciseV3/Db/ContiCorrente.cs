//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankomatExerciseV3.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContiCorrente
    {
        public long Id { get; set; }
        public long IdUtente { get; set; }
        public int Saldo { get; set; }
        public System.DateTime DataUltimaOperazione { get; set; }
        public Nullable<System.DateTime> DataUltimoVersamento { get; set; }
    
        public virtual Utenti Utenti { get; set; }
    }
}
