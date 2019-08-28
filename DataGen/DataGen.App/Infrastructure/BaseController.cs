using DataGen.App.Infrastructure.Contracts;
using System.Threading.Tasks;

namespace DataGen.App.Infrastructure
{
    abstract class BaseController
    {
        public void View(IView view)
        {
            view.Render();
        }
    }
}
