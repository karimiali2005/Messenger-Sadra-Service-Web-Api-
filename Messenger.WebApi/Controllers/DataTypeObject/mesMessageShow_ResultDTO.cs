

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public partial class mesMessageShow_ResultDTO
    {
      #region ~( Peroperties )~
      
      			  
     
     
     public int pkfMessage { get; set; }
    
    			  		
    	     				  
     
     
     public Nullable<int> FkfUser { get; set; }
    
    			  		
    	     				  
     
     
     public string message { get; set; }
    
    			  		
    	     				  
     
     
     public Nullable<int> FkfStatusMessage { get; set; }
    
    			  		
    	     				  
     
     
     public Nullable<int> FkfTypeMessage { get; set; }
    
    			  		
    	     				  
     
     
     public Nullable<int> FkfSource { get; set; }
    
    			  		
    	     				  
     
     
     public Nullable<int> FkfCompanyId { get; set; }
    
    			  		
    	     				  
     
     
     public bool isDelete { get; set; }
    
    			  		
    	     				  
     
     
     public Nullable<int> FkfDocument { get; set; }
    
    			  		
    	     				  
     
     
    [DataType(DataType.DateTime)] public System.DateTime changeDateEN { get; set; }
    
    			  		
    	     				  
     
     
     public string statusMessage { get; set; }
    
    			  		
    	     				  
     
     
     public string typeMessage { get; set; }
    
    			  		
    	     				  
     
     
     public string companyName { get; set; }
    
    			  		
    	     	
                
      
    #endregion
    
        } 
}
