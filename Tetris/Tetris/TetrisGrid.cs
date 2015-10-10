using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TetrisGrid
{
    Texture2D[,] grid;                          //Het speelveld
    static Color[,] occupied;                   //Houdt bij welke plekken bezet zijn; Color.White is onbezet
    Texture2D gridblock;                        //Het blokje waar het speelveld uit bestaat
    Vector2 position;                           //De positie van het grid
    public static int cellwidth, cellheight;    //De afmetingen van één cel in grid

    public TetrisGrid(Texture2D b)
    {
        gridblock = b;
        position = Vector2.Zero;
        cellwidth = gridblock.Width;
        cellheight = gridblock.Height;

        grid = new Texture2D[20, 12];
        for (int i = 0; i < 20; i++)            //Vult het grid met de bloksprite (gridblock)
            for (int j = 0; j < 12; j++)
                grid[i, j] = gridblock;

        occupied = new Color[20,12];
        for (int i = 0; i < 20; i++)            //Zet elke plek in het speelveld op onbezet
            for (int j = 0; j < 12; j++)
                occupied[i, j] = Color.White;
        this.Clear();
    }

    //Controleert of een blokje in de nieuwe positie (deels) uit het speelveld is
    public static bool IsOutOfField(Vector2 blockFormPosition, Vector2 blockPosition, Vector2 offset, int p)
    {
        return ((blockFormPosition.X + blockPosition.X * cellwidth < 0) ||                      //Kijkt of block aan de linkerkant eruit is
            (blockFormPosition.X > 12 * cellwidth - p * cellwidth + offset.X * cellwidth) ||    //Kijkt of block aan de rechterkant eruit is
            (blockFormPosition.Y > 20 * cellheight - p * cellwidth + offset.Y * cellheight));   //Kijkt of block aan de onderkant eruit is
    }

    //Controleert of een blokje geroteerd had mogen worden, true staat hier voor dat het niet had gemogen.
    public static bool CannotRotate(Vector2 blockFormPosition, Vector2 blockPosition, int blockwidth, int blockheight)
    {
        return ((blockPosition.X + blockFormPosition.X < 0) ||                                  //Kijkt of block aan de linkerkant eruit is 
                (blockPosition.X + blockwidth + blockFormPosition.X > 12 * cellwidth) ||        //Kijkt of block aan de rechterkant eruit is
                (blockPosition.Y + blockFormPosition.Y < 0) ||                                  //Kijkt of block aan de bovenkant eruit is
                (blockPosition.Y + blockheight + blockFormPosition.Y > 20 * cellheight));       //Kijkt of block aan de onder kant eruit is
    }

    //Controleert of een blokje verplaatst had mogen worden, true staat hier voor dat het niet had gemogen.
    public static bool CheckPlayField (int p, Vector2 blockFormPosition, Color[,] blockForm, Color color)
    {
        for (int i = 0; i< p; i++)
            for (int j = 0; j < p; j++)         //Gaat de rijen en kolommen af
            {
                if (blockForm[i, j] == color)   //Kijkt of de plek in blockForm bezet is en daarna of die plek in het speelveld ook bezet is, geeft dan true terug
                {
                    if ((occupied[i + ((int)blockFormPosition.Y / cellheight), j + ((int)blockFormPosition.X / cellwidth)] != Color.White))
                    {
                        return true;
                    }
                }
                if((i == p - 1) && (j == p - 1))    //Als na elke plek afgegaan te zijn, nergens twee plekken overlappen, mocht het blokje verplaatst worden
                {
                    return false;
                }
            }
        return true;
    }

    //Zet een plaats op het speelveld op bezet
    public static void FillOccupiedField(Color color, int p, Color[,] blockForm, Vector2 blockFormPosition)
    {
        for (int i = 0; i < p; i++)
        {
            for (int j = 0; j < p; j++)     //Gaat de rijen en kolommen af
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
        for (int i = row; i >= 0; i--)              //Kopieert de rij van onder naar boven
            for (int j = 0; j < 12; j++)
                occupied[i + 1, j] = occupied[i, j];
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
                s.Draw(grid[i, j], new Vector2(j * cellwidth, i * cellheight), occupied[i,j]);
    }
}
