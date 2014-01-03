using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Core.Controllers;
using Core.Extensions;
using Core.Handlers;

namespace Core.Towers
{
    public class ShopItem
    {
        Vector2 Position { get; set; }
        Vector2 Relative { get; set; }
        int Heigth { get; set; }
        int Width { get; set; }
        Tower Tower { get; set; }

        public ShopItem(Vector2 position, Tower tower, MouseHandler mh)
        {
            Position = position;
            Relative = new Vector2(5, 40);
            Tower = tower;
            Heigth = 125;
            Width = 100;
            mh.OnClick += this.OnClick;
        }

        public void Update(GameTime gametime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureLoader.ShopItemBorder, new Rectangle((int)Position.X, (int)Position.Y, Width, Heigth), Color.White);
            spriteBatch.Draw(Tower.Texture, Position+new Vector2(35, 0), Color.White);
            spriteBatch.DrawString(TextureLoader.FDescr, "Cost: " + Tower.Cost + "\n" + "Range: " + Tower.Radius + "\n" + "Power: " + Tower.Power, Position + Relative, Color.Red);
            if (Player.Gold < Tower.Cost)
                spriteBatch.Draw(TextureLoader.Cross, new Rectangle((int)Position.X, (int)Position.Y, Width, Heigth), Color.White);
        }

        public void OnClick(object sender, MouseAgrs e)
        {
            if (e.ClickedKey == Key.Left &&
                new Rectangle((int)Position.X, (int)Position.Y, Width, Heigth).Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
            {
                if (Player.Gold >= Tower.Cost)
                {
                    InterfaceController.IC.ShopPick(Tower);
                    if (Tower is TestTower) Tower = new TestTower(0, 0);
                    if (Tower is SmallTower) Tower = new SmallTower(0, 0);
                    if (Tower is MediumTower) Tower = new MediumTower(0, 0);
                    if (Tower is LargeTower) Tower = new LargeTower(0, 0);
                }
            }
        }

    }
}
