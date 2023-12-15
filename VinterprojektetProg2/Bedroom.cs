using Raylib_cs;

namespace Vinterprojektet
{
    public class Bedroom
    {
        // Skapar privata instanser av klasserna
        private Livingroom livingroom; 
        private TrashTwo trashTwo;  

        // Skapar array med positionerna för dom 3 collectibles här (dess koordinater)
        private int[] trashTwoInitialPositions = new int[] { 100, 100, 900, 20, 1100, 700  };


        // I bedroom skapas instans av trashTwo klassen och initieras med collectible positioner ^
        public Bedroom()
        {
            trashTwo = new TrashTwo(trashTwoInitialPositions);
        }


        // Metoden för att rita ut världen/rummet/scenen, med 3 instanser av karaktären i världen, världens bakgrundsbild och dörrarnas textur/bild
        public void DrawBedroomScene(Character character, Texture2D bedroomImage, Texture2D doorImage)
        {
            // Skapar "teleportern"/dörren som man går in i för byta rum & collectible sprite
            Rectangle sceneChangeLivingroom = new Rectangle(0, 320, doorImage.Width, doorImage.Height);
            Texture2D keySprite = Raylib.LoadTexture("clothespile.png");
            
            // Kollar om spelaren kolliderar med klassen trashTwo objekt vilket är collectibeln
            trashTwo.CollectCollision(character);
            // Om alla collectibles collectas så avslutas programmet
            if (trashTwo.AllCollected(character))
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
            Raylib.DrawTexture(bedroomImage, 0, 0, Color.WHITE);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, character.backgroundcolor);
            Raylib.DrawRectangleRec(sceneChangeLivingroom, Color.BROWN);
            Raylib.DrawTexture(doorImage, (int)sceneChangeLivingroom.X, (int)sceneChangeLivingroom.Y, Color.WHITE);
            trashTwo.DrawKeyRectangles(keySprite);
            }
            
        }
    }
}
