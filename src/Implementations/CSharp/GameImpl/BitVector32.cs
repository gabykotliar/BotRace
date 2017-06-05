namespace BotRace.Game.Implementation
{
    internal class BitVector32
    {
        private uint data;

        public BitVector32(int data)
        {
            this.data = (uint)data;
        }

        public bool this[int bit]
        {
            get
            {
                return (data & bit) == (uint)bit;
            }
            set
            {
                if (value)
                {
                    data |= (uint)bit;
                }
                else
                {
                    data &= ~(uint)bit;
                }
            }
        }

        public int Data
        {
            get
            {
                return (int)data;
            }
        }
    }
}