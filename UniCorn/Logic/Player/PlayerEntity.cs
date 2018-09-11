using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCorn.Logic.Player
{
    public class PlayerEntity
    {
        public Vector2i Position { get; set; }

        public PlayerEntity(int gameFieldSize)
        {
            Position = new Vector2i(64, 64);
        }

        public Vector2i CalculateNewPosition(Keyboard.Key keyDir)
        {
            var newXPos = Position.X;
            var newYPos = Position.Y;

            switch (keyDir)
            {
                case Keyboard.Key.Up:
                    newYPos -= 3;
                    break;
                case Keyboard.Key.Down:
                    newYPos += 3;
                    break;
                case Keyboard.Key.Left:
                    newXPos -= 3;
                    break;
                case Keyboard.Key.Right:
                    newXPos += 3;
                    break;
            }

            return new Vector2i(newXPos, newYPos);
        }

        public void Move(Vector2i newPos)
        {
            Position = newPos;
        }
    }
}
