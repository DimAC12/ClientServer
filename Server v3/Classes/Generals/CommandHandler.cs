using Server_v3.Classes.Commands;
using Server_v3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_v3.Classes.Generals
{
    static public class CommandHandler
    {
        static ICommandAction[] commandsList;

        static public void StartCommandHandler()
        {
            commandsList = new ICommandAction[]
            {
                new Connection(),
                new Disconnection(),
                new CheckConnection(),
                new TransformPlayer(),
                //new SetMaya()
            };
        }

        static public void PutCommands(string client, string inputCommand)
        {
            string[] fullCommand = inputCommand.Split(';');
            string[] nameAndCommand = fullCommand[0].Split('#');
            string[] strClientIpPort = client.Split(':');

            foreach (var item in commandsList)
            {
                if (item.Name == nameAndCommand[0])
                {
                    item.SetClient(strClientIpPort[0], int.Parse(strClientIpPort[1]));
                    if (nameAndCommand.Length > 1)
                        item.SetData(nameAndCommand?[1]);
                    item.Action();
                    BasePlayers.GetPlayer(strClientIpPort[0], int.Parse(strClientIpPort[1])).RestartTimerCheck();
                    return;
                }
            }
        }
    }
}
