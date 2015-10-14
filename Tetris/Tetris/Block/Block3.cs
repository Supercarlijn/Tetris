using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block3 : TetrisBlock
{
    Color[,] oldblockForm;
    int oldwidth, oldheight;
    Vector2 oldoffset;
    
    public Block3(Texture2D sprite)
        : base("block3")
    {
        base.width = 3 * TetrisGrid.cellwidth; //deze wordt aangepast in optie-menu
        base.height = 2 * TetrisGrid.cellheight; //deze wordt aangepast in optie-menu
        base.blockPosition = new Vector2(1, 0); //deze wordt aangepast in optie-menu, dus dan moet je eventueel een nieuwe waarde toekennen. Deze is te berekenen met methode uit TetrisBlock
        oldwidth = base.width;
        oldheight = base.height;

        base.color = Color.Green;
        base.blockForm = new Color[4, 4];
        blockForm[0, 2] = color;
        blockForm[1, 1] = color;
        blockForm[1, 2] = color;
        blockForm[1, 3] = color;
        oldblockForm = new Color[4, 4];
        oldblockForm[0, 2] = color;
        oldblockForm[1, 1] = color;
        oldblockForm[1, 2] = color;
        oldblockForm[1, 3] = color;

        base.blockFormTexture = new Texture2D[4, 4];
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                blockFormTexture[i, j] = sprite;
        base.blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);   //Startpositie van blockFormTexture
        base.offset = new Vector2(0, 2); //deze wordt aangepast in optie-menu, dus dan moet je eventueel een nieuwe waarde toekennen. Deze is te berekenen met methode uit TetrisBlock
        oldoffset = base.offset;
    }

    public override void Reset()
    {
        blockFormPosition = new Vector2(4 * TetrisGrid.cellwidth, 0);
        timesturn = 0;
        blockForm = oldblockForm;
        base.width = oldwidth;
        base.height = oldheight;
        base.offset = oldoffset;
    }
}