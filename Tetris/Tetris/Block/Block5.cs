using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block5 : TetrisBlock
{
    public Block5(Texture2D sprite)
        : base("block5", sprite)
    {
        base.color = Color.Purple;
        base.blockForm = new Color[4, 4];
        base.currentBlockForm = new Color[4, 4];
        blockForm[0, 1] = base.color;
        blockForm[1, 1] = base.color;
        blockForm[1, 2] = base.color;
        blockForm[2, 2] = base.color;
        base.currentBlockForm = base.blockForm;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }


}