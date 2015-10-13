using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block3 : TetrisBlock
{
    int blockheight, blockwidth;                                    //Hoogte en breedte van het blokje in blockFormTexture
    /*bool visible;*/
    
    public Block3(Color color, Texture2D sprite)
        : base("block3")
    {
        blockwidth = 3 * TetrisGrid.cellwidth; //deze wordt aangepast in optie-menu
        blockheight = 2 * TetrisGrid.cellheight; //deze wordt aangepast in optie-menu
        base.blockPosition = new Vector2(1, 0); //deze wordt aangepast in optie-menu, dus dan moet je eventueel een nieuwe waarde toekennen. Deze is te berekenen met methode uit TetrisBlock

        base.color = color;
        base.blockForm = new Color[4, 4];
        blockForm[0, 2] = color;
        blockForm[1, 1] = color;
        blockForm[1, 2] = color;
        blockForm[1, 3] = color;

        base.blockFormTexture = new Texture2D[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockFormTexture[i, j] = sprite;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
        base.offset = new Vector2(0, 2); //deze wordt aangepast in optie-menu, dus dan moet je eventueel een nieuwe waarde toekennen. Deze is te berekenen met methode uit TetrisBlock
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