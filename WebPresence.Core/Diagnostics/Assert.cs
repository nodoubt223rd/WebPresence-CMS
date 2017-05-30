using System;
using System.Reflection;
using System.Xml;

using WebPresence.Core.Utilities;
using WebPresence.Core.Exceptions;

namespace WebPresence.Core.Diagnostics
{
    public static class Assert
    {
        /// <summary>
        /// Asserts that the arguments are equal.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="T:WebPresence.Core.Exceptions.InvalidValueException"><c>InvalidValueException</c>.</exception>
        [AssertionMethod]
        public static void AreEqual(int value1, int value2, string message)
        {
            if (value1 != value2)
            {
                string[] strArrays = new string[] { message };
                throw new InvalidValueException(StringUtils.GetString(strArrays));
            }
        }

        /// <summary>
        /// Asserts that the arguments are equal.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        [AssertionMethod]
        public static void AreEqual(int value1, int value2, string format, params object[] args)
        {
            if (value1 == value2)
            {
                return;
            }
            string[] strArrays = new string[] { format };
            string str = Assert.Format(StringUtils.GetString(strArrays), args);
            Assert.AreEqual(value1, value2, str);
        }

        /// <summary>
        /// Asserts that the arguments are equal.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="T:WebPresence.Core.Exceptions.InvalidValueException"><c>InvalidValueException</c>.</exception>
        [AssertionMethod]
        public static void AreEqual(string value1, string value2, string message)
        {
            if (value1 == null && value2 != null)
            {
                string[] strArrays = new string[] { message };
                throw new InvalidValueException(StringUtils.GetString(strArrays));
            }
            if (value1 != null && value2 == null)
            {
                string[] strArrays1 = new string[] { message };
                throw new InvalidValueException(StringUtils.GetString(strArrays1));
            }
            if (value1 != null && value2 != null && value1.Length != value2.Length)
            {
                string[] strArrays2 = new string[] { message };
                throw new InvalidValueException(StringUtils.GetString(strArrays2));
            }
            if (value1 != value2)
            {
                string[] strArrays3 = new string[] { message };
                throw new InvalidValueException(StringUtils.GetString(strArrays3));
            }
        }

        
        /// <summary>
        /// Asserts that the arguments are equal.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="T:WebPresence.Core.Exceptions.InvalidValueException"><c>InvalidValueException</c>.</exception>
        [AssertionMethod]
        public static void AreEqual(bool value1, bool value2, string message)
        {
            if (value1 != value2)
            {
                string[] strArrays = new string[] { message };
                throw new InvalidValueException(StringUtils.GetString(strArrays));
            }
        }

        /// <summary>
        /// Asserts that the arguments are equal.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        [AssertionMethod]
        public static void AreEqual(bool value1, bool value2, string format, params object[] args)
        {
            if (value1 == value2)
            {
                return;
            }
            string[] strArrays = new string[] { format };
            string str = Assert.Format(StringUtils.GetString(strArrays), args);
            Assert.AreEqual(value1, value2, str);
        }

        /// <summary>
        /// Asserts a condition on an argument.
        /// </summary>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="T:System.ArgumentException"><c>ArgumentException</c>.</exception>
        [AssertionMethod]
        public static void ArgumentCondition([AssertionCondition(AssertionConditionType.IS_TRUE)] bool condition, [InvokerParameterName] string argumentName, string message)
        {
            if (!condition)
            {
                string[] strArrays = new string[] { message, "An argument condition was false." };
                message = StringUtils.GetString(strArrays);
                if (argumentName == null)
                {
                    throw new ArgumentException(message);
                }
                throw new ArgumentException(message, argumentName);
            }
        }

        /// <summary>
        /// Asserts that the arguments are not null.
        /// </summary>
        /// <param name="propertyInfo">The argument.</param>
        public static bool ArgumentNotNull(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Asserts that the arguments are not null.
        /// </summary>
        /// <param name="type">The argument.</param>
        public static bool ArgumentNotNull(Type type)
        {
            if (type == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Asserts that the arguments are not null.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the argument is null.</exception>
        [AssertionMethod]
        public static void ArgumentNotNull([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object argument, [InvokerParameterName] string argumentName)
        {
            if (argument == null)
            {
                if (argumentName == null)
                {
                    throw new ArgumentNullException();
                }
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Asserts that the arguments are not null.
        /// </summary>
        /// <param name="argument">The argument value.</param>
        /// <param name="getArgumentName">The delegate used to get the parameter name.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown if the argument is null.</exception>
        [AssertionMethod]
        public static void ArgumentNotNull([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object argument, Func<string> getArgumentName)
        {
            if (argument == null)
            {
                string str = getArgumentName();
                if (str == null)
                {
                    throw new ArgumentNullException();
                }
                throw new ArgumentNullException(str);
            }
        }

        /// <summary>
        /// Asserts that the arguments are not null or empty.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <exception cref="T:System.ArgumentException">Empty strings are not allowed.</exception>
        public static bool ArgumentNotNullOrEmpty(string argument)
        {
            if (string.IsNullOrEmpty(argument))
                return false;
            else
                return true;
        }        

        /// <summary>
        /// Asserts that the arguments are not null or empty.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="T:System.ArgumentNullException">Null ids are not allowed.</exception>
        /// <exception cref="T:System.ArgumentException">Empty strings are not allowed.</exception>
        [AssertionMethod]
        public static void ArgumentNotNullOrEmpty([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] string argument, [InvokerParameterName] string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                if (argument != null)
                {
                    if (argumentName == null)
                    {
                        throw new ArgumentException("Empty strings are not allowed.");
                    }
                    throw new ArgumentException("Empty strings are not allowed.", argumentName);
                }
                if (argumentName == null)
                {
                    throw new ArgumentNullException();
                }
                throw new ArgumentNullException(argumentName, "Null ids are not allowed.");
            }
        }

        /// <summary>
        /// Asserts that the arguments are not null or empty.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="getArgumentName">Delegate for getting the argument name.</param>
        /// <exception cref="T:System.ArgumentNullException">Null ids are not allowed.</exception>
        /// <exception cref="T:System.ArgumentException">Empty strings are not allowed.</exception>
        [AssertionMethod]
        public static void ArgumentNotNullOrEmpty([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] string argument, Func<string> getArgumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                string str = getArgumentName();
                if (argument != null)
                {
                    if (str == null)
                    {
                        throw new ArgumentException("Empty strings are not allowed.");
                    }
                    throw new ArgumentException("Empty strings are not allowed.", str);
                }
                if (str == null)
                {
                    throw new ArgumentNullException();
                }
                throw new ArgumentNullException(str, "Null ids are not allowed.");
            }
        }

        /// <summary>
        /// Formats a string.
        /// </summary>
        /// <param name="pattern">The format pattern.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        [StringFormatMethod("pattern")]
        private static string Format(string pattern, object[] args)
        {
            Assert.ArgumentNotNull(pattern, "pattern");
            if (args == null)
            {
                return pattern;
            }
            for (int i = 0; i < (int)args.Length; i++)
            {
                XmlNode xmlNodes = args[i] as XmlNode;
                if (xmlNodes != null)
                {
                    args[i] = xmlNodes.OuterXml;
                }
            }
            return string.Format(pattern, args);
        }

        /// <summary>
        /// Determines whether the specified access is allowed.
        /// </summary>
        /// <param name="accessAllowed">if set to <c>true</c> this access is allowed.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="T:WebPresence.Core.Exceptions.AccessDeniedException"><c>AccessDeniedException</c>.</exception>
        [AssertionMethod]
        public static void HasAccess(bool accessAllowed, string message)
        {
            Assert.ArgumentNotNull(message, "message");
            if (!accessAllowed)
            {
                throw new AccessDeniedException(message);
            }
        }

        /// <summary>
        /// Determines whether the specified access is allowed.
        /// </summary>
        /// <param name="accessAllowed">if set to <c>true</c> this access is allowed.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        [AssertionMethod]
        [StringFormatMethod("format")]
        public static void HasAccess(bool accessAllowed, string format, params object[] args)
        {
            if (accessAllowed)
            {
                return;
            }
            Assert.HasAccess(false, Assert.Format(format, args));
        }

        /// <summary>
        /// Asserts that the specified condition is false.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException"><c>InvalidOperationException</c>.</exception>
        [AssertionMethod]
        public static void IsFalse([AssertionCondition(AssertionConditionType.IS_FALSE)] bool condition, string message)
        {
            Assert.ArgumentNotNull(message, "message");
            if (condition)
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Asserts that the specified condition is false.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException"><c>InvalidOperationException</c>.</exception>
        [AssertionMethod]
        public static void IsFalse([AssertionCondition(AssertionConditionType.IS_FALSE)] bool condition, Func<string> getMessage)
        {
            if (condition)
            {
                string str = getMessage();
                if (str == null)
                {
                    throw new InvalidOperationException();
                }
                throw new InvalidOperationException(str);
            }
        }

        /// <summary>
        /// Asserts that the specified condition is false.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        [AssertionMethod]
        [StringFormatMethod("format")]
        public static void IsFalse([AssertionCondition(AssertionConditionType.IS_FALSE)] bool condition, string format, params object[] args)
        {
            if (!condition)
            {
                return;
            }
            Assert.IsFalse(condition, Assert.Format(format, args));
        }

        /// <summary>
        /// Asserts that the specified value is not null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="T:System.InvalidOperationException"><c>InvalidOperationException</c>.</exception>
        [AssertionMethod]
        public static void IsNotNull([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object value, string message)
        {
            if (value == null)
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Asserts that the specified value is not null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        [AssertionMethod]
        [StringFormatMethod("format")]
        public static void IsNotNull([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object value, string format, params object[] args)
        {
            if (value != null)
            {
                return;
            }
            Assert.IsNotNull(value, Assert.Format(format, args));
        }

        /// <summary>
        /// Asserts that the specified value is not null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The object type.</param>
        [AssertionMethod]
        public static void IsNotNull([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object value, Type type)
        {
            if (value != null)
            {
                return;
            }
            Assert.IsNotNull(value, type, string.Empty, new object[0]);
        }

        /// <summary>
        /// Asserts that the specified value is not null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        [AssertionMethod]
        [StringFormatMethod("format")]
        public static void IsNotNull([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object value, Type type, string format, params object[] args)
        {
            if (value != null)
            {
                return;
            }
            string str = string.Format("An instance of {0} was null.", type);
            if (format.Length > 0)
            {
                str = string.Concat(str, " Additional information: ", Assert.Format(format, args));
            }
            Assert.IsNotNull(value, str);
        }

        /// <summary>
        /// Asserts that the specified value is not null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="T:System.InvalidOperationException"><c>InvalidOperationException</c>.</exception>
        [AssertionMethod]
        public static void IsNotNullOrEmpty([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Asserts that the specified string is not null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        [AssertionMethod]
        [StringFormatMethod("format")]
        public static void IsNotNullOrEmpty([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] string value, string format, params object[] args)
        {
            if (string.IsNullOrEmpty(value))
            {
                Assert.IsNotNullOrEmpty(value, Assert.Format(format, args));
            }
        }

        /// <summary>
        /// Asserts that the specified value is null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="T:System.InvalidOperationException"><c>InvalidOperationException</c>.</exception>
        [AssertionMethod]
        public static void IsNull([AssertionCondition(AssertionConditionType.IS_NULL)] object value, string message)
        {
            if (value != null)
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Asserts that the specified value is null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        [AssertionMethod]
        [StringFormatMethod("format")]
        public static void IsNull([AssertionCondition(AssertionConditionType.IS_NULL)] object value, string format, params object[] args)
        {
            if (value == null)
            {
                return;
            }
            Assert.IsNull(value, Assert.Format(format, args));
        }

        /// <summary>
        /// Determines whether the specified condition is true.
        /// </summary>
        /// <param name="condition">if set to <c>true</c> th condition is true.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="T:System.InvalidOperationException"><c>InvalidOperationException</c>.</exception>
        [AssertionMethod]
        public static void IsTrue([AssertionCondition(AssertionConditionType.IS_TRUE)] bool condition, string message)
        {
            if (!condition)
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Determines whether the specified condition is true.
        /// </summary>
        /// <param name="condition">if set to <c>true</c> th condition is true.</param>
        /// <param name="getMessage">The get message delegate.</param>
        /// <exception cref="T:System.InvalidOperationException"><c>InvalidOperationException</c>.</exception>
        [AssertionMethod]
        public static void IsTrue([AssertionCondition(AssertionConditionType.IS_TRUE)] bool condition, Func<string> getMessage)
        {
            if (!condition)
            {
                string str = getMessage();
                if (str == null)
                {
                    throw new InvalidOperationException();
                }
                throw new InvalidOperationException(str);
            }
        }

        /// <summary>
        /// Determines whether the specified condition is true.
        /// </summary>
        /// <param name="condition">if set to <c>true</c> the condition is true.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        [AssertionMethod]
        [StringFormatMethod("format")]
        public static void IsTrue([AssertionCondition(AssertionConditionType.IS_TRUE)] bool condition, string format, params object[] args)
        {
            if (condition)
            {
                return;
            }
            Assert.IsTrue(false, Assert.Format(format, args));
        }

        /// <summary>
        /// Asserts that the object is created.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <exception cref="T:WebPresence.Core.Exceptions.UnknownTypeException">The type could not be created.</exception>
        [AssertionMethod]
        public static void ReflectionObjectCreated([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object obj, string typeName)
        {
            if (obj == null)
            {
                throw new UnknownTypeException(string.Format("The type '{0}' could not be created.", typeName));
            }
        }

        /// <summary>
        /// Throws a <see cref="T:WebPresence.Core.Exceptions.RequiredObjectIsNullException" /> if a specific
        /// condition is not met.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="T:WebPresence.Core.Exceptions.RequiredObjectIsNullException"><c>RequiredObjectIsNullException</c>.</exception>
        [AssertionMethod]
        public static void Required([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object obj, string message)
        {
            if (obj == null)
            {
                throw new RequiredObjectIsNullException(message);
            }
        }

        /// <summary>
        /// Throws a <see cref="T:WebPresence.Core.Exceptions.RequiredObjectIsNullException" /> if a specific
        /// condition is not met.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        [AssertionMethod]
        [StringFormatMethod("format")]
        public static void Required([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] object obj, string format, params object[] args)
        {
            if (obj != null)
            {
                return;
            }
            Assert.Required(obj, Assert.Format(format, args));
        }

        /// <summary>
        /// Results the not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        /// <param name="message"></param>
        [AssertionMethod]
        public static T ResultNotNull<T>(T result, string message)
        where T : class
        {
            Assert.ArgumentNotNullOrEmpty(message, "message");
            Assert.IsNotNull(result, message);
            return result;
        }

        /// <summary>
        /// Results the not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        [AssertionMethod]
        public static T ResultNotNull<T>(T result)
        where T : class
        {
            return Assert.ResultNotNull<T>(result, "Post condition failed");
        }
    }
}
