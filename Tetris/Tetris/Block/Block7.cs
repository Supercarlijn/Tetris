using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block7 : TetrisBlock
{
    public Block7(Texture2D sprite)
        : base("block7", sprite)
    {
        base.color = Color.DeepPink;
        base.blockForm = new Color[4, 4];
        base.currentBlockForm = new Color[4, 4];
        base.blockForm[0, 1] = color;
        base.blockForm[1, 1] = color;
        base.blockForm[2, 1] = color;
        base.blockForm[2, 0] = color;
        base.currentBlockForm = base.blockForm;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }


}