using SFML.Graphics;
using SFML.System;
using SFML.Window;
using UniCorn.Logic.Player;

namespace UniCorn.Logic.Field
{
    /// <summary>
    /// Takes care of logic regarding moving on the field (mostly collision)
    /// </summary>
    public class GameFieldMover
    {
        private readonly PlayerEntity m_playerEntity;

        private readonly GameField m_gameField;

        private readonly int m_movableGameFieldSize;
        private readonly int m_spriteSize;
        private readonly int m_centerSpritePointFactor;

        public Keyboard.Key LastDir { get; set; }

        public GameFieldMover(GameField gameField, PlayerEntity playerEntity)
        {
            m_gameField = gameField;
            m_playerEntity = playerEntity;

            m_movableGameFieldSize = gameField.MovableGameFieldSize;
            m_spriteSize = gameField.SpriteSize;
            m_centerSpritePointFactor = m_spriteSize / 2;
        }

        /// <summary>
        /// Moves the player in the direction of the key pressed. Takes care of checking for collisions
        /// </summary>
        /// <param name="keyDir">Direction in which the player walked</param>
        public void MovePlayerEntity(Keyboard.Key keyDir)
        {
            //Calculate new player position
            var newPos = m_playerEntity.CalculateNewPosition(keyDir);

            if (CheckMoveValidity(m_playerEntity.Position, newPos))
            {
                m_playerEntity.Move(newPos);

                LastDir = keyDir;
            }
        }

        /// <summary>
        /// Checks if the player is allowed to move 
        /// </summary>
        /// <param name="oldPos"></param>
        /// <param name="newPos"></param>
        /// <returns></returns>
        public bool CheckMoveValidity(Vector2i oldPos, Vector2i newPos)
        {
            CenterPositionsRelativeToSprite(ref oldPos, ref newPos);

            var oldTiledPos = CalculateTiledPosition(oldPos);
            var newTiledPos = CalculateTiledPosition(newPos);

            if (newTiledPos.X < 0 || newTiledPos.X > m_movableGameFieldSize || newTiledPos.Y < 0 || newTiledPos.Y > m_movableGameFieldSize )
            {
                return false;
            }

            if (oldTiledPos.X < newTiledPos.X || oldTiledPos.X > newTiledPos.X || oldTiledPos.Y > newTiledPos.Y || oldTiledPos.Y < newTiledPos.Y)
            {
                return !m_gameField.GetGameFieldTile(new Vector2i(newTiledPos.X, newTiledPos.Y)).IsBlocking;
            }

            return true;
        }

        /// <summary>
        /// We need to center both positions relative to the sprite size to not have a "top-left" collision
        /// </summary>
        /// <param name="oldPos">Old position</param>
        /// <param name="newPos">New position</param>
        public void CenterPositionsRelativeToSprite(ref Vector2i oldPos, ref Vector2i newPos)
        {
            oldPos.X += m_centerSpritePointFactor;
            oldPos.Y += m_centerSpritePointFactor;
            newPos.X += m_centerSpritePointFactor;
            newPos.Y += m_centerSpritePointFactor;
        }

        /// <summary>
        /// Converts position down to the corresponding position on the tilemap
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        private Vector2i CalculateTiledPosition(Vector2i pos)
        {
            return new Vector2i((pos.X / m_spriteSize), (pos.Y / m_spriteSize));
        }
    }
}
