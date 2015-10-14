using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block5 : TetrisBlock
{
    Color[,] oldblockForm;
    
    public Block5(Texture2D sprite)
        : base("block5", sprite)
    {
        base.color = Color.Purple;
        base.blockForm = new Color[4, 4];
        blockForm[0, 1] = color;
        blockForm[1, 1] = color;
        blockForm[1, 2] = color;
        blockForm[2, 2] = color;
        oldblockForm = new Color[4, 4];
        oldblockForm[0, 1] = color;
        oldblockForm[1, 1] = color;
        oldblockForm[1, 2] = color;
        oldblockForm[2, 2] = color;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }
}