using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class TetrisBlock
{
    Texture2D sprite;
    bool [,] startwaarde;
    
    public TetrisBlock (Texture2D block, bool [,] startw)
    {
        sprite = block;
        startwaarde = startw;
    }

    protected virtual void HandleInput (InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Up))
        {
            //draaien
        }
        else if (inputHelper.KeyPressed(Keys.Down))
        {
            //sneller naar beneden
        }
        else if (inputHelper.KeyPressed(Keys.Left))
        {
            //move left
        }
        else if (inputHelper.KeyPressed(Keys.Right))
        {
            //move right
        }
    }

    /*protected virtual bool TestMostDown ()
    {

    }*/
}