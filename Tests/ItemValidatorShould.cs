using csharp.Logic;
using csharp.Validators;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    class ItemValidatorShould
    {
        [Test]
        public void CheckIfItemIsAgedBrie()
        {
            var item = new Item()
            {
                Name = "Aged Brie"
            };

            var validator = new ItemValidator();
            var expected = validator.IsAgedBrie(item);

            Assert.IsTrue(expected);

        }
    }
}
