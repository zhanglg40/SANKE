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
    public partial class shop_log
    {
        private string databaseprefix; //数据库表名前缀
        public shop_log(string _databaseprefix)
        {
            databaseprefix = _databaseprefix; 
        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Model.shop_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "shop_order");
            strSql.Append(" where shop_id=@shop_id ");
            strSql.Append(" and goods_id=@goods_id ");
            SqlParameter[] parameters = {
								new SqlParameter("@shop_id", SqlDbType.Int,10),
					new SqlParameter("@goods_id", SqlDbType.Int,10)};
            parameters[0].Value = model.shop_id;
            parameters[1].Value = model.goods_id;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.shop_log model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "shop_order(");
            strSql.Append("shop_id,goods_id,user_id,quantity,createDate)");
            strSql.Append(" values (");
            strSql.Append("@shop_id,@goods_id,@user_id,@quantity,@createDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					
					new SqlParameter("@shop_id", SqlDbType.Int,10),
					new SqlParameter("@goods_id", SqlDbType.Int,10),
					new SqlParameter("@user_id", SqlDbType.Int,10),
					new SqlParameter("@quantity", SqlDbType.Int,10),
					new SqlParameter("@createDate", SqlDbType.DateTime,20)};
            parameters[0].Value = model.shop_id;
            parameters[1].Value = model.goods_id;
            parameters[2].Value = model.user_id;
            parameters[3].Value = model.quantity;
            parameters[4].Value = DateTime.Now;
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

        public bool UpdateCount(Model.shop_log model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "shop_order ");

            strSql.Append("set quantity=@quantity,");
            strSql.Append("createDate=@createDate");
            strSql.Append(" where id=@id ");
            
            SqlParameter[] parameters = {
							new SqlParameter("@quantity", SqlDbType.Int,10),
                            new SqlParameter("@createDate", SqlDbType.DateTime,10),
					new SqlParameter("@id", SqlDbType.Int,10)};
            parameters[0].Value = model.quantity;
            parameters[1].Value = DateTime.Now;
            parameters[2].Value = model.id;


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
            strSql.Append("delete from " + databaseprefix + "shop_order ");
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
        /// 清空数据
        /// </summary>
        public bool DeleteAll(int user_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "shop_order ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = user_id;

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
        public Model.shop_log GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from " + databaseprefix + "shop_order ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.shop_log model = new Model.shop_log();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }

                if (ds.Tables[0].Rows[0]["order_id"] != null && ds.Tables[0].Rows[0]["order_id"].ToString() != "")
                {
                    model.shop_id = int.Parse(ds.Tables[0].Rows[0]["linkman"].ToString());
                }
                if (ds.Tables[0].Rows[0]["goods_id"] != null && ds.Tables[0].Rows[0]["goods_id"].ToString() != "")
                {
                    model.goods_id = int.Parse(ds.Tables[0].Rows[0]["goods_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"] != null && ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["shop_name"] != null && ds.Tables[0].Rows[0]["shop_name"].ToString() != "")
                {
                    model.shop_name = ds.Tables[0].Rows[0]["shop_name"].ToString();
                }


                if (ds.Tables[0].Rows[0]["quantity"] != null && ds.Tables[0].Rows[0]["quantity"].ToString() != "")
                {
                    model.quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

     


        /// <summary>
        /// 获得查询数据
        /// </summary>
        public DataSet GetList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("      SELECT a.id, a.goods_id");
                strSql.Append("   ,a.quantity");
                strSql.Append("   ,p.title");
                 strSql.Append("   ,p.img_url");
               strSql.Append("    ,a.shop_id as companyid");
                strSql.Append("   ,s.shop_name as companyname");
                strSql.Append("   ,q.goods_no");
                strSql.Append("   ,q.Barcode");
                 strSql.Append("  ,q.english_name");
                 strSql.Append("  ,s.linkman as accept_name");
                 strSql.Append("  ,s.telphone");
                 strSql.Append("  ,s.address");
                  strSql.Append("  ,s.address as companyaddress");
                  strSql.Append("  ,s.city");
                  strSql.Append("  ,q.sell_price");
            strSql.Append("  FROM " + databaseprefix + "shop_order a");
            strSql.Append("  left join " + databaseprefix + "shop s on a.shop_id=s.id");
            strSql.Append("  left join " + databaseprefix + "article p on a.goods_id=p.id");
            strSql.Append("  left join " + databaseprefix + "article_attribute_value q on q.article_id=p.id");
            strSql.Append(" where a.quantity>0 ");
             
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            return DbHelperSQL.Query( strSql.ToString());
        }

        #endregion  Method

  
        public int GetCount(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + databaseprefix + "shop_order");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public DataSet GetShopList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,0 AS quantity FROM " + databaseprefix + "shop");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetDList(string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(quantity)quantity,SUM(s.quantity*t.sell_price) price from ax_shop_order s left join ax_article_attribute_value t on s.goods_id=t.article_id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by shop_id ");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}