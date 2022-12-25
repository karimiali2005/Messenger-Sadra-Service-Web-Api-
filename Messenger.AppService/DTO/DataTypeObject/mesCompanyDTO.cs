

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public  partial class mesCompanyDTO
    {
      #region ~( Peroperties )~
     
             
    [Key()] 
     
     public int pkfCompany { get; set; }
    		
    
    		
    
                  
     
     
     public string companyName { get; set; }
    		
    
    		
    
                  
     
     
     public Nullable<int> serialIdCompany { get; set; }
    		
    
    		
    
                  
     
     
     public bool active { get; set; }
    		
    
    		
    
                  
     
     
     public byte[] pic { get; set; }
    		
    
    		
    
                  
     
     
     public string picName { get; set; }
    		
    
    		
    
                  
     
     
     public string pass { get; set; }
    		
    
    		
    
                  
     
     
     public string userName { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.DateTime)] public System.DateTime changeDateEN { get; set; }
    		
    
    		
    
              
            #endregion
        } 
    
}
