using Raylib_cs;

namespace Vinterprojektet
{
    public class Bathroom
    {
        // Skapar privata instanser av klasserna
        private Livingroom livingroom; 
        private TrashOne trashOne;  

        // Skapar array med positionerna för dom rumets collectible här (dess koordinater)
        private int[] trashOneInitialPositions = new int[] { 250, 90,  };

        
        // I bathroom skapas instans av trashOne klassen och initieras med collectible positioner ^
        public Bathroom()
        {
            trashOne = new TrashOne(trashOneInitialPositions);
        }
       

        // Metoden för att rita ut världen/rummet/scenen, med 3 instanser av karaktären i världen, världens bakgrundsbild och dörrarnas textur/bild
        public void DrawBathroomScene(Character character, Texture2D bathroomImage, Texture2D doorImage)
        {
            // Skapar "teleportern"/dörren som man går in i för byta rum & collectible sprite
            Rectangle sceneChangeLivingroom = new Rectangle(1180, 320, doorImage.Width, doorImage.Height);
            Texture2D keySprite = Raylib.LoadTexture("poop.png");


            // Kollar om spelaren kolliderar med klassen trashOne objekt vilket är collectibeln
            trashOne.CollectCollision(character);
            // Om alla collectibles collectas så avslutas programmet
            if (trashOne.AllCollected(character))
            {
                System.Environment.Exit(0);
            }


            // Om spelaren kolliderar med teleporter/dörren som ritades ut tidigare byt scen till nya rummet & tp till mitten 
            if (Raylib.CheckCollisionRecs(character.player, sceneChangeLivingroom))
            {
                character.currentScene = "StartRoom";
                character.ResetCharacterPosition();
            }

            // Om spelaren inte aktivt kolliderar med dörr/teleporter, dvs bara är i rummet rita ut rummet (dess texturer & collectibles)
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
