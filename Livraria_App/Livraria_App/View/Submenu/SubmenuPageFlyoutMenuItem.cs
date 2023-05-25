using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria_App.View.Submenu
{
    public class SubmenuPageFlyoutMenuItem
    {
        public SubmenuPageFlyoutMenuItem()
        {
            TargetType = typeof(SubmenuPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public string Icon { get; set; }
    }
}