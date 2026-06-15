using System;
namespace NetWise.Entity
{
    /// <summary>
    /// Link:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Link
    {
        public Link()
        { }
        #region Model
        private int _id;
        private string _linkname;
        private string _linkname_en;
        private string _linkpic;
        private string _linkurl;
        private int _linktype;
        private int _sort;
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
        public string LinkName
        {
            set { _linkname = value; }
            get { return _linkname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkName_en
        {
            set { _linkname_en = value; }
            get { return _linkname_en; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkPic
        {
            set { _linkpic = value; }
            get { return _linkpic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkUrl
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        public int LinkType
        {
            get { return _linktype; }
            set { _linktype = value; }
        }
        #endregion Model

    }
}

