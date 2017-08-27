using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Common;

namespace DAL
{
    /// <summary>
    /// OAuth授权用户信息
    /// </summary>
    public partial class user_address
    {
        private string databaseprefix; //数据库表名前缀
        public user_address(string _databaseprefix)
        {
            databaseprefix = _databaseprefix; 
        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "user_address");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.user_address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "user_address(");
            strSql.Append("user_name,nick_name,address,telphone,mobile,city,post_code,is_check)");
            strSql.Append(" values (");
            strSql.Append("@user_name,@nick_name,@address,@telphone,@mobile,@city,@post_code,@is_check)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@nick_name", SqlDbType.NVarChar,100),
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
                    new SqlParameter("@mobile", SqlDbType.NVarChar,20),
                    new SqlParameter("@city", SqlDbType.NVarChar,50),
                    new SqlParameter("@post_code", SqlDbType.NVarChar,20),
					new SqlParameter("@is_check", SqlDbType.Decimal,1)};
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.nick_name;
            parameters[2].Value = model.address;
            parameters[3].Value = model.telphone;
            parameters[4].Value = model.mobile;
            parameters[5].Value = model.city;
            parameters[6].Value = model.post_code;
            parameters[7].Value = model.is_check;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.user_address model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "user_address set ");
            strSql.Append("user_name=@user_name,");
            strSql.Append("nick_name=@nick_name,");
            strSql.Append("address=@address,");
            strSql.Append("telphone=@telphone,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("is_check=@is_check,");
            strSql.Append("city=@city,");
            strSql.Append("post_code=@post_code");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@nick_name", SqlDbType.NVarChar,100),
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@telphone", SqlDbType.NVarChar,50),
                    new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@is_check", SqlDbType.Decimal,1),
                      new SqlParameter("@city", SqlDbType.NVarChar,50),
					new SqlParameter("@post_code", SqlDbType.NVarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.nick_name;
            parameters[2].Value = model.address;
            parameters[3].Value = model.telphone;
            parameters[4].Value = model.mobile;
            parameters[5].Value = model.is_check;
            parameters[6].Value = model.city;
            parameters[7].Value = model.post_code;
            parameters[8].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "user_address ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.user_address GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + databaseprefix + "user_address ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.user_address model = new Model.user_address();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
               
                if (ds.Tables[0].Rows[0]["user_name"] != null && ds.Tables[0].Rows[0]["user_name"].ToString() != "")
                {
                    model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["nick_name"] != null && ds.Tables[0].Rows[0]["nick_name"].ToString() != "")
                {
                    model.nick_name = ds.Tables[0].Rows[0]["nick_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null && ds.Tables[0].Rows[0]["address"].ToString() != "")
                {
                    model.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["telphone"] != null && ds.Tables[0].Rows[0]["telphone"].ToString() != "")
                {
                    model.telphone = ds.Tables[0].Rows[0]["telphone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["mobile"] != null && ds.Tables[0].Rows[0]["mobile"].ToString() != "")
                {
                    model.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["city"] != null && ds.Tables[0].Rows[0]["city"].ToString() != "")
                {
                    model.city = ds.Tables[0].Rows[0]["city"].ToString();
                }
                if (ds.Tables[0].Rows[0]["post_code"] != null && ds.Tables[0].Rows[0]["post_code"].ToString() != "")
                {
                    model.post_code = ds.Tables[0].Rows[0]["post_code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["is_check"] != null && ds.Tables[0].Rows[0]["is_check"].ToString() != "")
                {
                    model.is_check =decimal.Parse( ds.Tables[0].Rows[0]["is_check"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

     

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM " + databaseprefix + "user_address ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "user_address");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}