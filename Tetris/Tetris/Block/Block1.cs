using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

class Block1 : TetrisBlock
{
    Color[,] oldblockForm;
    
    public Block1(Texture2D sprite)
        : base("block1", sprite)
    {
        base.color = Color.Red;
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
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }
}