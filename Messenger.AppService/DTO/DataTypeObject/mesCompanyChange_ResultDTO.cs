

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public partial class mesCompanyChange_ResultDTO
    {
      #region ~( Peroperties )~
      
      			  
     
     
     public int pkfCompany { get; set; }
    
    			  		
    	     				  
     
     
     public string companyName { get; set; }
    
    			  		
    	     				  
     
     
     public string number { get; set; }
    
    			  		
    	     				  
     
     
     public Nullable<int> CountAll { get; set; }
    
    			  		
    	     				  
     
     
     public Nullable<int> CountSend { get; set; }
    
    			  		
    	     				  
     
     
     public Nullable<int> CountRecive { get; set; }
    
    			  		
    	     				  
     
     
     public Nullable<int> CountShow { get; set; }
    
    			  		
    	     	
                
      
    #endregion
    
        } 
}
