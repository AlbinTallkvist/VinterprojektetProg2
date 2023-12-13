using Raylib_cs;

namespace Vinterprojektet
{
    public class Bedroom
    {
        private Livingroom livingroom;

        public void DrawBedroomScene(Character character, Texture2D backgroundImage, Texture2D doorImage)
        {
            Rectangle sceneChangeLivingroom = new Rectangle(0, 320, doorImage.Width, doorImage.Height);
            
            if (Raylib.CheckCollisionRecs(character.player, sceneChangeLivingroom))
            {
                character.currentScene = "StartRoom";  
                character.ResetCharacterPosition();
            }

            else 
            {
            character.Update();
            Raylib.DrawTexture(backgroundImage, 0, 0, Color.WHITE);
            Raylib.DrawText("Bedroom", 515, 420, 32, Color.BLACK);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, character.backgroundcolor);
            Raylib.DrawRectangleRec(sceneChangeLivingroom, Color.BROWN);
            Raylib.DrawTexture(doorImage, (int)sceneChangeLivingroom.X, (int)sceneChangeLivingroom.Y, Color.WHITE);
            }
            
        }
    }
}
