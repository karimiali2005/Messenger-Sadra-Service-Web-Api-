

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public  partial class mesLoginDTO
    {
      #region ~( Peroperties )~
     
             
    [Key()] 
     
     public int pkfLogin { get; set; }
    		
    
    		
    
                  
     
     
     public string idConnectionSignalR { get; set; }
    		
    
    		
    
                  
     
     
     public int FkfUser { get; set; }
    		
    
    		
    
                  
     
     
     public int loginType { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.DateTime)] public System.DateTime connectDateTime { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.DateTime)] public Nullable<System.DateTime> disconnectDateTime { get; set; }
    		
    
    		
    
                  
     
     
     public string comment { get; set; }
    		
    
    		
    
                  
     
     
     public string ip { get; set; }
    		
    
    		
    
                  
     
     
     public int appVersion { get; set; }
    		
    
    		
    
                  
     
     
     public string androidVersion { get; set; }
    		
    
    		
    
                  
     
     
     public string mobileName { get; set; }
    		
    
    		
    
              
            #endregion
        } 
    
}
