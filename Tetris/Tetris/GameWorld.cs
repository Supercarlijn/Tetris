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
    Random random;
    SpriteFont font;
    Texture2D block, reset;
    GameState gameState;
    TetrisGrid grid;
    Options options;
    public int screenWidth, screenHeight;
    int i;
    InputHelper inputHelper;
    Block1 block1;                          //Langwerpig blokje
    Block2 block2;                          //Vierkant blokje
    Block3 block3;                          //Driehoek blokje
    Block4 block4;                          //Donderblokje naar rechts
    Block5 block5;                          //Donderblokje naar links
    Block6 block6;                          //Letter L
    Block7 block7;                          //Omgekeerde letter L
    BlockList blocks;                       //De lijst die de blokjes bevat


    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;
        random = new Random();
        gameState = GameState.Options;
        inputHelper = new InputHelper();
        block = Content.Load<Texture2D>("block");
        reset = Content.Load<Texture2D>("reset");
        font = Content.Load<SpriteFont>("SpelFont");
        grid = new TetrisGrid(block);
        i = (int)random.Next(7) + 1;

        blocks = new BlockList(block);
        block1 = new Block1(block);
        blocks.Add(block1, 1);
        block2 = new Block2(block);
        blocks.Add(block2, 2);
        block3 = new Block3(block);
        blocks.Add(block3, 3);
        block4 = new Block4(block);
        blocks.Add(block4, 4);
        block5 = new Block5(block);
        blocks.Add(block5, 5);
        block6 = new Block6(block);
        blocks.Add(block6, 6);
        block7 = new Block7(block);
        blocks.Add(block7, 7);
        options = new Options(block, reset, width, height, font, blocks);
    }

    public void Reset()
    {
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        if (gameState == GameState.Playing)
        {
            blocks.HandleInput(inputHelper, i); //i is dus het random generator nummer van 1 t/m 7 
        }

        if (gameState == GameState.Options)
        {
            options.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.K))
            {
                block1.BlockForm = block1.CurrentBlockForm;
                block2.BlockForm = block2.CurrentBlockForm;
                block3.BlockForm = block3.CurrentBlockForm;
                block4.BlockForm = block4.CurrentBlockForm;
                block5.BlockForm = block5.CurrentBlockForm;
                block6.BlockForm = block6.CurrentBlockForm;
                block7.BlockForm = block7.CurrentBlockForm;
                options.CalculateArrayRotatingLength(block1, block1.Color, 4);
                options.CalculateArrayRotatingLength(block2, block2.Color, 4);
                options.CalculateArrayRotatingLength(block3, block3.Color, 4);
                options.CalculateArrayRotatingLength(block4, block4.Color, 4);
                options.CalculateArrayRotatingLength(block5, block5.Color, 4);
                options.CalculateArrayRotatingLength(block6, block6.Color, 4);
                options.CalculateArrayRotatingLength(block7, block7.Color, 4);
                options.IsBlockSymmetrical(block1, block1.Color);
                options.IsBlockSymmetrical(block2, block2.Color);
                options.IsBlockSymmetrical(block3, block3.Color);
                options.IsBlockSymmetrical(block4, block4.Color);
                options.IsBlockSymmetrical(block5, block5.Color);
                options.IsBlockSymmetrical(block6, block6.Color);
                options.IsBlockSymmetrical(block7, block7.Color);
                gameState = GameState.Playing;
            }
        }
    }

    public void Update(GameTime gameTime)
    {
        inputHelper.Update(gameTime);
        if (gameState == GameState.Menu)
        {
            //MOUSE LOCATIONS TO BE DETERMINED
        }
        if (gameState == GameState.Options)
            options.Update();
        if (gameState == GameState.GameOver)
        {
            gameState = GameState.Options; // TIJDELIJK
        }
        if (gameState == GameState.Playing)
        { 
            blocks.Update(gameTime, i);
            if (block1.newBlock || block2.newBlock || block3.newBlock || block4.newBlock || block5.newBlock || block6.newBlock || block7.newBlock)
            {
                block1.newBlock = false;
                block2.newBlock = false;
                block3.newBlock = false;
                block4.newBlock = false;
                block5.newBlock = false;
                block6.newBlock = false;
                block7.newBlock = false;
                blocks.Reset(i);
                i = (int)random.Next(7) + 1;
                
            }
            for (int x = 0; x < grid.Width; x++)
                if (grid.Occupied[0, x] != Color.White)
                {
                    for (int y = 0; y < grid.Width; y++)
                    {
                        for (int z = 0; z < grid.Height; z++)
                            grid.Occupied[z, y] = Color.White;
                    }
                    gameState = GameState.GameOver;
                }
        }
        
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        if (gameState == GameState.Options)
            options.Draw(gameTime, spriteBatch);

        if (gameState == GameState.Playing)
        {
            grid.Draw(gameTime, spriteBatch);
            blocks.Draw(gameTime, spriteBatch, i);
        }
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
