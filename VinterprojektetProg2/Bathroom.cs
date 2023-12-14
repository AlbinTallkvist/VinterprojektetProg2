using Raylib_cs;

namespace Vinterprojektet
{
    public class Bathroom
    {
        private Livingroom livingroom; 
        private TrashOne trashOne;  
        private int[] trashOneInitialPositions = new int[] { 250, 90,  };

        

        public Bathroom()
        {
            trashOne = new TrashOne(trashOneInitialPositions);
        }
       
        public void DrawBathroomScene(Character character, Texture2D bathroomImage, Texture2D doorImage)
        {
            Rectangle sceneChangeLivingroom = new Rectangle(1180, 320, doorImage.Width, doorImage.Height);
            Texture2D keySprite = Raylib.LoadTexture("poop.png");



            trashOne.CollectCollisionen(character);
            if (trashOne.AllaCollected(character))
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
            Raylib.DrawTexture(bathroomImage, 0, 0, Color.WHITE);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, character.backgroundcolor);
            Raylib.DrawRectangleRec(sceneChangeLivingroom, Color.BROWN);
            Raylib.DrawTexture(doorImage, (int)sceneChangeLivingroom.X, (int)sceneChangeLivingroom.Y, Color.WHITE);
            trashOne.DrawKeyRectangles(keySprite);


            }
        }
    }
}
