

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public  partial class mesVersioningDTO
    {
      #region ~( Peroperties )~
     
             
    [Key()] 
     
     public int pkfVersioning { get; set; }
    		
    
    		
    
                  
     
     
     public int VersionCode { get; set; }
    		
    
    		
    
                  
     
     
     public string VersionName { get; set; }
    		
    
    		
    
                  
     
     
     public bool ForceInstalling { get; set; }
    		
    
    		
    
                  
     
     
     public string VersionDescription { get; set; }
    		
    
    		
    
              
            #endregion
        } 
    
}
