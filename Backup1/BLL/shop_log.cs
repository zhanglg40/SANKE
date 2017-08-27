using System;
using System.Data;
using System.Collections.Generic;

namespace BLL
{
    /// <summary>
    /// OAuth��Ȩ�û���Ϣ
    /// </summary>
    public partial class shop_log
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.shop_log dal;
        public shop_log()
        {
            dal = new DAL.shop_log(siteConfig.sysdatabaseprefix);
        }

        #region  Method
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(Model.shop_log model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.shop_log model)
        {
            return dal.Add(model);
        }



        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        public bool DeleteAll(int user_id)
        {
            return dal.DeleteAll(user_id);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.shop_log GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public int GetCount(string strWhere, string filedOrder)
        {
            return dal.GetCount(strWhere, filedOrder);
        }


        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList( string strWhere, string filedOrder)
        {
            return dal.GetList(strWhere, filedOrder);
        }
           public DataSet GetDList(string strWhere, string filedOrder)
        {
            return dal.GetDList(strWhere, filedOrder);
        }
        #endregion  Method

        public DataSet GetShopList(string strWhere, string filedOrder)
        {
            return dal.GetShopList(strWhere, filedOrder);
        }

        public int AddList(List<Model.shop_log> list)
        {
            int n = 0;
            foreach (Model.shop_log model in list)
            {
                n++;
                if (Exists(model))
                {
                    dal.UpdateCount(model);
                }
                else
                {
                    dal.Add(model);
                }
             
           }
            return n;
        }

        public bool Update(int id,  int quantity)
        {
            Model.shop_log model = new Model.shop_log();
            model.id = id;
           
            model.quantity = quantity;
           return dal.UpdateCount(model);
        }
    }
}