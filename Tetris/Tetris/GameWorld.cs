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
        blocks = new BlockList();
        gameState = GameState.Options;
        inputHelper = new InputHelper();
        block = Content.Load<Texture2D>("block");
        reset = Content.Load<Texture2D>("reset");
        font = Content.Load<SpriteFont>("SpelFont");
        grid = new TetrisGrid(block);
        options = new Options(block, reset, width, height);
        i = (int)random.Next(7) + 1;

        blocks = new BlockList();
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
        blocks.Add(block1, 1);
        block2 = new Block2(color, block);
        blocks.Add(block2, 2);
        block3 = new Block3(color, block);
        blocks.Add(block3, 3);
        block4 = new Block4(color, block);
        blocks.Add(block4, 4);
        block5 = new Block5(color, block);
        blocks.Add(block5, 5);
        block6 = new Block6(color, block);
        blocks.Add(block6, 6);
        block7 = new Block7(color, block);
        blocks.Add(block7, 7);
    }

    public void Reset()
    {
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        blocks.HandleInput(inputHelper, i); //i is dus het random generator nummer van 1 t/m 7 
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
        if (true)
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
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        if (gameState == GameState.Options)
            options.Draw(gameTime, spriteBatch);

        grid.Draw(gameTime, spriteBatch);
        blocks.Draw(gameTime, spriteBatch, i);
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
