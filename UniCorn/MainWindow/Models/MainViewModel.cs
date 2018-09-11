using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWindow.UniCorn.Models.Interfaces;
using SFML.System;
using SFML.Window;
using UniCorn.DataModels;
using UniCorn.Logic;
using UniCorn.Logic.Field;
using UniCorn.Logic.Player;
using UniCorn.MainWindow;

namespace MainWindow.UniCorn.Models
{
    public class MainViewModel : IMainViewModel
    {
        private readonly GameField m_gameField;

        private readonly GameRunner m_gameState;

        private const int m_gameFieldSize = 12;
        private const int m_spriteSize = 64;

        public MainViewModel()
        {
            m_gameField = new GameField(m_gameFieldSize, m_spriteSize);
            m_gameState = new GameRunner(m_gameField, new PlayerEntity(m_gameFieldSize));
        }

        public void InitializeGameField()
        {
            m_gameField.Initialize();
        }

        /// <summary>
        /// Retrieves metadata for window. If screen is too small, recalculates window size with a halving scaling factor.
        /// </summary>
        /// <returns>Metadata for window also containing a scaling factor if one is required</returns>
        public WindowMetadata GetWindowMetaData()
        {
            var metaData = new WindowMetadata();
            var desktopMode = VideoMode.DesktopMode;

            metaData.WindowTitle = MainWindowMetaData.TITLE;

            float scalingFactor = 1;
            float windowHeight = MainWindowMetaData.HEIGHT;
            float windowWidth = MainWindowMetaData.WIDTH;

            while (windowHeight > desktopMode.Height || windowWidth > desktopMode.Width)
            {
                float halfedScalingFactor = scalingFactor / 2;
                windowHeight = windowHeight * halfedScalingFactor;
                windowWidth = windowWidth * halfedScalingFactor;

                scalingFactor = halfedScalingFactor;
            }

            metaData.WindowHeight = (uint)windowHeight;
            metaData.WindowWidth = (uint)windowWidth;
            metaData.ScalingFactor = scalingFactor;

            return metaData;
        }

        public int GetGameFieldSize()
        {
            return m_gameFieldSize;
        }

        public int GetSprizeSize()
        {
            return m_spriteSize;
        }

        public GameFieldTileType GetGameFieldTile(int posX, int posY)
        {
            return m_gameField.GetGameFieldTile(new Vector2i(posX, posY)).GetTileType();
        }

        public void MovePlayerEntity(Keyboard.Key keyDir)
        {
            m_gameState.MovePlayerEntity(keyDir);
        }

        public Vector2f GetPlayerEntityPosition()
        {
            return m_gameState.GetPlayerEntityPosition();
        }
    }
}
