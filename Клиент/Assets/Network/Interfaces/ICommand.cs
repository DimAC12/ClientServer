using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Network.Interfaces
{
    public interface ICommand
    {
        string Name { get; }
        void ActionCommand();
        void setData(string data = "");
    }
}
