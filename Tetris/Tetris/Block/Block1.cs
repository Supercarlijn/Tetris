using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block1 : TetrisBlock
{
    int blockheight, blockwidth;     //Hoogte en breedte van het blokje in blockFormTexture
    /*bool visible;*/

    public Block1(Color color, Texture2D sprite)
        : base("block1")
    {
        blockwidth = TetrisGrid.cellwidth;
        blockheight = 4 * TetrisGrid.cellheight;
        base.blockPosition = new Vector2(1, 0);

        base.color = color;
        base.blockForm = new Color[4, 4];
        for (int i = 0; i < 4; i++)         //Geeft aan welke delen bezet zijn en met welke kleur
        {
            for (int j = 1; j < 2; j++ )
                base.blockForm[i, j] = color;
        }

        base.blockFormTexture = new Texture2D[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockFormTexture[i, j] = sprite;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
        base.offset = new Vector2(2, 0);
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