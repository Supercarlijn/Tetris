using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block2 : TetrisBlock
{
    public Block2(Texture2D sprite)
        : base("block2", sprite)
    {
        base.color = Color.Yellow;
        base.p = 4;
        base.blockForm = new Color[4, 4];
        base.currentBlockForm = new Color[4, 4];
        for (int i = 1; i < 3; i++)         //Geeft aan welke delen bezet zijn en met welke kleur
        {
            for (int j = 1; j < 3; j++)
            {
                base.blockForm[i, j] = base.color;
            }
        }
        base.currentBlockForm = base.blockForm;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }
    

}