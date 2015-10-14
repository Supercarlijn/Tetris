using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

class Options
{
    Texture2D block, reset;
    int screenWidth, screenHeight;
    BlockList blocks;
    TetrisBlock block1, block2, block3, block4, block5, block6, block7;
    SpriteFont font;

    public Options(Texture2D blockSprite, Texture2D resetSprite, int screenWidth, int screenHeight, SpriteFont spriteFont, BlockList blocks)
    {
        block = blockSprite;
        reset = resetSprite;
        this.screenWidth = screenWidth;
        this.screenHeight = screenHeight;
        this.blocks = blocks;
        block1 = blocks.Find(1);
        block2 = blocks.Find(2);
        block3 = blocks.Find(3);
        block4 = blocks.Find(4);
        block5 = blocks.Find(5);
        block6 = blocks.Find(6);
        block7 = blocks.Find(7);
        font = spriteFont;
        
        
    }

    public void HandleInput(InputHelper i)
    {

        if (i.MouseLeftButtonPressed())
        {
            if (i.MousePosition.X > (screenWidth / 2 + (-12 * block.Width)) && (i.MousePosition.Y > block.Height) && i.MousePosition.X < (screenWidth / 2 + (-8 * block.Width)) && (i.MousePosition.Y < 5 * block.Height))
            {

                if (block1.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] == Color.Red)
                {
                    block1.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] = Color.White;
                }
                else if (block1.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                          (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] != Color.Red)
                {
                    block1.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] = Color.Red;
                }
            }
            if (i.MousePosition.X > (screenWidth / 2 + (-11 * block.Width)) && (i.MousePosition.Y > 5 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (-9 * block.Width)) && (i.MousePosition.Y < 6 * block.Height))
                block1.CurrentBlockForm = block1.OldBlockForm;

            if (i.MousePosition.X > (screenWidth / 2 + (-7 * block.Width)) && (i.MousePosition.Y > block.Height) && i.MousePosition.X < (screenWidth / 2 + (-3 * block.Width)) && (i.MousePosition.Y < 5 * block.Height))
            {

                if (block2.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-7 * block.Width))) / block.Width)] == Color.Yellow)
                {
                    block2.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-7 * block.Width))) / block.Width)] = Color.White;
                }
                else if (block2.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                          (int)((i.MousePosition.X - (screenWidth / 2 + (-7 * block.Width))) / block.Width)] != Color.Yellow)
                {
                    block2.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-7 * block.Width))) / block.Width)] = Color.Yellow;
                }
            }
            if (i.MousePosition.X > (screenWidth / 2 + (-6 * block.Width)) && (i.MousePosition.Y > 5 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (-4 * block.Width)) && (i.MousePosition.Y < 6 * block.Height))
                block2.CurrentBlockForm = block2.OldBlockForm;

            if (i.MousePosition.X > (screenWidth / 2 + (-2 * block.Width)) && (i.MousePosition.Y > block.Height) && i.MousePosition.X < (screenWidth / 2 + (2 * block.Width)) && (i.MousePosition.Y < 5 * block.Height))
            {

                if (block3.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-2 * block.Width))) / block.Width)] == Color.Green)
                {
                    block3.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-2 * block.Width))) / block.Width)] = Color.White;
                }
                else if (block3.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                          (int)((i.MousePosition.X - (screenWidth / 2 + (-2 * block.Width))) / block.Width)] != Color.Green)
                {
                    block3.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-2 * block.Width))) / block.Width)] = Color.Green;
                }
            }
            if (i.MousePosition.X > (screenWidth / 2 + (-1 * block.Width)) && (i.MousePosition.Y > 5 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (1 * block.Width)) && (i.MousePosition.Y < 6 * block.Height))
                block3.CurrentBlockForm = block3.OldBlockForm;

            if (i.MousePosition.X > (screenWidth / 2 + (3 * block.Width)) && (i.MousePosition.Y > block.Height) && i.MousePosition.X < (screenWidth / 2 + (7 * block.Width)) && (i.MousePosition.Y < 5 * block.Height))
            {

                if (block4.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (3 * block.Width))) / block.Width)] == Color.Blue)
                {
                    block4.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (3 * block.Width))) / block.Width)] = Color.White;
                }
                else if (block4.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                          (int)((i.MousePosition.X - (screenWidth / 2 + (3 * block.Width))) / block.Width)] != Color.Blue)
                {
                    block4.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (3 * block.Width))) / block.Width)] = Color.Blue;
                }
            }
            if (i.MousePosition.X > (screenWidth / 2 + (8 * block.Width)) && (i.MousePosition.Y > block.Height) && i.MousePosition.X < (screenWidth / 2 + (12 * block.Width)) && (i.MousePosition.Y < 5 * block.Height))
            {

                if (block5.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] == Color.Purple)
                {
                    block5.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] = Color.White;
                }
                else if (block5.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                          (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] != Color.Purple)
                {
                    block5.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] = Color.Purple;
                }
            }
            if (i.MousePosition.X > (screenWidth / 2 + (-12 * block.Width)) && (i.MousePosition.Y > 7 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (-8 * block.Width)) && (i.MousePosition.Y < 11 * block.Height))
            {

                if (block6.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] == Color.DarkOrange)
                {
                    block6.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] = Color.White;
                }
                else if (block6.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                            (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] != Color.DarkOrange)
                {
                    block6.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] = Color.DarkOrange;
                }

            }
            if (i.MousePosition.X > (screenWidth / 2 + (8 * block.Width)) && (i.MousePosition.Y > 7 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (12 * block.Width)) && (i.MousePosition.Y < 11 * block.Height))
            {

                if (block7.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] == Color.DeepPink)
                {
                    block7.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] = Color.White;
                }
                else if (block7.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                            (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] != Color.DeepPink)
                {
                    block7.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] = Color.DeepPink;
                }

            }            
        }            
    }

    public void Update()
    {

    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        

        for (int i = -12; i < 9; i += 5)
            spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (i * block.Width)), block.Height), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
        
        spriteBatch.Draw(block, new Vector2((screenWidth / 2 - (12 * block.Width)), block.Height * 7), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
        spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (8 * block.Width)), block.Height * 7), null, Color.Black, 0.0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
        
        
        for (int j = 0; j < 4; j += 1)
        {
            for (int k = 0; k < 4; k += 1)
            {
                if (block1.CurrentBlockForm[k , j] == Color.Red)
                    spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (-12 * block.Width) + j * block.Width), (k + 1) * block.Height), Color.White);
                if (block2.CurrentBlockForm[k , j] == Color.Yellow)
                    spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (-7 * block.Width) + j * block.Width), (k + 1) * block.Height), Color.White);
                if (block3.CurrentBlockForm[k , j] == Color.Green)
                    spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (-2 * block.Width) + j * block.Width), (k + 1) * block.Height), Color.White);
                if (block4.CurrentBlockForm[k , j] == Color.Blue)
                    spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (3 * block.Width) + j * block.Width), (k + 1) * block.Height), Color.White);
                if (block5.CurrentBlockForm[k , j] == Color.Purple)
                    spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (8 * block.Width) + j * block.Width), (k + 1) * block.Height), Color.White);
                if (block6.CurrentBlockForm[k, j] == Color.DarkOrange)
                    spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (-12 * block.Width) + j * block.Width), (k + 7) * block.Height), Color.White);
                if (block7.CurrentBlockForm[k, j] == Color.DeepPink)
                    spriteBatch.Draw(block, new Vector2((screenWidth / 2 + (8 * block.Width) + j * block.Width), (k + 7) * block.Height), Color.White);
            }
        }

    for (int i = -11; i < 10; i += 5)
        spriteBatch.Draw(reset, new Vector2((screenWidth / 2 + (i * block.Width)), block.Height * 5), null, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

    spriteBatch.Draw(reset, new Vector2((screenWidth / 2 - (11 * block.Width)), block.Height * 11), null, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
    spriteBatch.Draw(reset, new Vector2((screenWidth / 2 + (9 * block.Width)), block.Height * 11), null, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);


        spriteBatch.DrawString(font, "In case of a block which fits in a 3x3 grid, place the schematic in the top left of the grid", new Vector2(0f, screenHeight - 24), Color.Black);
    }
}
