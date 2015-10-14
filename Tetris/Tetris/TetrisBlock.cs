using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class TetrisBlock
{
    protected Color[,] blockForm;                       //Houdt bij wat de vorm is van een blok
    protected Vector2 blockFormPosition;
    protected int timesturn;
    public bool newBlock;
    protected Color color;
    TimeSpan timelimit;
    double levelspeed;
    string block;
    Texture2D sprite;

    public TetrisBlock(string block, Texture2D sprite)
    {
        this.block = block;
        this.sprite = sprite;
        timesturn = 0;
        timelimit = TimeSpan.FromSeconds(1);
        levelspeed = 1;
    }

    public void HandleInput(InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Up))                            //Roteert blokje
        {
            timesturn++;                                                //Telt hoe vaak blokje is gedraaid
            if (timesturn == 4)
                timesturn = 0;
            RotateRight();

            if(TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color) || TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color))
            {
                if (!(block == "block1" || block == "block4" || block == "block5"))
                {
                    timesturn--;
                    RotateLeft();
                }
                else
                {
                    if (timesturn == 1)
                    {
                        timesturn--;
                        RotateLeft();
                    }
                    else
                    {
                        timesturn = 1;
                        RotateRight();
                    }
                }
            }
        }
        else if (inputHelper.KeyPressed(Keys.Down))                     //Beweegt naar beneden
        {
            blockFormPosition += new Vector2(0, 1 * TetrisGrid.cellheight);
            timelimit = TimeSpan.FromSeconds(1);
            if (TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color) || (TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color)))
            {
                blockFormPosition -= new Vector2(0, 1 * TetrisGrid.cellheight);
                TetrisGrid.FillOccupiedField(color, blockForm, blockFormPosition);
                newBlock = true;
            }
        }
        else if (inputHelper.KeyPressed(Keys.Left))                     //Beweegt naar links
        {
            blockFormPosition += new Vector2(-1 * TetrisGrid.cellwidth, 0);
            if (TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color))
            {
                blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
            }
            if (TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color))
            {
                blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
            }
        }
        else if (inputHelper.KeyPressed(Keys.Right))                    //Beweegt naar rechts
        {
            blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
            if (TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color))
            {
                blockFormPosition -= new Vector2(1 * TetrisGrid.cellwidth, 0);
            }
            if (TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color))
            {
                blockFormPosition -= new Vector2(1 * TetrisGrid.cellwidth, 0);
            }
        }
    }

    public void RotateRight()
    {
        if (timesturn == 2 && (block == "block1" || block == "block4" || block == "block5"))    //Deze blokjes hoeven maar 2x te draaien
        {
            RotateLeft();
            timesturn = 0;
        }
        else
        {
            Color[,] result = new Color[4, 4];
            for (int i = 0; i < 4; i++)                                 //Maakt van de kolommen rijen en vice versa en draait de inhoud van de rijen om
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = blockForm[3 - j, i];
                }
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    blockForm[i, j] = result[i, j];
        }
    }

    public void RotateLeft()
    {
        Color[,] result = new Color[4, 4];
        for (int i = 0; i < 4; i++)                                 //Maakt van de kolommen rijen en vice versa en draait de inhoud van de rijen om
            for (int j = 0; j < 4; j++)
            {
                result[i, j] = blockForm[j, 3 - i];
            }
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockForm[i, j] = result[i, j];
    }

    public void CheckRows()
    {
        for (int i = 0; i < 20; i++)
            if (TetrisGrid.RowFull(i))
            {
                TetrisGrid.ClearRow(i);
                TetrisGrid.MoveRows(i);
            }
    }

    public void Update(GameTime gameTime)
    {
        double totalSeconds = gameTime.ElapsedGameTime.TotalSeconds * levelspeed;
        timelimit -= TimeSpan.FromSeconds(totalSeconds);
        if(timelimit.TotalSeconds <= 0)
        {
            blockFormPosition += new Vector2(0, 1 * TetrisGrid.cellheight);
            timelimit = TimeSpan.FromSeconds(1);
            if (TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color) || (TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color)))
            {
                blockFormPosition -= new Vector2(0, 1 * TetrisGrid.cellheight);
                TetrisGrid.FillOccupiedField(color, blockForm, blockFormPosition);
                newBlock = true;
            }
        }
        CheckRows();
    }

    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                s.Draw(sprite, new Vector2(j * TetrisGrid.cellwidth, i * TetrisGrid.cellheight) + blockFormPosition, blockForm[i, j]);
                //blabla + blockFormPosition; blabla is de afstand van de blokken IN blockFormTexture
            }
    }

    public virtual void Reset()
    {
    }

    public string Block
    {
        get { return block; }
    }
}