using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xarial.XCad.Base.Attributes;
using Xarial.XCad.SolidWorks;
using Xarial.XCad.UI.Commands.Attributes;
using Xarial.XCad.UI.Commands.Enums;
using Xarial.XCad.UI.Commands;
using xCAD_PMPageExample.Page;
using Xarial.XCad.UI.PropertyPage;

namespace Xarial.XCad.Exampls.xCAD_PMPageExample.CSharp
{
    [ComVisible(true)]
    public class PMPageAddin : SwAddInEx
    {
        [Title("Property Manager Page Example")]
        private enum Commands_e
        {
            [Title("Open Page")]
            [CommandItemInfo(WorkspaceTypes_e.AllDocuments)]
            OpenPMPage
        }

        private IXPropertyPage<PMPageDataModel> m_Page;
        private PMPageDataModel m_Data;
        public override void OnConnect()
        {
            m_Data = new PMPageDataModel();
            m_Page = this.CreatePage<PMPageDataModel>();

            m_Page.Closed += M_Page_Closed;
            this.CommandManager.AddCommandGroup<Commands_e>().CommandClick+=OnCommandClick;
        }

        private void M_Page_Closed(UI.PropertyPage.Enums.PageCloseReasons_e reason)
        {
            throw new NotImplementedException();
        }

        private void OnCommandClick(Commands_e spec)
        {
            switch (spec)
            {
                case Commands_e.OpenPMPage:
                    m_Page.Show(m_Data);
                    break;
            }
        }
    }
}
