namespace FakeData
{
    /// <summary>
    /// 手机号码生成器
    /// </summary>
    public class MobileNumberGenerator
    {
        public static readonly int[] MAC_CHINA_MOBILE = { 134, 135, 136, 137, 138, 139, 150, 151, 152, 157, 158, 159, 182, 187, 188};
        public static readonly int[] MAC_CHINA_UNICOM = { 130, 131, 132, 155, 156, 182, 185, 186 };
        public static readonly int[] MAC_CHINA_TELECOM = { 133, 153, 180, 189 };

        /// <summary>
        /// 生成手机号码
        /// </summary>
        /// <param name="config">生成器配置</param>
        /// <param name="count">单次生成的数量</param>
        /// <returns></returns>
        public static IEnumerable<string> Generate(MobileNumberGeneratorConfig config, int count = 1)
        {
            var fakeNumbers = new List<string>();
            for(int i = 0; i < count; i++)
            {
                fakeNumbers.Add($"{GenerateMAC(config.MAC)}{config.R.Next(89999999) + 10000000}");
            }
            return fakeNumbers;
        }

        /// <summary>
        /// 生成随机移动接入码
        /// </summary>
        /// <param name="mac"></param>
        /// <returns></returns>
        public static int GenerateMAC(MAC mac)
        {
            return mac switch
            {
                MAC.ChinaMobile => MAC_CHINA_MOBILE[new Guid().GetHashCode() % MAC_CHINA_MOBILE.Length],
                MAC.ChinaUnicom => MAC_CHINA_UNICOM[new Guid().GetHashCode() % MAC_CHINA_UNICOM.Length],
                MAC.ChinaTelecom => MAC_CHINA_TELECOM[new Guid().GetHashCode() % MAC_CHINA_TELECOM.Length],
                _ => GenerateMAC(MAC.Any + new Guid().GetHashCode() % 3 + 1),
            };
        }
    }

    /// <summary>
    /// 手机号码生成器配置
    /// </summary>
    public class MobileNumberGeneratorConfig
    {
        public MAC MAC { get; set; }        // 移动接入码
        public Random R { get; set; }       // 随机数生成器

        public MobileNumberGeneratorConfig()
        {
            MAC = MAC.Any;
            R = new Random(DateTime.Now.Millisecond);
        }

        public MobileNumberGeneratorConfig(MAC mac, Random r)
        {
            MAC = mac;
            R = r;
        }
    }

    /// <summary>
    /// 移动接入码(移动、联通、电信)
    /// </summary>
    public enum MAC
    {
        Any = 0,            // 任意
        ChinaMobile,        // 中国移动
        ChinaUnicom,        // 中国联通
        ChinaTelecom        // 中国电信
    }
}
