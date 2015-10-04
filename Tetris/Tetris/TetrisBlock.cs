using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

class TetrisBlock
{
    Texture2D sprite;
    public bool[,] blockForm; //De array die bijhoudt hoe het tetrisblokje gedraait is en wat de vorm is en dus wat ie bezet houdt
    public Vector2 blockFormPosition, blockPosition; //blockFormP= de positie van blockForm in speelveld (in pixels), blockP = positie block in speelveld (in pixels)
    
    public TetrisBlock (int arrayLength, int x, int y, int s, int t)
    {
        blockForm = new bool[arrayLength, arrayLength]; //Wordt gevuld in de constructor van de individuele blokjes
        blockFormPosition = new Vector2(x, y); //TWIJFEL NOG OF BLOCKFORMPOSITION ECHT NODIG IS OF DAT JE HET MET ALLEEN BLOCKPOSITION KAN DOEN
        blockPosition = new Vector2(s, t);
    }

    protected void HandleInput (InputHelper inputHelper, TetrisBlock block, Color color) //parameter block is het blokje dat nu bewogen moet worden
    {
        if (inputHelper.KeyPressed(Keys.Up) && TetrisGrid.CheckPlayField(block))
        {
            //DRAAIEN (RECHTSOM)
            blockForm = RotateArray(blockForm, blockForm.Length);
            if (/*als het niet mogelijk is om rechtsom te draaien*/)
            {
                blockForm = RotateArrayLeft(blockForm, blockForm.Length); //DRAAIEN (LINKSOM)
            }
            //OCCUPIEDFIELD MOET NOG GEUPDATE WORDEN, ZODAT DIE VAN DE BEWEGING AFWEET
        }
        else if (inputHelper.KeyPressed(Keys.Down) && TetrisGrid.CheckPlayField(block))
        {
            //Naar beneden
            blockFormPosition += new Vector2(0, 1);
            blockPosition += new Vector2(0, 1);
            //OCCUPIEDFIELD MOET NOG GEUPDATE WORDEN, ZODAT DIE VAN DE BEWEGING AFWEET
        }
        else if (inputHelper.KeyPressed(Keys.Left) && TetrisGrid.CheckPlayField(block))
        {
            //Move left
            blockFormPosition += new Vector2(-1, 0);
            blockPosition += new Vector2(-1, 0);
            //OCCUPIEDFIELD MOET NOG GEUPDATE WORDEN, ZODAT DIE VAN DE BEWEGING AFWEET
        }
        else if (inputHelper.KeyPressed(Keys.Right) && TetrisGrid.CheckPlayField(block))
        {
            //Move right
            blockFormPosition += new Vector2(1, 0);
            blockPosition += new Vector2(1, 0);
            //OCCUPIEDFIELD MOET NOG GEUPDATE WORDEN, ZODAT DIE VAN DE BEWEGING AFWEET
        }
    }

    static bool[,] RotateArray(bool[,] array, int p)
    {
        bool[,] result = new bool[p, p];
        for (int x = 0; x < p; x++)
        {
            for (int y = 0; y < p; y++)
            {
                result[y, x] = array[p - x - 1, y];
            }
        }
        return result;
    }

    static bool[,] RotateArrayLeft(bool[,] array, int arrayLength)
    {
        bool[,] result = new bool[arrayLength, arrayLength];
        for (int x = 0; x < arrayLength; x++)
        {
            for (int y = 0; y < arrayLength; y++)
            {
                result [y, x] = array[arrayLength - x + 1, y];
            }
        }
        return result;
    }
}