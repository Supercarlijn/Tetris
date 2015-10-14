﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block6 : TetrisBlock
{
    int oldwidth, oldheight;
    Vector2 oldoffset;
    
    public Block6(Texture2D sprite)
        : base("block6")
    {
        base.width = 2 * TetrisGrid.cellwidth;
        base.height = 3 * TetrisGrid.cellheight;
        base.blockPosition = new Vector2(1, 0);
        oldwidth = base.width;
        oldheight = base.height;

        base.color = Color.DarkOrange;
        base.blockForm = new Color[4, 4];
        base.currentBlockForm = new Color[4, 4];
        blockForm[0, 1] = base.color;
        blockForm[1, 1] = base.color;
        blockForm[2, 1] = base.color;
        blockForm[2, 2] = base.color;
       base.oldBlockForm = new Color[4, 4];
       base.oldBlockForm = base.blockForm;
        base.currentBlockForm = base.blockForm;

        base.blockFormTexture = new Texture2D[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockFormTexture[i, j] = sprite;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
        base.offset = new Vector2(1, 1);
        oldoffset = base.offset;
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }


}