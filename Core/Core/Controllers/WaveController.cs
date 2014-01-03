using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Monsters;
using Microsoft.Xna.Framework;
using Core.Map;
using Microsoft.Xna.Framework.Graphics;
using Core.Extensions;
using System.Timers;

namespace Core.Controllers
{
    public class WaveController
    {
        MonsterController monsterController;
        string CurrentWawe;
        TimeSpan CD { get; set; }
        int CurrentMonster { get; set; }
        bool isWawing { get; set; }
        Timer TenSec { get; set; }
        bool isWaiting { get; set; }

        public WaveController(MonsterController monsterController)
        {
            this.monsterController = monsterController;
            CurrentWawe = "NO";
            isWawing = false;
            isWaiting = true;
        }

        public void NewWawe(string Wawe)
        {
            CD = TimeSpan.Zero;
            CurrentMonster = 0;
            CurrentWawe = Wawe;
            isWawing = true;
        }

        public void Start(string Wawe)
        {
            TenSec = new Timer(1000f);
            TenSec.AutoReset = false;
            TenSec.Elapsed += delegate(object sender, ElapsedEventArgs e)
            {
                CD = TimeSpan.Zero;
                CurrentMonster = 0;
                CurrentWawe = Wawe;
                isWawing = true;                
            };
            TenSec.Start();
        }

        public void Update(GameTime gameTime)
        {
            if (monsterController.GetMonsters().All(x => x.isAlive == false) && isWaiting == false)
            {
                monsterController.GetMonsters().Clear();
                Start(FileIO.GetWawe());
                isWaiting = true;
            }
            if (!isWawing) return;
            if (CurrentMonster == CurrentWawe.Length)
            {
                isWawing = false;
                isWaiting = false;
                return;
            }
            if (CD <= TimeSpan.Zero)
            {
                switch (CurrentWawe[CurrentMonster++])
                {
                    case '0': monsterController.Add(new TestMonster(Ground.Start.X, Ground.Start.Y)); break;
                    case '1': monsterController.Add(new Bee(Ground.Start.X, Ground.Start.Y)); break;
                    case '2': monsterController.Add(new Spider(Ground.Start.X, Ground.Start.Y)); break;
                    case '3': monsterController.Add(new Bug(Ground.Start.X, Ground.Start.Y)); break;
                    case '4': monsterController.Add(new Fly(Ground.Start.X, Ground.Start.Y)); break;
                    case '5': monsterController.Add(new Ladybug(Ground.Start.X, Ground.Start.Y)); break;
                }
                CD = new TimeSpan(0, 0, 0, 1, 500);
            }
            CD -= gameTime.ElapsedGameTime;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

        
    }
}
