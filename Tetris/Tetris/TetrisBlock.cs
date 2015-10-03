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
            //DRAAIEN
        }
        else if (inputHelper.KeyPressed(Keys.Down))
        {
            //SNELLER NAAR BENEDEN
        }
        else if (inputHelper.KeyPressed(Keys.Left))
        {
            //MOVE LEFT
        }
        else if (inputHelper.KeyPressed(Keys.Right))
        {
            //MOVE RIGHT
        }
    }

    /*protected virtual bool TestMostDown ()
    {

    }*/
}