using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Web.UI;

namespace WebPresence.Core.Diagnostics
{
    /// <summary>
    /// Defines methods for error handling.
    /// </summary>
    [DebuggerStepThrough]
    public sealed class Error
    {
        private const string EVENT_SOURCE = "WebPresence Server";

        private static ArrayList m_threadErrors;

        /// <summary>
        /// Get list of thread errors
        /// </summary>
        /// <value>The thread errors.</value>
        public static ArrayList ThreadErrors
        {
            get
            {
                return m_threadErrors;
            }
        }

        static Error()
        {
            m_threadErrors = new ArrayList();
        }

        public Error()
        {
        }

        /// <summary>
        /// Assert that an integer is valid
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="name">The name.</param>
        /// <param name="allowZero">if set to <c>true</c> this instance is allow zero.</param>
        /// <param name="allowNegative">if set to <c>true</c> this instance is allow negative.</param>
        public static void AssertInt(int argument, string name, bool allowZero, bool allowNegative)
        {
            if (!allowZero && argument == 0)
            {
                throw new ArgumentOutOfRangeException(string.Concat(name, "."), "Zero is not allowed.");
            }
            if (!allowNegative && argument < 0)
            {
                throw new ArgumentOutOfRangeException(string.Concat(name, "."), (object)argument, "Negative values are not allowed.");
            }
        }

        /// <summary>
        /// Assert that an object reference is not null
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="name">The name.</param>
        public static void AssertObject(object argument, string name)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Assert that a string is valid
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="name">The name.</param>
        /// <param name="allowEmpty">if set to <c>true</c> this instance is allow empty.</param>
        public static void AssertString(string argument, string name, bool allowEmpty)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
            if (!allowEmpty && argument.Length == 0)
            {
                throw new ArgumentOutOfRangeException(string.Concat(name, "."), argument, "Empty string is not allowed.");
            }
        }

        /// <summary>
        /// Gets the caller.
        /// </summary>
        /// <param name="indexInStack">The index in stack.</param>
        /// <returns></returns>
        public static string GetCaller(int indexInStack)
        {
            if ((new StackTrace()).FrameCount <= indexInStack)
            {
                return "";
            }

            StackFrame stackFrame = new StackFrame(indexInStack, true);
            MethodBase method = stackFrame.GetMethod();
            string str = "";
            ParameterInfo[] parameters = method.GetParameters();

            for (int i = 0; i < (int)parameters.Length; i++)
            {
                ParameterInfo parameterInfo = parameters[i];
                string str1 = str;
                string[] name = new string[] { str1, null, null, null, null };

                name[1] = (str.Length > 0 ? ", " : "");
                name[2] = parameterInfo.ParameterType.Name;
                name[3] = " ";
                name[4] = parameterInfo.Name;
                str = string.Concat(name);
            }

            string[] fullName = new string[] { method.DeclaringType.FullName, ".", method.Name, "(", str, ")" };
            str = string.Concat(fullName);
            string fileName = stackFrame.GetFileName();
            string str2 = stackFrame.GetFileLineNumber().ToString();
            int fileColumnNumber = stackFrame.GetFileColumnNumber();
            string str3 = string.Concat(str2, ", ", fileColumnNumber.ToString());

            if (fileName != null && fileName.Length > 0)
            {
                string str4 = str;
                string[] strArrays = new string[] { str4, " in ", fileName, ":", str3 };
                str = string.Concat(strArrays);
            }

            return str;
        }
    }
}
