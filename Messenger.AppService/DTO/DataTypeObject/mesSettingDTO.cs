

using System;
using System.ComponentModel.DataAnnotations;
	
 
namespace Messenger.AppService.DTO.DataTypeObject
{
    
    public  partial class mesSettingDTO
    {
      #region ~( Peroperties )~
     
             
    [Key()] 
     
     public int pkfSetting { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.EmailAddress)] public Nullable<bool> SendEmailManageEnable { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.EmailAddress)] public string SendEmailManageHost { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.EmailAddress)] public Nullable<int> SendEmailManagePort { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.EmailAddress)] public string SendEmailManageUsername { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.EmailAddress)] public string SendEmailManageUserPass { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.EmailAddress)] public string SendEmailManageFrom { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.EmailAddress)] public string SendEmailManageTo { get; set; }
    		
    
    		
    
                  
     
     
     public Nullable<bool> RegistrationFormVisit { get; set; }
    		
    
    		
    
                  
     
     
     public string ContactsInvitationText { get; set; }
    		
    
    		
    
                  
     
     
     public Nullable<bool> ShowHelpForm { get; set; }
    		
    
    		
    
                  
     
     
    [DataType(DataType.Url)] public string HelpMainUrl { get; set; }
    		
    
    		
    
                  
     
     
     public int ShowNotificationRepeat { get; set; }
    		
    
    		
    
                  
     
     
     public Nullable<int> InvitationPanelID { get; set; }
    		
    
    		
    
                  
     
     
     public string MessageInstallInvitation { get; set; }
    		
    
    		
    
                  
     
     
     public Nullable<int> InstallInvitationPanelID { get; set; }
    		
    
    		
    
                  
     
     
     public string NumberSMSAddUser { get; set; }
    		
    
    		
    
                  
     
     
     public string NumberSMSUpdateUser { get; set; }
    		
    
    		
    
                  
     
     
     public Nullable<int> NumberSMSManagerPanelID { get; set; }
    		
    
    		
    
                  
     
     
     public string NumberSMSManagerText { get; set; }
    		
    
    		
    
                  
     
     
     public string serverKeyFireBase { get; set; }
    		
    
    		
    
                  
     
     
     public string senderIdFireBase { get; set; }
    		
    
    		
    
                  
     
     
     public string webAddr { get; set; }
    		
    
    		
    
              
            #endregion
        } 
    
}
