using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class TetrisBlock
{
    protected Color[,] blockForm;                       //Houdt bij wat de vorm is van een blok; Color.White is onbezet
    protected Texture2D[,] blockFormTexture;            //Array met de textureblokjes
    Vector2 blockFormPosition;                           //Positie van blockFormTexture

    public TetrisBlock(Color color, Texture2D blocksprite,
        int maxrow, int maxcolumn,
             int a, int b, int c, int d, int e, int f) //LANGE CONSTRUCTOR MOET NOG KIJKEN HOE DIT OPGELOST KAN WORDEN
    {
        blockForm = new Color[4, 4];
        if (maxrow == 0 && maxcolumn == 0)
        {
            blockForm[0, a] = color;
            blockForm[1, b] = color;
            blockForm[c, d] = color;
            blockForm[e, f] = color;
        }
        for (int i = 0; i < maxrow; i++)                     //Vult in eerste instantie hele array met onbezet
            for (int j = 1; j < maxcolumn; j++)
                blockForm[i, j] = Color.White;
        for (int i = 0; i < maxrow; i++)                     //Geeft aan welke delen bezet zijn en met welke kleur
            for (int j = 1; j < maxcolumn; j++)
            {
                blockForm[i, j] = color;
            }
        blockFormTexture = new Texture2D[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockFormTexture[i, j] = blocksprite;
        blockFormPosition = new Vector2(5 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public void HandleInput(InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Up))                            //Roteert blokje
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
        else if (inputHelper.KeyPressed(Keys.Down))                     //Beweegt naar beneden
        {
            blockFormPosition += new Vector2(0, 1 * TetrisGrid.cellheight);
        }
        else if (inputHelper.KeyPressed(Keys.Left))                     //Beweegt naar links
        {
            blockFormPosition += new Vector2(-1 * TetrisGrid.cellwidth, 0);
        }
        else if (inputHelper.KeyPressed(Keys.Right))                    //Beweegt naar rechts
        {
            blockFormPosition += new Vector2(1 * TetrisGrid.cellwidth, 0);
        }
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