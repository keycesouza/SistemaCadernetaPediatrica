//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaCadernetaPediatrica
{
    using System;
    using System.Collections.Generic;
    
    public partial class ControlePediatrio
    {
        public long IdControlePediatrio { get; set; }
        public long IdPaciente { get; set; }
        public System.DateTime Data { get; set; }
        public string Idade { get; set; }
        public decimal Peso { get; set; }
        public decimal Estatura { get; set; }
        public decimal PCef { get; set; }
        public Nullable<decimal> IMC { get; set; }
        public string Observacoes { get; set; }
    
        public virtual Paciente Paciente { get; set; }
    }
}