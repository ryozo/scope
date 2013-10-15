using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scope.Const
{
    /// <summary>
    /// システム共通の定数クラス
    /// </summary>
    public class SystemConstants
    {
        /// <summary>
        /// セッションに利用するキーを設定する
        /// </summary>
        public class SessionKey
        {

            public const String USER_INFO = "session_userinfo";
        }
    }
}