using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xarial.XCad.Base.Attributes;
using Xarial.XCad.SolidWorks;
using Xarial.XCad.UI.Commands;
using Xarial.XCad.UI.Commands.Attributes;
using Xarial.XCad.UI.Commands.Enums;
using Xarial.XCad.UI.PropertyPage;
using xCAD_PanelWizard.Page;

namespace Xarial.XCad.Exampls.xCAD_PanelWizard.CSharp
{
    [ComVisible(true)]
    public class xCAD_PanelWizardAddin : SwAddInEx

    {
        private enum Commands_e
        {
            [Title("PAGE TITLE")]
            [CommandItemInfo(WorkspaceTypes_e.AllDocuments)]
            OpenPanelWizardPage
        }

        private IXPropertyPage<xCAD_PanelWizardDataModel> m_Page;

        public override void OnConnect()
        {
            m_Data = new xCAD_PanelWizardDataModel();
            m_Page = this.CreatePage<xCAD_PanelWizardDataModel>();

            m_Page.Closed += OnPageClosed;
            this.CommandManager.AddCommandGroup<Commands_e>().CommandClick+=OnCommandClick;
        }

        private void OnPageClosed(UI.PropertyPage.Enums.PageCloseReasons_e reason)
        {
            
        }

        private xCAD_PanelWizardDataModel m_Data;
        private void OnCommandClick(Commands_e spec)
        {
            switch (spec)
            {
                case Commands_e.OpenPanelWizardPage:
                    m_Page.Show(m_Data);
                    break;
            }
        }
    }
}
