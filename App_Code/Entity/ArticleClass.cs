using System;
namespace NetWise.Entity
{
    /// <summary>
    /// ArticleClass:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ArticleClass
    {
        public ArticleClass()
        { }
        #region Model
        private int _id;
        private string _cn_name;
        private string _en_name;
        private string _parentid;
        private int _sort;
        private string _cn_url;
        private string _en_url;
        private int _depth;
        private bool _isshow;
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
        public string ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
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
        public string CN_Url
        {
            set { _cn_url = value; }
            get { return _cn_url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Url
        {
            set { _en_url = value; }
            get { return _en_url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsShow
        {
            set { _isshow = value; }
            get { return _isshow; }
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

