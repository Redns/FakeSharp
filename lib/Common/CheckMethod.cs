namespace FakeSharp.Common
{
    public class CheckMethod
    {
        /// <summary>
        /// Luhn校验，用于银行卡号、IMEI、社会保险等场合
        /// </summary>
        /// <param name="n">待校验的数字</param>
        /// <returns></returns>
        public static int Luhn(long n)
        {
            var sum = 0L;
            var isDoubleBit = true;

            while (n > 0)
            {
                if (isDoubleBit) { sum += SelfSum((n % 10) * 2); }
                else { sum += n % 10; }

                isDoubleBit = !isDoubleBit;
                n /= 10;
            }

            var res = sum % 10;
            if (res != 0) { res = 10 - res; }

            return (int)res;
        }


        /// <summary>
        /// 身份证号校验
        /// </summary>
        /// <param name="n">身份证号码（不含校验码）</param>
        /// <returns></returns>
        public static char IDCardCheck(string number)
        {
            if(number.Length != 17)
            {
                return 'E';
            }
            else
            {
                var sum = (number[0] - 48) * 7 + (number[1] - 48) * 9 + (number[2] - 48) * 10 +
                      (number[3] - 48) * 5 + (number[4] - 48) * 8 + (number[5] - 48) * 4 +
                      (number[6] - 48) * 2 + (number[7] - 48) * 1 + (number[8] - 48) * 6 +
                      (number[9] - 48) * 3 + (number[10] - 48) * 7 + (number[11] - 48) * 9 +
                      (number[12] - 48) * 10 + (number[13] - 48) * 5 + (number[14] - 48) * 8 +
                      (number[15] - 48) * 4 + (number[16] - 48) * 2;
                return (sum % 11) switch
                {
                    0 => '1',
                    1 => '0',
                    2 => 'X',
                    3 => '9',
                    4 => '8',
                    5 => '7',
                    6 => '6',
                    7 => '5',
                    8 => '4',
                    9 => '3',
                    10 => '2',
                    _ => 'E'
                };
            }
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
