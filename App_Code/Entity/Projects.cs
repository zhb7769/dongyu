using System;
namespace NetWise.Entity
{
    /// <summary>
    /// Projects:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Projects
    {
        public Projects()
        { }
        #region Model
        private int _id;
        private int _classid;
        private string _cn_title;
        private string _en_title;
        private string _cn_summary;
        private string _en_summary;
        private string _pic_url;
        private string _cn_content;
        private string _en_content;
        private DateTime _createtime;
        private int _sort;
        private bool _homeshow;
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
        public int ClassID
        {
            set { _classid = value; }
            get { return _classid; }
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
        public string Pic_Url
        {
            set { _pic_url = value; }
            get { return _pic_url; }
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
        /// 
        /// </summary>
        public bool HomeShow
        {
            set { _homeshow = value; }
            get { return _homeshow; }
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


