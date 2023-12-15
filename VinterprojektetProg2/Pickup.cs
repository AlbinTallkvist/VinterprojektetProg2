using Raylib_cs;

namespace Vinterprojektet
{
    public class Pickup
    {
        // privat array av rektanglar  
        // lagrar & hantera info om positionerna och storlekarna för collectiblesn i spelet
        private Rectangle[] keyRects;

        // Skapar & Initierar arrayn av rektanglar (keyrects) med positionerna som väljs i rum-klass
        public Pickup(int[] initialPositions)
        {
            // Skapar array av rektanglar (keyrects), ".length" är positionerna för nycklar utifrån antalet koordinater i arrayn
            keyRects = new Rectangle[initialPositions.Length / 2];

            // Skapar rektanglnarna i array'n, genom använda positionen som väljs i rum-klass och varje rektangel har storlek 50x50
            // för varje "initialposition" skapas en rektangeln, de lagras sen i "keyrects" för användas nedre \/
            for (int i = 0; i < initialPositions.Length; i += 2)
            {
                keyRects[i / 2] = new Rectangle(initialPositions[i], initialPositions[i + 1], 50, 50);
            }
        }

        // Metod som hanterar spelaren/character kollison med en collectible("keyrects)
        public void CollectCollision(Character character)
        {
            for (int i = 0; i < keyRects.Length; i++)
            {
                // Om spelaren kolliderar med en nyckel/collectible
                if (Raylib.CheckCollisionRecs(character.player, keyRects[i]))
                {
                    // Ökar string (antal nycklar) med 1 och tp'ar nyckeln utanför skärmen
                    character.collectedKeys++;
                    keyRects[i].X = -10000;
                    keyRects[i].Y = -10000;
                }
            }
        }

        // Metod som säger "true" om spelaren/character har plockat upp 6 keys/collectibles 
        // Används för att avsluta spelet i rum-klasserna
        public bool AllCollected(Character character)
        {
            return character.collectedKeys >= 6;
        }

        // Metod som ritar ut Collectible/Key med Spriten som väljs i rum-klass med koordinater från array i rum-klass
        public void DrawKeyRectangles(Texture2D keySprite)
        {
            foreach (Rectangle keyRect in keyRects)
            {
                Raylib.DrawTexture(keySprite, (int)keyRect.X, (int)keyRect.Y, Color.WHITE);
            }
        }
    }
}
