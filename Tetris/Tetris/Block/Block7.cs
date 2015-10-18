using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

class Block7 : TetrisBlock
{
    public Block7(Texture2D sprite, ContentManager content)
        : base(sprite, content)
    {
        base.color = Color.DeepPink;                    //De kleur van het blokje
        base.blockForm = new Color[4, 4];               //Deze array houdt bij wat de vorm is van het blokje
        base.currentBlockForm = new Color[4, 4];        //Is de array dat bewerkt wordt in het optie menu
        base.blockForm[0, 1] = color;                   //Geeft aan welke delen bezet zijn en met welke kleur
        base.blockForm[1, 1] = color;
        base.blockForm[2, 1] = color;
        base.blockForm[2, 0] = color;
        base.currentBlockForm = base.blockForm;
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }
}