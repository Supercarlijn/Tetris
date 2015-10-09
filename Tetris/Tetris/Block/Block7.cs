using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block7 : TetrisBlock
{
    Vector2 blockPosition;           //Positie van blockFormTexture en positie van blokje in blockFormTexture
    int blockheight, blockwidth;                                    //Hoogte en breedte van het blokje in blockFormTexture

    public Block7(Color color, Texture2D sprite)
        : base(color, sprite, 0, 0, 2, 2, 2, 2, 2, 1, 4)
    {
        blockwidth = 2 * TetrisGrid.cellwidth;
        blockheight = 3 * TetrisGrid.cellheight;
        blockPosition = new Vector2(1, 0);
    }

    public void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper, blockwidth, blockheight, blockPosition, "block7", new Vector2(1,1));
    }
}