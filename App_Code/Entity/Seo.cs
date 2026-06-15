using System;
namespace NetWise.Entity
{
    /// <summary>
    /// Seo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Seo
    {
        public Seo()
        { }
        #region Model
        private int _id;
        private string _cn_title;
        private string _en_title;
        private string _cn_keywords;
        private string _en_keywords;
        private string _cn_description;
        private string _en_description;
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
        public string CN_Title
        {
            set { _cn_title = value; }
            get { return _cn_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Title
        {
            set { _en_title = value; }
            get { return _en_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_Keywords
        {
            set { _cn_keywords = value; }
            get { return _cn_keywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Keywords
        {
            set { _en_keywords = value; }
            get { return _en_keywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_Description
        {
            set { _cn_description = value; }
            get { return _cn_description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Description
        {
            set { _en_description = value; }
            get { return _en_description; }
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

