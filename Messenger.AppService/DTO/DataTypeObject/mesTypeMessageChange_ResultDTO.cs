

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public partial class mesTypeMessageChange_ResultDTO
    {
      #region ~( Peroperties )~
      
      			  
     
     
     public int pkfTypeMessage { get; set; }
    
    			  		
    	     				  
     
     
     public string typeMessage { get; set; }
    
    			  		
    	     				  
     
     
     public string typeMessageCode { get; set; }
    
    			  		
    	     				  
     
     
     public string memo { get; set; }
    
    			  		
    	     				  
     
     
    [DataType(DataType.DateTime)] public System.DateTime changeDateEN { get; set; }
    
    			  		
    	     	
                
      
    #endregion
    
        } 
}
