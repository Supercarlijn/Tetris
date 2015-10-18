using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;

class Menu
{
    Texture2D polytris, playSprite, optionsSprite;
    Rectangle polytrisRect, playRect, optionsRect;

    public Menu(Texture2D play, Texture2D options, Texture2D polytris, int width, int height)
    {
        this.polytris = polytris;
        playSprite = play;
        optionsSprite = options;
        polytrisRect = new Rectangle(width / 2 - polytris.Width / 2, 50, polytris.Width, polytris.Height);
        playRect = new Rectangle(width / 2 - play.Width / 2, 100 + polytris.Height, play.Width, play.Height);
        optionsRect = new Rectangle(width / 2 - options.Width / 2, 120 + polytris.Height + play.Height, options.Width, options.Height);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(polytris, polytrisRect, Color.White);
        spriteBatch.Draw(playSprite, playRect, Color.White);
        spriteBatch.Draw(optionsSprite, optionsRect, Color.White);
    }

    public Rectangle PlayRect
    {
        get { return playRect; }
    }
    
    public Rectangle OptionsRect
    {
        get { return optionsRect; }
    }
}