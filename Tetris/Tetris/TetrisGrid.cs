using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TetrisGrid
{
    Texture2D gridBlock;
    Vector2 position;
    Texture2D[,] playField; //het speelveld
    Color[,] occupiedField;  //houdt bij welke plekken bezet zijn (Color.White is onbezet, de rest is bezet)

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

    public bool CheckPlayField()
    {
        //Controleert of de rij onder tetrisblokje bezet is of niet en of onderste rij blokje erin past, geeft waarde false terug als het niet past en true als het wel past
        for (int i = blockPosition.X; i <  block.Width; i+= gridBlock.Width)    //Gaat alle blokken van het speelveld af die onder het tetrisblokje zitten
        {
            int x = i;  //x-coördinaat van een blok van het speelveld onder het tetrisblokje
            if (occupiedField[blockPosition.Y + block.Height, x] != Color.White) //Als rij onder blokje op de plek bezet is
            {
                if (blockForm[blockPosition.Y + block.Height - gridBlock.Height, x] == false) //Als onderste rij van het tetrisblokje op de plek boven de bezette plek onbezet is, false is hier onbezet
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
            if(i == block.Width - gridBlock.Width)    //Als aan het einde van de for-loop nog steeds elke plek past
            {
                return true;   //Het tetristblokje past en kan verder naar beneden bewegen
            }
        }
        //BLOCKPOSITION (BESTAAT NOG NIET) = IS DE LINKSBOVEN X,Y COORDINAAT VAN BLOCK
        //BLOCKFORM (BESTAAT NOG NIET) = DE ARRAY DIE BIJHOUDT HOE HET TETRISBLOKJE GEDRAAIT IS EN WAT DE VORM IS EN DUS WAT IE BEZET HOUDT
        //BLOCK (BESTAAT NOG NIET) = HET BLOK ZELF DAT IN DE ARRAY (BLOCKFORM) ZIT (BLOCK VULT NIET DE HELE ARRAY OP, HOUDT NIET DE HELE BLOCKFORM BEZET DUS VANDAAR DAT HIER EEN APARTE VARIABELE VOOR GEBRUIKT MOET WORDEN)
    }

    public void FillOccupiedField (Color col, Vector2 coör)
    {
        //Vult de occupiedFields als iets bezet moet zijn op het speelveld
        Color color = col;
        int x = (int)coör.X;
        int y = (int)coör.Y;
        if (occupiedField[y, x] != Color.White) //Bescherming zodat je niet iets kan vullen met een kleur terwijl de plek al gevuld is
            return;
        if (color == Color.White) //Bescherming: deze methode is niet bedoeld om de occupiedField weer "leeg" te maken
            return;
        occupiedField[y, x] = color;
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
                spriteBatch.Draw(playField[y, x], new Vector2(x * gridBlock.Width, y * gridBlock.Height), Color.White);
            }
        }
        
    }
}

