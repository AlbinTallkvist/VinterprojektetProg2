using Raylib_cs;

namespace Vinterprojektet
{
    public class Livingroom
    {
        // Skapar privata instanser av klasserna
        private Bedroom bedroom;
        private Bathroom bathroom;        
        private Pickup pickup;
        private Livingroom livingroom; 

        // Skapar array med positionerna för dom 2 collectibles här (dess koordinater)
        private int[] keyRectInitialPositions = new int[] { 1150, 100, 250, 700,  };

        // I livingroom skapas instans av Pickup klassen och initieras med collectible positioner ^
        public Livingroom()
        {
            pickup = new Pickup(keyRectInitialPositions);
        }

        // Metoden för att rita ut världen/rummet/scenen, med 3 instanser av karaktären i världen, världens bakgrundsbild och dörrarnas textur/bild
        public void DrawLivingroomScene(Character character, Texture2D livingroomImage, Texture2D doorImage)
        {
            // Skapar dom två "teleporters"/dörrar som man går in i för byta rum & collectible sprite
            Rectangle sceneChangeBedroom = new Rectangle(1180, 320, doorImage.Width, doorImage.Height);
            Rectangle sceneChangeBathroom = new Rectangle(0, 320, doorImage.Width, doorImage.Height);
            Texture2D keySprite = Raylib.LoadTexture("trashbag.png");

            // Kollar om spelaren kolliderar med klassen pickups objekt vilket är collectibeln
            pickup.CollectCollision(character);
            // Om alla collectibles collectas så avslutas programmet
            if (pickup.AllCollected(character))
            {
                System.Environment.Exit(0);
            }

            // Om spelaren kolliderar med teleporter/dörren som ritades ut tidigare byt scen till nya rummet & tp till mitten 
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
            
            // Om spelaren inte aktivt kolliderar med dörr/teleporter, dvs bara är i rummet rita ut rummet (dess texturer & collectibles)
            else 
            {
            character.Update();
            Raylib.DrawTexture(livingroomImage, 0, 0, Color.WHITE);
            Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, character.backgroundcolor);
            Raylib.DrawRectangleRec(sceneChangeBedroom, Color.BROWN);
            Raylib.DrawRectangleRec(sceneChangeBathroom, Color.BROWN);
            Raylib.DrawTexture(doorImage, (int)sceneChangeBedroom.X, (int)sceneChangeBedroom.Y, Color.WHITE);
            Raylib.DrawTexture(doorImage, (int)sceneChangeBathroom.X, (int)sceneChangeBathroom.Y, Color.WHITE);
            pickup.DrawKeyRectangles(keySprite);
            }
        }
    }
}
