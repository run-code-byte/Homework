using MyTools;
using System.Runtime.InteropServices;
namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [STAThread]
        static void Main()
        {
            // 2. 直接实例化 DLL 中的类并使用其方法
            //Person p = new Person();
            //MessageBox.Show(p.GetName());

            //AllocConsole();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            //Application.Run(new Form2());
            Application.Run(new Form3());
        }
    }
}