using System;
namespace Model
{
    /// <summary>
    /// 用户申请码
    /// </summary>
    [Serializable]
    public partial class user_address
    {
        public user_address()
        { }
        #region Model
        private int _id;
        private string _user_name;
        private string _nick_name;
        private string _address = "";
        private string _telphone;
        private string _mobile;
        private decimal _is_check = 0;
        private string _city = "";
        private string _post_code = "";
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
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// " + Resources.lang.Receiver+ "
        /// </summary>
        public string nick_name
        {
            set { _nick_name = value; }
            get { return _nick_name; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
          public string post_code
        {
            set { _post_code = value; }
            get { return _post_code; }
        }
          public string city
          {
              set { _city = value; }
              get { return _city; }
          }
        /// <summary>
        /// 默认地址0未默认1已默认
        /// </summary>
        public decimal is_check
        {
            set { _is_check = value; }
            get { return _is_check; }
        }

        /// <summary>
        /// 手机
        /// </summary>
        public string telphone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        #endregion Model

    }
}