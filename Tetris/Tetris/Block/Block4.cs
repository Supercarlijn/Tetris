using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block4 : TetrisBlock
{
    public Block4(Texture2D sprite)
        : base("block4", sprite)
    {
        base.color = Color.Blue;
        base.p = 3;
        base.blockForm = new Color[4, 4];
        base.currentBlockForm = new Color[4, 4];
        base.blockForm[0, 1] = base.color;
        base.blockForm[1, 0] = base.color;
        base.blockForm[1, 1] = base.color;
        base.blockForm[2, 0] = base.color;
        base.currentBlockForm = base.blockForm;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }


}