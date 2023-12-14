using Raylib_cs;

namespace Vinterprojektet
{
    public class TrashTwo : Pickup
    {
        public TrashTwo(int[] initialPositions) : base(initialPositions)
        {
        }

        public void CollectCollisionen(Character character)
        {
            base.CollectCollisionen(character);
        }
    }
}
