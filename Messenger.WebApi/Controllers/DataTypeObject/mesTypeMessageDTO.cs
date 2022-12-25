

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public  partial class mesTypeMessageDTO
    {
      #region ~( Peroperties )~
     
             
    [Key()] 
     
     public int pkfTypeMessage { get; set; }
    		
    
    		
    
                  
     
     
     public string typeMessage { get; set; }
    		
    
    		
    
                  
     
     
     public string typeMessageCode { get; set; }
    		
    
    		
    
                  
     
     
     public string memo { get; set; }
    		
    
    		
    
              
            #endregion
        } 
    
}
