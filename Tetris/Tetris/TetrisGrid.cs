using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TetrisGrid
{
    Texture2D[,] grid;
    static Color[,] occupied;                          //Houdt bij welke plekken bezet zijn; Color.White is onbezet
    Texture2D gridblock;
    Vector2 position;                           //De positie van het grid
    public static int cellwidth, cellheight;                  //De afmetingen van één cel in grid
    TetrisBlock tetrisBlock;

    public TetrisGrid(Texture2D b)
    {
        gridblock = b;
        position = Vector2.Zero;
        grid = new Texture2D[20, 12];           //[rows, colums] ofwel [y,x]
        cellwidth = gridblock.Width;
        cellheight = gridblock.Height;
        for (int i = 0; i < 20; i++)            //Vult het grid met de bloksprite
            for (int j = 0; j < 12; j++)
                grid[i, j] = gridblock;
        occupied = new Color[20,12];
        for (int i = 0; i < 20; i++)            //Maakt elke plek in array onbezet
            for (int j = 0; j < 12; j++)
                occupied[i, j] = Color.White;
        this.Clear();
    }

    public static bool IsOutOfField(Vector2 blockFormPosition, Vector2 blockPosition, int blockwidth, int blockheight, Vector2 offset, int p)
    {
        return ((blockFormPosition.X + blockPosition.X * cellwidth < 0) ||                                 //Kijkt of block aan de linkerkant eruit is
            (blockFormPosition.X > 12 * cellwidth - p * cellwidth + offset.X * cellwidth) ||            //Kijkt of block aan de rechterkant eruit is
            (blockFormPosition.Y > 20 * cellheight - p * cellwidth + offset.Y * cellheight));           //Kijkt of block aan de onder kant eruit is
    }

    public static bool CannotRotate(Color[,] blockForm, Vector2 blockFormPosition, Vector2 blockPosition, int blockwidth, int blockheight, int p, Color color)
    {
        return ((blockPosition.X + blockFormPosition.X < 0) ||
                (blockPosition.X + blockwidth + blockFormPosition.X > 12 * cellwidth) ||
                (blockPosition.Y + blockFormPosition.Y < 0) ||
                (blockPosition.Y + blockheight + blockFormPosition.Y > 20 * cellheight));
    }

    public static bool CheckPlayField (int p, Vector2 blockFormPosition, Color[,] blockForm, Color color, Vector2 offset)    //Controleert of een blokje verplaatst had mogen worden
    {
        for (int i = 0; i< p; i++)
            for (int j = 0; j < p; j++)
            {
                if (blockForm[i, j] == color)
                {
                    if ((occupied[i + ((int)blockFormPosition.Y / cellheight), j + ((int)blockFormPosition.X / cellwidth)] != Color.White))
                    {
                        return true;
                    }
                }
                if((i == p - 1) && (j == p - 1))
                {
                    return false;
                }
            }
        return true;
    }

    public static void FillOccupiedField(Color color, int p, Color[,] blockForm, Vector2 blockFormPosition, Vector2 offset)        //Vult de occupiedField als iets bezet moet zijn op het speelveld
    {
        for (int i = 0; i < p; i++)
        {
            for (int j = 0; j < p; j++)
            {
                if (blockForm[i, j] == color)
                {
                    occupied[i + ((int)blockFormPosition.Y / cellheight), j + ((int)blockFormPosition.X / cellwidth)] = color;
                }
            }
        }
    }

    public static bool RowFull(int i)               //Controleert of een rij vol is en verwijdert moet worden
    {
        for (int j = 0; j < 12; j++)
        {
            if (occupied[i, j] != Color.White)
            {
                if (j == 11)
                return true;
                continue;
            }
            break;
        }
        return false;
    }

    public static void ClearRow(int i)              //Verwijdert de rij
    {
        for (int j = 0; j < 12; j++)
        {
            occupied[i, j] = Color.White;
        }
    }

    public static void MoveRows(int row)               //Verplaatst alle rijen vanaf row een plaats naar beneden
    {
        for (int i = row; i >= 0; i--)
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
        for (int i = 0; i < 20; i++)
            for (int j = 0; j < 12; j++)
                s.Draw(grid[i, j], new Vector2(j * cellwidth, i * cellheight), occupied[i,j]);
    }
}
