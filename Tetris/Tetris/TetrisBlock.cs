using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class TetrisBlock
{
    protected Color[,] blockForm, currentBlockForm;         //Houdt bij wat de vorm is van een blok
    protected Vector2 blockFormPosition;                    //De positie van het blokje in het speelveld
    protected int p;                                        //p = de lengte van het "grid" dat gedraaid moet worden
    public bool newBlock;                                   //Geeft aan of er een nieuw blokje geplaatst moet worden bovenaan het scherm
    protected Color color;
    TimeSpan timelimit;                                     //De tijdlimiet van hoe lang een blokje stil mag blijven staan
    Texture2D sprite;

    public TetrisBlock(Texture2D sprite)
    {
        this.sprite = sprite;
        blockForm = new Color[4, 4];
        currentBlockForm = new Color[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockForm[i, j] = Color.White;
        timelimit = TimeSpan.FromSeconds(0.9);
    }

    //Deze methode moet aangeroepen worden voor elk blokje bij het sluiten van options, int k is daar dan 4 (voor elk blokje)
    //Het berekent hoe het blokje gedraaid moet worden afhankelijk van de grootte van het blokje
    //De uitkomst van deze methode wordt gebruikt in de methodes RotateRight en RotateLeft
    public void CalculateArrayRotatingLength(int k)
    {
        for (int j = 0; j < k; j++)                //Controleert hier de onderste rij van het 4x4 grid
        {
            if (k == 1)
            {
                p = k;      //Beveiliging dat je niet een "grid" krijgt van 0, minimale lengte moet namelijk 1 zijn ivm errors
                break;
            }
            if (blockForm[k - 1, j] == color)     //Als hij op een plek bezet is
            {
                p = k;                            //dan is de gridlengte dus k
                break;                            //en zijn we klaar met de methode
            }
            if (j == k - 1)                         //Als de rij na het doorlopen nergens bezet was
                for (int i = 0; i < k; i++)         //Controleert hier de rechterste kolom van het 4x4 grid
                {
                    if (blockForm[i, k - 1] == color) //Als hij op een plek bezet is
                    {
                        p = k;                        //dan is de gridlengte dus k
                        break;                        //en zijn we klaar met de methode
                    }
                    if (i == k - 1)                   //Als de kolom na het doorlopen nergens bezet was
                    {
                        CalculateArrayRotatingLength(k - 1);  //Moet hij hetzelfde controleren, maar dan voor een 3x3 grid ipv 4x4, totdat hij op een plek komt waar er een blokje bezet is (dus gaat eventueel door tot k = 1)
                    }
                }
        }
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
            //Controleert of een blokje geplaatst moet worden
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

    //Roteert het blokje rechtsom
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

    //Roteert het blokje linksom
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

    //Controleert of er rijen vol zijn en verwijderd moeten worden, en beweegt daarna de rijen eentje naar beneden
    public void CheckRows()
    {
        for (int i = 0; i < 20; i++)
            if (TetrisGrid.RowFull(i))
            {
                TetrisGrid.ClearRow(i);
                TetrisGrid.MoveRows(i);
                GameWorld.Score += 10;
            }
    }

    public void Update(GameTime gameTime)
    {
        //Hier wordt gekeken of een blokje te lang stilgestaan heeft en beweegt dan het blokje een rij naar beneden
        double totalSeconds = gameTime.ElapsedGameTime.TotalSeconds * GameWorld.LevelSpeed;
        timelimit -= TimeSpan.FromSeconds(totalSeconds);
        if(timelimit.TotalSeconds <= 0)
        {
            blockFormPosition += new Vector2(0, 1 * TetrisGrid.cellheight);
            timelimit = TimeSpan.FromSeconds(0.9);
            //Controleert of het blokje geplaatst moet worden
            if (TetrisGrid.IsOutOfField(blockFormPosition, blockForm, color) || (TetrisGrid.CheckPlayField(blockFormPosition, blockForm, color)))
            {
                blockFormPosition -= new Vector2(0, 1 * TetrisGrid.cellheight);
                TetrisGrid.FillOccupiedField(color, blockForm, blockFormPosition);
                newBlock = true;
            }
        }
        CheckRows();
    }

    public void Draw(GameTime gameTime, SpriteBatch s, Vector2 blockFoPos)
    {
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                s.Draw(sprite, new Vector2(j * TetrisGrid.cellwidth, i * TetrisGrid.cellheight) + blockFormPosition + blockFoPos, blockForm[i, j]);
                //blabla + blockFormPosition; blabla is de afstand van de blokken IN blockFormTexture
            }
    }

    public virtual void Reset()
    {
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
}