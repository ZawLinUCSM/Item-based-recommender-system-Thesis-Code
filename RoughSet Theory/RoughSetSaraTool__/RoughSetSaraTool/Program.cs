using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RoughSetSaraTool
{
    //Coding By Sara El-Sayed El-Metwally @ Friday, April 05, 2013 9:00 pm
    // Assistant Lecturer , Faculty of Computers & Information Sciences, Mansoura University ,Eygpt.
    // Email: sarah_almetwally4@yahoo.com 
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
