namespace MyCaptchaCodeCore
{
    public class CaptchaOptions
    {
        #region 私有字段

        private int _width;
        private int _height;
        private int _length;
        private string _chars;

        #endregion 私有字段

        #region 公共属性

        /// <summary>
        /// 验证字符长度（字符个数）
        /// </summary>
        public int TextLength
        {
            get { return _length; }
            set { _length = value < 3 ? 3 : value; }
        }

        /// <summary>
        /// 生成验证码用的字符
        /// </summary>
        public string TextChars
        {
            get { return _chars; }
            set { _chars = (string.IsNullOrEmpty(value) || value.Trim().Length < 3) ? "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789" : value.Trim(); }
        }

        /// <summary>
        /// Font warp factor
        /// </summary>
        public Level FontWarp { get; set; }

        /// <summary>
        /// Background Noise level
        /// </summary>
        public Level BackgroundNoise { get; set; }

        /// <summary>
        /// 线条杂色级别
        /// </summary>
        public Level LineNoise { get; set; }

        /// <summary>
        /// 验证码图片宽度
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value < (TextLength * 18) ? TextLength * 18 : value; }
        }

        /// <summary>
        /// 验证码图片高度
        /// </summary>
        public int Height
        {
            get { return _height; }
            set
            {
                _height = value < 20 ? 20 : value;
            }
        }

        #endregion 公共属性

        #region constructor

        public CaptchaOptions()
        {
            FontWarp = Level.None;
            BackgroundNoise = Level.Low;
            LineNoise = Level.Low;
            Width = 120;
            Height = 36;
            TextLength = 6;
        }

        #endregion constructor
    }

    public enum Level
    {
        None,
        Low,
        Medium,
        High,
        Extreme
    }
}