﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class BlockList : TetrisBlock
{
    public Dictionary<int, TetrisBlock> blocks;

    public BlockList(Texture2D sprite) :base(null, sprite)
    {
        blocks = new Dictionary<int, TetrisBlock>();
    }

    public void Add(TetrisBlock block, int id)
    {
        blocks.Add(id, block);
    }

    public TetrisBlock Find(int id)
    {
        if (blocks.ContainsKey(id))
        {
            foreach (KeyValuePair<int, TetrisBlock>pair in blocks)
                if (pair.Key == id)
                    return pair.Value;
        }
        return null;
    }

    public void HandleInput(InputHelper inputHelper, int i)
    {
         if (i < 0 || i > blocks.Count)
             return;
         blocks[i].HandleInput(inputHelper);
    }

    public void Update(GameTime gameTime, int i)
    {
        blocks[i].Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch, int i)
    {
        blocks[i].Draw(gameTime, spriteBatch);
    }

    public void Reset(int i)
    {
        blocks[i].Reset();
    }

    public Dictionary<int,TetrisBlock> Blocks
    {
        get { return blocks; }
    }
}
