using Raylib_cs;
using CharacterMovement;

Bathroom bathroom = new Bathroom();
Bedroom bedroom = new Bedroom();
Livingroom livingroom = new Livingroom();

Raylib.InitWindow(1280, 800, "Hurry");
Raylib.SetTargetFPS(60);
string currentScene = "StartScreen";
Texture2D playerModel = Raylib.LoadTexture("TheBoy.png");
Character character = new Character(playerModel); 
Color backgroundcolor = new Color(255, 255, 255, 255);
Texture2D backgroundImage = Raylib.LoadTexture("Backgroundd.png");
Rectangle sceneChangeBedroom = new Rectangle(1075, 60, 100, 100);
Rectangle sceneChangeBathroom = new Rectangle(800, 30, 100, 100);


// --------------------------------------------------------------------------------

while (Raylib.WindowShouldClose() == false)
{
  if (currentScene == "StartScreen")
  {
    if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
    {
      currentScene = "StartRoom";
    }
  }


  if (Raylib.CheckCollisionRecs(character.player, sceneChangeBedroom))
  {
    currentScene = "bedroomscene";
  }

  if (Raylib.CheckCollisionRecs(character.player, sceneChangeBathroom))
  {
    currentScene = "bathroomscene";
  }




    Raylib.BeginDrawing();
    Raylib.ClearBackground(backgroundcolor);

    if (currentScene == "StartRoom")
    {
       character.Update();

        Raylib.DrawTexture(backgroundImage, 0, 0, Color.WHITE);
        Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, backgroundcolor);
        Raylib.DrawRectangleRec(sceneChangeBedroom, Color.BLACK);
        Raylib.DrawRectangleRec(sceneChangeBathroom, Color.BLACK);




    }

      else if (currentScene == "StartScreen")
    {
        Raylib.DrawText("Welcome", 560, 420, 40, Color.BLACK);
        Raylib.DrawText("\nENTER to begin", 515, 420, 32, Color.BLACK);

    } 

    Raylib.EndDrawing();
}





// för senare
// bool = kläder etc

