// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Matthew Ward" email="mrward@users.sourceforge.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.IO;
using System.Security.Cryptography;

namespace md5sum
{
	class Md5SumApp
	{
		public static int Main(string[] args)
		{
			if (args.Length > 0) {
				Md5SumApp app = new Md5SumApp();
				return app.Run(args[0]);
			}
			
			Console.WriteLine("Usage: md5sum filename");
			return - 1;
		}
		
		public int Run(string fileName)
		{
			if (!File.Exists(fileName)) {
				Console.WriteLine("File not found: " + fileName);
				return 2;
			}
			
			MD5 md5 = MD5CryptoServiceProvider.Create();
			using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read)) {
				byte[] hash = md5.ComputeHash(stream);
				foreach (byte b in hash) {
					Console.Write(b.ToString("x2"));
				}
				Console.WriteLine();
			}
			return 0;
		}
	}
}