using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block7 : TetrisBlock
{
    public Block7(Texture2D sprite)
        : base("block7", sprite)
    {
        base.color = Color.DeepPink;
        base.blockForm = new Color[4, 4];
        blockForm[0, 2] = color;
        blockForm[1, 2] = color;
        blockForm[2, 2] = color;
        blockForm[2, 1] = color;
        base.currentBlockForm = new Color[4, 4];
        blockForm[0, 2] = base.color;
        blockForm[1, 2] = base.color;
        blockForm[2, 2] = base.color;
        blockForm[2, 1] = base.color;
        base.currentBlockForm = base.blockForm;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }


}