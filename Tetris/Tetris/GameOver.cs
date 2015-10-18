using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


    class GameOver
    {
        Texture2D backButton;
        Rectangle backRect;

        public GameOver(Texture2D backButton, int width, int height)
        {
            this.backButton = backButton;
            backRect = new Rectangle(width / 2 - backButton.Width / 2, height / 2, backButton.Width, backButton.Height);
        }

        public Rectangle BackRect
        {
            get { return backRect; }
        }
    }
