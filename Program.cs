#region Using statements

using System;
using System.Runtime;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

#endregion Using statements

namespace WeekNumberLite
{
    internal class Program
    {
        #region Private variable to allow only one instance of application

        private static readonly Mutex Mutex = new Mutex(true, "88D1C6E0-96C8-4BB3-BA08-ACEFDC90A023");

        #endregion Private variable to allow only one instance of application

        #region Application starting point

        [STAThread]
        private static void Main()
        {
            if (!Mutex.WaitOne(TimeSpan.Zero, true))
            {
                return;
            }
            WeekApplicationContext context = null;
            try
            {
                //Settings.StartWithWindows = MessageBox.Show("Start automatically with Windows?", "Start with Windows?", MessageBoxButtons.YesNo) == DialogResult.Yes;
                AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
                SetGCSettings();
                Application.EnableVisualStyles();
                Application.VisualStyleState = VisualStyleState.ClientAndNonClientAreasEnabled;
                Application.SetCompatibleTextRenderingDefault(false);
                context = new WeekApplicationContext();
                if (context?.Gui != null)
                {
                    Application.Run(context);
                }
            }
            finally
            {
                context?.Dispose();
                Mutex.ReleaseMutex();
            }
        }

        #endregion Application starting point

        #region Private methods

        /// <summary>
        /// Configures garbarge collection settings
        /// </summary>
        private static void SetGCSettings()
        {
            GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
            GCSettings.LatencyMode = GCLatencyMode.Batch;
        }

        #endregion Private methods that configures garbarge collection settings

        #region Global unhandled Exception trap

        /// <summary>
        /// Catches all unhandled exceptions for the application
        /// Writes the exception to the application log file
        /// Terminates the application with exit code -1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Message.Show(Resources.UnhandledException, ex);
            Environment.Exit(1);
        }

        #endregion Global unhandled Exception trap
    }
}