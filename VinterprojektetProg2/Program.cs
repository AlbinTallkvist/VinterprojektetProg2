using Raylib_cs;
using Vinterprojektet;

Bathroom bathroom = new Bathroom();
Bedroom bedroom = new Bedroom();
Livingroom livingroom = new Livingroom();

Raylib.InitWindow(1280, 800, "CleanUp");
Raylib.SetTargetFPS(60); 
string currentScene = "StartScreen";
Texture2D playerModel = Raylib.LoadTexture("TheBoy.png");
Character character = new Character(playerModel);
Color backgroundcolor = new Color(255, 255, 255, 255);
Texture2D bedroomImage = Raylib.LoadTexture("BedroomBackground.png");
Texture2D bathroomImage = Raylib.LoadTexture("BathroomBackground.png");
Texture2D livingroomImage = Raylib.LoadTexture("LivingroomBackground.png");
Texture2D startMenu = Raylib.LoadTexture("StartMenu.png");
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
            character.ResetCharacterPosition();

        }

        Raylib.DrawTexture(startMenu, 0, 0, Color.WHITE);
    }
    else if (currentScene == "StartRoom")
    {
        livingroom.DrawLivingroomScene(character, livingroomImage, doorImage);
        if (character.currentScene == "bedroomscene")
        {
            currentScene = "bedroomscene";
        }
        if (character.currentScene == "bathroomscene")
        {
            currentScene = "bathroomscene";
        }
    }
    else if (currentScene == "bedroomscene")
    {
        bedroom.DrawBedroomScene(character, bedroomImage, doorImage);
        if (character.currentScene == "StartRoom")
        {
            currentScene = "StartRoom";
        }
    }
    else if (currentScene == "bathroomscene")
    {
        bathroom.DrawBathroomScene(character, bathroomImage, doorImage);
        if (character.currentScene == "StartRoom")
        {
            currentScene = "StartRoom";
        }
    }
    Raylib.EndDrawing();
}

// kom ihåg du e dumm i bollen å använder svenska här o engelska där bara vnänd 1 i slutändan 
// fixa det!!! men på slutet för kommr fortsätta va dumm å göra de