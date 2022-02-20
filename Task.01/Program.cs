using System;
using System.Collections.Generic;

namespace Task._01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chatHistory = new List<string>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "Chat")
                {
                    chatHistory.Add(cmdArgs[1]);
                }
                else if (action == "Delete")
                {
                    if (!CheckIfContains(chatHistory, cmdArgs[1]))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    chatHistory.Remove(cmdArgs[1]);
                }
                else if (action == "Edit")
                {
                    if (!CheckIfContains(chatHistory, cmdArgs[1]))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    chatHistory.Insert(chatHistory.IndexOf(cmdArgs[1]), cmdArgs[2]);
                    chatHistory.RemoveAt(chatHistory.IndexOf(cmdArgs[2]) + 1);
                }
                else if (action == "Pin")
                {
                    if (!CheckIfContains(chatHistory, cmdArgs[1]))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    chatHistory.Add(cmdArgs[1]);
                    chatHistory.Remove(cmdArgs[1]);
                }
                else if (action == "Spam")
                {
                    string[] messages = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 1; i < messages.Length; i++)
                    {
                        chatHistory.Add(messages[i]);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", chatHistory));
        }

        static bool CheckIfContains(List<string> list, string element)
        {
            return list.Contains(element);
        }
    }
}
