using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block2 : TetrisBlock
{
    Color[,] oldblockForm;
    int oldwidth, oldheight;
    Vector2 oldoffset;
    
    public Block2(Texture2D sprite)
        : base("block2")
    {
        base.width = 2 * TetrisGrid.cellwidth;
        base.height = 2 * TetrisGrid.cellheight;
        base.blockPosition = new Vector2(1, 1);
        oldwidth = base.width;
        oldheight = base.height;

        base.color = Color.Yellow;
        base.blockForm = new Color[4, 4];
        oldblockForm = new Color[4, 4];
        for (int i = 1; i < 3; i++)         //Geeft aan welke delen bezet zijn en met welke kleur
        {
            for (int j = 1; j < 3; j++)
            {
                base.blockForm[i, j] = base.color;
                oldblockForm = new Color[4, 4];
            }
        }

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