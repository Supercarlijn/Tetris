using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

class Block1 : TetrisBlock
{
    int oldwidth, oldheight;
    Vector2 oldoffset;
    
    public Block1(Texture2D sprite)
        : base("block1")
    {
        base.width = TetrisGrid.cellwidth;
        base.height = 4 * TetrisGrid.cellheight;
        oldwidth = base.width;
        oldheight = base.height;

        base.blockPosition = new Vector2(1, 0);

        base.color = Color.Red;
        base.blockForm = new Color[4, 4];
        base.oldBlockForm = new Color[4, 4];
        base.currentBlockForm = new Color[4, 4];
        for (int i = 0; i < 4; i++)         //Geeft aan welke delen bezet zijn en met welke kleur
        {
                base.blockForm[i, 1] = base.color;
                base.oldBlockForm[i, 1] = base.color;
        }
        base.currentBlockForm = base.blockForm;

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
    }


}