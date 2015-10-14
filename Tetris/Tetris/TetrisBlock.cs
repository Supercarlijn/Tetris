using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class TetrisBlock
{
    protected Color[,] blockForm, currentBlockForm, oldBlockForm;                       //Houdt bij wat de vorm is van een blok
    protected Texture2D[,] blockFormTexture;            //Array met de textureblokjes
    protected Vector2 blockFormPosition, blockPosition, offset; //Positie van blokje in blockFormTexture
    protected int timesturn, width, height;
    public bool newBlock;
    protected Color color;
    TimeSpan timelimit;
    double levelspeed;
    string block;

    public TetrisBlock(string block)
    {
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

            if(TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color)/* || TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color)*/)
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
            if (TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color)/* || (TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color))*/)
            {
                blockFormPosition -= new Vector2(0, 1 * TetrisGrid.cellheight);
                TetrisGrid.FillOccupiedField(color, blockForm, blockFormPosition);
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
            if (TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color))
            {
                blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
            }
            /*if (TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color))
            {
                blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
            }*/
        }
        else if (inputHelper.KeyPressed(Keys.Right))                    //Beweegt naar rechts
        {
            if (timesturn == 0)
            {
                this.width = width;
                this.height = height;
            }
            blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
            if (TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color))
            {
                blockFormPosition -= new Vector2(1 * TetrisGrid.cellwidth, 0);
            }
            /*if (TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color))
            {
                blockFormPosition -= new Vector2(1 * TetrisGrid.cellwidth, 0);
            }*/
        }
    }

    public void RotateRight()
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

    public Vector2 CalculateBlockPosition()  //Verandert de positie van het blokje in array
    {
        Vector2 resultaat = new Vector2(10, 10);  //expres grote waarde 10 genomen, omdat hij anders grote kans heeft om al voortijdig te breaken
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (blockForm[i, j] == color)
                {
                    resultaat.Y = i;
                    break;
                }
            }
            if (resultaat.Y == i)
                break;
        }
        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < 4; i++)
            {
                if (blockForm[i,j] == color)
                {
                    resultaat.X = j;
                    break;
                }
            }
            if (resultaat.X == j)
                break;
        }
        return resultaat;
    }

    public Vector2 SetOffset ()
    {
        if (timesturn == 0 && (block == "block1" || block == "block4" || block == "block5"))
        {
            if (block == "block1")
                return new Vector2(2, 0);
            else
                return new Vector2(1, 1);
        }
        else
        {
            return new Vector2(4 - width / TetrisGrid.cellwidth - blockPosition.X, 4 - height / TetrisGrid.cellheight - blockPosition.Y);
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
            if (TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color)/* || (TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color))*/)
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
                s.Draw(blockFormTexture[i, j], new Vector2(j * TetrisGrid.cellwidth, i * TetrisGrid.cellheight) + blockFormPosition, blockForm[i, j]);
                //blabla + blockFormPosition; blabla is de afstand van de blokken IN blockFormTexture
            }
    }

    public virtual void Reset()
    {
    }

    public int Width
    {
        get { return this.width; }
    }

    public int Height
    {
        get { return this.height; }
    }

    public string Block
    {
        get { return block; }
    }

    public Color[,] BlockForm
    {
        get { return blockForm; }
        set { blockForm = value; }
    }

    public Color[,] CurrentBlockForm
    {
        get { return currentBlockForm; }
        set { currentBlockForm = value; }
    }

    public Color[,] OldBlockForm
    {
        get { return oldBlockForm; }
    }

    public Color Color
    {
        get { return color; }
    }
}