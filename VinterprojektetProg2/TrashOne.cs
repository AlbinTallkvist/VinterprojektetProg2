using Raylib_cs;

namespace Vinterprojektet
{
    public class TrashOne : Pickup
    {
        public TrashOne(int[] initialPositions) : base(initialPositions)
        {
        }

        public void CollectCollisionen(Character character)
        {
            base.CollectCollisionen(character);
        }
    }
}

