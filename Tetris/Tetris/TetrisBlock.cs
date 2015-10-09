using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class TetrisBlock
{
    protected Color[,] blockForm;                       //Houdt bij wat de vorm is van een blok; Color.White is onbezet
    protected Texture2D[,] blockFormTexture;            //Array met de textureblokjes
    Vector2 blockFormPosition, position, offset;
    int timesturn, width, height, p;
    Color color;
    TimeSpan timelimit;
    double levelspeed;

    public TetrisBlock(Color col, Texture2D blocksprite,
        int maxrow, int maxcolumn,
             int a, int b, int c, int d, int e, int f, int k) //LANGE CONSTRUCTOR MOET NOG KIJKEN HOE DIT OPGELOST KAN WORDEN
    {
        p = k;
        color = col;
        blockForm = new Color[p, p];
        if (maxrow == 0)
        {
            blockForm[0, a] = color;
            blockForm[1, b] = color;
            blockForm[c, d] = color;
            blockForm[e, f] = color;
        }
        else
        {
            for (int i = a; i < maxrow; i++)                     //Geeft aan welke delen bezet zijn en met welke kleur
                for (int j = 1; j < maxcolumn; j++)
                {
                    blockForm[i, j] = color;
                }
        }
        blockFormTexture = new Texture2D[p, p];
        for (int i = 0; i < p; i++)
            for (int j = 0; j < p; j++)
                blockFormTexture[i, j] = blocksprite;
        blockFormPosition = new Vector2(p * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
        timesturn = 0;
        timelimit = TimeSpan.FromSeconds(1);
        levelspeed = 1;
    }

    public void HandleInput(InputHelper inputHelper, int width, int height, Vector2 position, string block, Vector2 offset)
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
            RotateRight(width, height, position, block);
            int newwidth = this.height;
            int newheight = this.width;
            this.height = newheight;
            this.width = newwidth;
            this.position = CalculateBlockPosition(timesturn, this.width, block);
            this.offset = SetOffset(this.width, this.height, this.position, block, offset);
            if(TetrisGrid.CannotRotate(blockForm, blockFormPosition, this.position, this.width, this.height, p, color))
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
                        RotateRight(this.width, this.height, this.position, block);
                    }
                }
                int oldheight = this.width;
                int oldwidth = this.height;
                this.width = oldwidth;
                this.height = oldheight;
                this.position = CalculateBlockPosition(timesturn, this.width, block);
                this.offset = SetOffset(this.width, this.height, this.position, block, this.offset);
            }
            else if(TetrisGrid.CheckPlayField(p, blockFormPosition, blockForm, color, new Vector2(0,0)))
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
                        RotateRight(this.width, this.height, this.position, block);
                    }
                }
                int oldheight = this.width;
                int oldwidth = this.height;
                this.width = oldwidth;
                this.height = oldheight;
                this.position = CalculateBlockPosition(timesturn, this.width, block);
                this.offset = SetOffset(this.width, this.height, this.position, block, this.offset);
            }
        }
        else if (inputHelper.KeyPressed(Keys.Down))                     //Beweegt naar beneden
        {
            if (timesturn == 0)
            {
                this.position = position;
                this.width = width;
                this.height = height;
                this.offset = offset;
            }
            blockFormPosition += new Vector2(0, 1 * TetrisGrid.cellheight);
            timelimit = TimeSpan.FromSeconds(1);
            if (TetrisGrid.IsOutOfField(blockFormPosition, this.position, this.width, this.height, this.offset, p) || (TetrisGrid.CheckPlayField(p, blockFormPosition, blockForm, color, this.offset)))
            {
                blockFormPosition -= new Vector2(0, 1 * TetrisGrid.cellheight);
                TetrisGrid.FillOccupiedField(color, p, blockForm, blockFormPosition, this.offset);
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
                this.position = position;
                this.width = width;
                this.height = height;
                this.offset = offset;
            }
            blockFormPosition += new Vector2(-1 * TetrisGrid.cellwidth, 0);
            if (TetrisGrid.IsOutOfField(blockFormPosition, this.position, this.width, this.height, this.offset, p))
            {
                blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
            }
            if (TetrisGrid.CheckPlayField(p, blockFormPosition, blockForm, color, this.offset))
            {
                blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
                TetrisGrid.FillOccupiedField(color, p, blockForm, blockFormPosition, this.offset);
            }
        }
        else if (inputHelper.KeyPressed(Keys.Right))                    //Beweegt naar rechts
        {
            if (timesturn == 0)
            {
                this.position = position;
                this.width = width;
                this.height = height;
                this.offset = offset;
            }
            blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
            if (TetrisGrid.IsOutOfField(blockFormPosition, this.position, this.width, this.height, this.offset, p))
            {
                blockFormPosition -= new Vector2(1 * TetrisGrid.cellwidth, 0);
            }
            if (TetrisGrid.CheckPlayField(p, blockFormPosition, blockForm, color, this.offset))
            {
                blockFormPosition -= new Vector2(1 * TetrisGrid.cellwidth, 0);
                TetrisGrid.FillOccupiedField(color, p, blockForm, blockFormPosition, this.offset);
            }
        }
    }

    public void RotateRight(int width, int height, Vector2 position, string block)
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

    public Vector2 CalculateBlockPosition(int timesturn, int height, string block)  //Verandert de positie van het blokje in array
    {
        if (timesturn == 0)                                             
        {
            if (p == 3)
                return new Vector2(0, 0);
            else
                return new Vector2(1, 0);
        }
        else if (timesturn == 1)                                        
        {
            if (p == 3)
                return new Vector2(p - width / TetrisGrid.cellwidth, 0);
            else
                return new Vector2(p - width / TetrisGrid.cellwidth, 1);
        }
        else if (timesturn == 2)                                       
        {
            if (p == 3)
                return new Vector2(0, 1);
            else
                return new Vector2(1, 1);
        }
        else
        {                                                              
            if (p == 3)
                return new Vector2(0, 0);
            else
                return new Vector2(0, 1);

        }
    }

    public Vector2 SetOffset (int width, int height, Vector2 position, string block, Vector2 offset)
    {
        if (timesturn == 0 && (block == "block1" || block == "block4" || block == "block5"))    //Deze blokjes hoeven maar 2x te draaien
        {
            return new Vector2(offset.Y, offset.X);
        }
        else
        {
            return new Vector2(p - width / TetrisGrid.cellwidth - position.X, p - height / TetrisGrid.cellheight - position.Y);
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
            if (TetrisGrid.IsOutOfField(blockFormPosition, this.position, this.width, this.height, this.offset, p) || (TetrisGrid.CheckPlayField(p, blockFormPosition, blockForm, color, this.offset)))
            {
                blockFormPosition -= new Vector2(0, 1 * TetrisGrid.cellheight);
                TetrisGrid.FillOccupiedField(color, p, blockForm, blockFormPosition, this.offset);
            }
            for (int i = 0; i < 20; i++)
                if (TetrisGrid.RowFull(i))
                {
                    TetrisGrid.ClearRow(i);
                    TetrisGrid.MoveRows(i);
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
}