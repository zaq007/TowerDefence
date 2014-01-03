using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Towers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Extensions;
using Microsoft.Xna.Framework.Input;
using Core.Map;
using Core.Handlers;

namespace Core.Controllers
{
    public class InterfaceController
    {
        Tower Selected { get; set; }
        Tower Buying { get; set; }
        Vector2 GoldPosition { get; set; }
        Vector2 ShopPosition { get; set; }
        public static InterfaceController IC { get; set; }
        List<ShopItem> Shop;
        MouseState previous;
        TowerController towerController;
        SelectedItem SelectedItem { get; set; }        

        public InterfaceController(TowerController towerController, MouseHandler mh)
        {
            GoldPosition = new Vector2(530, 5);
            ShopPosition = new Vector2(535, 5 + TextureLoader.FGold.MeasureString("G").Y);
            IC = this;
            Shop = new List<ShopItem>();
            Shop.Add(new ShopItem(ShopPosition, new TestTower(0, 0), mh));
            Shop.Add(new ShopItem(ShopPosition + new Vector2(105, 0), new SmallTower(0, 0), mh));
            Shop.Add(new ShopItem(ShopPosition + new Vector2(0, 130), new MediumTower(0, 0), mh));
            Shop.Add(new ShopItem(ShopPosition + new Vector2(105, 130), new LargeTower(0, 0), mh));
            previous = Mouse.GetState();
            this.towerController = towerController;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in Shop)
                item.Update(gameTime);            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Selected != null)
                SelectedItem.Draw(spriteBatch);
            if (Buying != null)
            {
                spriteBatch.Draw(Buying.Texture, new Vector2(Mouse.GetState().X-17, Mouse.GetState().Y-17), Color.White);
                spriteBatch.Draw(TextureLoader.Circle, new Rectangle(Mouse.GetState().X - (int)Buying.Radius, Mouse.GetState().Y - (int)Buying.Radius, (int)Buying.Radius*2, (int)Buying.Radius*2), Color.White);
            }
            spriteBatch.DrawString(TextureLoader.FGold, "Gold: "+Player.Gold.ToString(), GoldPosition, Color.Red);
            foreach (var item in Shop)
                item.Draw(spriteBatch);
        }

        public void ShopPick(Tower Tower)
        {
            Buying = Tower;
        }

        public void Unpick()
        {
            Selected = null;
            Buying = null;
        }

        public void Pick(Tower Tower)
        {
            Selected = Tower;
            if (SelectedItem != null)
            {
                towerController.mouseHandler.OnClick -= SelectedItem.OnClick;  
            }
            SelectedItem = new SelectedItem(new Vector2(0, 530), Selected);
            towerController.mouseHandler.OnClick += SelectedItem.OnClick;  
        }

        public void OnClick(object sender, MouseAgrs e)
        {
            int key = e.ClickedKey == Key.Left ? 0 : e.ClickedKey == Key.Right ? 1 : 3;
            if (Buying == null && key == 0) return;
            if (key == 0)
            {
                int X = (int)Mouse.GetState().X/35;
                int Y = (int)Mouse.GetState().Y/35;
                if (X<0 || Y<0 || X >= 15 || Y >= 15) return;
                else
                {
                    if (Ground.Mask[X, Y] != '0') return;
                    Buying.Position = new Vector2(X * 35, Y * 35);
                    towerController.Add(Buying);
                    Player.Gold -= Buying.Cost;
                    Buying = null;   
                }
            }
            else
            {
                Unpick();
            }
        }

    }
}
