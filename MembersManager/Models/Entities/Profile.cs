//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MembersManager.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profile
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string MailUpID { get; set; }
        public Nullable<bool> OptIn { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public string ExternalId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string CVRnummer { get; set; }
        public string BrugerID { get; set; }
        public string Medlemsstatus { get; set; }
        public string Foreningsnummer { get; set; }
        public string Foedselsaar { get; set; }
        public string HektarDrevet { get; set; }
        public string AntalAndetKvaeg { get; set; }
        public string AntalAmmekoeer { get; set; }
        public string AntaMalkekoeer { get; set; }
        public string AntalSlagtesvin { get; set; }
        public string AntalSoeer { get; set; }
        public string AntalAarssoeer { get; set; }
        public string AntalPelsdyr { get; set; }
        public string AntalHoens { get; set; }
        public string AntalKyllinger { get; set; }
        public string Ecology { get; set; }
        public string Sektion_SSJ { get; set; }
        public string Driftform_planteavl { get; set; }
        public string Driftform_Koed_Koer { get; set; }
        public string Driftform_Mælk { get; set; }
        public string Driftform_Svin { get; set; }
        public string Driftform_Pelsdyr { get; set; }
        public string Driftform_Aeg_Kylling { get; set; }
        public string Driftstoerrelse_Planteavl { get; set; }
        public string Driftstoerrelse_Koed_Koer { get; set; }
        public string Driftfstoerrelse_Mælk { get; set; }
        public string Driftstoerrelse_Svin { get; set; }
        public string Driftstoerrelse_Pelsdyr { get; set; }
        public string Driftstoerrelse_Aeg_Kylling { get; set; }
        public string AntalSlagtekvaeg { get; set; }
    }
}