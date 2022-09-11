using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace iofficeTools
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("pwd加密选1");
			Console.WriteLine("sam加密选2");
			Console.WriteLine("sam解密选3");
			Console.WriteLine("dbpwd解密选4");
			Program program = new Program();
			while (true)
			{
				string str = Console.ReadLine();
				if (str.Equals("1"))
				{
					string pwd = Console.ReadLine();
					if (pwd.Length != 0)
					{
						Console.WriteLine("加密后的结果是：" + program.ConPwdHashString(pwd));
						Console.WriteLine("-------------------------------分割线-------------------------------");
					}
					else
					{
						Console.WriteLine("记得输入pwd的值！！！");
						Console.WriteLine("-------------------------------分割线-------------------------------");
					}

				}
				else if (str.Equals("2"))
				{
					string sam = Console.ReadLine();
					if (sam.Length != 0)
					{
						Console.WriteLine("加密后的结果是：" + program.SetSam(sam));
						Console.WriteLine("-------------------------------分割线-------------------------------");
					}
					else
					{
						Console.WriteLine("记得输入sam的值！！！");
						Console.WriteLine("-------------------------------分割线-------------------------------");
					}
				}
				else if (str.Equals("3"))
				{
					string sam = Console.ReadLine();
					if (sam.Length != 0)
					{
						Console.WriteLine("解密后的结果是：" + program.GetSam(sam));
						Console.WriteLine("-------------------------------分割线-------------------------------");
					}
					else
					{
						Console.WriteLine("记得输入sam的值！！！");
						Console.WriteLine("-------------------------------分割线-------------------------------");
					}
				}
				else if (str.Equals("4"))
				{
					string dbpwd = Console.ReadLine();
					if (dbpwd.Length != 0)
					{
						Console.WriteLine("解密后的结果是：" + program.decrypt(dbpwd));
						Console.WriteLine("-------------------------------分割线-------------------------------");
					}
					else
					{
						Console.WriteLine("记得输入dbpwd的值！！！");
						Console.WriteLine("-------------------------------分割线-------------------------------");
					}
				}
				else
				{
					Console.WriteLine("请选择正确的数字");
					Console.WriteLine("-------------------------------分割线-------------------------------");
				}
			}
		}
		private TripleDESCryptoServiceProvider des
		{
			get
			{
				if (true)
				{
				}
				return new TripleDESCryptoServiceProvider
				{
					Key = Convert.FromBase64String("RgGmPmIgEho9US3k2J4/ZgHLkFqx1PxZ"),
					IV = Convert.FromBase64String("wGbijR8MUTo=")
				};
			}
		}

		//web.config dbpwd解密密
		private string decrypt(string A_0)
		{
			if (Operators.CompareString(A_0, "", false) == 0)
			{
				if (true)
				{
				}
			}
			else
			{
				try
				{
					byte[] array = Convert.FromBase64String(A_0);
					return Encoding.UTF8.GetString(this.des.CreateDecryptor().TransformFinalBlock(array, 0, array.Length));
				}
				catch (Exception ex)
				{
					return "解密失败";
				}
			}
			return "";
		}
		//web.config dbpwd加密
		private string encrypt(string A_0)
		{
			if (Operators.CompareString(A_0, "", false) != 0)
			{
				try
				{
					byte[] bytes = Encoding.UTF8.GetBytes(A_0);
					return Convert.ToBase64String(this.des.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
				}
				catch (Exception ex)
				{
					return "加密失败";
				}
			}
			if (true)
			{
			}
			return "";
		}

		//密码加密
		string ConPwdHashString(string strPwd)
		{
			byte[] value = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(new ASCIIEncoding().GetBytes(Strings.Trim(strPwd)));
			return BitConverter.ToString(value);
		}

		//解密sam
		string GetSam(string sam)
		{
			string[] array = Strings.Split(sam, "O", -1, CompareMethod.Binary);
			bool flag = Operators.CompareString(sam, "", false) == 0;
			checked
			{
				string text;
				if (flag)
				{
					text = "";
				}
				else
				{
					text = "";
					int num = 0;
					int num2 = Information.UBound(array, 1);
					int num3 = num;
					for (; ; )
					{
						int num4 = num3;
						int num5 = num2;
						if (num4 > num5)
						{
							break;
						}
						text += Conversions.ToString(Strings.Chr((int)Math.Round(Conversions.ToDouble(array[num3]) / 15192332.0)));
						num3++;
					}
					text = Microsoft.VisualBasic.Strings.StrReverse(text);
				}
				return text;
			}
		}


		//加密sam
		string SetSam(string sam)
		{
			bool flag = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(sam, "", false) == 0;
			checked
			{
				string text;
				if (flag)
				{
					text = "";
				}
				else
				{
					sam = Microsoft.VisualBasic.Strings.StrReverse(sam);
					text = Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Microsoft.VisualBasic.Strings.Asc(sam[0]) * 15192332);
					int num = 1;
					int num2 = Microsoft.VisualBasic.Strings.Len(sam) - 1;
					int num3 = num;
					for (; ; )
					{
						int num4 = num3;
						int num5 = num2;
						if (num4 > num5)
						{
							break;
						}
						text = text + "O" + Microsoft.VisualBasic.CompilerServices.Conversions.ToString(Microsoft.VisualBasic.Strings.Asc(sam[num3]) * 15192332);
						num3++;
					}
					text = text;
				}
				return text;
			}
		}

	}

}

