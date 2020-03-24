using System.Diagnostics;

namespace ClientSideDiscordBot
{
    public class ProcessID
    {
        public static void EndProcess(string processID)
        {
            var runningProcs = Process.GetProcesses(); // Gets all running Procs

            foreach (Process process in runningProcs) // Goes through all running Procs
            {
                if (process.ProcessName == processID) // If Proc == the processID/Name
                {
                    process.CloseMainWindow(); // Closes The Process
                }
            }
        }
    }
}
