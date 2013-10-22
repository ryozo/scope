using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scope.Entity;
using Scope.DbAccessor;
using System.Data.SqlClient;

namespace Scope.Dao
{
    /// <summary>
    /// Employeeテーブルへのアクセスを担当するDao
    /// </summary>
    public class EmployeeDao : AbstractDao
    {
        public EmployeeDao(DataBaseAccessor accessor) : base(accessor) {}
        public Employee findByEmployeeNo(String employeeNo)
        {
            String sql = "select * from employee where employeeno = @employeeno";
            SqlParameter param = makeParameter("@employeeno", employeeNo);
            SqlDataReader reader = null;
            Employee employee = null;

            try
            {
                reader = accessor.select(sql, param);
                if (reader.Read())
                {
                    employee = new Employee();
                    employee.EmployeeNo = reader["employeeNo"].ToString();
                    employee.EmployeeName = reader["employeeName"].ToString();
                    employee.Sex = Boolean.Parse(reader["sex"].ToString());
                    employee.TelNo = reader["telNo"].ToString();
                    employee.UserId = reader["userId"].ToString();
                    return employee;
                }
            }
            finally
            {
                closeReader(reader);
            }

            return employee;
        }

        public Employee findByUserId(String userId) {
            String sql = "select * from employee where userid = @userid";
            SqlParameter param = makeParameter("@userid", userId);
            SqlDataReader reader = null;
            Employee employee = null;

            try
            {
                reader = accessor.select(sql, param);
                if (reader.Read())
                {
                    employee = new Employee();
                    employee.EmployeeNo = (String) read(reader, "employeeNo");
                    employee.EmployeeName = (String) read(reader, "employeeName");
                    employee.Sex = Boolean.Parse(read(reader, "sex").ToString());
                    employee.TelNo = (String) read(reader, "telNo");
                    employee.UserId = (String) read(reader, "userId");
                    return employee;
                }
            }
            finally
            {
                closeReader(reader);
            }

            return employee;
        }
    }
}