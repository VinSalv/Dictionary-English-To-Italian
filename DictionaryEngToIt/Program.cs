/**
 *  @author Vincenzo Salvati - vincenzosalvati@hotmail.it
 *
 *  @file main.cs
 *
 *  @brief Start the program.
 *
 *  This file contains istructions to start the program.
 */

namespace DictionaryEngToIt
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}