using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using SuperMarioBros.Commands;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Controllers
{
    public class KeyboardController : IController
    {
        protected Game1 game;
        protected float timeSinceLastUpdate;
        protected Dictionary<Keys, ICommand> commandMapping;
        protected List<Keys> heldKeys;
        public KeyboardController(Game1 game)
        {
            this.game = game;
            commandMapping = new Dictionary<Keys, ICommand>();
            heldKeys = new List<Keys>();
            RegisterCommands();
            timeSinceLastUpdate = 0;
        }
        public virtual void RegisterCommands()
        {
            commandMapping.Add(Keys.Q, new Quit(game));
            //commandMapping.Add(Keys.R, new Reset(game));
        }
        public virtual void Update(GameTime gameTime)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            for (int c = 0; c < heldKeys.Count; c++)
            {
                if (!pressedKeys.Contains(heldKeys[c]))
                {
                    heldKeys.Remove(heldKeys[c]);
                    c--;
                }
            }

            timeSinceLastUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (pressedKeys.Length > 0 && timeSinceLastUpdate > 0.1f)
            {
                foreach (Keys key in pressedKeys)
                {
                    if (commandMapping.ContainsKey(key) && !heldKeys.Contains(key))
                    {
                        commandMapping[key].Execute();
                        heldKeys.Add(key);
                    }
                }
                timeSinceLastUpdate = 0;
            }
        }
    }
}
