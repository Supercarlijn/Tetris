using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class BlockList : TetrisBlock
{
    public Dictionary<int, TetrisBlock> blocks;
    public Dictionary<int, TetrisBlock> reserve; //Tweede dictionary voor het tekenen van het volgende blokje naast speelveld

    public BlockList(Texture2D sprite) :base(sprite)
    {
        blocks = new Dictionary<int, TetrisBlock>();
        reserve = new Dictionary<int, TetrisBlock>();
    }

    //Deze methode voegt objecten toe aan onze Dictionary
    public void Add(TetrisBlock block, int id)
    {
        blocks.Add(id, block);
    }

    public void AddToReserve(TetrisBlock block, int id)
    {
        reserve.Add(id, block);
    }

    //Deze methode zoekt naar een object met een gegeven id
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

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch, int i, int i2, Vector2 blockFoPos)
    {
        blocks[i].Draw(gameTime, spriteBatch, Vector2.Zero);
        reserve[i2].Draw(gameTime, spriteBatch, blockFoPos);
    }

    public void Reset(int i, int i2)
    {
        blocks[i].Reset();
        reserve[i2].Reset();
    }

    public Dictionary<int,TetrisBlock> Blocks
    {
        get { return blocks; }
    }
}
