using System;
namespace Model
{
    /// <summary>
    /// 用户申请码
    /// </summary>
    [Serializable]
    public partial class shop_log
    {
        public shop_log()
        { }
        #region Model
        private int _id;
        private int _goods_id;
        private int _shop_id;
        private DateTime _createDate;
        private int _user_id;
        private int _quantity;
        private string _shop_name;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        public int goods_id
        {
            set { _goods_id = value; }
            get { return _goods_id; }
        }

        public int shop_id
        {
            set { _shop_id = value; }
            get { return _shop_id; }
        }

        /// <summary>
        /// 店铺名称
        /// </summary>
        public string shop_name
        {
            set { _shop_name = value; }
            get { return _shop_name; }
        }

        public int user_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }

        public int quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }

        

        #endregion Model

    }
}