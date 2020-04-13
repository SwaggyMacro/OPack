namespace OPack.Tests
{
    using FluentAssertions;

    using Xunit;

    public class PackTests
    {
        [Fact]
        public void PackLongValueBigEndian()
        {
            var returnValue = new Packer().Pack(">q", 0, long.MaxValue);
            returnValue.Should().HaveCount(8).And.StartWith(0x7F).And.OnlyContain(x => (x == 0X7F && x == returnValue[0]) || x == 0xFF);
        }

        [Fact]
        public void PackLongValueLittleEndian()
        {
            var returnValue = new Packer().Pack("<q", 0, long.MaxValue);
            returnValue.Should().HaveCount(8).And.EndWith(0x7F).And.OnlyContain(x => (x == 0X7F && x == returnValue[7]) || x == 0xFF);
        }

        [Fact]
        public void PackSignedByteBigEndian()
        {
            var returnValue = new Packer().Pack(">b", 0, -128);
            returnValue.Should().ContainSingle().And.BeEquivalentTo(128);
        }

        [Fact]
        public void PackSignedByteLittleEndian()
        {
            var returnValue = new Packer().Pack("<b", 0, -128);
            returnValue.Should().ContainSingle().And.BeEquivalentTo(128);
        }
    }
}