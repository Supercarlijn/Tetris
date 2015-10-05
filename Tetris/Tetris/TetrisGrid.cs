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
        
    //CHECKPLAYFIELD IS NOG NIET AANGEPAST AAN MIJN NIEUWE CODE VERSIE DUS ER STAAN VARIABELEN IN DIE NIET MEER BESTAAN

    /*public static bool CheckPlayField(TetrisBlock block)    //parameter block is het blokje waarvan de omgeving gecontroleerd moet worden
    {
        //Controleert of de omgeving van tetrisblokje bezet is of niet en of onderste rij blokje erin past, geeft waarde false terug als het niet past en true als het wel past
        //WERKT NOG NIET ALS BLOCKFORM GEROTEERD IS
        for (int i = (int)block.blockPosition.X; i < block.blockForm.GetLength(1) + (int)block.blockPosition.X; i ++)    //Gaat alle blokken van het speelveld af die onder het tetrisblokje zitten
        {
            int x = i;  //x-coördinaat van een blok van het speelveld onder het tetrisblokje
            if (occupiedField[(int)block.blockPosition.Y + block.blockForm.GetLength(0), x] != Color.White) //Als rij onder blokje op de plek bezet is
            {
                if (block.blockForm[(int)block.blockPosition.Y - (int)block.blockFormPosition.Y + block.blockForm.GetLength(0) - 1, x] == false) //Als onderste rij van het tetrisblokje op de plek boven de bezette plek onbezet is, false is hier onbezet
                {
                }
                else
                {
                    return false;    //Plek is bezet en het tetrisblokje kan hierdoor niet verder naar beneden
                }
            }
            else    //Als rij onder tetrisblokje op de plek onbezet is
            {
            }
            if(i == block.blockForm.GetLength(1) + (int)block.blockPosition.X - 1)    //Als aan het einde van de for-loop nog steeds elke plek past
            {
                return true;   //Het tetristblokje past en kan verder naar beneden bewegen
            }
        }
        return false;   //als de for-loop niet kan, is resultaat false
        //MOET NOG CONTROLE AAN DE ZIJKANTEN VAN TETRISBLOKJE TOEVOEGEN
    }*/

    //NOG AANGEPAST WORDEN AAN NIEUWE VERSIE VAN MIJN CODE
    public static void FillOccupiedField(Color col, int maxcolumn, int maxrow, Vector2 blockPosition)
    {
        //Vult de occupiedField als iets bezet moet zijn op het speelveld
        Color color = col;
        /*if (occupiedField[y, x] != Color.White) //Bescherming zodat je niet iets kan vullen met een kleur terwijl de plek al gevuld is
            return;*/
        if (color == Color.White) //Bescherming: deze methode is niet bedoeld om de occupiedField weer "leeg" te maken
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
    }

    //NOG AANGEPAST WORDEN AAN NIEUWE VERSIE VAN MIJN CODE
    public static void ClearOccupiedField(int column, int row)
    {
        int j = column;
        int i = row;
        occupied[i, j] = Color.White;
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
