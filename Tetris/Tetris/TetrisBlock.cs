using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class TetrisBlock
{
    protected Color[,] blockForm;                       //Houdt bij wat de vorm is van een blok; Color.White is onbezet
    protected Texture2D[,] blockFormTexture;            //Array met de textureblokjes
    Vector2 blockFormPosition;
    int timesturn;

    public TetrisBlock(Color color, Texture2D blocksprite,
        int maxrow, int maxcolumn,
             int a, int b, int c, int d, int e, int f) //LANGE CONSTRUCTOR MOET NOG KIJKEN HOE DIT OPGELOST KAN WORDEN
    {
        blockForm = new Color[4, 4];
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
        blockFormTexture = new Texture2D[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockFormTexture[i, j] = blocksprite;
        blockFormPosition = new Vector2(5 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
        timesturn = 0;
    }

    public void HandleInput(InputHelper inputHelper, int wid, int heig, Vector2 position, string block)
    {
        int width = wid;
        int height = heig;
        if (inputHelper.KeyPressed(Keys.Up))                            //Roteert blokje
        {
            if (width == height)                                        //Controleren dat iemand niet het vierkante blokje probeert te draaien
                return;

            timesturn++;                                                //Telt hoe vaak blokje is gedraaid
            if (timesturn == 4)
                timesturn = 0;

            if (timesturn == 2 && (block == "block1" || block == "block4" || block == "block5"))    //Deze blokjes hoeven maar 2x te draaien
            {
                RotateLeft(width, height, position);
                timesturn = 0;
            }
            else
            {
                Color[,] result = new Color[4, 4];
                for (int i = 0; i < 4; i++)                                 //Maakt van de kolommen rijen en vice versa en draait de inhoud van de rijen om
                    for (int j = 0; j < 4; j++)
                    {
                        result[i, j] = blockForm[3 - j, i];
                    }
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        blockForm[i, j] = result[i, j];
            }

            if (timesturn == 0)                                             //Verandert de positie van het blokje in array
            {
                position = new Vector2(1, 0);
            }
            else if (timesturn == 1)
            {
                position = new Vector2(4 - height / TetrisGrid.cellheight, 1);
            }
            else if (timesturn == 2)
            {
                int a = 1;
                if (block == "block3")
                    a = 0;
                position = new Vector2(a, 4 - height / TetrisGrid.cellheight);
            }
            else
            {
                int a = 1;
                if (block == "block3")
                    a = 0;
                position = new Vector2(0, a);
            }
            int newwidth = height;
            int newheight = width;
            height = newheight;
            width = newwidth;
        }
        else if (inputHelper.KeyPressed(Keys.Down))                     //Beweegt naar beneden
        {
            blockFormPosition += new Vector2(0, 1 * TetrisGrid.cellheight);
            if (TetrisGrid.IsOutOfField(blockFormPosition, position, height, width))
            {
                blockFormPosition -= new Vector2(0, 1 * TetrisGrid.cellheight);
            }
        }
        else if (inputHelper.KeyPressed(Keys.Left))                     //Beweegt naar links
        {
            blockFormPosition += new Vector2(-1 * TetrisGrid.cellwidth, 0);
            if (TetrisGrid.IsOutOfField(blockFormPosition, position, height, width))
            {
                blockFormPosition -= new Vector2(-1 * TetrisGrid.cellwidth, 0);
            }
        }
        else if (inputHelper.KeyPressed(Keys.Right))                    //Beweegt naar rechts
        {
            blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
            if (TetrisGrid.IsOutOfField(blockFormPosition, position, height, width))
            {
                blockFormPosition -= new Vector2(1 * TetrisGrid.cellwidth, 0);
            }
        }
    }

    public void RotateLeft(int width, int height, Vector2 position)
    {
        Color[,] result = new Color[4, 4];
        for (int i = 0; i < 4; i++)                                 //Maakt van de kolommen rijen en vice versa en draait de inhoud van de rijen om
            for (int j = 0; j < 4; j++)
            {
                result[i, j] = blockForm[j, 3 - i];
            }
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockForm[i, j] = result[i, j];
    }

    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
            {
                s.Draw(blockFormTexture[i, j], new Vector2(j * TetrisGrid.cellwidth, i * TetrisGrid.cellheight) + blockFormPosition, blockForm[i, j]);
                //blabla + blockFormPosition; blabla is de afstand van de blokken IN blockFormTexture
            }
    }
}