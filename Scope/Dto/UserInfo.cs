using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scope.Dto
{
    /// <summary>
    /// ユーザ情報を保持するクラス
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// ユーザID
        /// </summary>
        private String userId;

        /// <summary>
        /// ユーザ名
        /// </summary>
        private String userName;

        public String UserId
        {
            set { this.userId = value; }
            get { return userId; }
        }

        public String UserName
        {
            set { this.userName = value; }
            get { return userName; }
        }
    }
}