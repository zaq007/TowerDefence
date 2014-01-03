using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Map;
using Core.Monsters;
using Core.Towers;
using Core.Extensions;
using Core.Handlers;
using XNAGameConsole;

namespace Core.Controllers
{
    public class Controller
    {
        Ground ground;
        MonsterController monsterController;
        TowerController towerController;
        BulletController bulletController;
        WaveController waweController;
        InterfaceController interfaceController;
        MouseHandler mouseHandler;

        public Controller()
        {
            mouseHandler = new MouseHandler();
            ground = new Ground();
            monsterController = new MonsterController();
            waweController = new WaveController(monsterController);
            waweController.Start(FileIO.GetWawe());
            towerController = new TowerController(mouseHandler);
            towerController.Add(new Test1Tower(5, 10));
            towerController.Add(new Test1Tower(4, 9));
            towerController.Add(new Test1Tower(5, 8));
            bulletController = new BulletController(towerController.GetTowers(), monsterController.GetMonsters());
            interfaceController = new InterfaceController(towerController, mouseHandler);
            mouseHandler.OnClick += interfaceController.OnClick;
        }

        public void Update(GameTime gameTime)
        {
            mouseHandler.Update(gameTime);
            waweController.Update(gameTime);
            monsterController.Update(gameTime);
            towerController.Update(gameTime);
            bulletController.Update(gameTime);
            interfaceController.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ground.Draw(spriteBatch);
            monsterController.Draw(spriteBatch);
            towerController.Draw(spriteBatch);
            bulletController.Draw(spriteBatch);
            interfaceController.Draw(spriteBatch);
            //mouseHandler.Draw(spriteBatch);
        }

    }
}
