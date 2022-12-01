using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_v3.Interfaces
{
    public interface ICommandAction
    {
        string Name { get; }
        void SetData(string data);
        void SetClient(string ip, int port);
        void Action();
    }
}
