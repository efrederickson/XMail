/*
 * User: elijah
 * Date: 02/07/2012
 * Time: 14:48
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace XMail.Tasks
{
    /// <summary>
    /// Global tasks
    /// </summary>
    public class TaskManager
    {
        private static Timer t;
        static TaskManager()
        {
            t = new Timer();
            t.Tick += delegate {
                foreach (ITask t2 in Tasks)
                {
                    if (t2.Done)
                    {
                        Tasks.Remove(t2);
                        return; // collection was modified
                    }
                }
            };
            t.Interval = 50;
            t.Enabled = true;
            t.Start();
        }
        private static List<ITask> Tasks = new List<ITask>();
        
        public static void StopAll()
        {
            foreach (ITask t in Tasks)
                t.Stop();
        }
        
        public static void AddTask(ITask t)
        {
            foreach (ITask t2 in Tasks)
                if (t.UniqueTaskName == t2.UniqueTaskName)
                    return;
            
            Tasks.Add(t);
            t.Run();
        }
        
        public static string GetTaskText(int index)
        {
            if (index > Tasks.Count)
                index = Tasks.Count;
            return Tasks[index].Text;
        }
        
        public static int TaskCount
        {
            get
            {
                return Tasks.Count;
            }
        }
    }
}
