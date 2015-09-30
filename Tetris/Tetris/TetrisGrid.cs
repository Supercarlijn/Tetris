using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TetrisGrid
{
    Texture2D gridBlock;
    Vector2 position;
    Texture2D[,] playField;
    int[,] checkPlayField;

    public TetrisGrid(Texture2D b)
    {
        playField = new Texture2D[12,20];
        checkPlayField = new int[12,1];
        gridBlock = b;
        position = Vector2.Zero;
        this.Clear();
    }

    public int Width
    {
        get { return 12; }
    }

    public int Height
    {
        get { return 20; }
    }

    public void Clear()
    {
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        int x, y;
        for (x = 0; x < 12; x++)
        {
            for (y = 0; y < 20; y++)
            {
                playField[x, y] = gridBlock;
                spriteBatch.Draw(playField[x,y], new Vector2(x * gridBlock.Width, y * gridBlock.Height), Color.White);
            }
        }
        
    }
}

