using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Extensions;
using XNAGameConsole;

namespace Core
{
    public class Core
    {
        Controller controller;
        GameConsole console;
        System.Windows.Forms.Button btn;

        public Core(Game game, SpriteBatch spriteBatch)
        {
            controller = new Controller();
            console = new GameConsole(game, spriteBatch);
            btn = new System.Windows.Forms.Button();
            btn.Height = 50;
            btn.Width = 100;
            btn.Bounds = new System.Drawing.Rectangle(0, 0, 50, 100);
            btn.BringToFront();
            //game.Window.Title = btn.Handle.ToString();
           // System.Windows.Forms.Form a = System.Windows.Forms.

            
        }

        public string Update(GameTime gameTime)
        {
            Return.Message = "OK";
            controller.Update(gameTime);
            if (Player.Health <= 0)
                return "Game Over";
            return Return.Message;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            controller.Draw(spriteBatch);
        }
    }
}
