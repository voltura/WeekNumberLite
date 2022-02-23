//#region Using statements

////using Microsoft.Win32;
//using System;
//using System.Windows.Forms;

//#endregion Using statements

//namespace WeekNumberLite
//{
//    internal static class Settings
//    {
//        #region Internal static property that updates registry for application to start when Windows start

//        internal static bool StartWithWindows
//        {
//            get
//            {
//                //bool startWithWindows = Registry.CurrentUser.GetValue($@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\{Application.ProductName}") != null;
//                //return startWithWindows;
//                //string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + $@"\{Application.ProductName}.lnk";
//                //return System.IO.File.Exists(shortcutAddress);
//                return true;
//            }
//            set
//            {
//                try
//                {
//                    string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + $@"\{Application.ProductName}.lnk";
//                    if (value)
//                    {
//                        IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
//                        System.Reflection.Assembly curAssembly = System.Reflection.Assembly.GetExecutingAssembly();
//                        IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutAddress);
//                        shortcut.Description = Application.ProductName;
//                        shortcut.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
//                        shortcut.TargetPath = curAssembly.Location;
//                        string iconLocation = System.IO.Path.Combine(Application.StartupPath, "WeekNumberLite.exe,0");
//                        shortcut.IconLocation = iconLocation;
//                        shortcut.Save();
//                    }
//                    else
//                    {
//                        /*if (System.IO.File.Exists(shortcutAddress))
//                        {
//                            System.IO.File.Delete(shortcutAddress);
//                        }*/
//                    }
//                }
//                catch
//                {
//                }
//                //using (RegistryKey registryKey = Registry.CurrentUser)
//                //using (RegistryKey regRun = registryKey?.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
//                //{
//                //    if (value)
//                //    {
//                //        if (regRun?.GetValue(Application.ProductName) == null)
//                //        {
//                //            regRun?.SetValue(Application.ProductName, Application.ExecutablePath);
//                //            regRun?.Flush();
//                //        }
//                //    }
//                //    else
//                //    {
//                //        if (regRun?.GetValue(Application.ProductName) != null)
//                //        {
//                //            regRun?.DeleteValue(Application.ProductName);
//                //            regRun?.Flush();
//                //        }
//                //    }
//                //}
//            }
//        }

//        #endregion Internal static property that updates registry for application to start when Windows start
//    }
//}