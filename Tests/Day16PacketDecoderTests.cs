using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using Puzzles.Day16PacketDecoder;
using Puzzles.Day16PacketDecoder.PacketTypes;

namespace Tests;

[TestFixture]
public class Day16PacketDecoderTests
{
    [Test]
    public void CanDecodeLiteralValue()
    {
        var result = PacketDecoder.DecodeHex("D2FE28");
        result.TypeId.Should().Be(4);
        result.BitRepresentation.Should().Be("110100101111111000101");
        result.Version.Should().Be(6);
        result.Should().BeOfType<LiteralPacket>();
        var literalPacket = (LiteralPacket)result;
        literalPacket.UnusedBitRepresentation.Should().Be("000");
        literalPacket.Value.Should().Be(2021);
    }
    
    [Test]
    public void CanDecodeOperatorPacketWhereLengthIsSpecified()
    {
        var result = PacketDecoder.DecodeHex("38006F45291200");

        using var _ = new AssertionScope();
        result.TypeId.Should().Be(6);
        result.BitRepresentation.Should().Be("00111000000000000110111101000101001010010001001000000000");
        result.Version.Should().Be(1);
        result.Should().BeAssignableTo<OperatorPacket>();
        var operatorPacket = (OperatorPacket)result;
        operatorPacket.LengthTypeId.Should().Be(0);
        operatorPacket.SubPackets.Count.Should().Be(2);
        ((LiteralPacket)operatorPacket.SubPackets[0]).Value.Should().Be(10);
        ((LiteralPacket)operatorPacket.SubPackets[1]).Value.Should().Be(20);
    }
    
    [Test]
    public void CanDecodeOperatorPacketWhereSubPacketCountIsSpecified()
    {
        var result = PacketDecoder.DecodeHex("EE00D40C823060");

        using var _ = new AssertionScope();
        result.TypeId.Should().Be(3);
        result.BitRepresentation.Should().Be("11101110000000001101010000001100100000100011000001100000");
        result.Version.Should().Be(7);
        result.Should().BeAssignableTo<OperatorPacket>();
        var operatorPacket = (OperatorPacket)result;
        operatorPacket.LengthTypeId.Should().Be(1);
        operatorPacket.SubPackets.Count.Should().Be(3);
        ((LiteralPacket)operatorPacket.SubPackets[0]).Value.Should().Be(1);
        ((LiteralPacket)operatorPacket.SubPackets[1]).Value.Should().Be(2);
        ((LiteralPacket)operatorPacket.SubPackets[2]).Value.Should().Be(3);
    }

    [Test]
    [TestCase("8A004A801A8002F478", 16)]
    [TestCase("620080001611562C8802118E34", 12)]
    [TestCase("C0015000016115A2E0802F182340", 23)]
    [TestCase("A0016C880162017C3686B18A3D4780", 31)]
    public void CanSumVersionNumbers(string input, int sumOfVersionNumbers)
    {
        var result = PacketDecoder.DecodeHex(input);
        result.SumOfVersionNumbers().Should().Be(sumOfVersionNumbers);
    }
    
    [Test]
    [TestCase("C200B40A82", 3)]
    [TestCase("04005AC33890", 54)]
    [TestCase("880086C3E88112", 7)]
    [TestCase("CE00C43D881120", 9)]
    [TestCase("D8005AC2A8F0", 1)]
    [TestCase("F600BC2D8F", 0)]
    [TestCase("9C005AC2F8F0", 0)]
    [TestCase("9C0141080250320F1802104A08", 1)]
    public void CanCalculatePacket(string input, int sumOfVersionNumbers)
    {
        var result = PacketDecoder.DecodeHex(input);
        result.Value.Should().Be(sumOfVersionNumbers);
    }
}