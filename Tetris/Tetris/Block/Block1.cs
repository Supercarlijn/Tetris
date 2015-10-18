using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

class Block1 : TetrisBlock
{
    public Block1(Texture2D sprite, ContentManager content)
        : base(sprite, content)
    {
        base.color = Color.Red;                             //De kleur van het blokje
        base.blockForm = new Color[4, 4];                   //Deze array houdt bij wat de vorm is van het blokje
        base.currentBlockForm = new Color[4, 4];            //Is de array dat bewerkt wordt in het optie menu
        for (int i = 0; i < 4; i++)                         //Geeft aan welke delen bezet zijn en met welke kleur
        {
                base.blockForm[i, 1] = base.color;
        }
        base.currentBlockForm = base.blockForm;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van het blokje
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
        base.blockForm = base.currentBlockForm;
    }
}