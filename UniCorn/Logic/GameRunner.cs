using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCorn.Logic.Field;
using UniCorn.Logic.Player;

namespace UniCorn.Logic
{
    public class GameRunner
    {
        private readonly GameFieldMover m_gameFieldMover;

        private PlayerEntity m_playerEntity;

        public GameRunner(GameField gameField, PlayerEntity playerEntity)
        {
            m_gameFieldMover = new GameFieldMover(gameField, playerEntity);
            m_playerEntity = playerEntity;
        }

        public Vector2f GetPlayerEntityPosition()
        {
            return m_playerEntity.Position;
        }

        public void MovePlayerEntity(Keyboard.Key keyDir)
        {
            m_gameFieldMover.MovePlayerEntity(keyDir);
        }
    }
}
