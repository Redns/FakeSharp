namespace FakeSharp
{
    public class Email
    {
        static readonly string[] EMAIL_SUFFIX = { "163.com", "qq.com", "126.com", "139.com", "gmail.com", "yahoo.com", "msn.com",
                                                  "hotmail.com", "aol.com", "ask.com", "live.com", "outlook.com", "163.net" };
        static readonly char[] LEGAL_CHARACTER_NUMBER = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '_', 'a', 'b', 'c', 'd', 'e', 'f',
                                                          'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w',
                                                          'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                                          'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
        static readonly char[] LEGAL_CHARACTER = { '_', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 
                                                   's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 
                                                   'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        public enum Format
        {
            Any = 0,        // 任意
            Number,         // 仅数字
            Character,      // 仅字符
        }


        /// <summary>
        /// 生成邮箱账号
        /// </summary>
        /// <param name="emailSuffix">邮箱后缀数组</param>
        /// <param name="minLength">最小长度</param>
        /// <param name="maxLength">最大长度</param>
        /// <param name="count">生成数量</param>
        /// <returns></returns>
        public static IEnumerable<string> Generate(string[]? emailSuffix = null, int minLength = 8, int maxLength = 8, int count = 100, Format format = Format.Any)
        {
            // 检验输入参数
            if(emailSuffix == null) { emailSuffix = EMAIL_SUFFIX; }
            if(minLength <= 0) { minLength = 8; }
            if(maxLength <= 0) { maxLength = 8; }
            if(minLength > maxLength) { minLength = maxLength; }
            if(count <= 0) { count = 100; }

            var fakeEmails = new string[count];
            var random = new Random(DateTime.Now.Second * 1000 + DateTime.Now.Millisecond);

            // 48-57：数字0~9
            // 65-90：大写字母A~Z
            // 97-122：小写字母a~z
            // 95：下划线
            for(int i = 0; i < count; i++)
            {
                fakeEmails[i] = string.Empty;
                if(format == Format.Any)
                {
                    for (int j = 0; j < random.Next(minLength, maxLength + 1); j++)
                    {
                        fakeEmails[i] += LEGAL_CHARACTER_NUMBER[random.Next(LEGAL_CHARACTER.Length)];
                    }
                }
                else if(format == Format.Number)
                {
                    for (int j = 0; j < random.Next(minLength, maxLength + 1); j++)
                    {
                        fakeEmails[i] += $"{random.Next(10)}";
                    }
                }
                else if(format == Format.Character)
                {
                    for (int j = 0; j < random.Next(minLength, maxLength + 1); j++)
                    {
                        fakeEmails[i] += LEGAL_CHARACTER[random.Next(LEGAL_CHARACTER.Length)];
                    }
                }
                else
                {

                }
                
                fakeEmails[i] += $"@{emailSuffix[random.Next(emailSuffix.Length)]}";
            }

            return fakeEmails;
        }
    }
}
