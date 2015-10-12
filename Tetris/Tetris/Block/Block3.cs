using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block3 : TetrisBlock
{
    int blockheight, blockwidth;                                    //Hoogte en breedte van het blokje in blockFormTexture
    /*bool visible;*/
    
    public Block3(Color color, Texture2D sprite)
        : base(3, "block3")
    {
        blockwidth = 3 * TetrisGrid.cellwidth;
        blockheight = 2 * TetrisGrid.cellheight;
        base.blockPosition = new Vector2(0, 0);

        base.color = color;
        base.blockForm = new Color[3, 3];
        blockForm[0, 1] = color;
        blockForm[1, 0] = color;
        blockForm[1, 1] = color;
        blockForm[1, 2] = color;

        base.blockFormTexture = new Texture2D[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                blockFormTexture[i, j] = sprite;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
        base.offset = new Vector2(0, 1);
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

    /*public bool Visible
    {
        get { return visible; }
        set { visible = value; }
    }*/
}