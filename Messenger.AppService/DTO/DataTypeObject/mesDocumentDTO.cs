

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public  partial class mesDocumentDTO
    {
      #region ~( Peroperties )~
     
             
    [Key()] 
     
     public int pkfDocument { get; set; }
    		
    
    		
    
                  
     
     
     public int FkfMessage { get; set; }
    		
    
    		
    
                  
     
     
     public int FkfDocumentType { get; set; }
    		
    
    		
    
                  
     
     
     public byte[] fileScan { get; set; }
    		
    
    		
    
                  
     
     
     public string memo { get; set; }
    		
    
    		
    
                  
     
     
     public string fileExt { get; set; }
    		
    
    		
    
                  
     
     
     public Nullable<int> fileSize { get; set; }
    		
    
    		
    
              
            #endregion
        } 
    
}
