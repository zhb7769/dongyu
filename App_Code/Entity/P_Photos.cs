using System;
namespace NetWise.Entity
{
    /// <summary>
    /// P_Photos:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class P_Photos
    {
        public P_Photos()
        { }
        #region Model
        private int _id;
        private int _productid;
        private string _cn_title;
        private string _en_title;
        private string _s_img;
        private string _m_img;
        private string _o_img;
        private string _l_img;
        private int _sort;
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
        public int ProductId
        {
            set { _productid = value; }
            get { return _productid; }
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
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
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

