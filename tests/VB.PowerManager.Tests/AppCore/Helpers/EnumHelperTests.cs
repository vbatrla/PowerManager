namespace VB.PowerManager.Tests.AppCore.Helpers
{
    using System;
    using NUnit.Framework;
    using VB.PowerManager.AppCore.Helpers;
    using VB.PowerManager.AppCore.Attributes;

    [TestFixture]
    public class EnumHelperTests
    {
        [Test]
        public void GetGuid_HasAttribute_GuidReceived()
        {
            Assert.That(TestEnum.ValidGuid.GetGuid(), Is.EqualTo(new Guid("803ff8e5-c79b-4701-a277-fa7e6b38049a")));
        }

        [Test]
        public void GetGuid_HasAttributeWithInvalidFormat_ThrowException()
        {
            Assert.Throws(typeof(FormatException), () => TestEnum.InvalidGuid.GetGuid());
        }

        [Test]
        public void GetGuid_HasntAttribute_ThrowException()
        {
            Assert.Throws(typeof(InvalidOperationException), () => TestEnum.NotSetGuid.GetGuid());
        }

        [Test]
        public void GetName_HasAttribute_NameReceived()
        {
            Assert.That(TestEnum.ValidGuid.GetName(), Is.EqualTo("Valid"));
        }

        [Test]
        public void GetName_HasntAttribute_ThrowException()
        {
            Assert.Throws(typeof(InvalidOperationException), () => TestEnum.NotSetGuid.GetGuid());
        }

        [Test]
        public void GetEnumValueByGuid_HasAttribute_ValidGuid()
        {
            var value = EnumHelper.GetEnumValueByGuid<TestEnum>(new Guid("803ff8e5-c79b-4701-a277-fa7e6b38049a"));

            Assert.That(value, Is.EqualTo(TestEnum.ValidGuid));
        }

        internal enum TestEnum
        {
            [GuidEnum("803ff8e5-c79b-4701-a277-fa7e6b38049a")]
            [Name("Valid")]
            ValidGuid,

            [GuidEnum("")]
            InvalidGuid,

            NotSetGuid
        }
    }
}