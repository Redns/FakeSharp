using FakeSharp;

namespace test
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 随机生成10条手机号码，移动接入码无限制
            GenerateMobileNumber();

            // 随机生成10个银行卡号，限制Bin码为建设银行
            GenerateCreditCardNumbers();

            // 随机生成10个身份证号
            GenerateIDCardNumbers();

            // 随机生成10个邮箱账号
            GenerateEmails();
        }

        /// <summary>
        /// 随机生成手机号码
        /// </summary>
        static void GenerateMobileNumber()
        {
            var fakeMobileNumbers = MobileNumber.Generate(count:10).ToArray();

            Console.WriteLine("########## 手机号码 ##########");
            for(int i = 0; i < fakeMobileNumbers.Length; i++)
            {
                Console.WriteLine($"[{i}]{fakeMobileNumbers[i]}");
            }
        }


        /// <summary>
        /// 随机生成银行卡号
        /// </summary>
        static void GenerateCreditCardNumbers()
        {
            var fakeCreditCardNumbers = CreditCard.Generate(CreditCard.BinType.Any, count: 10).ToArray();

            Console.WriteLine("########## 银行卡号 ##########");
            for (int i = 0; i < fakeCreditCardNumbers.Length; i++)
            {
                Console.WriteLine($"[{i}]{fakeCreditCardNumbers[i]}");
            }
        }


        /// <summary>
        /// 随机生成身份证号
        /// </summary>
        static void GenerateIDCardNumbers()
        {
            var fakeIDCardNumbers = IdentifyCard.Generate(count: 10).ToArray();

            Console.WriteLine("########## 身份证号 ##########");
            for (int i = 0; i < fakeIDCardNumbers.Length; i++)
            {
                Console.WriteLine($"[{i}]{fakeIDCardNumbers[i]}");
            }
        }

        /// <summary>
        /// 随机生成邮箱号
        /// </summary>
        static void GenerateEmails()
        {
            var fakeEmails = Email.Generate(count: 10, format:Email.Format.Any).ToArray();

            Console.WriteLine("########## 邮箱号 ##########");
            for (int i = 0; i < fakeEmails.Length; i++)
            {
                Console.WriteLine($"[{i}]{fakeEmails[i]}");
            }
        }
    }
}