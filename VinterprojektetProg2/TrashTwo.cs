using Raylib_cs;

namespace Vinterprojektet
{
    // TrashTwo metoden ärver från Pickup metoden
    public class TrashTwo : Pickup
    {
        // Trashtwo klassen Anropar klassen pickup som den ärver med positionerna som väljs i rum-klass
        public TrashTwo(int[] initialPositions) : base(initialPositions)
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
