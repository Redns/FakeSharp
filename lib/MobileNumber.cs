namespace FakeSharp
{
    /// <summary>
    /// 手机号码生成器
    /// </summary>
    public class MobileNumber
    {
        static readonly int[] MAC_CHINA_MOBILE = { 134, 135, 136, 137, 138, 139, 150, 151, 152, 157, 158, 159, 182, 187, 188};
        static readonly int[] MAC_CHINA_UNICOM = { 130, 131, 132, 155, 156, 182, 185, 186 };
        static readonly int[] MAC_CHINA_TELECOM = { 133, 153, 180, 189 };
        static readonly int[] MAC_CHINA_ALL = { 134, 135, 136, 137, 138, 139, 150, 151, 152, 157, 158, 159, 182, 187, 188, 130, 131, 132, 155, 156, 182, 185, 186, 133, 153, 180, 189 };


        /// <summary>
        /// 生成手机号码
        /// </summary>
        /// <param name="macConfig">移动接入码</param>
        /// <param name="count">生成数量</param>
        /// <returns></returns>
        public static IEnumerable<string> Generate(MAC macConfig = MAC.Any, int count = 100)
        {
            var r = new Random(DateTime.Now.Second * 1000 + DateTime.Now.Millisecond);
            var fakeNumbers = new string[count];
            for(int i = 0; i < count; i++)
            {
                int mac = macConfig switch
                {
                    MAC.ChinaMobile => MAC_CHINA_MOBILE[r.Next(MAC_CHINA_MOBILE.Length)],
                    MAC.ChinaUnicom => MAC_CHINA_UNICOM[r.Next(MAC_CHINA_UNICOM.Length)],
                    MAC.ChinaTelecom => MAC_CHINA_TELECOM[r.Next(MAC_CHINA_TELECOM.Length)],
                    _ => MAC_CHINA_ALL[r.Next(MAC_CHINA_ALL.Length)],
                };
                fakeNumbers[i] = $"{mac}{r.Next(10000000, 89999999)}";
            }
            return fakeNumbers;
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
}
