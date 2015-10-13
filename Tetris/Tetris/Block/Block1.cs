using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

class Block1 : TetrisBlock
{
    Color[,] oldblockForm;
    int oldwidth, oldheight;
    Vector2 oldoffset;
    
    public Block1(Color color, Texture2D sprite)
        : base("block1")
    {
        base.width = TetrisGrid.cellwidth;
        base.height = 4 * TetrisGrid.cellheight;
        oldwidth = base.width;
        oldheight = base.height;

        base.blockPosition = new Vector2(1, 0);

        base.color = color;
        base.blockForm = new Color[4, 4];
        oldblockForm = new Color[4, 4];
        for (int i = 0; i < 4; i++)         //Geeft aan welke delen bezet zijn en met welke kleur
        {
            for (int j = 1; j < 2; j++)
            {
                base.blockForm[i, j] = color;
                oldblockForm[i, j] = color;
            }
        }

        base.blockFormTexture = new Texture2D[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockFormTexture[i, j] = sprite;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
        base.offset = new Vector2(2, 0);
        oldoffset = base.offset;
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
        timesturn = 0;
        blockForm = oldblockForm;
        base.width = oldwidth;
        base.height = oldheight;
        base.offset = oldoffset;
    }
}