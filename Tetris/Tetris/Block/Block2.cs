using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

class Block2 : TetrisBlock
{
    public Block2(Texture2D sprite, ContentManager content)
        : base(sprite, content)
    {
        base.color = Color.Yellow;                      //De kleur van het blokje
        base.blockForm = new Color[4, 4];               //Deze array houdt bij wat de vorm is van het blokje
        base.currentBlockForm = new Color[4, 4];        //Is de array dat bewerkt wordt in het optie menu
        for (int i = 0; i < 2; i++)                     //Geeft aan welke delen bezet zijn en met welke kleur
        {
            for (int j = 0; j < 2; j++)
            {
                base.blockForm[i, j] = base.color;
            }
        }
        base.currentBlockForm = base.blockForm;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van het blokje
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }
}