﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

class InputHelper
{
    MouseState currentMouseState, previousMouseState;
    KeyboardState currentKeyboardState, previousKeyboardState;
    double timeSinceLastKeyPress;
    double keyPressInterval;

    public InputHelper()
    {
        keyPressInterval = 125;
        timeSinceLastKeyPress = 0;
    }

    public void Update(GameTime gameTime)
    {
        Keys[] prevKeysDown = previousKeyboardState.GetPressedKeys();
        Keys[] currKeysDown = currentKeyboardState.GetPressedKeys();
        if (currKeysDown.Length != 0 && (prevKeysDown.Length == 0 || timeSinceLastKeyPress > keyPressInterval))
            timeSinceLastKeyPress = 0;
        else
            timeSinceLastKeyPress += gameTime.ElapsedGameTime.TotalMilliseconds;

        previousMouseState = currentMouseState;
        previousKeyboardState = currentKeyboardState;
        currentMouseState = Mouse.GetState();
        currentKeyboardState = Keyboard.GetState();
    }

    public Vector2 MousePosition
    {
        get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
    }

    public bool MouseLeftButtonPressed()
    {
        return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
    }

    public bool KeyPressed(Keys k, bool detecthold = true)
    {
        return currentKeyboardState.IsKeyDown(k) && (previousKeyboardState.IsKeyUp(k) || (timeSinceLastKeyPress > keyPressInterval && detecthold));
    }

    public bool IsKeyDown(Keys k)
    {
        return currentKeyboardState.IsKeyDown(k);
    }
}