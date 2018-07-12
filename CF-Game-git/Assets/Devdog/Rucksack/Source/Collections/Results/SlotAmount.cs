namespace Devdog.Rucksack.Collections
{
    public struct SlotAmount
    {
        public int slot;
        public int amount;
            
        public SlotAmount(int slot, int amount)
        {
            this.slot = slot;
            this.amount = amount;
        }
    }
}