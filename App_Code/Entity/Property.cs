using System;
namespace NetWise.Entity
{
    /// <summary>
    /// Property:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Property
    {
        public Property()
        { }
        #region Model
        private int _id;
        private int _productid;
        private string _cn_name;
        private string _en_name;
        private string _cn_value;
        private string _en_value;
        private string _remark;
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
        public int ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_Name
        {
            set { _cn_name = value; }
            get { return _cn_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Name
        {
            set { _en_name = value; }
            get { return _en_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_Value
        {
            set { _cn_value = value; }
            get { return _cn_value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Value
        {
            set { _en_value = value; }
            get { return _en_value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}