using Raylib_cs;

namespace Vinterprojektet
{
    public class Bedroom
    {
        private Pickup pickup;
        private Livingroom livingroom; 

    
        private int[] keyRectInitialPositions = new int[] { 100, 100, 900, 20, 1100, 700 };

        public Bedroom()
        {
            pickup = new Pickup(keyRectInitialPositions);
        }

        public void DrawBedroomScene(Character character, Texture2D bedroomImage, Texture2D doorImage)
        {
            Rectangle sceneChangeLivingroom = new Rectangle(0, 320, doorImage.Width, doorImage.Height);
            Texture2D keySprite = Raylib.LoadTexture("key.png");
            
            pickup.CollectCollisionen(character);
            if (pickup.AllaCollected(character))
            {
                System.Environment.Exit(0);
            }



            if (Raylib.CheckCollisionRecs(character.player, sceneChangeLivingroom))
            {
                character.currentScene = "StartRoom";  
                character.ResetCharacterPosition();
            }

            else 
            {
            character.Update();
            Raylib.DrawTexture(bedroomImage, 0, 0, Color.WHITE);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, character.backgroundcolor);
            Raylib.DrawRectangleRec(sceneChangeLivingroom, Color.BROWN);
            Raylib.DrawTexture(doorImage, (int)sceneChangeLivingroom.X, (int)sceneChangeLivingroom.Y, Color.WHITE);
            pickup.DrawKeyRectangles(keySprite);
            }
            
        }
    }
}
