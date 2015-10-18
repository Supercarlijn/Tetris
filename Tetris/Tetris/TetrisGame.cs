using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;

class TetrisGame : Game
{
    SpriteBatch spriteBatch;
    InputHelper inputHelper;
    GameWorld gameWorld;
    Song song;
    Random random;

    static void Main(string[] args)
    {
        TetrisGame game = new TetrisGame();
        game.Run();
    }

    public TetrisGame()
    {
        GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
        this.Content.RootDirectory = "Content";
        graphics.PreferredBackBufferWidth = 800;
        graphics.PreferredBackBufferHeight = 600;
        inputHelper = new InputHelper();
        IsMouseVisible = true; 
        random = new Random();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        gameWorld = new GameWorld(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Content);
        SongGenerator();
        MediaPlayer.Play(song);
        MediaPlayer.IsRepeating = true;
        gameWorld.Reset();
    }

    protected override void Update(GameTime gameTime)
    {
        inputHelper.Update(gameTime);
        gameWorld.HandleInput(gameTime, inputHelper);
        gameWorld.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        gameWorld.Draw(gameTime, spriteBatch);
    }

    public void SongGenerator()
    {
        Song blow = Content.Load<Song>("Blow");
        Song built = Content.Load<Song>("Built To Fall");
        Song divide = Content.Load<Song>("New Divide");
        Song paranoid = Content.Load<Song>("Paranoid");
        Song thnks = Content.Load<Song>("Thnks");
        switch (random.Next(5))
        {
            case 1:
                song = blow;
                break;
            case 2:
                song = built;
                break;
            case 3:
                song = divide;
                break;
            case 4:
                song = paranoid;
                break;
            default:
                song = thnks;
                break;
        }
    }
}
