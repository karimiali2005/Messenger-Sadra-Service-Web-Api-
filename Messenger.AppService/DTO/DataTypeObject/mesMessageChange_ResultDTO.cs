

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public partial class mesMessageChange_ResultDTO
    {
      #region ~( Peroperties )~
      
      			  
     
     
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
    
    			  		
    	     				  
     
     
    [DataType(DataType.DateTime)] public Nullable<System.DateTime> sendDateEN { get; set; }
    
    			  		
    	     				  
     
     
    [DataType(DataType.DateTime)] public Nullable<System.DateTime> reciveDateEN { get; set; }
    
    			  		
    	     				  
     
     
    [DataType(DataType.DateTime)] public Nullable<System.DateTime> showDateEN { get; set; }
    
    			  		
    	     				  
     
     
    [DataType(DataType.DateTime)] public Nullable<System.DateTime> ansswerDateEN { get; set; }
    
    			  		
    	     				  
     
     
     public string replayDiscript { get; set; }
    
    			  		
    	     				  
     
     
     public bool IsFireBase { get; set; }
    
    			  		
    	     				  
     
     
    [DataType(DataType.DateTime)] public System.DateTime changeDateEN { get; set; }
    
    			  		
    	     	
                
      
    #endregion
    
        } 
}
