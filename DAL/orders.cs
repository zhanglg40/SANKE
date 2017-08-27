using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBUtility;
using Common;

namespace DAL
{
    /// <summary>
    /// 数据访问类:订单
    /// </summary>
    public partial class orders
    {
        private string databaseprefix; //数据库表名前缀
        public orders(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        /// <summary>
        /// 坝珇琌
        /// </summary>
        public bool ExistsGoods(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "order_goods");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,8)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 畐琌镑
        /// </summary>
        public bool ExistsGoodsNum(string id,int num,string type)
        {
            StringBuilder strSql = new StringBuilder();
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,8),
                    new SqlParameter("@num", SqlDbType.Int,8)};
            if (type == "edit")
            {
                strSql.Append("select count(1) from " + databaseprefix + "article_attribute_value");
                strSql.Append(" where article_id=(select goods_id from " + databaseprefix + "order_goods where id=@id) ");
                strSql.Append(" and stock_quantity>(@num - (select isnull(quantity,0) from " + databaseprefix + "order_goods where id=@id)) ");
                
                parameters[0].Value = id;
                parameters[1].Value = num;
            }
            else if (type == "add")
            {
                strSql.Append("select count(1) from " + databaseprefix + "article_attribute_value");
                strSql.Append(" where article_id=@id ");
                strSql.Append(" and stock_quantity>@num");

                parameters[0].Value = id;
                parameters[1].Value = num;
            }

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        #region 基本方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "orders");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public DataSet getData(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select order_no,Barcode,goods_title,english_name,quantity,real_price from " + databaseprefix + "orders s");
            strSql.Append(" left join ax_order_goods t on s.id=t.order_id ");
            strSql.Append(strWhere);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string order_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "orders");
            strSql.Append(" where order_no=@order_no ");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = order_no;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回数据数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H from " + databaseprefix + "orders ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据,及其子表数据
        /// </summary>
        public int Add(Model.orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "orders(");
            strSql.Append("order_no,trade_no,user_id,user_name,payment_id,payment_fee,payment_status,payment_time,express_id,express_no,express_fee,express_status,express_time,accept_name,post_code,telphone,mobile,area,address,message,remark,payable_amount,real_amount,order_amount,point,status,add_time,confirm_time,complete_time,wechat,companyid,companyname,companyaddress,city,taxid,ref1,ref2,ref3)");
            strSql.Append(" values (");
            strSql.Append("@order_no,@trade_no,@user_id,@user_name,@payment_id,@payment_fee,@payment_status,@payment_time,@express_id,@express_no,@express_fee,@express_status,@express_time,@accept_name,@post_code,@telphone,@mobile,@area,@address,@message,@remark,@payable_amount,@real_amount,@order_amount,@point,@status,@add_time,@confirm_time,@complete_time,@wechat,@companyid,@companyname,@companyaddress,@city,@taxid,@ref1,@ref2,@ref3)");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100),
					new SqlParameter("@trade_no", SqlDbType.NVarChar,100),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@payment_id", SqlDbType.Int,4),
					new SqlParameter("@payment_fee", SqlDbType.Decimal,5),
					new SqlParameter("@payment_status", SqlDbType.TinyInt,1),
					new SqlParameter("@payment_time", SqlDbType.DateTime),
					new SqlParameter("@express_id", SqlDbType.Int,4),
					new SqlParameter("@express_no", SqlDbType.NVarChar,100),
					new SqlParameter("@express_fee", SqlDbType.Decimal,5),
					new SqlParameter("@express_status", SqlDbType.TinyInt,1),
					new SqlParameter("@express_time", SqlDbType.DateTime),
					new SqlParameter("@accept_name", SqlDbType.NVarChar,50),
					new SqlParameter("@post_code", SqlDbType.NVarChar,20),
					new SqlParameter("@telphone", SqlDbType.NVarChar,30),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@area", SqlDbType.NVarChar,100),
					new SqlParameter("@address", SqlDbType.NVarChar,500),
					new SqlParameter("@message", SqlDbType.NVarChar,500),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@payable_amount", SqlDbType.Decimal,5),
					new SqlParameter("@real_amount", SqlDbType.Decimal,5),
					new SqlParameter("@order_amount", SqlDbType.Decimal,5),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@confirm_time", SqlDbType.DateTime),
					new SqlParameter("@complete_time", SqlDbType.DateTime),
                    new SqlParameter("@wechat", SqlDbType.NVarChar,50),
                    new SqlParameter("@companyid", SqlDbType.NVarChar,100),
                    new SqlParameter("@companyname", SqlDbType.NVarChar,100),
                    new SqlParameter("@companyaddress", SqlDbType.NVarChar,255),
                   new SqlParameter("@city", SqlDbType.NVarChar,50),
                  new SqlParameter("@taxid", SqlDbType.VarChar,100),
                    new SqlParameter("@ref1", SqlDbType.VarChar,100),
                    new SqlParameter("@ref2", SqlDbType.VarChar,100),
                    new SqlParameter("@ref3", SqlDbType.VarChar,100),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};
            parameters[0].Value = model.order_no;
            parameters[1].Value = model.trade_no;
            parameters[2].Value = model.user_id;
            parameters[3].Value = model.user_name;
            parameters[4].Value = model.payment_id;
            parameters[5].Value = model.payment_fee;
            parameters[6].Value = model.payment_status;
            parameters[7].Value = model.payment_time;
            parameters[8].Value = model.express_id;
            parameters[9].Value = model.express_no;
            parameters[10].Value = model.express_fee;
            parameters[11].Value = model.express_status;
            parameters[12].Value = model.express_time;
            parameters[13].Value = model.accept_name;
            parameters[14].Value = model.post_code;
            parameters[15].Value = model.telphone;
            parameters[16].Value = model.mobile;
            parameters[17].Value = model.area;
            parameters[18].Value = model.address;
            parameters[19].Value = model.message;
            parameters[20].Value = model.remark;
            parameters[21].Value = model.payable_amount;
            parameters[22].Value = model.real_amount;
            parameters[23].Value = model.order_amount;
            parameters[24].Value = model.point;
            parameters[25].Value = model.status;
            parameters[26].Value = model.add_time;
            parameters[27].Value = model.confirm_time;
            parameters[28].Value = model.complete_time;
            parameters[29].Value = model.wechat;
            parameters[30].Value = model.companyid;
            parameters[31].Value = model.companyname;
            parameters[32].Value = model.companyaddress;
            parameters[33].Value = model.city;
            parameters[34].Value = model.taxid;
            parameters[35].Value = model.ref1;
            parameters[36].Value = model.ref2;
            parameters[37].Value = model.ref3;
            parameters[38].Direction = ParameterDirection.Output;
            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //" + Resources.lang.commodity+ "列表
            if (model.order_goods != null)
            {
                StringBuilder strSql2;
                foreach (Model.order_goods models in model.order_goods)
                {
                    strSql2 = new StringBuilder();
                    strSql2.Append("insert into " + databaseprefix + "order_goods(");
                    strSql2.Append("order_id,goods_id,goods_title,goods_price,real_price,quantity,point,Barcode,english_name)");
                    strSql2.Append(" values (");
                    strSql2.Append("@order_id,@goods_id,@goods_title,@goods_price,@real_price,@quantity,@point,@Barcode,@english_name)");
                    SqlParameter[] parameters2 = {
						    new SqlParameter("@order_id", SqlDbType.Int,4),
						    new SqlParameter("@goods_id", SqlDbType.Int,4),
						    new SqlParameter("@goods_title", SqlDbType.NVarChar,100),
						    new SqlParameter("@goods_price", SqlDbType.Decimal,5),
						    new SqlParameter("@real_price", SqlDbType.Decimal,5),
						    new SqlParameter("@quantity", SqlDbType.Int,4),
						    new SqlParameter("@point", SqlDbType.Int,4),
						    new SqlParameter("@Barcode", SqlDbType.NVarChar,100),
						    new SqlParameter("@english_name", SqlDbType.NVarChar,50)};
                    parameters2[0].Direction = ParameterDirection.InputOutput;
                    parameters2[1].Value = models.goods_id;
                    parameters2[2].Value = models.goods_title;
                    parameters2[3].Value = models.goods_price;
                    parameters2[4].Value = models.real_price;
                    parameters2[5].Value = models.quantity;
                    parameters2[6].Value = models.point;
                    parameters2[7].Value = models.Barcode;
                    parameters2[8].Value = models.english_name;
                    cmd = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd);
                }
            }
            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[38].Value;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "orders set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public bool UpdateField(string order_no, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "orders set " + strValue);
            strSql.Append(" where order_no='" + order_no + "'");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "orders set ");
            strSql.Append("order_no=@order_no,");
            strSql.Append("trade_no=@trade_no,");
            strSql.Append("user_id=@user_id,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("payment_id=@payment_id,");
            strSql.Append("payment_fee=@payment_fee,");
            strSql.Append("payment_status=@payment_status,");
            strSql.Append("payment_time=@payment_time,");
            strSql.Append("express_id=@express_id,");
            strSql.Append("express_no=@express_no,");
            strSql.Append("express_fee=@express_fee,");
            strSql.Append("express_status=@express_status,");
            strSql.Append("express_time=@express_time,");
            strSql.Append("accept_name=@accept_name,");
            strSql.Append("post_code=@post_code,");
            strSql.Append("telphone=@telphone,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("area=@area,");
            strSql.Append("address=@address,");
            strSql.Append("message=@message,");
            strSql.Append("remark=@remark,");
            strSql.Append("payable_amount=@payable_amount,");
            strSql.Append("real_amount=@real_amount,");
            strSql.Append("order_amount=@order_amount,");
            strSql.Append("point=@point,");
            strSql.Append("status=@status,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("confirm_time=@confirm_time,");
            strSql.Append("complete_time=@complete_time,");
            strSql.Append("city=@city");

            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100),
					new SqlParameter("@trade_no", SqlDbType.NVarChar,100),
					new SqlParameter("@user_id", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@payment_id", SqlDbType.Int,4),
					new SqlParameter("@payment_fee", SqlDbType.Decimal,5),
					new SqlParameter("@payment_status", SqlDbType.TinyInt,1),
					new SqlParameter("@payment_time", SqlDbType.DateTime),
					new SqlParameter("@express_id", SqlDbType.Int,4),
					new SqlParameter("@express_no", SqlDbType.NVarChar,100),
					new SqlParameter("@express_fee", SqlDbType.Decimal,5),
					new SqlParameter("@express_status", SqlDbType.TinyInt,1),
					new SqlParameter("@express_time", SqlDbType.DateTime),
					new SqlParameter("@accept_name", SqlDbType.NVarChar,50),
					new SqlParameter("@post_code", SqlDbType.NVarChar,20),
					new SqlParameter("@telphone", SqlDbType.NVarChar,30),
					new SqlParameter("@mobile", SqlDbType.NVarChar,20),
					new SqlParameter("@area", SqlDbType.NVarChar,100),
					new SqlParameter("@address", SqlDbType.NVarChar,500),
					new SqlParameter("@message", SqlDbType.NVarChar,500),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@payable_amount", SqlDbType.Decimal,5),
					new SqlParameter("@real_amount", SqlDbType.Decimal,5),
					new SqlParameter("@order_amount", SqlDbType.Decimal,5),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.TinyInt,1),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@confirm_time", SqlDbType.DateTime),
					new SqlParameter("@complete_time", SqlDbType.DateTime),
                     new SqlParameter("@city", SqlDbType.NVarChar,50),
               
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.order_no;
            parameters[1].Value = model.trade_no;
            parameters[2].Value = model.user_id;
            parameters[3].Value = model.user_name;
            parameters[4].Value = model.payment_id;
            parameters[5].Value = model.payment_fee;
            parameters[6].Value = model.payment_status;
            parameters[7].Value = model.payment_time;
            parameters[8].Value = model.express_id;
            parameters[9].Value = model.express_no;
            parameters[10].Value = model.express_fee;
            parameters[11].Value = model.express_status;
            parameters[12].Value = model.express_time;
            parameters[13].Value = model.accept_name;
            parameters[14].Value = model.post_code;
            parameters[15].Value = model.telphone;
            parameters[16].Value = model.mobile;
            parameters[17].Value = model.area;
            parameters[18].Value = model.address;
            parameters[19].Value = model.message;
            parameters[20].Value = model.remark;
            parameters[21].Value = model.payable_amount;
            parameters[22].Value = model.real_amount;
            parameters[23].Value = model.order_amount;
            parameters[24].Value = model.point;
            parameters[25].Value = model.status;
            parameters[26].Value = model.add_time;
            parameters[27].Value = model.confirm_time;
            parameters[28].Value = model.complete_time;
            parameters[29].Value = model.city;

            parameters[30].Value = model.id;

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
        /// 删除一条数据，及子表所有相关数据
        /// </summary>
        public bool Delete(int id)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from " + databaseprefix + "order_goods ");
            strSql2.Append(" where order_id=@order_id ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@order_id", SqlDbType.Int,4)};
            parameters2[0].Value = id;

            CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "orders ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 莉坝珇э跑肂
        /// </summary>
        public decimal GetGoodsChangeAmount(string id, int num)
        {
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("select * from " + databaseprefix + "order_goods ");
            strSql2.Append(" where id=@id ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters2[0].Value = id;
            decimal amount = 0;
            decimal afteramount = 0;

            DataSet ds = DbHelperSQL.Query(strSql2.ToString(), parameters2);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int i = ds.Tables[0].Rows.Count;
                Model.order_goods modelt;
                for (int n = 0; n < i; n++)
                {
                    modelt = new Model.order_goods();
                    if (ds.Tables[0].Rows[n]["real_price"] != null && ds.Tables[0].Rows[n]["real_price"].ToString() != "")
                    {
                        modelt.real_price = decimal.Parse(ds.Tables[0].Rows[n]["real_price"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["quantity"] != null && ds.Tables[0].Rows[n]["quantity"].ToString() != "")
                    {
                        modelt.quantity = int.Parse(ds.Tables[0].Rows[n]["quantity"].ToString());
                    }
                    amount = modelt.real_price * modelt.quantity;
                    afteramount = modelt.real_price * num;
                }
                return afteramount-amount;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 莉璹虫い琘兜坝珇羆肂
        /// </summary>
        public decimal GetGoodsRealAmount(string id)
        {
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("select * from " + databaseprefix + "order_goods ");
            strSql2.Append(" where id=@id ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters2[0].Value = id;
            decimal amount = 0;

            DataSet ds = DbHelperSQL.Query(strSql2.ToString(), parameters2);
            if (ds.Tables[0].Rows.Count > 0)
            {
                int i = ds.Tables[0].Rows.Count;
                Model.order_goods modelt;
                for (int n = 0; n < i; n++)
                {
                    modelt = new Model.order_goods();
                    if (ds.Tables[0].Rows[n]["real_price"] != null && ds.Tables[0].Rows[n]["real_price"].ToString() != "")
                    {
                        modelt.real_price = decimal.Parse(ds.Tables[0].Rows[n]["real_price"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["quantity"] != null && ds.Tables[0].Rows[n]["quantity"].ToString() != "")
                    {
                        modelt.quantity = int.Parse(ds.Tables[0].Rows[n]["quantity"].ToString());
                    }
                    amount = modelt.real_price * modelt.quantity;
                }
                return amount;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// р坝珇獺础ら粁,穝畐,埃
        /// </summary>
        public bool DeleteGoods(string id, int user_id, string user_name)
        {
            //础ら粁
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("insert into " + databaseprefix + "order_log ");
            strSql2.Append("select *,@user_id,@user_name,getdate() from " + databaseprefix + "order_goods ");
            strSql2.Append(" where id=@id ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@id", SqlDbType.Int,8),
                    new SqlParameter("@user_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@user_name", SqlDbType.NVarChar,50)};
            parameters2[0].Value = id;
            parameters2[1].Value = user_id;
            parameters2[2].Value = user_name;

            CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            //穝畐
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("update " + databaseprefix + "article_attribute_value ");
            strSql3.Append("set stock_quantity=stock_quantity +(");
            strSql3.Append("select quantity from " + databaseprefix + "order_goods where id=@id)");
            strSql3.Append("where article_id=( ");
            strSql3.Append("select goods_id from " + databaseprefix + "order_goods where id=@id)");
            SqlParameter[] parameters3 = {
					new SqlParameter("@id", SqlDbType.Int,8)};
            parameters3[0].Value = id;

            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            //埃坝珇
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "order_goods ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,8)};
            parameters[0].Value = id;

            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// р睰坝珇,穝畐
        /// </summary>
        public bool AddGoods(int orderid, string id, int num)
        {
            //础ら粁
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("insert into " + databaseprefix + "order_goods([order_id],[goods_id],[goods_title],[goods_price],[real_price],[quantity],[point],[Barcode],[english_name]) ");
            strSql2.Append("select @orderid,article_id,sub_title,sell_price,sell_price,@num,0,Barcode,english_name");
            strSql2.Append(" from " + databaseprefix + "article_attribute_value where article_id=@id");
            SqlParameter[] parameters2 = {
					new SqlParameter("@orderid", SqlDbType.Int,8),
                    new SqlParameter("@id", SqlDbType.NVarChar,50),
                    new SqlParameter("@num", SqlDbType.NVarChar,50)};
            parameters2[0].Value = orderid;
            parameters2[1].Value = id;
            parameters2[2].Value = num;

            CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            //穝畐
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("update " + databaseprefix + "article_attribute_value ");
            strSql3.Append("set stock_quantity=stock_quantity - @num ");
            strSql3.Append("where article_id=@id");
            SqlParameter[] parameters3 = {
					new SqlParameter("@id", SqlDbType.Int,8),
                    new SqlParameter("@num", SqlDbType.Int,8)};
            parameters3[0].Value = id;
            parameters3[1].Value = num;

            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// р坝珇獺础ら粁,穝畐,穝坝珇计秖
        /// </summary>
        public bool UpdateGoodsNum(string id, int num,int user_id,string user_name)
        {
            //础ら粁
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("insert into " + databaseprefix + "order_log ");
            strSql2.Append("select *,@user_id,@user_name,getdate() from " + databaseprefix + "order_goods ");
            strSql2.Append(" where id=@id ");
            SqlParameter[] parameters2 = {
					new SqlParameter("@id", SqlDbType.Int,8),
                    new SqlParameter("@user_id", SqlDbType.NVarChar,50),
                    new SqlParameter("@user_name", SqlDbType.NVarChar,50)};
            parameters2[0].Value = id;
            parameters2[1].Value = user_id;
            parameters2[2].Value = user_name;

            CommandInfo cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            //穝畐
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("update " + databaseprefix + "article_attribute_value ");
            strSql3.Append("set stock_quantity=stock_quantity - (@num - ");
            strSql3.Append("(select isnull(quantity,0) from " + databaseprefix + "order_goods where id=@id))");
            strSql3.Append("where article_id=( ");
            strSql3.Append("select goods_id from " + databaseprefix + "order_goods where id=@id)");
            SqlParameter[] parameters3 = {
					new SqlParameter("@id", SqlDbType.Int,8),
                    new SqlParameter("@num", SqlDbType.Int,8)};
            parameters3[0].Value = id;
            parameters3[1].Value = num;

            cmd = new CommandInfo(strSql3.ToString(), parameters3);
            sqllist.Add(cmd);

            //穝计秖
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "order_goods set quantity=@num ");
            strSql.Append("where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,8),
                    new SqlParameter("@num", SqlDbType.Int,8)
                                        };
            parameters[0].Value = id;
            parameters[1].Value = num;

            cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 沮坝珇ID莉坝珇獺
        /// </summary>
        public Model.article_attribute_value GetModelID(int id)
        {
            #region 琩高獺
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("select * from " + databaseprefix + "article_attribute_value ");
            strSql2.Append(" where article_id=@id ");
            SqlParameter[] parameters2 = {
					    new SqlParameter("@id", SqlDbType.Int,8)};
            parameters2[0].Value = id;
            Model.article_attribute_value modelt = new Model.article_attribute_value();

            DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                int i = ds2.Tables[0].Rows.Count;
                for (int n = 0; n < i; n++)
                {
                    if (ds2.Tables[0].Rows[n]["article_id"] != null && ds2.Tables[0].Rows[n]["article_id"].ToString() != "")
                    {
                        modelt.Id = int.Parse(ds2.Tables[0].Rows[n]["article_id"].ToString());
                    }
                    if (ds2.Tables[0].Rows[n]["sub_title"] != null && ds2.Tables[0].Rows[n]["sub_title"].ToString() != "")
                    {
                        modelt.Title = ds2.Tables[0].Rows[n]["sub_title"].ToString();
                    }
                    if (ds2.Tables[0].Rows[n]["sell_price"] != null && ds2.Tables[0].Rows[n]["sell_price"].ToString() != "")
                    {
                        modelt.Price = decimal.Parse(ds2.Tables[0].Rows[n]["sell_price"].ToString());
                    }
                    if (ds2.Tables[0].Rows[n]["stock_quantity"] != null && ds2.Tables[0].Rows[n]["stock_quantity"].ToString() != "")
                    {
                        modelt.Num = int.Parse(ds2.Tables[0].Rows[n]["stock_quantity"].ToString());
                    }
                }
                return modelt;
            }
            #endregion
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 沮坝珇ID莉坝珇獺
        /// </summary>
        public Model.order_goods GetModelGoods(int id)
        {
            #region 琩高獺
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("select * from " + databaseprefix + "order_goods ");
            strSql2.Append(" where id=@id ");
            SqlParameter[] parameters2 = {
					    new SqlParameter("@id", SqlDbType.Int,8)};
            parameters2[0].Value = id;
            Model.order_goods modelt = new Model.order_goods();

            DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                int i = ds2.Tables[0].Rows.Count;
                for (int n = 0; n < i; n++)
                {
                    if (ds2.Tables[0].Rows[n]["id"] != null && ds2.Tables[0].Rows[n]["id"].ToString() != "")
                    {
                        modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                    }
                    if (ds2.Tables[0].Rows[n]["order_id"] != null && ds2.Tables[0].Rows[n]["order_id"].ToString() != "")
                    {
                        modelt.order_id = int.Parse(ds2.Tables[0].Rows[n]["order_id"].ToString());
                    }
                    if (ds2.Tables[0].Rows[n]["goods_id"] != null && ds2.Tables[0].Rows[n]["goods_id"].ToString() != "")
                    {
                        modelt.goods_id = int.Parse(ds2.Tables[0].Rows[n]["goods_id"].ToString());
                    }
                    if (ds2.Tables[0].Rows[n]["goods_title"] != null && ds2.Tables[0].Rows[n]["goods_title"].ToString() != "")
                    {
                        modelt.goods_title = ds2.Tables[0].Rows[n]["goods_title"].ToString();
                    }
                    if (ds2.Tables[0].Rows[n]["goods_price"] != null && ds2.Tables[0].Rows[n]["goods_price"].ToString() != "")
                    {
                        modelt.goods_price = decimal.Parse(ds2.Tables[0].Rows[n]["goods_price"].ToString());
                    }
                    if (ds2.Tables[0].Rows[n]["real_price"] != null && ds2.Tables[0].Rows[n]["real_price"].ToString() != "")
                    {
                        modelt.real_price = decimal.Parse(ds2.Tables[0].Rows[n]["real_price"].ToString());
                    }
                    if (ds2.Tables[0].Rows[n]["quantity"] != null && ds2.Tables[0].Rows[n]["quantity"].ToString() != "")
                    {
                        modelt.quantity = int.Parse(ds2.Tables[0].Rows[n]["quantity"].ToString());
                    }
                    if (ds2.Tables[0].Rows[n]["point"] != null && ds2.Tables[0].Rows[n]["point"].ToString() != "")
                    {
                        modelt.point = int.Parse(ds2.Tables[0].Rows[n]["point"].ToString());
                    }
                    if (ds2.Tables[0].Rows[n]["Barcode"] != null && ds2.Tables[0].Rows[n]["Barcode"].ToString() != "")
                    {
                        modelt.Barcode = ds2.Tables[0].Rows[n]["Barcode"].ToString();
                    }
                    if (ds2.Tables[0].Rows[n]["english_name"] != null && ds2.Tables[0].Rows[n]["english_name"].ToString() != "")
                    {
                        modelt.english_name = ds2.Tables[0].Rows[n]["english_name"].ToString();
                    }
                }
                return modelt;
            }
            #endregion
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.orders GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * ");
            strSql.Append(" from " + databaseprefix + "orders ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.orders model = new Model.orders();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region 父表信息
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.order_no = ds.Tables[0].Rows[0]["order_no"].ToString();
                model.trade_no = ds.Tables[0].Rows[0]["trade_no"].ToString();
                if (ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                if (ds.Tables[0].Rows[0]["payment_id"].ToString() != "")
                {
                    model.payment_id = int.Parse(ds.Tables[0].Rows[0]["payment_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payment_fee"].ToString() != "")
                {
                    model.payment_fee = decimal.Parse(ds.Tables[0].Rows[0]["payment_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payment_status"].ToString() != "")
                {
                    model.payment_status = int.Parse(ds.Tables[0].Rows[0]["payment_status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payment_time"].ToString() != "")
                {
                    model.payment_time = DateTime.Parse(ds.Tables[0].Rows[0]["payment_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["express_id"].ToString() != "")
                {
                    model.express_id = int.Parse(ds.Tables[0].Rows[0]["express_id"].ToString());
                }
                model.express_no = ds.Tables[0].Rows[0]["express_no"].ToString();
                if (ds.Tables[0].Rows[0]["express_fee"].ToString() != "")
                {
                    model.express_fee = decimal.Parse(ds.Tables[0].Rows[0]["express_fee"].ToString());
                }
                if (ds.Tables[0].Rows[0]["express_status"].ToString() != "")
                {
                    model.express_status = int.Parse(ds.Tables[0].Rows[0]["express_status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["express_time"].ToString() != "")
                {
                    model.express_time = DateTime.Parse(ds.Tables[0].Rows[0]["express_time"].ToString());
                }
                model.accept_name = ds.Tables[0].Rows[0]["accept_name"].ToString();
                model.post_code = ds.Tables[0].Rows[0]["post_code"].ToString();
                model.telphone = ds.Tables[0].Rows[0]["telphone"].ToString();
                model.mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                model.area = ds.Tables[0].Rows[0]["area"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.message = ds.Tables[0].Rows[0]["message"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                model.companyaddress = ds.Tables[0].Rows[0]["companyaddress"].ToString();
                model.companyid = ds.Tables[0].Rows[0]["companyid"].ToString();
                model.companyname = ds.Tables[0].Rows[0]["companyname"].ToString();
                model.wechat = ds.Tables[0].Rows[0]["wechat"].ToString();
                model.city = ds.Tables[0].Rows[0]["city"].ToString();
                model.taxid = ds.Tables[0].Rows[0]["taxid"].ToString();
                if (ds.Tables[0].Rows[0]["payable_amount"].ToString() != "")
                {
                    model.payable_amount = decimal.Parse(ds.Tables[0].Rows[0]["payable_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["real_amount"].ToString() != "")
                {
                    model.real_amount = decimal.Parse(ds.Tables[0].Rows[0]["real_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_amount"].ToString() != "")
                {
                    model.order_amount = decimal.Parse(ds.Tables[0].Rows[0]["order_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["point"].ToString() != "")
                {
                    model.point = int.Parse(ds.Tables[0].Rows[0]["point"].ToString());
                }
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["confirm_time"].ToString() != "")
                {
                    model.confirm_time = DateTime.Parse(ds.Tables[0].Rows[0]["confirm_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["complete_time"].ToString() != "")
                {
                    model.complete_time = DateTime.Parse(ds.Tables[0].Rows[0]["complete_time"].ToString());
                }
                #endregion

                #region 子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select * from " + databaseprefix + "order_goods ");
                strSql2.Append(" where order_id=@id ");
                SqlParameter[] parameters2 = {
					    new SqlParameter("@id", SqlDbType.Int,4)};
                parameters2[0].Value = id;

                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int i = ds2.Tables[0].Rows.Count;
                    List<Model.order_goods> models = new List<Model.order_goods>();
                    Model.order_goods modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Model.order_goods();
                        if (ds2.Tables[0].Rows[n]["id"] != null && ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["order_id"] != null && ds2.Tables[0].Rows[n]["order_id"].ToString() != "")
                        {
                            modelt.order_id = int.Parse(ds2.Tables[0].Rows[n]["order_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["goods_id"] != null && ds2.Tables[0].Rows[n]["goods_id"].ToString() != "")
                        {
                            modelt.goods_id = int.Parse(ds2.Tables[0].Rows[n]["goods_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["goods_title"] != null && ds2.Tables[0].Rows[n]["goods_title"].ToString() != "")
                        {
                            modelt.goods_title = ds2.Tables[0].Rows[n]["goods_title"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["goods_price"] != null && ds2.Tables[0].Rows[n]["goods_price"].ToString() != "")
                        {
                            modelt.goods_price = decimal.Parse(ds2.Tables[0].Rows[n]["goods_price"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["real_price"] != null && ds2.Tables[0].Rows[n]["real_price"].ToString() != "")
                        {
                            modelt.real_price = decimal.Parse(ds2.Tables[0].Rows[n]["real_price"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["quantity"] != null && ds2.Tables[0].Rows[n]["quantity"].ToString() != "")
                        {
                            modelt.quantity = int.Parse(ds2.Tables[0].Rows[n]["quantity"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["point"] != null && ds2.Tables[0].Rows[n]["point"].ToString() != "")
                        {
                            modelt.point = int.Parse(ds2.Tables[0].Rows[n]["point"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["Barcode"] != null && ds2.Tables[0].Rows[n]["Barcode"].ToString() != "")
                        {
                            modelt.Barcode = ds2.Tables[0].Rows[n]["Barcode"].ToString();
                        }
                        if (ds2.Tables[0].Rows[n]["english_name"] != null && ds2.Tables[0].Rows[n]["english_name"].ToString() != "")
                        {
                            modelt.english_name = ds2.Tables[0].Rows[n]["english_name"].ToString();
                        }
                        models.Add(modelt);
                    }
                    model.order_goods = models;
                }
                #endregion

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据订单号返回一个实体
        /// </summary>
        public Model.orders GetModel(string order_no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from " + databaseprefix + "orders");
            strSql.Append(" where order_no=@order_no");
            SqlParameter[] parameters = {
					new SqlParameter("@order_no", SqlDbType.NVarChar,100)};
            parameters[0].Value = order_no;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
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
            strSql.Append(" id,order_no,trade_no,user_id,user_name,payment_id,payment_fee,payment_status,payment_time,express_id,express_no,express_fee,express_status,express_time,accept_name,post_code,telphone,mobile,area,address,message,remark,payable_amount,real_amount,order_amount,point,status,add_time,confirm_time,complete_time ");
            strSql.Append(" FROM " + databaseprefix + "orders ");
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
            strSql.Append("select * FROM " + databaseprefix + "orders");
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