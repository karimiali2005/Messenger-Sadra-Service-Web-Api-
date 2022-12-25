// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Messenger.AppService.Services.Imp;
using Messenger.AppService.Services.Interface;
using Messenger.Repository.Services.Imp;
using Messenger.Repository.Services.Interface;
using StructureMap;

namespace Messenger.WebApi.DependencyResolution {
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            #region ~( User )~
            For<IUserService>().Use<UserService>();
            For<IUserRepository>().Use<UserRepository>();
            #endregion

            #region ~( Panel )~
            For<IPanelService>().Use<PanelService>();
            For<IPanelRepository>().Use<PanelRepository>();
            #endregion


            #region ~( Setting )~
            /*For<ISettingService>().Use<SettingService>();*/
            For<ISettingRepository>().Use<SettingRepository>();
            #endregion

            #region ~( Versioning )~
            For<IVersioningService>().Use<VersioningService>();
            For<IVersioningRepository>().Use<VersioningRepository>();
            #endregion

            #region ~( CompanyService )~
            For<ICompanyService>().Use<CompanyService>();
            For<ICompanyRepository>().Use<CompanyRepository>();
            #endregion

            #region ~( CompanyService )~
            For<IMessageService>().Use<MessageService>();
            For<IMessageRepository>().Use<MessageRepository>();
            #endregion
        }

        #endregion
    }
}