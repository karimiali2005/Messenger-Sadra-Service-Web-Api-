
	
using Messenger.DAL;
using Messenger.AppService.DTO.DataTypeObject;
using AutoMapper; 


 
namespace Messenger.AppService.MappingProfile
{
    	
    
    public class AutoMapperConfig
    {
       public static void Load()
       {
       Mapper.Initialize(cfg =>
                {
    	
    	
    				cfg.CreateMap<mesCompany,mesCompanyDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesCompanyDTO,mesCompany>().IgnoreAllNonExisting();		 
    			
    	
    				cfg.CreateMap<mesCompanyUser,mesCompanyUserDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesCompanyUserDTO,mesCompanyUser>().IgnoreAllNonExisting();		 
    			
    	
    				cfg.CreateMap<mesDocument,mesDocumentDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesDocumentDTO,mesDocument>().IgnoreAllNonExisting();		 
    			
    	
    				cfg.CreateMap<mesDocumentType,mesDocumentTypeDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesDocumentTypeDTO,mesDocumentType>().IgnoreAllNonExisting();		 
    			
    	
    				cfg.CreateMap<mesMessage,mesMessageDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesMessageDTO,mesMessage>().IgnoreAllNonExisting();		 
    			
    	
    				cfg.CreateMap<mesPanel,mesPanelDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesPanelDTO,mesPanel>().IgnoreAllNonExisting();		 
    			
    	
    				cfg.CreateMap<mesSetting,mesSettingDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesSettingDTO,mesSetting>().IgnoreAllNonExisting();		 
    			
    	
    				cfg.CreateMap<mesStatusMessage,mesStatusMessageDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesStatusMessageDTO,mesStatusMessage>().IgnoreAllNonExisting();		 
    			
    	
    				cfg.CreateMap<mesTypeMessage,mesTypeMessageDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesTypeMessageDTO,mesTypeMessage>().IgnoreAllNonExisting();		 
    			
    	
    				cfg.CreateMap<mesUser,mesUserDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesUserDTO,mesUser>().IgnoreAllNonExisting();		 
    			
    	
    				cfg.CreateMap<mesVersioning,mesVersioningDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesVersioningDTO,mesVersioning>().IgnoreAllNonExisting();		 
    		
    				cfg.CreateMap<mesCompanyChange_Result,mesCompanyChange_ResultDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesCompanyChange_ResultDTO,mesCompanyChange_Result>().IgnoreAllNonExisting();		 
    		 
    				cfg.CreateMap<mesMessageChange_Result,mesMessageChange_ResultDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesMessageChange_ResultDTO,mesMessageChange_Result>().IgnoreAllNonExisting();		 
    		 
    				cfg.CreateMap<mesMessageShow_Result,mesMessageShow_ResultDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesMessageShow_ResultDTO,mesMessageShow_Result>().IgnoreAllNonExisting();		 
    		 
    				cfg.CreateMap<mesStatusMessageChange_Result,mesStatusMessageChange_ResultDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesStatusMessageChange_ResultDTO,mesStatusMessageChange_Result>().IgnoreAllNonExisting();		 
    		 
    				cfg.CreateMap<mesTypeMessageChange_Result,mesTypeMessageChange_ResultDTO>().IgnoreAllNonExisting();	
    				cfg.CreateMap<mesTypeMessageChange_ResultDTO,mesTypeMessageChange_Result>().IgnoreAllNonExisting();		 
    		  
    		 });
       } 
     }
}
   
