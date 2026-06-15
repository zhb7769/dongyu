using System;
namespace NetWise.Entity
{
    /// <summary>
    /// ProductRegister:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProductRegister
    {
        public ProductRegister()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _en_username;
        private string _email;
        private string _en_country;
        private string _serialnumber;
        private string _en_serialnumber;
        private string _producttype;
        private string _en_producttype;
        private DateTime? _purchasedate;
        private int? _c_id;
        private int? _channels_id;
        private bool _isreceive;
        private string _v1;
        private string _v2;
        private string _v3;
        private string _v4;
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
        public string userName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_userName
        {
            set { _en_username = value; }
            get { return _en_username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_country
        {
            set { _en_country = value; }
            get { return _en_country; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string serialNumber
        {
            set { _serialnumber = value; }
            get { return _serialnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_serialNumber
        {
            set { _en_serialnumber = value; }
            get { return _en_serialnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productType
        {
            set { _producttype = value; }
            get { return _producttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_productType
        {
            set { _en_producttype = value; }
            get { return _en_producttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PurchaseDate
        {
            set { _purchasedate = value; }
            get { return _purchasedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? c_id
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? channels_id
        {
            set { _channels_id = value; }
            get { return _channels_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isReceive
        {
            set { _isreceive = value; }
            get { return _isreceive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string V1
        {
            set { _v1 = value; }
            get { return _v1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string V2
        {
            set { _v2 = value; }
            get { return _v2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string V3
        {
            set { _v3 = value; }
            get { return _v3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string V4
        {
            set { _v4 = value; }
            get { return _v4; }
        }
        #endregion Model

    }
}

