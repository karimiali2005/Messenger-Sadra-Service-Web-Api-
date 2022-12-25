

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public  partial class mesDocumentTypeDTO
    {
      #region ~( Peroperties )~
     
             
    [Key()] 
     
     public int pkfDocumentType { get; set; }
    		
    
    		
    
                  
     
     
     public string documentType { get; set; }
    		
    
    		
    
              
            #endregion
        } 
    
}
