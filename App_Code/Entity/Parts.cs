using System;
namespace NetWise.Entity
{
    /// <summary>
    /// Parts:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Parts
    {
        public Parts()
        { }
        #region Model
        private int _p_id;
        private string _cn_name;
        private string _en_name;
        private string _cn_label;
        private string _en_label;
        private string _s_img;
        private string _m_img;
        private string _o_img;
        private string _l_img;
        private string _cn_synopsis;
        private string _en_synopsis;
        private int _classid;
        private bool _ispage;
        private bool _istop;
        private DateTime _createtime;
        private int _sort;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int P_Id
        {
            set { _p_id = value; }
            get { return _p_id; }
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
        public string CN_Label
        {
            set { _cn_label = value; }
            get { return _cn_label; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Label
        {
            set { _en_label = value; }
            get { return _en_label; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string S_Img
        {
            set { _s_img = value; }
            get { return _s_img; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string M_Img
        {
            set { _m_img = value; }
            get { return _m_img; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string O_Img
        {
            set { _o_img = value; }
            get { return _o_img; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string L_Img
        {
            set { _l_img = value; }
            get { return _l_img; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_Synopsis
        {
            set { _cn_synopsis = value; }
            get { return _cn_synopsis; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Synopsis
        {
            set { _en_synopsis = value; }
            get { return _en_synopsis; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ClassId
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsPage
        {
            set { _ispage = value; }
            get { return _ispage; }
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
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
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

