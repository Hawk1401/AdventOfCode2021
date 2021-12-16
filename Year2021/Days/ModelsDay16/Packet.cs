using System;
using System.Collections.Generic;
using System.Linq;

namespace Year2021.Days.ModelsDay16
{
    public class Packet
    {
        static Packet()
        {
            Mapper = new bool[16][];
            Mapper[0] = ConvertHexToBinary("0");
            Mapper[1] = ConvertHexToBinary("1");
            Mapper[2] = ConvertHexToBinary("2");
            Mapper[3] = ConvertHexToBinary("3");
            Mapper[4] = ConvertHexToBinary("4");
            Mapper[5] = ConvertHexToBinary("5");
            Mapper[6] = ConvertHexToBinary("6");
            Mapper[7] = ConvertHexToBinary("7");
            Mapper[8] = ConvertHexToBinary("8");
            Mapper[9] = ConvertHexToBinary("9");
            Mapper[10] = ConvertHexToBinary("A");
            Mapper[11] = ConvertHexToBinary("B");
            Mapper[12] = ConvertHexToBinary("C");
            Mapper[13] = ConvertHexToBinary("D");
            Mapper[14] = ConvertHexToBinary("E");
            Mapper[15] = ConvertHexToBinary("F");
        }
        public static bool[] ConvertHexToBinary(string Hex)
        {
            var s = Convert.ToString(Convert.ToInt32(Hex, 16), 2).PadLeft(4, '0');

            bool[] o = new bool[4];
            for (int i = 0; i < o.Length; i++)
            {
                o[i] = s[i] == '1';
            }
            return o;
        }
        static bool[][] Mapper;


        bool[] binary;
        public int Version;
        public int TypeID;
        public int IndexOfLast;
        public long literall;
        private int index;
        public List<Packet> SubPackets = new List<Packet>();


        public Packet(string input)
        {
            var _nums = new List<bool>();

            for (int i = 0; i < input.Length; i++)
            {
                _nums.AddRange(Mapper[GetIndex(input[i])]);
            }

            binary = _nums.ToArray();

            ReadPacket();
        }
        public Packet(bool[] binary)
        {
            this.binary = binary;

            ReadPacket();

        }
        public Packet(bool[] binary, int index)
        {
            this.binary = binary;
            this.index = index;
            ReadPacket();

        }


        public void ReadPacket()
        {
            Version = (int)BinaryTolong(0 + index, 3);
            TypeID = (int)BinaryTolong(3 + index, 3);


            if (TypeID == 4)
            {
                literall = ReadIiterall();
            }
            else
            {
                // operation
                var lengthId = BinaryTolong(6 + index, 1);
                if (lengthId == 0)
                {
                    var _index = 22 + index;

                    var totalLength = BinaryTolong(7 + index, 15) + _index;


                    while (_index < totalLength)
                    {
                        var _sub = new Packet(binary, _index);
                        _index = _sub.IndexOfLast;
                        SubPackets.Add(_sub);
                    }

                    IndexOfLast = _index;
                }
                else
                {
                    var numberOfSubPackets = BinaryTolong(7 + index, 11);
                    var _index = 18 + index;
                    for (int i = 0; i < numberOfSubPackets; i++)
                    {
                        var _sub = new Packet(binary, _index);
                        _index = _sub.IndexOfLast;
                        SubPackets.Add(_sub);
                    }
                    IndexOfLast = _index;

                }
            }

            if (TypeID > 4 && SubPackets.Count == 0)
            {
                throw new Exception();
            }

        }
        public long ReadIiterall()
        {
            List<bool> number = new List<bool>();
            int index = 6 + this.index;
            while (NextStep(number, index))
            {
                index += 5;
            }

            IndexOfLast = index + 5;

            return BinaryTolong(0, number.Count, number.ToArray());

        }
        public bool NextStep(List<bool> number, int index)
        {
            for (int i = index + 1; i < index + 5; i++)
            {
                number.Add(binary[i]);
            }

            return binary[index];
        }
        public int GetIndex(char c)
        {
            if (c < 'A')
            {
                return c - '0';
            }

            return c - 55;

        }



        public long BinaryTolong(int start, int length)
        {
            return BinaryTolong(start, length, binary);
        }
        public long BinaryTolong(int start, int length, bool[] binary)
        {
            long result = 0;
            int end = start + length;
            for (int i = start; i < end; i++)
            {
                result = result << 1;

                if (binary[i])
                {
                    result++;
                }
            }

            return result;
        }


        public int GetTotalVersionNumber()
        {
            return Version + SubPackets.Select(x => x.GetTotalVersionNumber()).Sum();
        }
        public long GetValue()
        {
            switch (TypeID)
            {
                case 0:
                    return sumPackets();
                case 1:
                    return productPackets();
                case 2:
                    return minimumPackets();
                case 3:
                    return maximumPackets();
                case 4:
                    return literall;
                case 5:
                    return greaterThanPackets();
                case 6:
                    return lessThanPackets();
                case 7:
                    return equalPackets();
            }

            throw new ArgumentException();
        }


        private long sumPackets()
        {
            return SubPackets.Select(x => x.GetValue()).Sum();
        }
        private long productPackets()
        {
            long p = 1;
            foreach (var item in SubPackets.Select(x => x.GetValue()))
            {
                p *= item;
            }
            return p;
        }
        private long minimumPackets()
        {
            return SubPackets.Select(x => x.GetValue()).Min();

        }
        private long maximumPackets()
        {
            return SubPackets.Select(x => x.GetValue()).Max();
        }
        private long greaterThanPackets()
        {
            if (SubPackets[0].GetValue() > SubPackets[1].GetValue())
            {
                return 1;
            }
            return 0;

        }
        private long lessThanPackets()
        {
            if (SubPackets[0].GetValue() < SubPackets[1].GetValue())
            {
                return 1;
            }
            return 0;
        }
        private long equalPackets()
        {
            if (SubPackets[0].GetValue() == SubPackets[1].GetValue())
            {
                return 1;
            }
            return 0;
        }
    }
}