using FakeSharp.Common;

namespace FakeSharp
{
    public class CreditCard
    {
        /// <summary>
        /// Bin码类型
        /// </summary>
        public enum BinType
        {
            Any = 0,                // 任意
            GongShang = 623062,     // 工商银行
            ZhongGuo = 621343,      // 中国银行
            JianShe = 622676,       // 建设银行
            ZhaoShang = 410062,     // 招商银行
            ZhongXin = 433680,      // 中信银行
            GuangDa = 622663,       // 光大银行
            MinSheng = 622622,      // 民生银行
            JiaoTong = 621335,      // 交通银行
            PingAn = 622989,        // 平安银行
            NongYe = 622848         // 农业银行
        }


        /// <summary>
        /// 生成银行卡号
        /// </summary>
        /// <param name="binType">Bin码类型</param>
        /// <param name="length">银行卡号长度</param>
        /// <param name="count">生成数量</param>
        /// <returns></returns>
        public static IEnumerable<string> Generate(BinType binType = BinType.Any, int length = 16, int count = 100)
        {
            var fakeCardNumber = 0L;
            var fakeCardNumbers = new string[count];
            var r = new Random(DateTime.Now.Second * 1000 + DateTime.Now.Millisecond);

            for (int i = 0; i < count; i++)
            {
                // 生成bin码
                if (binType == BinType.Any) { fakeCardNumber = (int)GenerateRandomBinCode(r); }
                else { fakeCardNumber = (int)binType; }

                // 添加中间位
                fakeCardNumber += (long)(fakeCardNumber * Math.Pow(10, length - 7)) + r.Next((int)Math.Pow(10, length - 8), (int)(0.9 * Math.Pow(10, length - 7)));

                // 构造银行卡号
                fakeCardNumbers[i] = $"{fakeCardNumber}{CheckMethod.Luhn(fakeCardNumber)}";
            }

            return fakeCardNumbers;
        }


        /// <summary>
        /// 随机生成Bin码
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        static BinType GenerateRandomBinCode(Random? r = null)
        {
            if (r == null) { r = new Random(DateTime.Now.Second + DateTime.Now.Millisecond); }
            return r.Next(10) switch
            {
                0 => BinType.GongShang,
                1 => BinType.ZhongGuo,
                2 => BinType.JianShe,
                3 => BinType.ZhaoShang,
                4 => BinType.ZhongXin,
                5 => BinType.GuangDa,
                6 => BinType.MinSheng,
                7 => BinType.JiaoTong,
                8 => BinType.PingAn,
                9 => BinType.NongYe,
                _ => BinType.Any
            };
        }
    }
}