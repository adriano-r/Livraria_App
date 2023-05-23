using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria_App.View.Submenu
{
    public class SubmenuFlyoutMenuItem
    {
        public SubmenuFlyoutMenuItem()
        {
            TargetType = typeof(SubmenuFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}