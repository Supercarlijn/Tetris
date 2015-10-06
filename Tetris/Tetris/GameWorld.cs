using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;

class GameWorld
{
    enum GameState
    {
        Playing, GameOver
    }
    int screenWidth, screenHeight;
    Random random;
    SpriteFont font;
    Texture2D block;
    GameState gameState;
    TetrisGrid grid;
    Block1 block1;                          //Langwerpig blokje
    Block2 block2;                          //Vierkant blokje
    Block3 block3;                          //Driehoek blokje
    Block4 block4;                          //Donderblokje naar rechts
    Block5 block5;                          //Donderblokje naar links
    Block6 block6;                          //Letter L
    Block7 block7;                          //Omgekeerde letter L

    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;
        random = new Random();
        gameState = GameState.Playing;

        block = Content.Load<Texture2D>("block");
        font = Content.Load<SpriteFont>("SpelFont");
        grid = new TetrisGrid(block);
        Color color;                        //De kleur van het blokje
        int p = Random.Next(6);
        if (p == 0)                          //Bepaalt de kleur dmv de random generator
            color = Color.Red;
        else if (p == 1)
            color = Color.Yellow;
        else if (p == 2)
            color = Color.Green;
        else if (p == 3)
            color = Color.Blue;
        else if (p == 4)
            color = Color.Purple;
        else
            color = Color.Orange;
        block1 = new Block1(color, block);
        block2 = new Block2(color, block);
        block3 = new Block3(color, block);
        block4 = new Block4(color, block);
        block5 = new Block5(color, block);
        block6 = new Block6(color, block);
        block7 = new Block7(color, block);
    }

    public void Reset()
    {
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        block1.HandleInput(inputHelper);
        block2.HandleInput(inputHelper);
        block3.HandleInput(inputHelper);
        block4.HandleInput(inputHelper);
        block5.HandleInput(inputHelper);
        block6.HandleInput(inputHelper);
        block7.HandleInput(inputHelper);
    }

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        block3.Draw(gameTime, spriteBatch);
        spriteBatch.End();
    }

    public void DrawText(string text, Vector2 positie, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, positie, Color.Blue);
    }

    public Random Random
    {
        get { return random; }
    }
}
