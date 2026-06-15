using System;
namespace NetWise.Entity
{
    /// <summary>
    /// PurchasingChannelsType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PurchasingChannelsType
    {
        public PurchasingChannelsType()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _en_name;
        private int? _ctype;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_name
        {
            set { _en_name = value; }
            get { return _en_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cType
        {
            set { _ctype = value; }
            get { return _ctype; }
        }
        #endregion Model

    }
}

