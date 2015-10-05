using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Block3 : TetrisBlock
{
    public Block3(Color color, Texture2D sprite)
        : base(color, sprite, 0, 0, 2, 1, 1, 2, 1, 3)
    {
    }
}