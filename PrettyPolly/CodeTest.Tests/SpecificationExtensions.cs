using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodeTest.Tests.Unit
{
    public static class SpecificationExtensions
    {
        public delegate void MethodThatThrows();

        public static void should_be_false(this bool condition)
        {
            Assert.That(condition, Is.False);
        }

        public static void should_be_the_same_as(this object actual, object expected)
        {
            Assert.That(actual, Is.SameAs(expected));
        }

        public static void should_be_true(this bool condition)
        {
            Assert.That(condition, Is.True);
        }

        public static void should_equal(this object actual, object expected)
        {
            Assert.That(actual, Is.EqualTo(expected));
        }
               
        public static object should_not_equal(this object actual, object expected)
        {
            Assert.AreNotEqual(expected, actual);
            return expected;
        }

        public static void should_be_null(this object anObject)
        {
            Assert.IsNull(anObject);
        }

        public static void should_not_be_null(this object anObject)
        {
            Assert.IsNotNull(anObject);
        }

        public static object should_not_be_the_same_as(this object actual, object expected)
        {
            Assert.AreNotSame(expected, actual);
            return expected;
        }

        public static void should_be_of_type(this object actual, Type expected)
        {
            Assert.IsInstanceOf(expected, actual);
        }

        public static void should_not_be_of_type(this object actual, Type expected)
        {
            Assert.IsNotInstanceOf(expected, actual);
        }

        public static void should_contain(this IList actual, object expected)
        {
            Assert.Contains(expected, actual);
        }

        public static void should_contain<T>(this IEnumerable<T> actual, T expected)
        {
            should_contain(actual, x => x.Equals(expected));
        }

        public static void should_contain<T>(this IEnumerable<T> actual, Func<T, bool> expected)
        {
            actual.Single(expected).should_not_equal(default(T));
        }

        public static void should_be_empty<T>(this IEnumerable<T> actual)
        {
            actual.Count().should_equal(0);
        }

        public static void should_have_count<T>(this IEnumerable<T> actual, int expected)
        {
            actual.Count().should_equal(expected);
        }

        public static IComparable should_be_greater_than(this IComparable arg1, IComparable arg2)
        {
            Assert.Greater(arg1, arg2);
            return arg2;
        }

        public static IComparable should_be_less_than(this IComparable arg1, IComparable arg2)
        {
            Assert.Less(arg1, arg2);
            return arg2;
        }

        public static void should_be_empty(this ICollection collection)
        {
            Assert.IsEmpty(collection);
        }

        public static void should_be_empty(this string aString)
        {
            Assert.IsEmpty(aString);
        }

        public static void should_not_be_empty(this ICollection collection)
        {
            Assert.IsNotEmpty(collection);
        }

        public static void should_not_be_empty(this string aString)
        {
            Assert.IsNotEmpty(aString);
        }

        public static void should_contain(this string actual, string expected)
        {
            StringAssert.Contains(expected, actual);
        }

        public static string should_be_equal_ignoring_case(this string actual, string expected)
        {
            StringAssert.AreEqualIgnoringCase(expected, actual);
            return expected;
        }

        public static void should_end_with(this string actual, string expected)
        {
            StringAssert.EndsWith(expected, actual);
        }

        public static void should_start_with(this string actual, string expected)
        {
            StringAssert.StartsWith(expected, actual);
        }

        public static void should_contain_error_message(this Exception exception, string expected)
        {
            StringAssert.Contains(expected, exception.Message);
        }

        public static Exception should_be_thrown_by(this Type exceptionType, MethodThatThrows method)
        {
            Exception exception = null;

            try
            {
                method();
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
                exception = e;
            }

            if (exception == null)
            {
                Assert.Fail(String.Format("Expected {0} to be thrown.", exceptionType.FullName));
            }

            return exception;
        }
    }
}