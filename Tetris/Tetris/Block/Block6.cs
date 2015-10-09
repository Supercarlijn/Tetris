using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block6 : TetrisBlock
{
    Vector2 blockPosition;           //Positie van blockFormTexture en positie van blokje in blockFormTexture
    int blockheight, blockwidth;                                    //Hoogte en breedte van het blokje in blockFormTexture
    /*bool visible;*/

    public Block6(Color color, Texture2D sprite)
        : base(color, sprite, 0, 0, 1, 1, 2, 1, 2, 2, 4)
    {
        blockwidth = 2 * TetrisGrid.cellwidth;
        blockheight = 3 * TetrisGrid.cellheight;
        blockPosition = new Vector2(1, 0);
        /*visible = false;*/
    }

    public void HandleInput(InputHelper inputHelper)
    {
        /*if (!Visible)
        {
            return;
        }*/
        base.HandleInput(inputHelper, blockwidth, blockheight, blockPosition, "block6", new Vector2(1, 1));
    }

    /*public bool Visible
    {
        get { return visible; }
        set { visible = value; }
    }*/
}