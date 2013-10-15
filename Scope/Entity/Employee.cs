using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scope.Entity
{
    /// <summary>
    /// Employeeテーブルと紐付くEntityクラス
    /// </summary>
    public class Employee
    {
        private String employeeNo;
        private String employeeName;
        private Boolean sex;
        private String telNo;
        private String userId;

        public String EmployeeNo
        {
            set { this.employeeNo = value; }
            get { return employeeNo; }
        }

        public String EmployeeName
        {
            set { this.employeeName = value; }
            get { return employeeName; }
        }

        public Boolean Sex
        {
            set { this.sex = value; }
            get { return sex; }
        }

        public String TelNo
        {
            set { this.telNo = value; }
            get { return telNo; }
        }

        public String UserId
        {
            set { this.userId = value; }
            get { return userId; }
        }
    }
}