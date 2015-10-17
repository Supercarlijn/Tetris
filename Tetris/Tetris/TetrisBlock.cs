using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class TetrisBlock
{
    protected Color[,] blockForm, currentBlockForm;                       //Houdt bij wat de vorm is van een blok
    protected Vector2 blockFormPosition;
    protected int timesturn, p; //p = de lengte van het "grid" dat gedraaid moet worden
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
        blockForm = new Color[4, 4];
        currentBlockForm = new Color[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockForm[i, j] = Color.White;
    }

    public void HandleInput(InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Up))                            //Roteert blokje
        {
            RotateRight();

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

            Color[,] result = new Color[p, p];
            for (int i = 0; i < p; i++)                                 //Maakt van de kolommen rijen en vice versa en draait de inhoud van de rijen om
                for (int j = 0; j < p; j++)
                {
                    result[i, j] = blockForm[p - j - 1, i];
                }
            for (int i = 0; i < p; i++)
                for (int j = 0; j < p; j++)
                    blockForm[i, j] = result[i, j];
            if ((TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color) || TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color)))
            {
                if (!(TetrisGrid.IsOutOfField(blockFormPosition + new Vector2(sprite.Width, 0), blockForm, color) || TetrisGrid.CheckPlayField(blockFormPosition + new Vector2(sprite.Width, 0), blockForm, color)))
                    blockFormPosition += new Vector2(sprite.Width, 0);
                else if (!(TetrisGrid.IsOutOfField(blockFormPosition - new Vector2(sprite.Width, 0), blockForm, color) || TetrisGrid.CheckPlayField(blockFormPosition - new Vector2(sprite.Width, 0), blockForm, color)))
                    blockFormPosition -= new Vector2(sprite.Width, 0);
                else RotateLeft();
            }
    }
    
    public void CleanRotateRight()
    {

        Color[,] result = new Color[ArrayRotatingLength, ArrayRotatingLength];
        for (int i = 0; i < ArrayRotatingLength; i++)                                 //Maakt van de kolommen rijen en vice versa en draait de inhoud van de rijen om
            for (int j = 0; j < ArrayRotatingLength; j++)
            {
                result[i, j] = blockForm[p - j - 1, i];
            }
        for (int i = 0; i < ArrayRotatingLength; i++)
            for (int j = 0; j < ArrayRotatingLength; j++)
                blockForm[i, j] = result[i, j];
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
        if (TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color))
            RotateRight();
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

    public Color Color
    {
        get { return color; }
        set { color = value; }
    }

    public int ArrayRotatingLength
    {
        get { return p; }
        set { p = value; }
    }
}