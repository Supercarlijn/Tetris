using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class TetrisBlock
{
    protected Color[,] blockForm;                       //Houdt bij wat de vorm is van een blok
    protected Texture2D[,] blockFormTexture;            //Array met de textureblokjes
    protected Vector2 blockFormPosition, blockPosition, offset; //Positie van blokje in blockFormTexture
    int timesturn, width, height, p;
    public bool newBlock;
    protected Color color;
    TimeSpan timelimit;
    double levelspeed;
    string block;

    public TetrisBlock(int k, string block)
    {
        p = k;
        this.block = block;
        timesturn = 0;
        timelimit = TimeSpan.FromSeconds(1);
        levelspeed = 1;
    }

    public void HandleInput(InputHelper inputHelper, int width, int height)
    {
        if (inputHelper.KeyPressed(Keys.Up))                            //Roteert blokje
        {
            if (timesturn == 0)
            {
                this.height = height;
                this.width = width;
            }

            if (width == height)                                        //Controleren dat iemand niet het vierkante blokje probeert te draaien
                return;

            timesturn++;                                                //Telt hoe vaak blokje is gedraaid
            if (timesturn == 4)
                timesturn = 0;
            RotateRight();

            int newwidth = this.height;
            int newheight = this.width;
            this.height = newheight;
            this.width = newwidth;

            this.blockPosition = CalculateBlockPosition();
            this.offset = SetOffset();

            if(TetrisGrid.CannotRotate(blockFormPosition, this.width, this.height) || TetrisGrid.CheckPlayField(p, blockFormPosition, blockForm, color))
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
                int oldheight = this.width;
                int oldwidth = this.height;
                this.width = oldwidth;
                this.height = oldheight;

                this.blockPosition = CalculateBlockPosition();
                this.offset = SetOffset();
            }
        }
        else if (inputHelper.KeyPressed(Keys.Down))                     //Beweegt naar beneden
        {
            if (timesturn == 0)
            {
                this.width = width;
                this.height = height;
            }
            blockFormPosition += new Vector2(0, 1 * TetrisGrid.cellheight);
            timelimit = TimeSpan.FromSeconds(1);
            if (TetrisGrid.IsOutOfField(blockFormPosition, this.blockPosition, this.offset, p) || (TetrisGrid.CheckPlayField(p, blockFormPosition, blockForm, color)))
            {
                blockFormPosition -= new Vector2(0, 1 * TetrisGrid.cellheight);
                TetrisGrid.FillOccupiedField(color, p, blockForm, blockFormPosition);
                CheckRows();
            }
            for (int i = 0; i < 20; i++)
                if (TetrisGrid.RowFull(i))
                {
                    TetrisGrid.ClearRow(i);
                    TetrisGrid.MoveRows(i);
                }
        }
        else if (inputHelper.KeyPressed(Keys.Left))                     //Beweegt naar links
        {
            if (timesturn == 0)
            {
                this.width = width;
                this.height = height;
            }
            blockFormPosition += new Vector2(-1 * TetrisGrid.cellwidth, 0);
            if (TetrisGrid.IsOutOfField(blockFormPosition, this.blockPosition, this.offset, p))
            {
                blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
            }
            if (TetrisGrid.CheckPlayField(p, blockFormPosition, blockForm, color))
            {
                blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
                TetrisGrid.FillOccupiedField(color, p, blockForm, blockFormPosition);
                CheckRows();
            }
        }
        else if (inputHelper.KeyPressed(Keys.Right))                    //Beweegt naar rechts
        {
            if (timesturn == 0)
            {
                this.width = width;
                this.height = height;
            }
            blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
            if (TetrisGrid.IsOutOfField(blockFormPosition, this.blockPosition, this.offset, p))
            {
                blockFormPosition -= new Vector2(1 * TetrisGrid.cellwidth, 0);
            }
            if (TetrisGrid.CheckPlayField(p, blockFormPosition, blockForm, color))
            {
                blockFormPosition -= new Vector2(1 * TetrisGrid.cellwidth, 0);
                TetrisGrid.FillOccupiedField(color, p, blockForm, blockFormPosition);
                CheckRows();
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
            Color[,] result = new Color[p, p];
            for (int i = 0; i < p; i++)                                 //Maakt van de kolommen rijen en vice versa en draait de inhoud van de rijen om
                for (int j = 0; j < p; j++)
                {
                    result[i, j] = blockForm[p - j - 1, i];
                }
            for (int i = 0; i < p; i++)
                for (int j = 0; j < p; j++)
                    blockForm[i, j] = result[i, j];
        }
    }

    public void RotateLeft()
    {
        Color[,] result = new Color[p, p];
        for (int i = 0; i < p; i++)                                 //Maakt van de kolommen rijen en vice versa en draait de inhoud van de rijen om
            for (int j = 0; j < p; j++)
            {
                result[i, j] = blockForm[j, p - i - 1];
            }
        for (int i = 0; i < p; i++)
            for (int j = 0; j < p; j++)
                blockForm[i, j] = result[i, j];
    }

    public Vector2 CalculateBlockPosition()  //Verandert de positie van het blokje in array
    {
        switch (timesturn)
        {
            case 1:
                if (p == 3)
                    return new Vector2(p - width / TetrisGrid.cellwidth, 0);
                else
                    return new Vector2(p - width / TetrisGrid.cellwidth, 1);
            case 2:
                if (p == 3)
                    return new Vector2(0, 1);
                else
                    return new Vector2(1, 1);
            case 3:
                if (p == 3)
                    return new Vector2(0, 0);
                else
                    return new Vector2(0, 1);
            default:            //Als timesturn == 0
                if (p == 3)
                    return new Vector2(0, 0);
                else
                    return new Vector2(1, 0);
        }
    }

    public Vector2 SetOffset ()
    {
        if (timesturn == 0 && (block == "block1" || block == "block4" || block == "block5"))
        {
            return new Vector2(offset.Y, offset.X);
        }
        else
        {
            return new Vector2(p - width / TetrisGrid.cellwidth - blockPosition.X, p - height / TetrisGrid.cellheight - blockPosition.Y);
        }
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
            if (TetrisGrid.IsOutOfField(blockFormPosition, this.blockPosition, this.offset, p) || (TetrisGrid.CheckPlayField(p, blockFormPosition, blockForm, color)))
            {
                blockFormPosition -= new Vector2(0, 1 * TetrisGrid.cellheight);
                TetrisGrid.FillOccupiedField(color, p, blockForm, blockFormPosition);
                CheckRows();
                newBlock = true;
                //Reset();
            }
        }
    }

    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        for (int i = 0; i < p; i++)
            for (int j = 0; j < p; j++)
            {
                s.Draw(blockFormTexture[i, j], new Vector2(j * TetrisGrid.cellwidth, i * TetrisGrid.cellheight) + blockFormPosition, blockForm[i, j]);
                //blabla + blockFormPosition; blabla is de afstand van de blokken IN blockFormTexture
            }
    }

    public virtual void Reset()
    { }

    public int Width
    {
        get { return width; }
    }

    public int Height
    {
        get { return height; }
    }

    public string Block
    {
        get { return block; }
    }
}