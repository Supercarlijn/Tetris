using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block2 : TetrisBlock
{
    int blockheight, blockwidth;                                    //Hoogte en breedte van het blokje in blockFormTexture
    /*bool visible;*/

    public Block2(Color color, Texture2D sprite)
        : base(4, "block2")
    {
        blockwidth = 2 * TetrisGrid.cellwidth;
        blockheight = 2 * TetrisGrid.cellheight;
        base.blockPosition = new Vector2(1, 1);

        base.color = color;
        base.blockForm = new Color[4, 4];
        for (int i = 1; i < 3; i++)         //Geeft aan welke delen bezet zijn en met welke kleur
        {
            for (int j = 1; j < 3; j++)
                base.blockForm[i, j] = base.color;
        }

        base.blockFormTexture = new Texture2D[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockFormTexture[i, j] = sprite;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
        base.offset = new Vector2(1, 1);
        /*visible = false;*/
    }

    public void HandleInput(InputHelper inputHelper)
    {
        /*if (!Visible)
        {
            return;
        }*/
        base.HandleInput(inputHelper, blockwidth, blockheight);
    }

    public override void Reset()
    {
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
    }

    /*public bool Visible
    {
        get { return visible; }
        set { visible = value; }
    }*/
}