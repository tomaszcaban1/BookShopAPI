using System;
using System.Data;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace BookShopAPI.Tests
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }

        protected void WriteDescription(Type typ)
        {
            var testName = TestContext.CurrentContext.Test.Name;

            MemberInfo method = typ.GetMethod(testName);
            if (method != null)
            {
                Attribute attr = method.GetCustomAttribute(typeof(DescriptionAttribute));
                if (attr != null)
                {
                    DescriptionAttribute dattr = (DescriptionAttribute)attr;
                    TestContext.WriteLine("Test Description: " + dattr);
                }
            }
        }
    }
}
