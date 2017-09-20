using System.Collections.Generic;

namespace TheChromium.Controllers
{
    internal class FBPermissions
    {
        private List<string> permissionList;

        public FBPermissions(List<string> permissionList)
        {
            this.permissionList = permissionList;
        }
    }
}