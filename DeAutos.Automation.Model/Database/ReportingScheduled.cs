//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;

namespace DeAutos.Automation.Model.Database
{
    public partial class ReportingScheduled
    {
        public string Nombre_Reporte { get; set; }
        public string Nombre_Reporte_Interno { get; set; }
        public string To { get; set; }
        public Nullable<DateTime> Date_Envio { get; set; }
        public Nullable<DateTime> Date_Ultimo_Envio { get; set; }
        public string Enviado { get; set; }
        public string SQL { get; set; }
        public Nullable<int> INTERVALO_DIAS { get; set; }
    }
}
