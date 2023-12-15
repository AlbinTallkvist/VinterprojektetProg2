using Raylib_cs;

namespace Vinterprojektet
{
    // TrashOne metoden ärver från Pickup metoden
    public class TrashOne : Pickup
    {
        // Trashone klassen Anropar klassen pickup som den ärver med positionerna som väljs i rum-klass
        public TrashOne(int[] initialPositions) : base(initialPositions)
        {
        }

        // Metod som anropar/tar CollectCollision metoden från PickUp som ärvs
        public void CollectCollision(Character character)
        {
            // "base" används för att indikera att det är en metod från den ärvda klassen 
            base.CollectCollision(character);
        }
    }
}

