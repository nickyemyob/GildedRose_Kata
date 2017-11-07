using csharp.Logic;

namespace csharp.Validators
{
    internal class ItemValidator
    {
        public bool IsAgedBrie(Item item)
        {
            return item.Name == "Aged Brie";
        }
    }
}