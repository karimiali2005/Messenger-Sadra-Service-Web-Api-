

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public  partial class mesPanelDTO
    {
      #region ~( Peroperties )~
     
             
    [Key()] 
     
     public int pkfPanel { get; set; }
    		
    
    		
    
                  
     
     
     public string PanelName { get; set; }
    		
    
    		
    
                  
     
     
     public string UserName { get; set; }
    		
    
    		
    
                  
     
     
     public string UserPass { get; set; }
    		
    
    		
    
                  
     
     
     public string Sender { get; set; }
    		
    
    		
    
              
            #endregion
        } 
    
}
