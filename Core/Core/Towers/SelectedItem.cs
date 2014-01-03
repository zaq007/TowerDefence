using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Core.Extensions;
using Core.Controllers;
using Core.Buttons;
using Core.Handlers;

namespace Core.Towers
{
    class SelectedItem
    {
        Vector2 Uptate { get; set; }
        Vector2 SellV { get; set; }
        Vector2 Position { get; set; }
        Vector2 Relative { get; set; }
        int Heigth { get; set; }
        int Width { get; set; }
        Tower Tower { get; set; }
        MouseState previous { get; set; }
        Sell Sell;
        Upgrade Upgrade;

        public SelectedItem(Vector2 position, Tower tower)
        {
            Position = position;
            Relative = new Vector2(5, 40);
            Tower = tower;
            previous = Mouse.GetState();
            Heigth = 70;
            Width = 250;
            SellV = Position + new Vector2(35, 3);
            Uptate = Position + new Vector2(100, 3);
            Sell = new Sell((int)SellV.X, (int)SellV.Y, tower);
            Upgrade = new Upgrade((int)Uptate.X, (int)Uptate.Y, tower);
            //TowerController.Instanse.mouseHandler.OnClick += Sell.OnClick;
            //TowerController.Instanse.mouseHandler.OnClick += Upgrade.OnClick;
        }

        public void Update(GameTime gametime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sell.Draw(spriteBatch);
            Upgrade.Draw(spriteBatch);
            spriteBatch.Draw(TextureLoader.ShopItemBorder, new Rectangle((int)Position.X, (int)Position.Y, Width, Heigth), Color.White);
            spriteBatch.Draw(Tower.Texture, Position, Color.White);
            spriteBatch.DrawString(TextureLoader.FDescr, "Cost: " + Tower.Cost + " " + "Range: " + Tower.Radius + " " + "Power: " + Tower.Power, Position + Relative, Color.Red);
            spriteBatch.Draw(TextureLoader.Circle, new Rectangle((int)Tower.Position.X - (int)Tower.Radius + 17, (int)Tower.Position.Y - (int)Tower.Radius + 17, (int)Tower.Radius * 2, (int)Tower.Radius * 2), Color.White);
        }

        public void OnClick(object sender, MouseAgrs e)
        {
            Sell.OnClick(sender, e);
            Upgrade.OnClick(sender, e);
        }
    }
}
