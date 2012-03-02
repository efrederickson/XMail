/*
 * User: elijah
 * Date: 02/07/2012
 * Time: 14:34
 */
using System;

namespace XMail.Tasks
{
    /// <summary>
    /// An XMAil Task interface
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// The text to display when the task is running
        /// </summary>
        string Text
        {get;}
        
        /// <summary>
        /// The tasks name. Preferably set to the full class name, to prevent two tasks from having the same name
        /// </summary>
        string UniqueTaskName
        {get;}
        
        /// <summary>
        /// Should run Async
        /// </summary>
        void Run();
        
        /// <summary>
        /// Should stop the task right then with no prompting, waiting, etc.
        /// </summary>
        void Stop();
        
        /// <summary>
        /// Whether this instance of the task has finished or not.
        /// </summary>
        bool Done
        {get;}
    }
}
