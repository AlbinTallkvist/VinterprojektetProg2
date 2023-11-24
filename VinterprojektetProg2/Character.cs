using Raylib_cs;

public class Character
{
    Texture2D PlayerModel = Raylib.LoadTexture("TheBoy.png");
    float WalkSpeed = 2f;
    Rectangle player = new Rectangle(415, 60, PlayerModel.Width, PlayerModel.Height);



    public void Update()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            player.X += WalkSpeed;

            if (player.X > Raylib.GetScreenWidth() - player.Width)
            {
                player.X = Raylib.GetScreenWidth() - player.Width;
            }
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            player.X -= WalkSpeed;

            if (player.X < 0)
            {
                player.X = 0;
            }
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            player.Y += WalkSpeed;

            if (player.Y > Raylib.GetScreenHeight() - player.Height)
            {
                player.Y = Raylib.GetScreenHeight() - player.Height;
            }
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            player.Y -= WalkSpeed;

            if (player.Y < 0)
            {
                player.Y = 0;
            }
        }
    }
}
