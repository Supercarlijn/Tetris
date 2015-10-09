using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block1 : TetrisBlock
{
    Vector2 blockPosition;           //Positie van blockFormTexture en positie van blokje in blockFormTexture
    int blockheight, blockwidth;     //Hoogte en breedte van het blokje in blockFormTexture

    public Block1(Color color, Texture2D sprite)
        : base(color, sprite, 4, 2, 0, 0, 0, 0, 0, 0, 4)
    {
        blockwidth = TetrisGrid.cellwidth;
        blockheight = 4 * TetrisGrid.cellheight;
        blockPosition = new Vector2(1, 0);
    }
    
    public void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper, blockwidth, blockheight, blockPosition, "block1", new Vector2(2,0));
    }
}