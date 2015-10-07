﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;

class GameWorld
{
    enum GameState
    {
        Playing, GameOver, Options, Menu, ZZ
    }
    int screenWidth, screenHeight;
    Random random;
    SpriteFont font;
    Texture2D block, reset;
    GameState gameState;
    TetrisGrid grid;
    /*Block1 block1;
    Block2 block2;
    Block3 block3;
    Block4 block4;
    Block5 block5;*/
    InputHelper inputHelper;
    
    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;
        random = new Random();
        gameState = GameState.Options;
        inputHelper = new InputHelper();
        block = Content.Load<Texture2D>("block");
        reset = Content.Load<Texture2D>("block"); //RESET SPRITE HERE
        font = Content.Load<SpriteFont>("SpelFont");
        grid = new TetrisGrid(block);
    }

    public void Reset()
    {
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
    }

    public void Update(GameTime gameTime)
    {
        inputHelper.Update(gameTime);
        if (gameState == GameState.Menu)
        {
            //MOUSE LOCATIONS TO BE DETERMINED
        }
        if (gameState == GameState.Options)
        {
            
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        if (gameState == GameState.Options)
        {
            for (int i = -12; i < 9; i += 5)
                spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (i * block.Width)), block.Height), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
            for (int i = -11; i < 10; i += 5)
                spriteBatch.Draw(reset, new Vector2((screenWidth / 2 + (i * block.Width)), block.Height * 5), null, Color.Black, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);


            if (screenWidth / 2 - (17 * block.Width) > 0)
            {
                spriteBatch.Draw(block, new Vector2((screenWidth / 2 - (17 * block.Width)), block.Height), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
                spriteBatch.Draw(reset, new Vector2((screenWidth / 2 - (16 * block.Width)), block.Height * 5), null, Color.Black, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (13 * block.Width)), block.Height), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
                spriteBatch.Draw(reset, new Vector2((screenWidth / 2 + (14 * block.Width)), block.Height * 5), null, Color.Black, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(block, new Vector2((screenWidth / 2 - (12 * block.Width)), block.Height * 7), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
                spriteBatch.Draw(reset, new Vector2((screenWidth / 2 - (11 * block.Width)), block.Height * 11), null, Color.Black, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (8 * block.Width)), block.Height * 7), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
                spriteBatch.Draw(reset, new Vector2((screenWidth / 2 + (9 * block.Width)), block.Height * 11), null, Color.Black, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }
        //grid.Draw(gameTime, spriteBatch);
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
