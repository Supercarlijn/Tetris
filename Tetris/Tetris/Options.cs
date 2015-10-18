using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

class Options
{
    Texture2D block, reset, back;
    int screenWidth, screenHeight;
    BlockList blocks;
    TetrisBlock block1, block2, block3, block4, block5, block6, block7;
    SpriteFont font;
    Rectangle backRect;

    public Options(Texture2D blockSprite, Texture2D resetSprite, Texture2D backSprite, int screenWidth, int screenHeight, SpriteFont spriteFont, BlockList blocks)
    {
        block = blockSprite;
        reset = resetSprite;
        back = backSprite;
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
        backRect = new Rectangle(screenWidth / 2 - backSprite.Width / 2, screenHeight - backSprite.Height - 100, backSprite.Width, backSprite.Height);
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
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] = Color.Black;
                    block1.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)].A = 0;
                }
                else if (block1.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                          (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] != Color.Red)
                {
                    block1.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] = Color.Red;
                }
            }

            if (i.MousePosition.X > (screenWidth / 2 + (-11 * block.Width)) && (i.MousePosition.Y > 5 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (-9 * block.Width)) && (i.MousePosition.Y < 6 * block.Height))
            {
                for (int m = 0; m < 4; m++)
                {
                    block1.CurrentBlockForm[m, 0] = Color.Black;
                    block1.CurrentBlockForm[m, 0].A = 0;
                    block1.CurrentBlockForm[m, 1] = Color.Red;
                    block1.CurrentBlockForm[m, 2] = Color.Black;
                    block1.CurrentBlockForm[m, 2].A = 0;
                    block1.CurrentBlockForm[m, 3] = Color.Black;
                    block1.CurrentBlockForm[m, 3].A = 0;
                }
            }

            if (i.MousePosition.X > (screenWidth / 2 + (-7 * block.Width)) && (i.MousePosition.Y > block.Height) && i.MousePosition.X < (screenWidth / 2 + (-3 * block.Width)) && (i.MousePosition.Y < 5 * block.Height))
            {

                if (block2.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-7 * block.Width))) / block.Width)] == Color.Yellow)
                {
                    block2.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-7 * block.Width))) / block.Width)] = Color.Black;
                    block2.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-7 * block.Width))) / block.Width)].A = 0;
                }
                else if (block2.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                          (int)((i.MousePosition.X - (screenWidth / 2 + (-7 * block.Width))) / block.Width)] != Color.Yellow)
                {
                    block2.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-7 * block.Width))) / block.Width)] = Color.Yellow;
                }
            }

            if (i.MousePosition.X > (screenWidth / 2 + (-6 * block.Width)) && (i.MousePosition.Y > 5 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (-3 * block.Width)) && (i.MousePosition.Y < 6 * block.Height))
            {
                for (int m = 0; m < 4; m++)
                {
                    block2.CurrentBlockForm[m, 0] = Color.Black;
                    block2.CurrentBlockForm[m, 0].A = 0;
                    block2.CurrentBlockForm[m, 1] = Color.Black;
                    block2.CurrentBlockForm[m, 1].A = 0;
                    block2.CurrentBlockForm[m, 2] = Color.Black;
                    block2.CurrentBlockForm[m, 2].A = 0;
                    block2.CurrentBlockForm[m, 3] = Color.Black;
                    block2.CurrentBlockForm[m, 3].A = 0;
                }
                block2.CurrentBlockForm[0, 0] = Color.Yellow;
                block2.CurrentBlockForm[0, 1] = Color.Yellow;
                block2.CurrentBlockForm[1, 0] = Color.Yellow;
                block2.CurrentBlockForm[1, 1] = Color.Yellow;
            }

            if (i.MousePosition.X > (screenWidth / 2 + (-2 * block.Width)) && (i.MousePosition.Y > block.Height) && i.MousePosition.X < (screenWidth / 2 + (2 * block.Width)) && (i.MousePosition.Y < 5 * block.Height))
            {

                if (block3.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-2 * block.Width))) / block.Width)] == Color.Green)
                {
                    block3.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-2 * block.Width))) / block.Width)] = Color.Black;
                    block3.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-2 * block.Width))) / block.Width)].A = 0;
                }
                else if (block3.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                          (int)((i.MousePosition.X - (screenWidth / 2 + (-2 * block.Width))) / block.Width)] != Color.Green)
                {
                    block3.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (-2 * block.Width))) / block.Width)] = Color.Green;
                }
            }
            
            if (i.MousePosition.X > (screenWidth / 2 + (-1 * block.Width)) && (i.MousePosition.Y > 5 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (1 * block.Width)) && (i.MousePosition.Y < 6 * block.Height))
            {
                for (int m = 0; m < 4; m++)
                {
                    block3.CurrentBlockForm[m, 0] = Color.Black;
                    block3.CurrentBlockForm[m, 0].A = 0;
                    block3.CurrentBlockForm[m, 1] = Color.Black;
                    block3.CurrentBlockForm[m, 1].A = 0;
                    block3.CurrentBlockForm[m, 2] = Color.Black;
                    block3.CurrentBlockForm[m, 2].A = 0;
                    block3.CurrentBlockForm[m, 3] = Color.Black;
                    block3.CurrentBlockForm[m, 3].A = 0;
                }
                block3.CurrentBlockForm[0, 1] = Color.Green;
                block3.CurrentBlockForm[1, 1] = Color.Green;
                block3.CurrentBlockForm[1, 0] = Color.Green;
                block3.CurrentBlockForm[1, 2] = Color.Green;
            }
            
            if (i.MousePosition.X > (screenWidth / 2 + (3 * block.Width)) && (i.MousePosition.Y > block.Height) && i.MousePosition.X < (screenWidth / 2 + (7 * block.Width)) && (i.MousePosition.Y < 5 * block.Height))
            {

                if (block4.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (3 * block.Width))) / block.Width)] == Color.Blue)
                {
                    block4.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (3 * block.Width))) / block.Width)] = Color.Black;
                    block4.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (3 * block.Width))) / block.Width)].A = 0;
                }
                else if (block4.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                          (int)((i.MousePosition.X - (screenWidth / 2 + (3 * block.Width))) / block.Width)] != Color.Blue)
                {
                    block4.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (3 * block.Width))) / block.Width)] = Color.Blue;
                }
            }

            if (i.MousePosition.X > (screenWidth / 2 + (4 * block.Width)) && (i.MousePosition.Y > 5 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (6 * block.Width)) && (i.MousePosition.Y < 6 * block.Height))
            {
                for (int m = 0; m < 4; m++)
                {
                    block4.CurrentBlockForm[m, 0] = Color.Black;
                    block4.CurrentBlockForm[m, 0].A = 0;
                    block4.CurrentBlockForm[m, 1] = Color.Black;
                    block4.CurrentBlockForm[m, 1].A = 0;
                    block4.CurrentBlockForm[m, 2] = Color.Black;
                    block4.CurrentBlockForm[m, 2].A = 0;
                    block4.CurrentBlockForm[m, 3] = Color.Black;
                    block4.CurrentBlockForm[m, 3].A = 0;
                }
                block4.CurrentBlockForm[0, 1] = Color.Blue;
                block4.CurrentBlockForm[1, 1] = Color.Blue;
                block4.CurrentBlockForm[1, 0] = Color.Blue;
                block4.CurrentBlockForm[2, 0] = Color.Blue;
            }

            if (i.MousePosition.X > (screenWidth / 2 + (8 * block.Width)) && (i.MousePosition.Y > block.Height) && i.MousePosition.X < (screenWidth / 2 + (12 * block.Width)) && (i.MousePosition.Y < 5 * block.Height))
            {

                if (block5.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] == Color.Purple)
                {
                    block5.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] = Color.Black;
                    block5.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)].A = 0;
                }
                else if (block5.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                          (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] != Color.Purple)
                {
                    block5.CurrentBlockForm[(int)((i.MousePosition.Y - block.Height) / block.Height),
                                     (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] = Color.Purple;
                }
            }

            if (i.MousePosition.X > (screenWidth / 2 + (9 * block.Width)) && (i.MousePosition.Y > 5 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (11 * block.Width)) && (i.MousePosition.Y < 6 * block.Height))
            {
                for (int m = 0; m < 4; m++)
                {
                    block5.CurrentBlockForm[m, 0] = Color.Black;
                    block5.CurrentBlockForm[m, 0].A = 0;
                    block5.CurrentBlockForm[m, 1] = Color.Black;
                    block5.CurrentBlockForm[m, 1].A = 0;
                    block5.CurrentBlockForm[m, 2] = Color.Black;
                    block5.CurrentBlockForm[m, 2].A = 0;
                    block5.CurrentBlockForm[m, 3] = Color.Black;
                    block5.CurrentBlockForm[m, 3].A = 0;
                }
                block5.CurrentBlockForm[0, 0] = Color.Purple;
                block5.CurrentBlockForm[1, 0] = Color.Purple;
                block5.CurrentBlockForm[1, 1] = Color.Purple;
                block5.CurrentBlockForm[2, 1] = Color.Purple;
            }

            if (i.MousePosition.X > (screenWidth / 2 + (-12 * block.Width)) && (i.MousePosition.Y > 7 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (-8 * block.Width)) && (i.MousePosition.Y < 11 * block.Height))
            {

                if (block6.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] == Color.DarkOrange)
                {
                    block6.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] = Color.Black;
                    block6.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)].A = 0;
                }
                else if (block6.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                            (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] != Color.DarkOrange)
                {
                    block6.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (-12 * block.Width))) / block.Width)] = Color.DarkOrange;
                }

            }

            if (i.MousePosition.X > (screenWidth / 2 + (-11 * block.Width)) && (i.MousePosition.Y > 11 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (-9 * block.Width)) && (i.MousePosition.Y < 12 * block.Height))
            {
                for (int m = 0; m < 4; m++)
                {
                    block6.CurrentBlockForm[m, 0] = Color.Black;
                    block6.CurrentBlockForm[m, 0].A = 0;
                    block6.CurrentBlockForm[m, 1] = Color.Black;
                    block6.CurrentBlockForm[m, 1].A = 0;
                    block6.CurrentBlockForm[m, 2] = Color.Black;
                    block6.CurrentBlockForm[m, 2].A = 0;
                    block6.CurrentBlockForm[m, 3] = Color.Black;
                    block6.CurrentBlockForm[m, 3].A = 0;
                }
                block6.CurrentBlockForm[0, 1] = Color.DarkOrange;
                block6.CurrentBlockForm[1, 1] = Color.DarkOrange;
                block6.CurrentBlockForm[2, 1] = Color.DarkOrange;
                block6.CurrentBlockForm[2, 2] = Color.DarkOrange;
            }

            if (i.MousePosition.X > (screenWidth / 2 + (8 * block.Width)) && (i.MousePosition.Y > 7 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (12 * block.Width)) && (i.MousePosition.Y < 11 * block.Height))
            {

                if (block7.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] == Color.DeepPink)
                {
                    block7.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] = Color.Black;
                    block7.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)].A = 0;
                }
                else if (block7.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                            (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] != Color.DeepPink)
                {
                    block7.CurrentBlockForm[(int)((i.MousePosition.Y - 7 * block.Height) / block.Height),
                                        (int)((i.MousePosition.X - (screenWidth / 2 + (8 * block.Width))) / block.Width)] = Color.DeepPink;
                }

            }

            if (i.MousePosition.X > (screenWidth / 2 + (9 * block.Width)) && (i.MousePosition.Y > 11 * block.Height) && i.MousePosition.X < (screenWidth / 2 + (11 * block.Width)) && (i.MousePosition.Y < 12 * block.Height))
            {
                for (int m = 0; m < 4; m++)
                {
                    block7.CurrentBlockForm[m, 0] = Color.Black;
                    block7.CurrentBlockForm[m, 0].A = 0;
                    block7.CurrentBlockForm[m, 1] = Color.Black;
                    block7.CurrentBlockForm[m, 1].A = 0;
                    block7.CurrentBlockForm[m, 2] = Color.Black;
                    block7.CurrentBlockForm[m, 2].A = 0;
                    block7.CurrentBlockForm[m, 3] = Color.Black;
                    block7.CurrentBlockForm[m, 3].A = 0;
                }
                block7.CurrentBlockForm[0, 1] = Color.DeepPink;
                block7.CurrentBlockForm[1, 1] = Color.DeepPink;
                block7.CurrentBlockForm[2, 1] = Color.DeepPink;
                block7.CurrentBlockForm[2, 0] = Color.DeepPink;
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


            spriteBatch.DrawString(font, "Note when making custom blocks:", new Vector2(0f, screenHeight - 48), Color.Black);
            spriteBatch.DrawString(font, "The rotating point will always be at the center of the smallest square grid from the top left", new Vector2(0f, screenHeight - 24), Color.Black);

            spriteBatch.Draw(back, backRect, Color.White);
    }

    public Rectangle BackRect
    {
        get { return backRect; }
    }
}
