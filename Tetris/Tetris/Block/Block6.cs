using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block6 : TetrisBlock
{
    public Block6(Texture2D sprite)
        : base("block6", sprite)
    {
        base.color = Color.DarkOrange;
        base.blockForm = new Color[4, 4];
        base.currentBlockForm = new Color[4, 4];
        base.blockForm[0, 1] = base.color;
        base.blockForm[1, 1] = base.color;
        base.blockForm[2, 1] = base.color;
        base.blockForm[2, 2] = base.color;
        base.currentBlockForm = base.blockForm;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }


}