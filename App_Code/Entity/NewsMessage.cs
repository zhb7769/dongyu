using System;
namespace NetWise.Entity
{
    /// <summary>
    /// Message:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class NewsMessage
    {
        public NewsMessage()
        { }
        #region Model
        private int _id;
        private int _newsid;
        private string _mtitle;
        private string _mcontent;
        private string _mname;
        private string _msex;
        private string _mcompany;
        private string _mtel;
        private string _mfax;
        private string _memail;
        private bool _isread;
        private DateTime _createtime;
        private string _remark;
        private int _p_id;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public int NEWSID
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MTitle
        {
            set { _mtitle = value; }
            get { return _mtitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MContent
        {
            set { _mcontent = value; }
            get { return _mcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MName
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MSex
        {
            set { _msex = value; }
            get { return _msex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MCompany
        {
            set { _mcompany = value; }
            get { return _mcompany; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MTel
        {
            set { _mtel = value; }
            get { return _mtel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MFax
        {
            set { _mfax = value; }
            get { return _mfax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MEmail
        {
            set { _memail = value; }
            get { return _memail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsRead
        {
            set { _isread = value; }
            get { return _isread; }
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

        public int P_ID
        {
            get
            {
                return _p_id;
            }

            set
            {
                _p_id = value;
            }
        }
        #endregion Model

    }
}

