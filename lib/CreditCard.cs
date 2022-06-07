namespace FakeSharp
{
    public class CreditCard
    {
        /// <summary>
        /// Bin码类型
        /// </summary>
        public enum BinType
        {
            Any = 0,
            GongShang = 623062,
            ZhongGuo = 621343,
            JianShe = 622676,
            ZhaoShang = 410062,
            ZhongXin = 433680,
            GuangDa = 622663,
            MinSheng = 622622,
            JiaoTong = 621335,
            PingAn = 622989,
            NongYe = 622848
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
            var r = new Random(DateTime.Now.Second + DateTime.Now.Millisecond);

            for (int i = 0; i < count; i++)
            {
                // 生成bin码
                if (binType == BinType.Any) { fakeCardNumber = (int)GenerateRandomBinCode(r); }
                else { fakeCardNumber = (int)binType; }

                // 添加中间位
                fakeCardNumber += (long)(fakeCardNumber * Math.Pow(10, length - 7)) + r.Next((int)Math.Pow(10, length - 8), (int)(0.9 * Math.Pow(10, length - 7)));

                // 计算校验位
                var sum = 0L;
                var isDoubleBit = true;

                var fakeCardNumberCopy = fakeCardNumber;
                while (fakeCardNumberCopy > 0)
                {
                    if (isDoubleBit)
                    {
                        sum += SelfSum((fakeCardNumberCopy % 10) * 2);
                    }
                    else
                    {
                        sum += fakeCardNumberCopy % 10;
                    }

                    isDoubleBit = !isDoubleBit;
                    fakeCardNumberCopy /= 10;
                }

                var res = sum % 10;
                if (res != 0) { res = 10 - res; }

                // 构造银行卡号
                fakeCardNumbers[i] = $"{fakeCardNumber}{res}";
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


        /// <summary>
        /// 求整数中每位数字之和
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static long SelfSum(long n)
        {
            var sum = n % 10;
            var rest = n;

            while ((rest /= 10) > 0)
            {
                sum += rest % 10;
            }

            return sum;
        }
    }
}