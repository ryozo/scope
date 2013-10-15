using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scope.Entity
{
    /// <summary>
    /// Userテーブルと紐付くEntityクラス
    /// </summary>
    public class User
    {
        private String userId;
        private String password;

        public String UserId
        {
            set { this.userId = value; }
            get { return userId; }
        }

        public String Password
        {
            set { this.password = value; }
            get { return password; }
        }
    }
}