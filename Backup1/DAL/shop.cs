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
    public partial class shop
    {
        private string databaseprefix; //数据库表名前缀
        public shop(string _databaseprefix)
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
            strSql.Append("select count(1) from " + databaseprefix + "shop");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.shop model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "shop(");
            strSql.Append("address,telphone,user_id,shop_name,city,linkman)");
            strSql.Append(" values (");
            strSql.Append("@address,@telphone,@user_id,@shop_name,@city,@linkman)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@telphone", SqlDbType.NVarChar,100),
					new SqlParameter("@user_id", SqlDbType.Int,10),
					new SqlParameter("@shop_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@city", SqlDbType.NVarChar,50),
                    new SqlParameter("@linkman", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.address;
            parameters[1].Value = model.telphone;
            parameters[2].Value = model.user_id;
            parameters[3].Value = model.shop_name;
            parameters[4].Value = model.city;

            parameters[5].Value = model.linkman;
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
        public bool Update(Model.shop model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "shop set ");
            strSql.Append("address=@address,");
            strSql.Append("telphone=@telphone,");
            strSql.Append("user_id=@user_id,");
            strSql.Append("shop_name=@shop_name,");
            strSql.Append("city=@city,");
            strSql.Append("linkman=@linkman");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
							new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@telphone", SqlDbType.NVarChar,100),
					new SqlParameter("@user_id", SqlDbType.Int,10),
					new SqlParameter("@shop_name", SqlDbType.NVarChar,50),
                    new SqlParameter("@city", SqlDbType.NVarChar,50),
                    new SqlParameter("@linkman", SqlDbType.NVarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.address;
            parameters[1].Value = model.telphone;
            parameters[2].Value = model.user_id;
            parameters[3].Value = model.shop_name;
            parameters[4].Value = model.city;
            parameters[5].Value = model.linkman;
            parameters[6].Value = model.id;

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
            strSql.Append("delete from " + databaseprefix + "shop ");
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
        public Model.shop GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + databaseprefix + "shop ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.shop model = new Model.shop();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }

                if (ds.Tables[0].Rows[0]["linkman"] != null && ds.Tables[0].Rows[0]["linkman"].ToString() != "")
                {
                    model.linkman = ds.Tables[0].Rows[0]["linkman"].ToString();
                }
                if (ds.Tables[0].Rows[0]["shop_name"] != null && ds.Tables[0].Rows[0]["shop_name"].ToString() != "")
                {
                    model.shop_name = ds.Tables[0].Rows[0]["shop_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null && ds.Tables[0].Rows[0]["address"].ToString() != "")
                {
                    model.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["telphone"] != null && ds.Tables[0].Rows[0]["telphone"].ToString() != "")
                {
                    model.telphone = ds.Tables[0].Rows[0]["telphone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["city"] != null && ds.Tables[0].Rows[0]["city"].ToString() != "")
                {
                    model.city = ds.Tables[0].Rows[0]["city"].ToString();
                }

                if (ds.Tables[0].Rows[0]["user_id"] != null && ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
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
            strSql.Append(" FROM " + databaseprefix + "shop ");
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
        public DataSet GetList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "shop");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
           
            return DbHelperSQL.Query( strSql.ToString());
        }

        #endregion  Method
        public int GetCount(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + databaseprefix + "shop");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
    }
}