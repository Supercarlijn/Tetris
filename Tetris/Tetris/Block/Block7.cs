using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block7 : TetrisBlock
{
    Color[,] oldblockForm;

    public Block7(Texture2D sprite)
        : base("block7", sprite)
    {
        base.color = Color.DeepPink;
        base.blockForm = new Color[4, 4];
        blockForm[0, 2] = color;
        blockForm[1, 2] = color;
        blockForm[2, 2] = color;
        blockForm[2, 1] = color;
        oldblockForm = new Color[4, 4];
        oldblockForm[0, 2] = color;
        oldblockForm[1, 2] = color;
        oldblockForm[2, 2] = color;
        oldblockForm[2, 1] = color;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }
}