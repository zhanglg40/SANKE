using System;
using System.Data;
using System.Collections.Generic;
using Common;

namespace BLL
{
    /// <summary>
    /// ������
    /// </summary>
    public partial class orders
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private DAL.orders dal;
        public orders()
        {
            dal = new DAL.orders(siteConfig.sysdatabaseprefix);
        }

        /// <summary>
        /// �ӫ~�O�_�s�b
        /// </summary>
        public bool ExistsGoods(int id)
        {
            return dal.ExistsGoods(id);
        }

        /// <summary>
        /// �w�s�O�_��
        /// </summary>
        public bool ExistsGoodsNum(string id,int num,string type)
        {
            return dal.ExistsGoodsNum(id, num, type);
        }

        #region ��������

        public DataSet getData(string strWhere)
        {
            return dal.getData(strWhere);
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string order_no)
        {
            return dal.Exists(order_no);
        }

        /// <summary>
        /// ����������
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.orders model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public bool UpdateField(string order_no, string strValue)
        {
            return dal.UpdateField(order_no, strValue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.orders model)
        {
            //���㶩���ܽ��:��Ʒ�ܽ��+���ͷ���+֧��������
            model.order_amount = model.real_amount + model.express_fee + model.payment_fee;
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
        /// ����q�椤�Y���ӫ~�`���B
        /// </summary>
        public decimal GetGoodsRealAmount(string id)
        {
            return dal.GetGoodsRealAmount(id);
        }

        /// <summary>
        /// ����ӫ~���ܪ��B
        /// </summary>
        public decimal GetGoodsChangeAmount(string id,int num)
        {
            return dal.GetGoodsChangeAmount(id, num);
        }

        /// <summary>
        /// �R���ӫ~
        /// </summary>
        public bool DeleteGoods(string id,int user_id,string user_name)
        {
            return dal.DeleteGoods(id, user_id, user_name);
        }

        /// <summary>
        /// ��s�ӫ~�ƶq
        /// </summary>
        public bool UpdateGoodsNum(string id, int num, int user_id, string user_name)
        {
            return dal.UpdateGoodsNum(id, num, user_id, user_name);
        }

        /// <summary>
        /// �K�[�ӫ~
        /// </summary>
        public bool AddGoods(int orderid, string id, int num)
        {
            return dal.AddGoods(orderid, id, num);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.orders GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// �ھڰӫ~�C��ID����ӫ~�H��
        /// </summary>
        public Model.order_goods GetModelGoods(int id)
        {
            return dal.GetModelGoods(id);
        }

        /// <summary>
        /// �ھڰӫ~ID����ӫ~�H��
        /// </summary>
        public Model.article_attribute_value GetModelID(int id)
        {
            return dal.GetModelID(id);
        }

        /// <summary>
        /// ���ݶ����ŷ���һ��ʵ��
        /// </summary>
        public Model.orders GetModel(string order_no)
        {
            return dal.GetModel(order_no);
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
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion  Method
    }
}