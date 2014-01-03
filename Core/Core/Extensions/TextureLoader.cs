using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Core.Extensions
{
    public static class TextureLoader
    {
        private static ContentManager content;

        public static void Initialize(ContentManager contentManager)
        {
            content = contentManager;
        }

        private static Texture2D none;
        public static Texture2D None
        {
            get
            {
                if (none == null)
                    none = content.Load<Texture2D>("None");
                return none;
            }
        }

        private static Texture2D smallTower;
        public static Texture2D SmallTower
        {
            get
            {
                if (smallTower == null)
                    smallTower = content.Load<Texture2D>("SmallTower");
                return smallTower;
            }
        }

        private static Texture2D mediumTower;
        public static Texture2D MediumTower
        {
            get
            {
                if (mediumTower == null)
                    mediumTower = content.Load<Texture2D>("MediumTower");
                return mediumTower;
            }
        }

        private static Texture2D largeTower;
        public static Texture2D LargeTower
        {
            get
            {
                if (largeTower == null)
                    largeTower = content.Load<Texture2D>("BigTower");
                return largeTower;
            }
        }

        private static Texture2D road;
        public static Texture2D Road
        {
            get
            {
                if (road == null)
                    road = content.Load<Texture2D>("Road");
                return road;
            }
        }

        private static Texture2D cursor;
        public static Texture2D Cursor
        {
            get
            {
                if (cursor == null)
                    cursor = content.Load<Texture2D>("Cursor");
                return cursor;
            }
        }

        private static Texture2D start;
        public static Texture2D Start
        {
            get
            {
                if (start == null)
                    start = content.Load<Texture2D>("Start");
                return start;
            }
        }

        private static Texture2D finish;
        public static Texture2D Finish
        {
            get
            {
                if (finish == null)
                    finish = content.Load<Texture2D>("Finish");
                return finish;
            }
        }

        private static Texture2D testMonster;
        public static Texture2D TestMonster
        {
            get
            {
                if (testMonster == null)
                    testMonster = content.Load<Texture2D>("Monster");
                return testMonster;
            }
        }

        private static Texture2D bullet;
        public static Texture2D Bullet
        {
            get
            {
                if (bullet == null)
                    bullet = content.Load<Texture2D>("Bullet");
                return bullet;
            }
        }

        private static Texture2D tower;
        public static Texture2D Tower
        {
            get
            {
                if (tower == null)
                    tower = content.Load<Texture2D>("Tower");
                return tower;
            }
        }

        private static Texture2D cross;
        public static Texture2D Cross
        {
            get
            {
                if (cross == null)
                    cross = content.Load<Texture2D>("Cross");
                return cross;
            }
        }

        private static Texture2D sIBorder;
        public static Texture2D ShopItemBorder
        {
            get
            {
                if (sIBorder == null)
                    sIBorder = content.Load<Texture2D>("ShopItemBorder");
                return sIBorder;
            }
        }

        private static Texture2D upgrade;
        public static Texture2D Upgrade
        {
            get
            {
                if (upgrade == null)
                    upgrade = content.Load<Texture2D>("Upgrade");
                return upgrade;
            }
        }

        private static Texture2D bee;
        public static Texture2D Bee
        {
            get
            {
                if (bee == null)
                    bee = content.Load<Texture2D>("Bee");
                return bee;
            }
        }

        private static Texture2D spider;
        public static Texture2D Spider
        {
            get
            {
                if (spider == null)
                    spider = content.Load<Texture2D>("Spider");
                return spider;
            }
        }

        private static Texture2D bug;
        public static Texture2D Bug
        {
            get
            {
                if (bug == null)
                    bug = content.Load<Texture2D>("Bug");
                return bug;
            }
        }

        private static Texture2D fly;
        public static Texture2D Fly
        {
            get
            {
                if (fly == null)
                    fly = content.Load<Texture2D>("Fly");
                return fly;
            }
        }

        private static Texture2D lady;
        public static Texture2D Lady
        {
            get
            {
                if (lady == null)
                    lady = content.Load<Texture2D>("Ladybug");
                return lady;
            }
        }

        private static Texture2D sell;
        public static Texture2D Sell
        {
            get
            {
                if (sell == null)
                    sell = content.Load<Texture2D>("Sell");
                return sell;
            }
        }

        private static Texture2D circle;
        public static Texture2D Circle
        {
            get
            {
                if (circle == null)
                    circle = content.Load<Texture2D>("Circle");
                return circle;
            }
        }

        private static SpriteFont fGold;
        public static SpriteFont FGold
        {
            get
            {
                if (fGold == null)
                    fGold = content.Load<SpriteFont>("Gold_Font");
                return fGold;
            }
        }

        private static SpriteFont fDescr;
        public static SpriteFont FDescr
        {
            get
            {
                if (fDescr == null)
                    fDescr = content.Load<SpriteFont>("Descr_Font");
                return fDescr;
            }
        }



    }
}
