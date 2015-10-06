using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block2 : TetrisBlock
{
    Vector2 blockPosition;           //Positie van blockFormTexture en positie van blokje in blockFormTexture
    int blockheight, blockwidth;                                    //Hoogte en breedte van het blokje in blockFormTexture

    public Block2(Color color, Texture2D sprite)
        : base(color, sprite, 3, 3, 1, 0, 0, 0, 0, 0)
    {
        blockwidth = 2 * TetrisGrid.cellwidth;
        blockheight = 2 * TetrisGrid.cellheight;
        blockPosition = new Vector2(1, 1);
    }

    public void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper, blockwidth, blockheight, blockPosition, "block2");
    }
}