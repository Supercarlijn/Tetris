using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Options
{
    Texture2D block, reset;
    int screenWidth, screenHeight;

    public Options(Texture2D blockSprite, Texture2D resetSprite, int screenWidth, int screenHeight)
    {
        block = blockSprite;
        reset = resetSprite;
        this.screenWidth = screenWidth;
        this.screenHeight = screenHeight;
    }

    public void Update()
    {

    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        for (int i = -12; i < 9; i += 5)
            spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (i * block.Width)), block.Height), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
        for (int i = -11; i < 10; i += 5)
            spriteBatch.Draw(reset, new Vector2((screenWidth / 2 + (i * block.Width)), block.Height * 5), null, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

        if (screenWidth / 2 - (17 * block.Width) > 0)
        {
            spriteBatch.Draw(block, new Vector2((screenWidth / 2 - (17 * block.Width)), block.Height), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
            spriteBatch.Draw(reset, new Vector2((screenWidth / 2 - (16 * block.Width)), block.Height * 5), null, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (13 * block.Width)), block.Height), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
            spriteBatch.Draw(reset, new Vector2((screenWidth / 2 + (14 * block.Width)), block.Height * 5), null, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        else
        {
            spriteBatch.Draw(block, new Vector2((screenWidth / 2 - (12 * block.Width)), block.Height * 7), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
            spriteBatch.Draw(reset, new Vector2((screenWidth / 2 - (11 * block.Width)), block.Height * 11), null, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (8 * block.Width)), block.Height * 7), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
            spriteBatch.Draw(reset, new Vector2((screenWidth / 2 + (9 * block.Width)), block.Height * 11), null, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
