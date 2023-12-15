using Raylib_cs;
using Vinterprojektet;

// Skapar 3 instanser av de 3 klasser/rum i spelet
Bathroom bathroom = new Bathroom();
Bedroom bedroom = new Bedroom();
Livingroom livingroom = new Livingroom();

// Laddar in texturerna för alla karktärer osv, Standard inställningar, hur stor ska resolutionen vara och fps
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

// Starten till game-loopen, laddar in StartMenu
while (Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(backgroundcolor);

    // StartMenu Transition -> Spelet
    if (currentScene == "StartScreen")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            currentScene = "StartRoom"; 
            character.ResetCharacterPosition();

        }

        Raylib.DrawTexture(startMenu, 0, 0, Color.WHITE);
    }
    // Spel-loopen när man är i vardagsrummet, startar klassernas kod, ritar världen
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
    // Spel-loopen när man är i sovrummet, startar klassernas kod, ritar världen
    else if (currentScene == "bedroomscene")
    {
        bedroom.DrawBedroomScene(character, bedroomImage, doorImage);
        if (character.currentScene == "StartRoom")
        {
            currentScene = "StartRoom";
        }
    }
    // Spel-loopen när man är i vardagsrummet, startar klassernas kod, ritar världen
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