using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block4 : TetrisBlock
{
    int blockheight, blockwidth;                                    //Hoogte en breedte van het blokje in blockFormTexture
    /*bool visible;*/

    public Block4(Color color, Texture2D sprite)
        : base("block4")
    {
        blockwidth = 2 * TetrisGrid.cellwidth;
        blockheight = 3 * TetrisGrid.cellheight;
        base.blockPosition = new Vector2(1, 0);

        base.color = color;
        base.blockForm = new Color[4, 4];
        blockForm[0, 2] = color;
        blockForm[1, 1] = color;
        blockForm[1, 2] = color;
        blockForm[2, 1] = color;

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