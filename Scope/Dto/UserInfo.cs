using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scope.Entity;

namespace Scope.Dto
{
    /// <summary>
    /// ユーザ情報を保持するクラス
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// User情報
        /// </summary>
        private User user;

        /// <summary>
        /// Employee情報
        /// </summary>
        private Employee employee;

        public User User
        {
            set { this.user = value; }
            get { return user; }
        }

        public Employee Employee
        {
            set { this.employee = value; }
            get { return employee; }
        }
    }
}