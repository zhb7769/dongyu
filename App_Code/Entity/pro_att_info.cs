using System;
namespace NetWise.Entity
{
    /// <summary>
    /// pro_att_info:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class pro_att_info
    {
        public pro_att_info()
        { }
        #region Model
        private int _at_id;
        private int _pro_id;
        private string _pro_img;
        private DateTime? _create_time;
        /// <summary>
        /// 
        /// </summary>
        public int at_id
        {
            set { _at_id = value; }
            get { return _at_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pro_id
        {
            set { _pro_id = value; }
            get { return _pro_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pro_img
        {
            set { _pro_img = value; }
            get { return _pro_img; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        #endregion Model

    }
}


