using System;
namespace NetWise.Entity
{
    /// <summary>
    /// CountryType:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class CountryType
    {
        public CountryType()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _en_name;
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
        #endregion Model

    }
}

