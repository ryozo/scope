using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scope.Service.Login
{
    /// <summary>
    /// ログイン機能を提供するServiceクラス
    /// </summary>
    public class LoginService
    {

        public static Dto.UserInfo login(String userId, String password)
        {
            Dto.UserInfo info = new Dto.UserInfo();
            return info;
        }
    }
}