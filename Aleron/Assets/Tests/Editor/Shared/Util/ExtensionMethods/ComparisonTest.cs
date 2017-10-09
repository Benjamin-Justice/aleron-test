// TODO Fix NUNIT Reference in Project

using BrutalHack.Aleron.Shared.Util.ExtensionMethods;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BrutalHack.Aleron.Tests.Shared.Util.ExtensionMethods
{
    [TestFixture]
    public class ComparisonExtensionMethods
    {
        [Test]
        public void FloatNearlyEquals()
        {
            Assert.IsTrue(0.1f.NearlyEquals(0.1f));
            Assert.IsTrue(0.0f.NearlyEquals(0.0f));
            Assert.IsTrue(float.MinValue.NearlyEquals(float.MinValue));
            Assert.IsTrue(float.MaxValue.NearlyEquals(float.MaxValue));
            Assert.IsFalse(float.MaxValue.NearlyEquals(float.MinValue));
            Assert.IsFalse(0.0f.NearlyEquals(0.0011f));
            Assert.IsFalse(1.0f.NearlyEquals(1.000001f, 0.0f));
            Assert.IsTrue(1.0f.NearlyEquals(1.000001f, 0.000001f));
        }

        [Test]
        public void DoubleNearlyEquals()
        {
            Assert.IsTrue(0.1.NearlyEquals(0.1));
            Assert.IsTrue(0.0.NearlyEquals(0.0));
            Assert.IsTrue(float.MinValue.NearlyEquals(float.MinValue));
            Assert.IsTrue(float.MaxValue.NearlyEquals(float.MaxValue));
            Assert.IsFalse(float.MaxValue.NearlyEquals(float.MinValue));
            Assert.IsFalse(0.0.NearlyEquals(0.0011));
            Assert.IsFalse(1.0.NearlyEquals(1.000001, 0.0));
            Assert.IsTrue(1.0.NearlyEquals(1.000001, 0.000001));
        }
    }
}