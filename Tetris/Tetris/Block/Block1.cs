using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

class Block1 : TetrisBlock
{
    public Block1(Texture2D sprite)
        : base("block1", sprite)
    {
        base.color = Color.Red;
        base.p = 4;
        base.blockForm = new Color[4, 4];
        base.currentBlockForm = new Color[4, 4];
        for (int i = 0; i < 4; i++)         //Geeft aan welke delen bezet zijn en met welke kleur
        {
                base.blockForm[i, 1] = base.color;
        }
        base.currentBlockForm = base.blockForm;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }


}