using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block3 : TetrisBlock
{
    public Block3(Texture2D sprite)
        : base("block3", sprite)
    {
        base.color = Color.Green;
        base.p = 3;
        base.blockForm = new Color[4, 4];
        base.blockForm[0, 1] = color;
        base.blockForm[1, 0] = color;
        base.blockForm[1, 1] = color;
        base.blockForm[1, 2] = color;
        base.currentBlockForm = new Color[4, 4];
        base.currentBlockForm = base.blockForm;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }


}