using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TetrisGrid
{
    Texture2D gridBlock;
    Vector2 position;
    Texture2D[,] playField; //het speelveld
    public static Color[,] occupiedField;  //houdt bij welke plekken bezet zijn (Color.White is onbezet, de rest is bezet)

    public TetrisGrid(Texture2D b)
    {
        playField = new Texture2D[20,12];
        occupiedField = new Color[20,12];
        gridBlock = b;
        position = Vector2.Zero;
        this.Clear();
        for (int x = 0; x < 12; x++)    //vullen van playField
        {
            for (int y = 0; y < 20; y++)
            {
                playField[y, x] = gridBlock;
            }
        }
        for (int x = 0; x <12; x++) //vullen van occupiedField
        {
            for (int y = 0; y < 20; y++)
            {
                occupiedField[y, x] = Color.White;
            }
        }
    }

    public static bool CheckPlayField(TetrisBlock block)    //parameter block is het blokje waarvan de omgeving gecontroleerd moet worden
    {
        //Controleert of de omgeving van tetrisblokje bezet is of niet en of onderste rij blokje erin past, geeft waarde false terug als het niet past en true als het wel past
        //WERKT NOG NIET ALS BLOCKFORM GEROTEERD IS
        for (int i = (int)block.blockPosition.X; i < block.blockForm.GetLength(1) + (int)block.blockPosition.X; i ++)    //Gaat alle blokken van het speelveld af die onder het tetrisblokje zitten
        {
            int x = i;  //x-coördinaat van een blok van het speelveld onder het tetrisblokje
            if (occupiedField[(int)block.blockPosition.Y + block.blockForm.Length, x] != Color.White) //Als rij onder blokje op de plek bezet is
            {
                if (block.blockForm[(int)block.blockPosition.Y - (int)block.blockFormPosition.Y + block.blockForm.Length - 1, x] == false) //Als onderste rij van het tetrisblokje op de plek boven de bezette plek onbezet is, false is hier onbezet
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
    }

    public static void FillOccupiedField(Color col, int column, int row)
    {
        //Vult de occupiedField als iets bezet moet zijn op het speelveld
        Color color = col;
        int x = column;
        int y = row;
        if (occupiedField[y, x] != Color.White) //Bescherming zodat je niet iets kan vullen met een kleur terwijl de plek al gevuld is
            return;
        if (color == Color.White) //Bescherming: deze methode is niet bedoeld om de occupiedField weer "leeg" te maken
            return;
        occupiedField[y, x] = color;
    }

    public void ClearOccupiedField(int column, int row)
    {
        int x = column;
        int y = row;
        occupiedField[y, x] = Color.White;
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

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        for (int x = 0; x < 12; x++)    //tekenen van playfield
        {
            for (int y = 0; y < 20; y++)
            {
                spriteBatch.Draw(playField[y, x], new Vector2(x * gridBlock.Width, y * gridBlock.Height), occupiedField[y, x]);
            }
        }
        
    }
}

