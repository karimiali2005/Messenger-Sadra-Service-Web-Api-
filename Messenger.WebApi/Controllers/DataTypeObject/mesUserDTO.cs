

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public  partial class mesUserDTO
    {
      #region ~( Peroperties )~
     
             
    [Key()] 
     
     public int pkfUser { get; set; }
    		
    
    		
    
                  
     
     
     public string number { get; set; }
    		
    
    		
    
                  
     
     
     public string name { get; set; }
    		
    
    		
    
                  
     
     
     public string famile { get; set; }
    		
    
    		
    
                  
     
     
     public byte[] pic { get; set; }
    		
    
    		
    
                  
     
     
     public string picName { get; set; }
    		
    
    		
    
                  
     
     
     public string pass { get; set; }
    		
    
    		
    
                  
     
     
     public string userName { get; set; }
    		
    
    		
    
                  
     
     
     public Nullable<int> ActiveCode { get; set; }
    		
    
    		
    
                  
     
     
     public Nullable<bool> UserActive { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.DateTime)] public Nullable<System.DateTime> UserCreateDate { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.DateTime)] public Nullable<System.DateTime> UserExpireDate { get; set; }
    		
    
    		
    
                  
     
     
     public Nullable<bool> DeactiveAdministrator { get; set; }
    		
    
    		
    
                  
     
     
     public string PublicKey { get; set; }
    		
    
    		
    
                  
     
     
     public string PrivateKey { get; set; }
    		
    
    		
    
                  
     
     
     public string PrivateKeyRefresh { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.DateTime)] public Nullable<System.DateTime> PrivateKeyExpire { get; set; }
    		
    
    		
    
              
            #endregion
        } 
    
}
