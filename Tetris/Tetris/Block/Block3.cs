using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block3 : TetrisBlock
{
    Vector2 blockPosition;           //Positie van blockFormTexture en positie van blokje in blockFormTexture
    int blockheight, blockwidth;                                    //Hoogte en breedte van het blokje in blockFormTexture
    
    public Block3(Color color, Texture2D sprite)
        : base(color, sprite, 0, 0, 2, 1, 1, 2, 1, 3)
    {
        blockwidth = 3 * TetrisGrid.cellwidth;
        blockheight = 2 * TetrisGrid.cellheight;
        blockPosition = new Vector2(1, 0); ;
    }

    public void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper, blockwidth, blockheight, blockPosition, "block3");
    }
}