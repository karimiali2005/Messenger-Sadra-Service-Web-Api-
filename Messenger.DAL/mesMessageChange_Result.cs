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
    
    public partial class mesMessageChange_Result
    {
        public int pkfMessage { get; set; }
        public Nullable<int> FkfUser { get; set; }
        public string message { get; set; }
        public Nullable<int> FkfStatusMessage { get; set; }
        public Nullable<int> FkfTypeMessage { get; set; }
        public Nullable<int> FkfSource { get; set; }
        public Nullable<int> FkfCompanyId { get; set; }
        public string sendDate { get; set; }
        public string reciveDate { get; set; }
        public string showDate { get; set; }
        public string ansswerDate { get; set; }
        public bool isDelete { get; set; }
        public Nullable<int> FkfDocument { get; set; }
        public int replay { get; set; }
        public string sendTime { get; set; }
        public string reciveTime { get; set; }
        public string showTime { get; set; }
        public string ansswerTime { get; set; }
        public Nullable<System.DateTime> sendDateEN { get; set; }
        public Nullable<System.DateTime> reciveDateEN { get; set; }
        public Nullable<System.DateTime> showDateEN { get; set; }
        public Nullable<System.DateTime> ansswerDateEN { get; set; }
        public string replayDiscript { get; set; }
        public bool IsFireBase { get; set; }
        public System.DateTime changeDateEN { get; set; }
    }
}
