using Assets.Network.Commands;
using Assets.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Network
{
    public class CommandHandler : MonoBehaviour
    {
        static public CommandHandler instance;

        ICommand[] commands = new ICommand[]
        {
            new Connected(),
            new CheckConnected(),
            new SpawnPlayer(),
            new TransformAnotherPlayer(),
            new RemoveAnotherPlayer(),
            new SetMaya(),
        };

        List<Tuple<string, string>> commandsList = new List<Tuple<string, string>>();

        public void PutCommand(string command)
        {
            string[] commandFull = command.Split(';');
            string[] nameCommandAndData = commandFull[0].Split('#');

            string date = null;

            if (nameCommandAndData.Length == 3)
            {
                date = nameCommandAndData[2];
            }

            if (nameCommandAndData[0] == "TransformPlayer")
            {
                commands[3].setData(nameCommandAndData[1]);
                commands[3].ActionCommand();
                //Debug.Log(commandFull[0]);
            }

            else
            {
                //Debug.Log(commandFull[0]);
                commandsList.Add(Tuple.Create(nameCommandAndData[0], nameCommandAndData[1]));
            }
        }

        private void Start()
        {
            instance = this;
        }

        private void Update()
        {
            if (commandsList.Count > 0)
            {
                for (int i = 0; i < commandsList.Count; i++)
                {
                    foreach (var item in commands)
                    {
                        if (item.Name == commandsList[i].Item1)
                        {
                            item.setData(commandsList[i].Item2);
                            item.ActionCommand();
                            break;
                        }
                    }
                    commandsList.Remove(commandsList[i]);
                }
            }
        }
    }
}
