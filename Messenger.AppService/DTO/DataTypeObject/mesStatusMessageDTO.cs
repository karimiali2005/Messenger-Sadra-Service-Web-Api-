

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public  partial class mesStatusMessageDTO
    {
      #region ~( Peroperties )~
     
             
    [Key()] 
     
     public int pkfStatusMessage { get; set; }
    		
    
    		
    
                  
     
     
     public string statusMessage { get; set; }
    		
    
    		
    
                  
     
     
     public string statusMessageCode { get; set; }
    		
    
    		
    
                  
     
     
     public string memo { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.DateTime)] public System.DateTime changeDateEN { get; set; }
    		
    
    		
    
              
            #endregion
        } 
    
}
