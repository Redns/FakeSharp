using FakeSharp.Common;

namespace FakeSharp
{
    public class IdentifyCard
    {
        static readonly string[] PROVINCE_CODE = { "11", "12", "13", "14", "15", "21", "22", "23", "31", "32", "33", "34", "35", "36",
                                                   "37", "42", "42", "43", "44", "45", "46", "50", "51", "52", "53", "54", "61", "62",
                                                   "63", "64", "65", "71", "81", "82" };
        static readonly string[] PREFECTURE_CODE = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13",
                                                     "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26",
                                                     "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39",
                                                     "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52",
                                                     "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65",
                                                     "66", "67", "68", "69", "70", "90" };

        /// <summary>
        /// 生成身份证号
        /// </summary>
        /// <param name="dateStart">起始日期</param>
        /// <param name="dateEnd">终止日期</param>
        /// <param name="gender">性别</param>
        /// <param name="count">生成数量</param>
        /// <returns></returns>
        public static IEnumerable<string> Generate(DateTime? dateStart = null, DateTime? dateEnd = null, Gender gender = Gender.Any, int count = 100)
        {
            var IDCardNumber = "";
            var fakeIDCardNumbers = new string[count];
            var random = new Random(DateTime.Now.Second * 1000 + DateTime.Now.Millisecond);

            // 检查输入参数
            if(dateStart == null) { dateStart = new DateTime(1949, 10, 1); }
            if(dateEnd == null) { dateEnd = DateTime.Now; }
            if(dateStart > dateEnd) { dateStart = dateEnd; }

            for(int i = 0; i < count; i++)
            {
                IDCardNumber = $"{PROVINCE_CODE[random.Next(PROVINCE_CODE.Length)]}{PREFECTURE_CODE[random.Next(PREFECTURE_CODE.Length)]}{random.Next(100):D2}{random.Next(dateStart.Value.Year, dateEnd.Value.Year + 1)}{random.Next(13):D2}{random.Next(29):D2}{random.Next(100):D2}";
                
                // 添加性别位
                _ = gender switch
                {
                    Gender.Any => IDCardNumber += $"{random.Next(10)}",
                    Gender.Male => IDCardNumber += $"{random.Next(5) * 2 + 1}",
                    Gender.Female => IDCardNumber += $"{random.Next(5) * 2}",
                    _ => ""
                };

                // 添加校验位
                fakeIDCardNumbers[i] = $"{IDCardNumber}{CheckMethod.IDCardCheck(IDCardNumber)}";
            }

            return fakeIDCardNumbers;
        }


        /// <summary>
        /// 性别
        /// </summary>
        public enum Gender
        {
            Any = 0,        // 任意
            Male = 1,       // 男性
            Female = 2      // 女性
        }
    }
}
