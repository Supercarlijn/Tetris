using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TetrisGrid
{
    static Color[,] occupied;                   //Houdt bij welke plekken bezet zijn; Color.White is onbezet
    Texture2D gridblock;                        //Het blokje waar het speelveld uit bestaat
    Vector2 position;                           //De positie van het grid
    public static int cellwidth, cellheight;    //De afmetingen van één cel in grid
    static Rectangle field;

    public TetrisGrid(Texture2D b)
    {
        gridblock = b;
        position = Vector2.Zero;
        cellwidth = gridblock.Width;
        cellheight = gridblock.Height;

        occupied = new Color[20,12];
        for (int i = 0; i < 20; i++)            //Zet elke plek in het speelveld op onbezet
            for (int j = 0; j < 12; j++)
                occupied[i, j] = Color.White;
        
        field = new Rectangle(0, 0, 12 * cellwidth, 20 * cellheight);
        this.Clear();
    }

    //Controleert of een blokje in de nieuwe positie (deels) uit het speelveld is
    public static bool IsOutOfField(Vector2 blockFormPosition, Color[,] blockForm, Color color)
    {
        Vector2 pos;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (blockForm[i, j] == color)
                {
                    pos = new Vector2(j * cellwidth + blockFormPosition.X, i * cellheight + blockFormPosition.Y);
                    if (!field.Contains((int)pos.X, (int)pos.Y))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    //Controleert of een blokje verplaatst had mogen worden, true staat hier voor dat het niet had gemogen.
    public static bool CheckPlayField (Vector2 blockFormPosition, Color[,] blockForm, Color color)
    {
        for (int i = 0; i< 4; i++)
            for (int j = 0; j < 4; j++)         //Gaat de rijen en kolommen af
            {
                if (blockForm[i, j] == color)   //Kijkt of de plek in blockForm bezet is en daarna of die plek in het speelveld ook bezet is, geeft dan true terug
                {
                    if ((occupied[i + ((int)blockFormPosition.Y / cellheight), j + ((int)blockFormPosition.X / cellwidth)] != Color.White))
                    {
                        return true;
                    }
                }
                if((i == 3) && (j == 3))    //Als na elke plek afgegaan te zijn, nergens twee plekken overlappen, mocht het blokje verplaatst worden
                {
                    return false;
                }
            }
        return true;
    }

    //Zet een plaats op het speelveld op bezet
    public static void FillOccupiedField(Color color, Color[,] blockForm, Vector2 blockFormPosition)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)     //Gaat de rijen en kolommen af
            {
                if (blockForm[i, j] == color)   //Kijkt of de plek in blockForm bezet is en kent de kleur van deze plek toe aan de plek in het speelveld
                {
                    occupied[i + ((int)blockFormPosition.Y / cellheight), j + ((int)blockFormPosition.X / cellwidth)] = color;
                }
            }
        }
    }

    //Controleert of een rij vol is en verwijdert moet worden
    public static bool RowFull(int i)
    {
        for (int j = 0; j < 12; j++)    //Gaat alle kolommen van de rij af
        {
            if (occupied[i, j] != Color.White)  //Kijkt of die plek bezet is
            {
                if (j == 11)                    //Als alle plekken bezet zijn, geeft methode true terug
                    return true;
                continue;                       //Gaat door naar volgende j om te controleren
            }
            break;                              //Als een plek niet bezet is, wordt de loop gestopt en geeft methode false terug
        }
        return false;
    }

    //Verwijdert de rij
    public static void ClearRow(int i)
    {
        for (int j = 0; j < 12; j++)    //Gaat alle kolommen van de rij af
        {
            occupied[i, j] = Color.White;   //Zet de plek in het speelveld op onbezet
        }
    }

    //Verplaatst alle rijen vanaf row een plaats naar beneden
    public static void MoveRows(int row)
    {
        for (int i = row - 1; i >= 0; i--)              //Kopieert de rij van onder naar boven
            for (int j = 0; j < 12; j++)
                occupied[i+1, j] = occupied[i, j];
    }

    public int Width
    {
        get { return 12; }
    }

    public int Height
    {
        get { return 20; }
    }

    public void Clear()
    {
    }

    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        //Tekent het speelveld
        for (int i = 0; i < 20; i++)
            for (int j = 0; j < 12; j++)
                s.Draw(gridblock, new Vector2(j * cellwidth, i * cellheight), occupied[i,j]);
    }
}
