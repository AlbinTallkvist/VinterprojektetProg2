using Raylib_cs;

namespace Vinterprojektet
{
    public class Character
    {

        public Texture2D PlayerModel;
        float WalkSpeed = 6f;
        public Rectangle player;
        public int collectedKeys = 0;

        public Character(Texture2D playerModel)
        {
            PlayerModel = playerModel;
            player = new Rectangle(415, 60, PlayerModel.Width, PlayerModel.Height);
        }

            public void ResetCharacterPosition()
        {
            player.X = Raylib.GetScreenWidth() / 2 - PlayerModel.Width / 2;
            player.Y = Raylib.GetScreenHeight() / 2 - PlayerModel.Height / 2;
        }

        

        public string currentScene;
        public Color backgroundcolor = new Color(255, 255, 255, 255);

        




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
}