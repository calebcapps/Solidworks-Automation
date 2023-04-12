using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swpublished;
using System.Runtime.InteropServices;
using Microsoft.Win32;
namespace AddinSample
{
    public class AddinSample : SwAddin
    {
        SldWorks swApp;
        int SessionCookie;
        #region solidworks connection
        public bool ConnectToSW(object ThisSW, int Cookie)
        {
            swApp = ThisSW as SldWorks;
            swApp.SetAddinCallbackInfo2(0, this, Cookie);
            SessionCookie = Cookie;
            swApp.FileNewNotify2 += SwApp_FileNewNotify2;

            //this is where we build the UI

            return true;
        }

        private int SwApp_FileNewNotify2(object NewDoc, int DocType, string TemplateName)
        {
            swApp.SendMsgToUser("New file created!");

            return 0;
        }

        public bool DisconnectFromSW()
        {
            //this is where we dsetroy the UI
            GC.Collect();
            swApp = null;
            return true;
        }
        #endregion

        #region com register-unregister functions
        [ComRegisterFunction]
        private static void RegisterAssembly(Type t)
        {
            string Path = String.Format(@"SOFTWARE\Solidworks\AddIns\{0:b}", t);
            RegistryKey Key = Registry.LocalMachine.CreateSubKey(Path);

            // startup int
            Key.SetValue(null, 1);
            Key.SetValue("Title", "AddinSample");
            Key.SetValue("Description", "This is a description");
        }
        [ComUnregisterFunction]
        private static void UnregisterAssembly(Type t)
        {
            string Path = String.Format(@"SOFTWARE\Solidworks\AddIns\{0:b}", t);
            Registry.LocalMachine.DeleteSubKey(Path);
        }
        #endregion
    }

}
