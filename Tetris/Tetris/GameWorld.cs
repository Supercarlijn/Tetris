using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;

class GameWorld
{
    enum GameState                                  //De verschillende gamestates
    {
        Playing, GameOver, Options, Menu
    }
    Random random;
    SpriteFont font;
    Texture2D block, reset, playButton, optionsButton, polytris, backButton;
    GameState gameState;
    TetrisGrid grid;
    Options options;
    Menu menu;
    GameOver gameOver;
    public int screenWidth, screenHeight;
    int i, i2, blockcounter;            //i, i2 worden gebruikt om een random blokje te laten verschijnen, blockcounter om te tellen hoeveel blokjes al geplaatst zijn
    static int level, score;
    static float levelspeed;            //Geeft de snelheid aan waarmee een blokje automatisch naar beneden valt
    InputHelper inputHelper;
    Block1 block1, block1res;               //Langwerpig blokje
    Block2 block2, block2res;               //Vierkant blokje
    Block3 block3, block3res;               //Driehoek blokje
    Block4 block4, block4res;               //Donderblokje naar rechts
    Block5 block5, block5res;               //Donderblokje naar links
    Block6 block6, block6res;               //Letter L
    Block7 block7, block7res;               //Omgekeerde letter L
    BlockList blocks;                       //De lijst die de blokjes bevat


    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;
        random = new Random();
        gameState = GameState.Menu;
        inputHelper = new InputHelper();
        block = Content.Load<Texture2D>("block");
        reset = Content.Load<Texture2D>("reset");
        font = Content.Load<SpriteFont>("SpelFont");
        playButton = Content.Load<Texture2D>("Play");
        optionsButton = Content.Load<Texture2D>("Options");
        backButton = Content.Load<Texture2D>("Back");
        polytris = Content.Load<Texture2D>("Polytris");
        grid = new TetrisGrid(block);
        level = 1;
        levelspeed = 1;
        score = 0;
        i = (int)random.Next(7) + 1;
        i2 = (int)random.Next(7) + 1;
        blockcounter = 1;

        blocks = new BlockList(block);          //Voegen de verschillende blockobjecten toe aan de lijst
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

        //Voegen de verschillende blockobjecten toe aan een tweede lijst voor het tekenen van het volgende blokje
        block1res = new Block1(block);
        blocks.AddToReserve(block1res, 1);
        block2res = new Block2(block);
        blocks.AddToReserve(block2res, 2);
        block3res = new Block3(block);
        blocks.AddToReserve(block3res, 3);
        block4res = new Block4(block);
        blocks.AddToReserve(block4res, 4);
        block5res = new Block5(block);
        blocks.AddToReserve(block5res, 5);
        block6res = new Block6(block);
        blocks.AddToReserve(block6res, 6);
        block7res = new Block7(block);
        blocks.AddToReserve(block7res, 7);

        options = new Options(block, reset, backButton, width, height, font, blocks);
        menu = new Menu(playButton, optionsButton, polytris, width, height);
        gameOver = new GameOver(backButton, width, height);
        
    }

    public void Reset()
    {
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        if (gameState == GameState.Playing)                 //Speelfase
        {
            blocks.HandleInput(inputHelper, i);             //Het bewegen van de blokjes over het speelveld
        }

        if (gameState == GameState.Menu)
        {
            if (inputHelper.MouseLeftButtonPressed())
            {
                if (menu.PlayRect.Contains((int)inputHelper.MousePosition.X, (int)inputHelper.MousePosition.Y))
                {
                    gameState = GameState.Playing;
                }
                
                if (menu.OptionsRect.Contains((int)inputHelper.MousePosition.X, (int)inputHelper.MousePosition.Y))
                {
                    gameState = GameState.Options;
                }
            }
        }

        if (gameState == GameState.GameOver)
        {
            if (inputHelper.MouseLeftButtonPressed())
            {
                if (gameOver.BackRect.Contains((int)inputHelper.MousePosition.X, (int)inputHelper.MousePosition.Y))
                    gameState = GameState.Menu;
            }
        }
        if (gameState == GameState.Options)                 //Optie menu
        {
            options.HandleInput(inputHelper);
            if (inputHelper.MouseLeftButtonPressed() && options.BackRect.Contains((int)inputHelper.MousePosition.X, (int)inputHelper.MousePosition.Y))             //Het beginnen van het spel
            {
                block1.BlockForm = block1.CurrentBlockForm;         //De bewerkte vormen moeten doorgegeven worden aan de speelfase
                block2.BlockForm = block2.CurrentBlockForm;
                block3.BlockForm = block3.CurrentBlockForm;
                block4.BlockForm = block4.CurrentBlockForm;
                block5.BlockForm = block5.CurrentBlockForm;
                block6.BlockForm = block6.CurrentBlockForm;
                block7.BlockForm = block7.CurrentBlockForm;

                block1res.BlockForm = block1.CurrentBlockForm;
                block2res.BlockForm = block2.CurrentBlockForm;
                block3res.BlockForm = block3.CurrentBlockForm;
                block4res.BlockForm = block4.CurrentBlockForm;
                block5res.BlockForm = block5.CurrentBlockForm;
                block6res.BlockForm = block6.CurrentBlockForm;
                block7res.BlockForm = block7.CurrentBlockForm;

                block1.CalculateArrayRotatingLength(4);            //Hier wordt berekend hoe de blokjes moeten draaien afhankelijk van hun vorm
                block2.CalculateArrayRotatingLength(4);
                block3.CalculateArrayRotatingLength(4);
                block4.CalculateArrayRotatingLength(4);
                block5.CalculateArrayRotatingLength(4);
                block6.CalculateArrayRotatingLength(4);
                block7.CalculateArrayRotatingLength(4);

                gameState = GameState.Menu;
            }
        }
    }

    public void Update(GameTime gameTime)
    {
        inputHelper.Update(gameTime);
        if (gameState == GameState.Options)
            options.Update();
        if (gameState == GameState.Playing)
        { 
            blocks.Update(gameTime, i);

            //Hier wordt gekeken of er een nieuw blokje bovenaan het speelveld getekend moet worden
            if (block1.newBlock || block2.newBlock || block3.newBlock || block4.newBlock || block5.newBlock || block6.newBlock || block7.newBlock)
            {
                block1.newBlock = false;
                block2.newBlock = false;
                block3.newBlock = false;
                block4.newBlock = false;
                block5.newBlock = false;
                block6.newBlock = false;
                block7.newBlock = false;
                blocks.Reset(i, i2);
                i = (int)random.Next(7) + 1;
                i = i2;
                i2 = (int)random.Next(7) + 1;
                blockcounter++;
                if (blockcounter == 11)          //Als er 10 blokjes geplaatst zijn, gaan we een level omhoog
                {
                    blockcounter = 1;
                    level++;
                    levelspeed += 0.35f;
                }
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
        if (gameState == GameState.Menu)
            menu.Draw(gameTime, spriteBatch);
        if (gameState == GameState.Options)
            options.Draw(gameTime, spriteBatch);

        if (gameState == GameState.Playing)
        {
            grid.Draw(gameTime, spriteBatch);
            blocks.Draw(gameTime, spriteBatch, i, i2, new Vector2(9.5f * TetrisGrid.cellwidth, 4 * TetrisGrid.cellheight));
            spriteBatch.DrawString(font, "Level: " + level, new Vector2(13 * TetrisGrid.cellwidth, 0.5f * TetrisGrid.cellheight), Color.Black);
            spriteBatch.DrawString(font, "Score: " + score, new Vector2(13 * TetrisGrid.cellwidth, 1.5f * TetrisGrid.cellheight), Color.Black);
            spriteBatch.DrawString(font, "Next block:", new Vector2(13 * TetrisGrid.cellwidth, 2.5f * TetrisGrid.cellheight), Color.Black);
        }

        if (gameState == GameState.GameOver)
        {
            spriteBatch.Draw(backButton, gameOver.BackRect, Color.White);
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

    public static int Level
    {
        get { return level; }
        set { level = value; }
    }

    public static float LevelSpeed
    {
        get { return levelspeed; }
        set { levelspeed = value; }
    }

    public static int Score
    {
        get { return score; }
        set { score = value; }
    }
}
