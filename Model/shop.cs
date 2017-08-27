using System;
namespace Model
{
    /// <summary>
    /// 用户申请码
    /// </summary>
    [Serializable]
    public partial class shop
    {
        public shop()
        { }
        #region Model
        private int _id;
        private string _shop_name;
        private string _linkman;
        private string _address = "";
        private string _telphone;
        private int _user_id;
        private string _city;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
      
        /// <summary>
        /// " + Resources.lang.username+ "
        /// </summary>
        public string linkman
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string shop_name
        {
            set { _shop_name = value; }
            get { return _shop_name; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        public int user_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }

        

        /// <summary>
        /// 手机
        /// </summary>
        public string telphone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
         public string city{
             set { _city = value; }
             get { return _city; }
        }
        

        #endregion Model

    }
}