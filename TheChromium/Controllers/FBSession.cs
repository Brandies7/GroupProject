using System;
using System.Threading.Tasks;

namespace TheChromium.Controllers
{
    internal class FBSession
    {
        public static FBSession ActiveSession { get; internal set; }

        internal Task<FBResult> LoginAsync(FBPermissions permissions)
        {
            throw new NotImplementedException();
        }
    }
}