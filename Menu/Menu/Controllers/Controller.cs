using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Menu.Buttons;
using Menu.Extensions;

namespace Menu.Controllers
{
    class Controller
    {
        ButtonControler buttonController;

        public Controller()
        {
            buttonController = new ButtonControler();
            buttonController.NewButton(new NewGame(250, 100, TextureLoader.BtnNewGame));
            buttonController.NewButton(new Exit(250, 250, TextureLoader.BtnExit));
        }

        internal void Update(Microsoft.Xna.Framework.GameTime gametime)
        {
            buttonController.Update(gametime);
        }

        internal void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            buttonController.Draw(spriteBatch);
        }
    }
}
