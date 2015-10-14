using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block6 : TetrisBlock
{
    Color[,] oldblockForm;
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
        blockForm[0, 1] = color;
        blockForm[1, 1] = color;
        blockForm[2, 1] = color;
        blockForm[2, 2] = color;
        oldblockForm = new Color[4, 4];
        oldblockForm[0, 1] = color;
        oldblockForm[1, 1] = color;
        oldblockForm[2, 1] = color;
        oldblockForm[2, 2] = color;

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
        timesturn = 0;
        blockForm = oldblockForm;
        base.width = oldwidth;
        base.height = oldheight;
        base.offset = oldoffset;
    }
}