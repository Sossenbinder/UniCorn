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

        private int m_playerEntitySpeed;

        public PlayerEntity(int gameFieldSize, int playerEntitiySpeed = 5)
        {
            Position = new Vector2i(64, 64);
            m_playerEntitySpeed = playerEntitiySpeed;
        }

        public Vector2i CalculateNewPosition(Keyboard.Key keyDir)
        {
            var newXPos = Position.X;
            var newYPos = Position.Y;

            switch (keyDir)
            {
                case Keyboard.Key.Up:
                    newYPos -= m_playerEntitySpeed;
                    break;
                case Keyboard.Key.Down:
                    newYPos += m_playerEntitySpeed;
                    break;
                case Keyboard.Key.Left:
                    newXPos -= m_playerEntitySpeed;
                    break;
                case Keyboard.Key.Right:
                    newXPos += m_playerEntitySpeed;
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
