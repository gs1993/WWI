//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Countries_Archive
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string FormalName { get; set; }
        public string IsoAlpha3Code { get; set; }
        public Nullable<int> IsoNumericCode { get; set; }
        public string CountryType { get; set; }
        public Nullable<long> LatestRecordedPopulation { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public System.Data.Entity.Spatial.DbGeography Border { get; set; }
        public int LastEditedBy { get; set; }
        public System.DateTime ValidFrom { get; set; }
        public System.DateTime ValidTo { get; set; }
    }
}
