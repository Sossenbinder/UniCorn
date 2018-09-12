using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCorn.Logic.Field
{
    public class GameField
    {
        private int m_gameFieldSize;

        public int SpriteSize { get; }

        public int MovableGameFieldSize
        {
            // "Movable" does not include walls on each side
            get => m_gameFieldSize - 2;
        }

        private GameFieldTile[,] m_gameField;

        public GameField(int gameFieldSize = 10, int spriteSize = 16)
        {
            m_gameFieldSize = gameFieldSize;
            SpriteSize = spriteSize;
        }

        /// <summary>
        /// Initialize the gamefield
        /// </summary>
        public void Initialize()
        {
            m_gameField = new GameFieldTile[m_gameFieldSize, m_gameFieldSize];
            InitializeBorders();
            InitializeField();
        }

        /// <summary>
        /// Initializes borders surrounding gamefield
        /// </summary>
        private void InitializeBorders()
        {
            for(var i = 0; i < m_gameFieldSize; ++i)
            {
                m_gameField[i, 0] = new GameFieldTile(GameFieldTileType.BorderTopBottom);
                m_gameField[i, m_gameFieldSize - 1] = new GameFieldTile(GameFieldTileType.BorderTopBottom);
            }

            for(var i = 1; i < m_gameFieldSize - 1; ++i)
            {
                m_gameField[0, i] = new GameFieldTile(GameFieldTileType.BorderLeftRight);
                m_gameField[m_gameFieldSize - 1, i] = new GameFieldTile(GameFieldTileType.BorderLeftRight);
            }
        }

        /// <summary>
        /// Initializes the inner game field
        /// </summary>
        private void InitializeField()
        {
            var borderIndex = m_gameFieldSize - 1;

            for(var y = 1; y < borderIndex; ++y)
            {
                for(var x = 1; x < borderIndex; ++x)
                {
                    GameFieldTile tile;

                    if(y % 2 == 0 && x % 2 == 0)
                    {
                        tile = new GameFieldTile(GameFieldTileType.BlockMiddle);
                    }
                    else
                    {
                        tile = new GameFieldTile(GameFieldTileType.Grass);
                    }

                    m_gameField[x, y] = tile;
                }
            }
        }

        /// <summary>
        /// Retrieves data about tile at given position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public GameFieldTile GetGameFieldTile(Vector2i position)
        {
            return m_gameField[position.X, position.Y];
        }
    }
}
