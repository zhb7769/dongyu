using System;
namespace NetWise.Entity
{
    /// <summary>
    /// News:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class News
    {
        public News()
        { }
        #region Model
        private int _id;
        private int _newsclassid;
        private string _cn_title;
        private string _en_title;
        private string _cn_keywords;
        private string _en_keywords;
        private string _pic_url;
        private string _cn_summary;
        private string _en_summary;
        private string _cn_content;
        private string _en_content;
        private int _sort;
        private bool _istop;
        private DateTime _createtime;
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
        public int NewsClassId
        {
            set { _newsclassid = value; }
            get { return _newsclassid; }
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
        public string CN_KeyWords
        {
            set { _cn_keywords = value; }
            get { return _cn_keywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_KeyWords
        {
            set { _en_keywords = value; }
            get { return _en_keywords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pic_Url
        {
            set { _pic_url = value; }
            get { return _pic_url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_Summary
        {
            set { _cn_summary = value; }
            get { return _cn_summary; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Summary
        {
            set { _en_summary = value; }
            get { return _en_summary; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_Content
        {
            set { _cn_content = value; }
            get { return _cn_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Content
        {
            set { _en_content = value; }
            get { return _en_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
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

