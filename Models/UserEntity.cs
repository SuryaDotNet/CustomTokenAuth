using System;
using System.Collections.Generic;

namespace TokenAuth
{
    public class UserEntity
    {
        private static UserEntity userEntity;
        private static readonly object padlock = new object();
        public List<UserEntity> users;
        public UserEntity()
        {
            users = new List<UserEntity>();
        }

        public static UserEntity Instance
        {
            get
            {
                lock (padlock)
                {
                    if (userEntity == null)
                    {
                        userEntity = new UserEntity();
                    }
                    return userEntity;
                }
            }
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// InMemory User Data
        /// </summary>
        /// <returns></returns>
        public List<UserEntity> LoadUserData()
        {
            //Used MD5 algorithm to encrypt the password
            //You can decrypt the password using https://www.md5decrypt.org/
            users.Add(new UserEntity { Id = 1, UserName = "admin",Password = "21232f297a57a5a743894a0e4a801fc3" });
            users.Add(new UserEntity { Id = 2, UserName = "user", Password = "5f4dcc3b5aa765d61d8327deb882cf99" });
            users.Add(new UserEntity { Id = 3, UserName = "surya",Password = "8c3a9f08696af482a53e1dd8db0ef40f" });
            return users;
        }
    }
    }



