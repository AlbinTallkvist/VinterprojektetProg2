using Raylib_cs;
using Vinterprojektet;

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
        livingroom.DrawLivingroomScene(character, backgroundImage, doorImage);
    }
    else if (currentScene == "bedroomscene")
    {
        bedroom.DrawBedroomScene(character, backgroundImage, doorImage);
    }

    else if (currentScene == "bathroomscene")
    {
        bathroom.DrawBathroomScene(character, backgroundImage, doorImage);
    }
     
    

    Raylib.EndDrawing();
}






// för senare
// bool = kläder etc