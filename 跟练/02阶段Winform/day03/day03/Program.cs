namespace day03
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LunBoTu());
            //Application.Run(new CursorLocation());
            //Application.Run(new FocusWork());
            //Application.Run(new KeyTest());
            //Application.Run(new KeyTest2());
            //Application.Run(new Move());
        }
    }
}