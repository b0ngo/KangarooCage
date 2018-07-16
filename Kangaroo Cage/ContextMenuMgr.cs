using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kangaroo_Cage
{
    class ContextMenuMgr
    {
        public ContextMenu TrayMenu;

        public ContextMenuMgr()
        {
            TrayMenu = new ContextMenu();

            SetTrayMenu();
        }

        public void GetTrayMenu() { TrayMenu = DataModel.TrayMenu; }
        public void SetTrayMenu() { DataModel.TrayMenu = TrayMenu; }

        public void initMenu()
        {
            AddMenuItem("About", new EventHandler(OnAbout));
            AddMenuItem("Exit", new EventHandler(AppMgr.OnExit));
        }

        public void AddMenuItem(string name, EventHandler eventHandler)
        {
            GetTrayMenu();

            if (TrayMenu == null)
                initMenu();

            TrayMenu.MenuItems.Add(name, eventHandler);

            SetTrayMenu();
        }

        private void OnAbout(object sender, EventArgs e)
        {
            DialogHandler.ShowAbout();
        }

    }
}
