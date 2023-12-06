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
Texture2D doorImage = Raylib.LoadTexture("doorone.png");

void ResetCharacterPosition()
{
    character.player.X = Raylib.GetScreenWidth() / 2 - character.PlayerModel.Width / 2;
    character.player.Y = Raylib.GetScreenHeight() / 2 - character.PlayerModel.Height / 2;
}

while (Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(backgroundcolor);

    if (currentScene == "StartScreen")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            currentScene = "StartRoom";
        }

        Raylib.DrawText("Welcome", 560, 420, 40, Color.BLACK);
        Raylib.DrawText("\nENTER to begin", 515, 420, 32, Color.BLACK);
    }
    else if (currentScene == "StartRoom")
    {
        character.Update();
        Rectangle sceneChangeBedroom = new Rectangle(1180, 320, doorImage.Width, doorImage.Height);
        Rectangle sceneChangeBathroom = new Rectangle(0, 320, doorImage.Width, doorImage.Height);

        Raylib.DrawTexture(backgroundImage, 0, 0, Color.WHITE);
        Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, backgroundcolor);
        Raylib.DrawRectangleRec(sceneChangeBedroom, Color.BROWN);
        Raylib.DrawText("Living room", 515, 420, 32, Color.BLACK);
        Raylib.DrawRectangleRec(sceneChangeBathroom, Color.BROWN);
        Raylib.DrawTexture(doorImage, (int)sceneChangeBedroom.X, (int)sceneChangeBedroom.Y, Color.WHITE);
        Raylib.DrawTexture(doorImage, (int)sceneChangeBathroom.X, (int)sceneChangeBathroom.Y, Color.WHITE);

        if (Raylib.CheckCollisionRecs(character.player, sceneChangeBedroom))
        {
            currentScene = "bedroomscene";
            ResetCharacterPosition();
        }

        else if (Raylib.CheckCollisionRecs(character.player, sceneChangeBathroom))
        {
            currentScene = "bathroomscene"; 
            ResetCharacterPosition();
        }


    }
    else if (currentScene == "bedroomscene")
    {
        character.Update();
        Rectangle sceneChangeLivingroom = new Rectangle(0, 320, doorImage.Width, doorImage.Height);

        Raylib.DrawTexture(backgroundImage, 0, 0, Color.WHITE);
        Raylib.DrawText("Bedroom", 515, 420, 32, Color.BLACK);
        Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, backgroundcolor);
        Raylib.DrawRectangleRec(sceneChangeLivingroom, Color.BROWN);
        Raylib.DrawTexture(doorImage, (int)sceneChangeLivingroom.X, (int)sceneChangeLivingroom.Y, Color.WHITE);

        if (Raylib.CheckCollisionRecs(character.player, sceneChangeLivingroom))
        {
            currentScene = "StartRoom";
            ResetCharacterPosition();
        }
    }
    else if (currentScene == "bathroomscene")
    {
        character.Update();
        Rectangle sceneChangeLivingroom = new Rectangle(1180, 320, doorImage.Width, doorImage.Height);


        Raylib.DrawTexture(backgroundImage, 0, 0, Color.WHITE);
        Raylib.DrawText("Bathroom", 515, 420, 32, Color.BLACK);
        Raylib.DrawTexture(character.PlayerModel, (int)character.player.X, (int)character.player.Y, backgroundcolor);
        Raylib.DrawRectangleRec(sceneChangeLivingroom, Color.BROWN);
        Raylib.DrawTexture(doorImage, (int)sceneChangeLivingroom.X, (int)sceneChangeLivingroom.Y, Color.WHITE);

        if (Raylib.CheckCollisionRecs(character.player, sceneChangeLivingroom))
        {
            currentScene = "StartRoom";
            ResetCharacterPosition();
        }
    }
     
    

    Raylib.EndDrawing();
}






// för senare
// bool = kläder etc

