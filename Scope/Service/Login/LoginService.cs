using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Scope.DbAccessor;
using Scope.Dao;
using Scope.Entity;
using Scope.Dto;

namespace Scope.Service.Login
{
    /// <summary>
    /// ログイン機能を提供するServiceクラス
    /// </summary>
    public class LoginService : Service.Base.AbstractService
    {
        /// <summary>
        /// ログイン処理。
        /// </summary>
        /// <param name="userId">ログインユーザのユーザID</param>
        /// <param name="password">ログインユーザのパスワード</param>
        /// <returns>ログイン成功：ログインユーザ情報を保持するUserInfo。ログイン失敗：null</returns>
        public static UserInfo login(String userId, String password)
        {
            DataBaseAccessor accessor = new DataBaseAccessor();
            accessor.open();

            UserDao userDao = new UserDao(accessor);
            User user = userDao.findByUserIdAndPassword(userId, password);

            if (user == null)
            {
                return null;
            }

            EmployeeDao employeeDao = new EmployeeDao(accessor);
            Employee employee = employeeDao.findByUserId(userId);
            accessor.close();

            UserInfo userInfo = new UserInfo();
            userInfo.User = user;
            userInfo.Employee = employee;
            return userInfo;
        }
    }
}