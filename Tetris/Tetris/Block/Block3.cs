using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block3 : TetrisBlock
{
    Color[,] oldblockForm;
    
    public Block3(Texture2D sprite)
        : base("block3", sprite)
    {
        base.color = Color.Green;
        base.blockForm = new Color[4, 4];
        blockForm[0, 2] = color;
        blockForm[1, 1] = color;
        blockForm[1, 2] = color;
        blockForm[1, 3] = color;
        oldblockForm = new Color[4, 4];
        oldblockForm[0, 2] = color;
        oldblockForm[1, 1] = color;
        oldblockForm[1, 2] = color;
        oldblockForm[1, 3] = color;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }
}