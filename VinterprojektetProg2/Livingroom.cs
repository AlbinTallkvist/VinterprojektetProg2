using Raylib_cs;

namespace Vinterprojektet
{
    public class Livingroom
    {
        public void DrawLivingroomScene(Character character, Texture2D backgroundImage, Texture2D doorImage)
        {
            character.Update();

            Rectangle sceneChangeBedroom = new Rectangle(1180, 320, doorImage.Width, doorImage.Height);
            Rectangle sceneChangeBathroom = new Rectangle(0, 320, doorImage.Width, doorImage.Height);

            Raylib.DrawTexture(backgroundImage, 0, 0, Color.WHITE);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, character.backgroundcolor);
            Raylib.DrawRectangleRec(sceneChangeBedroom, Color.BROWN);
            Raylib.DrawText("Living room", 515, 420, 32, Color.BLACK);
            Raylib.DrawRectangleRec(sceneChangeBathroom, Color.BROWN);
            Raylib.DrawTexture(doorImage, (int)sceneChangeBedroom.X, (int)sceneChangeBedroom.Y, Color.WHITE);
            Raylib.DrawTexture(doorImage, (int)sceneChangeBathroom.X, (int)sceneChangeBathroom.Y, Color.WHITE);

            if (Raylib.CheckCollisionRecs(character.player, sceneChangeBedroom))
            {
                character.currentScene = "bedroomscene";
                character.ResetCharacterPosition();
            }
            else if (Raylib.CheckCollisionRecs(character.player, sceneChangeBathroom))
            {
                character.currentScene = "bathroomscene";
                character.ResetCharacterPosition();
            }
        }
    }
}
