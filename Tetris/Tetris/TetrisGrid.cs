using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TetrisGrid
{
    Texture2D[,] grid;
    Color[,] occupied;                          //Houdt bij welke plekken bezet zijn; Color.White is onbezet
    Texture2D gridblock;
    Vector2 position;                           //De positie van het grid
    public static int cellwidth, cellheight;                  //De afmetingen van één cel in grid

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

    public static bool IsOutOfField(Vector2 blockFormPosition, Vector2 blockPosition, int blockheight, int blockwidth) //werkt nog niet bij block 3
    {
        //PROBLEEM: HIER PAKT HIJ DE OUDE BLOCKWIDTH, BLOCKHEIGHT EN BLOCKPOSITION NIET DEGENE NA ROTATIE, HIJ PAKT WEL NIEUWE BLOCKFORMPOSITION
        //Console.WriteLine(blockwidth / TetrisGrid.cellwidth);
        return ((blockFormPosition.X < -blockPosition.X * cellwidth) ||                                 //Kijkt of block aan de linkerkant eruit is
            (blockFormPosition.X > 11 * cellwidth - blockwidth + blockPosition.X) ||                    //Kijkt of block aan de rechterkant eruit is
            (blockFormPosition.Y > 20 * cellheight - (blockheight + blockPosition.Y)));                 //Kijkt of block aan de onder kant eruit is
    }

    /*public static bool CannotRotate()
    {
        return ;
    }*/

    //NOG AANGEPAST WORDEN AAN NIEUWE VERSIE VAN MIJN CODE
    /*public static void FillOccupiedField(Color col, int maxcolumn, int maxrow, Vector2 blockPosition)
    {
        //Vult de occupiedField als iets bezet moet zijn op het speelveld
        Color color = col;
        /*if (occupiedField[y, x] != Color.White) //Bescherming zodat je niet iets kan vullen met een kleur terwijl de plek al gevuld is
            return;*/
        /*if (color == Color.White) //Bescherming: deze methode is niet bedoeld om de occupiedField weer "leeg" te maken
            return;
        for (int i = (int)blockPosition.X; i < maxcolumn; i++ )
        {
            for (int j = (int)blockPosition.Y; j < maxrow; j++)
            {
                int y = p;
                occupied[i, j] = color;
                //Console.WriteLine(y);
                Console.WriteLine(x);
            }
        }
    }*/

    //NOG AANGEPAST WORDEN AAN NIEUWE VERSIE VAN MIJN CODE
    /*public static void ClearOccupiedField(int column, int row)
    {
        int j = column;
        int i = row;
        occupied[i, j] = Color.White;
    }*/

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
