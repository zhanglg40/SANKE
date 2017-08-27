using System;
using System.Data;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// OAuth��Ȩ�û���Ϣ
    /// </summary>
    public partial class shop
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.shop dal;
        public shop()
        {
            dal = new DAL.shop(siteConfig.sysdatabaseprefix);
        }

        #region  Method
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.shop model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.shop model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
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
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList( string strWhere, string filedOrder)
        {
            return dal.GetList(strWhere, filedOrder);
        }

        #endregion  Method
    }
}