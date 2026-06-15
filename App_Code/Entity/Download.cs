using System;
namespace NetWise.Entity
{
    /// <summary>
    /// Download:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Download
    {
        public Download()
        { }
        #region Model
        private int _id;
        private string _cn_title;
        private string _en_title;
        private string _cn_summary;
        private string _en_summary;
        private string _download_url;
        private string _cn_content;
        private string _en_content;
        private DateTime _createtime;
        private int _sort;
        private int _ClassId;
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
        public string Download_Url
        {
            set { _download_url = value; }
            get { return _download_url; }
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
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
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
        /// 分类
        /// </summary>
        public int ClassId
        {
            set { _ClassId = value; }
            get { return _ClassId; }
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


