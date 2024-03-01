using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Commands;
using SuperMarioBros.PlayerCharacter.PlayerStates;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Controllers
{
    public class GameplayController : KeyboardController
    {
        private List<Keys> moveKeys = new List<Keys>();

        public GameplayController(Game1 game) : base(game) { }

        public override void RegisterCommands()
        {
            base.RegisterCommands();

            commandMapping.Add(Keys.W, new JumpCommand(game));
            commandMapping.Add(Keys.S, new CrouchCommand(game));
            commandMapping.Add(Keys.A, new MoveLeftCommand(game));
            commandMapping.Add(Keys.D, new MoveRightCommand(game));
            commandMapping.Add(Keys.Up, new JumpCommand(game));
            commandMapping.Add(Keys.Down, new CrouchCommand(game));
            commandMapping.Add(Keys.Left, new MoveLeftCommand(game));
            commandMapping.Add(Keys.Right, new MoveRightCommand(game));
            commandMapping.Add(Keys.LeftControl, new SprintCommand(game));
            commandMapping.Add(Keys.None, new BecomeIdleCommand(game));
            commandMapping.Add(Keys.R, new UseAbilityCommand(game));

            moveKeys.Add(Keys.Left);
            moveKeys.Add(Keys.Right);
            moveKeys.Add(Keys.D);
            moveKeys.Add(Keys.A);
           // moveKeys.Add(Keys.LeftControl);
        }
        public override void Update(GameTime gameTime)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            for (int c = 0; c < heldKeys.Count; c++)
            {
                if (!pressedKeys.Contains(heldKeys[c]))
                {
                    //Checks if the sprint button is still being held
                    if (heldKeys[c] == Keys.LeftControl)
                        new StopSprintingCommand(game).Execute();
                    else if (heldKeys[c] == Keys.W)//|| heldKeys[c] == Keys.Up)
                        new StopJumpingCommand(game).Execute();

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
                        if(!moveKeys.Contains(key))
                            heldKeys.Add(key);
                    }
                }
                timeSinceLastUpdate = 0;
            }
            if (!(pressedKeys.Contains(Keys.A) || pressedKeys.Contains(Keys.D) || pressedKeys.Contains(Keys.Left) || pressedKeys.Contains(Keys.Right)))
                commandMapping[Keys.None].Execute();
        }

    }
}
