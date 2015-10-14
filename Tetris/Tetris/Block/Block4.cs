using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block4 : TetrisBlock
{
    Color[,] oldblockForm;
    int oldwidth, oldheight;
    Vector2 oldoffset;
    
    public Block4(Texture2D sprite)
        : base("block4", sprite)
    {
        base.color = Color.Blue;
        base.blockForm = new Color[4, 4];
        blockForm[0, 2] = color;
        blockForm[1, 1] = color;
        blockForm[1, 2] = color;
        blockForm[2, 1] = color;
        oldblockForm = new Color[4, 4];
        oldblockForm = base.blockForm;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }
}