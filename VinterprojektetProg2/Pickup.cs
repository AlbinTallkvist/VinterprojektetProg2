using Raylib_cs;

namespace Vinterprojektet
{
    public class Pickup
    {
        private Rectangle[] keyRects;

        public Pickup(int[] initialPositions)
        {
            keyRects = new Rectangle[initialPositions.Length / 2];

            for (int i = 0; i < initialPositions.Length; i += 2)
            {
                keyRects[i / 2] = new Rectangle(initialPositions[i], initialPositions[i + 1], 50, 50);
            }
        }

        public void CollectCollisionen(Character character)
        {
            for (int i = 0; i < keyRects.Length; i++)
            {
                if (Raylib.CheckCollisionRecs(character.player, keyRects[i]))
                {
                    character.collectedKeys++;
                    keyRects[i].X = -10000;
                    keyRects[i].Y = -10000;
                }
            }
        }

        public bool AllaCollected(Character character)
        {
            return character.collectedKeys >= 6;
        }

        public void DrawKeyRectangles(Texture2D keySprite)
        {
            foreach (Rectangle keyRect in keyRects)
            {
                Raylib.DrawTexture(keySprite, (int)keyRect.X, (int)keyRect.Y, Color.WHITE);
            }
        }
    }
}
