//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Messenger.DAL
{
    using System;
    
    public partial class mesMessageShow_Result
    {
        public int pkfMessage { get; set; }
        public Nullable<int> FkfUser { get; set; }
        public string message { get; set; }
        public Nullable<int> FkfStatusMessage { get; set; }
        public Nullable<int> FkfTypeMessage { get; set; }
        public Nullable<int> FkfSource { get; set; }
        public Nullable<int> FkfCompanyId { get; set; }
        public bool isDelete { get; set; }
        public Nullable<int> FkfDocument { get; set; }
        public System.DateTime changeDateEN { get; set; }
        public string statusMessage { get; set; }
        public string typeMessage { get; set; }
        public string companyName { get; set; }
    }
}
