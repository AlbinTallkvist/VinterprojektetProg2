// Ide: Man är ett barn som måste städa ens hus genom gå i olika rum och plocka upp saker mm innan morsan kommer hem
// Rum klass och subklasser varje rum, samma action varje rum? olika ctions?
// Raylib inställningarna
using Raylib_cs;

Bathroom bathroom = new Bathroom();
Bedroom bedroom = new Bedroom();
Livingroom livingroom = new Livingroom();

Raylib.InitWindow(1280, 800, "Untitled");
Raylib.SetTargetFPS(60);
string currentScene = "StartScreen";  


// ladda in texturer här - hitta bra textur för playable character på freda
//-Texture2D PlayerModel = Raylib.LoadTexture("TheBoy.png");
///-Rectangle player = new Rectangle(415, 60, PlayerModel.Width, PlayerModel.Height);
Color backgroundcolor = new Color(255, 255, 255, 255);


while (Raylib.WindowShouldClose() == false)
{
    using Character;





  if (currentScene == "StartScreen")
  {
    if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
    {
      currentScene = "StartRoom";
    }
  }






// rita

    Raylib.BeginDrawing();
    Raylib.ClearBackground(backgroundcolor);


    if (currentScene == "StartRoom")
    {
        Raylib.DrawText("Test", 280, 300, 50, Color.BLACK);
        Raylib.DrawTexture(PlayerModel, (int) player.X, (int) player.Y, backgroundcolor);


    }

      else if (currentScene == "StartScreen")
    {
        Raylib.DrawText("Welcome", 280, 380, 50, Color.BLACK);
        Raylib.DrawText("\nENTER to begin", 515, 420, 32, Color.BLACK);

    } 

    Raylib.EndDrawing();
}





// för senare
// bool = kläder etc

