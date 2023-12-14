using Raylib_cs;

namespace Vinterprojektet
{
    public class Livingroom
    {
        private Bedroom bedroom;
        private Bathroom bathroom;        
        private int collectedKeys = 0; 
        
        private Rectangle[] keyRects = new Rectangle[]
        {
            new Rectangle(100, 320, 50, 50), 
            new Rectangle(300, 320, 50, 50), 
            new Rectangle(500, 320, 50, 50)  
        };



        public void DrawLivingroomScene(Character character, Texture2D backgroundImage, Texture2D doorImage)
        {
            Rectangle sceneChangeBedroom = new Rectangle(1180, 320, doorImage.Width, doorImage.Height);
            Rectangle sceneChangeBathroom = new Rectangle(0, 320, doorImage.Width, doorImage.Height);
            Texture2D keySprite = Raylib.LoadTexture("key.png");

            
            for (int i = 0; i < keyRects.Length; i++)
            {
                if (Raylib.CheckCollisionRecs(character.player, keyRects[i]))
                {
                    collectedKeys++;
                    keyRects[i].X = -10000;
                    keyRects[i].Y = -10000;
                }
            }

            if (collectedKeys >= 3) 
            {
                System.Environment.Exit(0); 
            }



            if (Raylib.CheckCollisionRecs(character.player, sceneChangeBedroom))
            {
                character.currentScene = "bedroomscene";
                character.ResetCharacterPosition();
            }
            if (Raylib.CheckCollisionRecs(character.player, sceneChangeBathroom))
            {
                character.currentScene = "bathroomscene";
                character.ResetCharacterPosition();
            }
            

            else 
            {
            character.Update();
            Raylib.DrawTexture(backgroundImage, 0, 0, Color.WHITE);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, character.backgroundcolor);
            Raylib.DrawRectangleRec(sceneChangeBedroom, Color.BROWN);
            Raylib.DrawText("Living room", 515, 420, 32, Color.BLACK);
            Raylib.DrawRectangleRec(sceneChangeBathroom, Color.BROWN);
            Raylib.DrawTexture(doorImage, (int)sceneChangeBedroom.X, (int)sceneChangeBedroom.Y, Color.WHITE);
            Raylib.DrawTexture(doorImage, (int)sceneChangeBathroom.X, (int)sceneChangeBathroom.Y, Color.WHITE);
                foreach (Rectangle keyRect in keyRects)
                {
                    Raylib.DrawTexture(keySprite, (int)keyRect.X, (int)keyRect.Y, Color.WHITE);
                }
            }
        }
    }
}
