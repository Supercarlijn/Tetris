using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block3 : TetrisBlock
{
    public Block3(Texture2D sprite)
        : base(sprite)
    {
        base.color = Color.Green;                       //De kleur van het blokje
        base.blockForm = new Color[4, 4];               //Deze array houdt bij wat de vorm is van het blokje
        base.currentBlockForm = new Color[4, 4];        //Is de array dat bewerkt wordt in het optie menu
        base.blockForm[0, 1] = color;                   //Geeft aan welke delen bezet zijn en met welke kleur
        base.blockForm[1, 0] = color;
        base.blockForm[1, 1] = color;
        base.blockForm[1, 2] = color;
        base.currentBlockForm[0, 1] = color;                   //Geeft aan welke delen bezet zijn en met welke kleur
        base.currentBlockForm[1, 0] = color;
        base.currentBlockForm[1, 1] = color;
        base.currentBlockForm[1, 2] = color;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van het blokje
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
        base.blockForm = base.currentBlockForm;
    }
}