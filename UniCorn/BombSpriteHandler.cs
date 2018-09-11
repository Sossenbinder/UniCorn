using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCorn.Logic;
using UniCorn.Logic.Field;

namespace UniCorn
{
    public class BombSpriteHandler
    {
        private readonly Texture m_texture;

        private const int DEFAULT_SPRITE_SIZE = 16;
        private readonly int m_spriteSize;
        private readonly float m_scale;

        private readonly Dictionary<GameFieldTileType, IntRect> m_spriteDict = new Dictionary<GameFieldTileType, IntRect>()
        {
            {GameFieldTileType.Grass, new IntRect(32, 16, 16, 16)},
            {GameFieldTileType.BorderTopBottom, new IntRect(16, 0, 16, 16)},
            {GameFieldTileType.BorderLeftRight, new IntRect(0, 16, 16, 16)},
            {GameFieldTileType.BlockMiddle, new IntRect(32, 32, 16, 16)},
        };

        public BombSpriteHandler(string filePath, int spriteSize = 16)
        {
            m_texture = new Texture(filePath);
            m_spriteSize = spriteSize;
            m_scale = spriteSize / DEFAULT_SPRITE_SIZE;
        }

        public Sprite GetSprite(GameFieldTileType tileType)
        {
            var sprite = new Sprite(m_texture, m_spriteDict[tileType])
            {
                Scale = new Vector2f(m_scale, m_scale)
            };

            return sprite;
        }

        public Sprite GetSpritePositioned(GameFieldTileType tileType, int posX, int posY)
        {
            var sprite = GetSprite(tileType);
            sprite.Position = new Vector2f(posX * m_spriteSize, posY * m_spriteSize);

            return sprite;
        }

        public Sprite GetSpriteUnscaled(GameFieldTileType tileType)
        {
            return new Sprite(m_texture, m_spriteDict[tileType]);
        }
    }
}
