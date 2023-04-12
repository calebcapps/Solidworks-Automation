using CodeStack.SwEx.AddIn;
using System.Runtime.InteropServices;

namespace Primitives
{
    [ComVisible(true), Guid("5EB4E810-2F9E-4E7D-B3B1-6FFADB5C6851")] // Guid generated from Tools->Create Guid->Registry Format
    [CodeStack.SwEx.AddIn.Attributes.AutoRegister("Geometry primives", "Creates geometry primitives")]
    public class AddIn : SwAddInEx
    {
        private enum Commands_e // enum corresponds to a new toolbar
        {
            CreateCylinder, // item corresponds to a new command
            CreateBox
        }

        public override bool OnConnect()
        {
            AddCommandGroup <Commands_e> (onButtonClick);
            return true;
        }

        private void onButtonClick(Commands_e cmd)
        {
            switch (cmd)
            {
                case Commands_e.CreateCylinder:
                    //TODO create cylinder
                    break;
                case Commands_e.CreateBox:
                    //TODO create box

                    break;

            }
        }
    }
}