using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Towers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Map;
using Core.Handlers;
using Core.Extensions;

namespace Core.Controllers
{
    public class TowerController
    {
        List<Tower> towers;
        public MouseHandler mouseHandler { get; set; }
        public static TowerController Instanse { get; private set; }

        public TowerController(MouseHandler MH)
        {
            this.towers = new List<Tower>();
            mouseHandler = MH;
            Instanse = this;
        }

        public void Add(Tower Tower)
        {
            towers.Add(Tower);
            mouseHandler.OnClick += Tower.OnClick;
            Ground.Mask[(int)(Tower.Position.X / 35), (int)(Tower.Position.Y / 35)] = '9';
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in towers)
                item.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in towers)
                item.Draw(spriteBatch);
        }

        public List<Tower> GetTowers()
        {
            return towers;
        }

        public void Sell(Tower tower)
        {
            towers.Remove(tower);
            mouseHandler.OnClick -= tower.OnClick;
            Player.Gold += tower.Cost / 2;
        }


    }
}
