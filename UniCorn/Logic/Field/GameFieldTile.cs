using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCorn.Logic.Field
{
    public class GameFieldTile
    {
        private GameFieldTileType m_tileType;

        public bool IsBlocking
        {
            get => m_tileType == GameFieldTileType.BlockMiddle
                || m_tileType == GameFieldTileType.BorderLeftRight
                || m_tileType == GameFieldTileType.BorderTopBottom;
        }

        public GameFieldTile(GameFieldTileType tileType)
        {
            m_tileType = tileType;
        }

        public GameFieldTileType GetTileType()
        {
            return m_tileType;
        }
    }
}
