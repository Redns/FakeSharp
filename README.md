# FakeSharp

![version: v1.0.5 (shields.io)](https://img.shields.io/badge/version-v1.0.5-green) ![version: v1.0.0 (shields.io)](https://img.shields.io/badge/.net-v6.0-orange) ![version: v1.0.0 (shields.io)](https://img.shields.io/badge/License-MIT-blue)

## Background

在应用开发过程中我们常常需要对输入参数进行检查，以剔除无效数据，增强程序的稳定性。这就需要我们生成大量的伪数据来进行测试，也即该库的主要功能。

## Install

1. [Nuget](https://www.nuget.org/packages) 搜索 [FakeSharp](https://www.nuget.org/packages/FakeSharp/) 

   ![image-20220609152942809](http://imagebed.krins.cloud/api/image/024L6400.png)

2. 点击右侧 [下载链接](https://www.nuget.org/api/v2/package/FakeSharp/1.0.5) 或使用包管理器下载

   ![image-20220609153037309](http://imagebed.krins.cloud/api/image/448T6488.png)

## Usage

[FakeSharp](https://www.nuget.org/packages/FakeSharp/) 目前支持手机号、银行卡号、身份证号、邮箱号的生成，相应的接口如下

|  生成器  |    接 口     |                    校验地址                    |
| :------: | :----------: | :--------------------------------------------: |
|  手机号  | MobileNumber |        [云检号](https://yunjianhao.cn/)        |
| 银行卡号 |  CreditCard  | [银行卡号归属地查询](http://yinhangkahao.com/) |
| 身份证号 | IdentifyCard | [ip33](http://www.ip33.com/shenfenzheng.html)  |
|  邮箱号  |    Email     |   [邮箱侦探](https://www.mail-verifier.com/)   |

上述的部分信息具有特定的校验规则（如：Luhn），可以通过上述校验地址来检验生成的伪数据是否合法

## Q & A