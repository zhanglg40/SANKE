using System;
using System.Data;
using System.Collections.Generic;
using Common;

namespace BLL
{
    /// <summary>
    /// ��������
    /// </summary>
    public partial class article
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //���վ��������Ϣ
        private readonly DAL.article dal;

        public article()
        {
            dal = new DAL.article(siteConfig.sysdatabaseprefix);
        }

        #region ��������=============================================
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        /// <summary>
        /// �Ƿ���ڱ���
        /// </summary>
        public bool ExistsTitle(string title)
        {
            return dal.ExistsTitle(title);
        }
          /// <summary>
        /// �Ƿ���ڱ���
        /// </summary>
        public bool ExistsTitle(string title, int category_id)
        {
            return dal.ExistsTitle(title, category_id);
        }
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string call_index)
        {
            return dal.Exists(call_index);
        }
        public bool ExistsBarcode(string barcode)
        {
            return dal.ExistsBarcode( barcode);
        }
        /// <summary>
        /// ������Ϣ����
        /// </summary>
        public string GetTitle(int id)
        {
            return dal.GetTitle(id);
        }

        /// <summary>
        /// ��ȡ�Ķ�����
        /// </summary>
        public int GetClick(int id)
        {
            return dal.GetClick(id);
        }

        /// <summary>
        /// ������������
        /// </summary>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Model.article model)
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
        public void updateAttribute(int id, string strValue)
        {
            dal.updateAttribute(id, strValue);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Model.article model)
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
        public Model.article GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Model.article GetModel(string call_index)
        {
            return dal.GetModel(call_index);
        }
        public Model.article GetModelNew(string sqlwhere)
        {
            return dal.GetModelNew(sqlwhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        public void updateQuantity(int id, int count)
        {
             dal.updateQuantity( id,  count);
        }
        /// <summary>
        /// ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(int channel_id, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(channel_id, category_id, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        public DataSet GetListNew(int channel_id, int category_id, int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetListNew(channel_id, category_id, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion  Method

        #region ǰ̨ģ���õ��ķ���===================================
        /// <summary>
        /// ������ͼ��ʾǰ��������
        /// </summary>
        public DataSet GetList(string channel_name, int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(channel_name, Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ������ͼ��ʾǰ��������
        /// </summary>
        public DataSet GetList(string channel_name, int category_id, int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(channel_name, category_id, Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ������ͼ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetList(string channel_name, int category_id, int pageIndex, string strWhere, string filedOrder, out int recordCount, out int pageSize)
        {
            pageSize = new channel().GetPageSize(channel_name); //�Զ����Ƶ����ҳ����
            return dal.GetList(channel_name, category_id, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// ������ͼ��ò�ѯ��ҳ����
        /// </summary>
        public DataSet GetListpp(string channel_name, int category_id, int vote_id, int pageIndex, string strWhere, string filedOrder, out int recordCount, out int pageSize)
        {
            pageSize = new channel().GetPageSize(channel_name); //�Զ����Ƶ����ҳ����
            return dal.GetListpp(channel_name, category_id, vote_id, pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        public DataSet GetListgood(int pageIndex, out int recordCount,  int pageSize)
        {
          
            return dal.GetListgood(pageSize, pageIndex,  out recordCount);
        }
        public DataSet GetListthreshold(int pageIndex, out int recordCount, int pageSize)
        {

            return dal.GetListthreshold(pageSize, pageIndex, out recordCount);
        }
          /// <summary>
        /// ������ͼ��ȡ�ܼ�¼��
        /// </summary>
        public int GetCount(string channel_name, int category_id, string strWhere)
        {
            return dal.GetCount(channel_name, category_id,strWhere);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����(�����õ�)
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        /// <summary>
        /// ��ò�ѯ��ҳ����(�����õ�)
        /// </summary>
        public DataSet GetGoodList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetGoodList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion

    }
}