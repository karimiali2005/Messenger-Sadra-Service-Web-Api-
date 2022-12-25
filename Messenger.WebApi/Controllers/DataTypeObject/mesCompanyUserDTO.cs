

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public  partial class mesCompanyUserDTO
    {
      #region ~( Peroperties )~
     
             
    [Key()] 
     
     public int pkfCompanyUser { get; set; }
    		
    
    		
    
                  
     
     
     public string number { get; set; }
    		
    
    		
    
                  
     
     
     public Nullable<int> FkfCompany { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.DateTime)] public System.DateTime validyDateUser { get; set; }
    		
    
    		
    
                  
     
     
     public bool active { get; set; }
    		
    
    		
    
              
            #endregion
        } 
    
}
