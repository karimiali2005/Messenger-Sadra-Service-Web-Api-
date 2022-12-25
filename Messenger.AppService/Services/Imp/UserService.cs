using System;
using System.Linq;
using Messenger.AppService.Classes;
using Messenger.AppService.DTO.DataTypeObject;
using Messenger.AppService.Services.Interface;
using Messenger.AppService.ViewModel;
using Messenger.DAL;
using Messenger.Repository.Services.Interface;

namespace Messenger.AppService.Services.Imp
{
    public partial class UserService:IUserService
    {
        #region ~( Fields )~

        private readonly IUserRepository _userRepository;
        private readonly IVersioningRepository _versioningRepository;


        #endregion

        #region ~( Constructors )~
        public UserService(IUserRepository userRepository, IVersioningRepository versioningRepository)
        {
            _userRepository = userRepository;
            _versioningRepository = versioningRepository;
        }

        #endregion

        #region ~( Methods )~
        public mesUserDTO Add(string username, int type, string ip4, int appVersion, ref int newUser,ref string publicKey)
        {
            var rnd = new Random();
            publicKey = Guid.NewGuid().ToString();

            try
            {
                var myUser = _userRepository.First(u => u.number == username);
                if (myUser!=null)
                {
                    
                    if(myUser.ActiveCode==null)
                    {
                        myUser.ActiveCode = rnd.Next(1000, 9999);
                    }

                    if (String.IsNullOrEmpty(myUser.PublicKey))
                    {
                        myUser.PublicKey = publicKey;
                    }
                   
                    _userRepository.Update(myUser);
                   
                    newUser = 0;
                    publicKey = AesEncryptionAlgorithm.EncryptServicePublicKeyReceive(myUser.PublicKey);


                    var myUserDTO = new mesUserDTO();
                    AutoMapper.Mapper.Map(myUser, myUserDTO);
                  
                    return myUserDTO;

                }
                else
                {
                    var user= new mesUser()
                        {
                            number = username,
                            ActiveCode = rnd.Next(1000, 9999),
                            UserCreateDate = DateTime.Now,
                            DeactiveAdministrator = false,
                            PublicKey = publicKey,
                            picName = Guid.NewGuid().ToString()
                        };
                    _userRepository.Add(user);
                    
                    newUser = 1;
                    publicKey = AesEncryptionAlgorithm.EncryptServicePublicKeyReceive(user.PublicKey);

                    var myUserDTO = new mesUserDTO();
                    AutoMapper.Mapper.Map(user, myUserDTO);
                    return myUserDTO;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public mesUser GetById(object id)
        {
            try
            {
                var user = _userRepository.GetByKey(id);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public mesUserDTO GetById2(object id)
        {
            try
            {
                var user = _userRepository.GetByKey(id);
                var myUserDTO = new mesUserDTO();
                AutoMapper.Mapper.Map(user, myUserDTO);
                return myUserDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetDeactiveAdministrator(int userId, string ip4, int appVersion)
        {
            try
            {
                var deactiveAdministrator = _userRepository.GetByKey(userId).DeactiveAdministrator ?? true;
                
                return deactiveAdministrator;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LoginLimitViewModel GetLoadFirstAppInfo(int userId, bool isReminder, string ip4, int appVersion)
        {
            try
            {
                var lastForce = _versioningRepository.Get(v => v.ForceInstalling).LastOrDefault();
                var lastNoForce = _versioningRepository.GetAll().LastOrDefault();
                var loginLimit = new LoginLimitViewModel()
                {
                    DeactiveAdministrator = GetDeactiveAdministrator(userId, ip4, appVersion),
                    VersionCodeForceInstalling = lastForce.VersionCode,
                    VersionNameForceInstalling = lastForce.VersionName,
                    VersionCodeNoForceInstalling = lastNoForce.VersionCode,
                    VersionNameNoForceInstalling = lastNoForce.VersionName
                };
                
                return loginLimit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidVerificationCode(int userId, int verificationCode, string publicKey, string tokenFireBase, ref int publicKeyValid, ref string privateKey, ref string privateKeyRefresh, ref string privateKeyExpire)
        {
            try
            {
                publicKey = AesEncryptionAlgorithm.DecryptServicePublicKeySend(publicKey);

                var user = GetById(userId);
                if (user.PublicKey == publicKey)
                    publicKeyValid = 1;
                else
                {
                    publicKeyValid = 0;
                   
                }

                if (user.ActiveCode == verificationCode)
                {
                    user.UserActive = true;
                    user.ActiveCode = null;
                    if (String.IsNullOrEmpty(user.PrivateKey))
                    {
                        user.PrivateKey = Guid.NewGuid().ToString();
                        user.PrivateKeyRefresh = Guid.NewGuid().ToString();
                        user.PrivateKeyExpire = DateTime.Now;
                    }
                    user.tokenFireBase = tokenFireBase;
                    _userRepository.Update(user);
                    privateKey = AesEncryptionAlgorithm.EncryptServicePrivateKeyReceive(user.PrivateKey);
                    privateKeyRefresh = AesEncryptionAlgorithm.EncryptServicePrivateKeyReceive(user.PrivateKeyRefresh);
                    privateKeyExpire = AesEncryptionAlgorithm.EncryptServicePrivateKeyReceive(((DateTime)user.PrivateKeyExpire).ToString("yyyy-MM-dd'T'HH:mm"));

                    
                    return true;
                }
               
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ChangeTokenFireBase(int userId, string tokenFireBase)
        {
            try
            {


                var user = GetById(userId);

                user.tokenFireBase = tokenFireBase;

                _userRepository.Update(user);

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckOnline(int userId)
        {
            try
            {
                return _userRepository.CheckOnline(userId);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegisterUserInfo(UserViewModel user)
        {
            try
            {
                var myUser = GetById(user.UserID);
                myUser.name = user.FirstName;
                myUser.famile = user.LastName;
                _userRepository.Update(myUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserViewModel GetUserInfo(object id)
        {
            try
            {
                var user = _userRepository.GetByKey(id);
                var userViewModel = new UserViewModel()
                {
                    UserID = user.pkfUser,
                    UserName = user.number,
                    FirstName = user.name,
                    LastName = user.famile
                };

                return userViewModel;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateImage(int userId, byte[] pic)
        {
            try
            {
                var user = _userRepository.GetByKey(userId);
                user.pic = pic;
                user.picName = Guid.NewGuid().ToString();
                _userRepository.Update(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Authorize(int userId, string privateKey)
        {
            try
            {
                return _userRepository.Get(u => u.pkfUser == userId && u.PrivateKey == privateKey).Any();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
