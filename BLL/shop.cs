using System;
using System.Data;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// OAuth授权用户信息
    /// </summary>
    public partial class shop
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.shop dal;
        public shop()
        {
            dal = new DAL.shop(siteConfig.sysdatabaseprefix);
        }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.shop model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.shop model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.shop GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public int GetCount(string strWhere, string filedOrder)
        {
            return dal.GetCount(strWhere, filedOrder);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList( string strWhere, string filedOrder)
        {
            return dal.GetList(strWhere, filedOrder);
        }

        #endregion  Method
    }
}