using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace PoisnFang.ThirdParty
{
    public class Interop
    {
        private readonly IJSRuntime _jsRuntime;

        public Interop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    }
}
