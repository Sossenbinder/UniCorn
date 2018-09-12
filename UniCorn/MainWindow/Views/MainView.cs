using SFML.Graphics;
using SFML.System;
using SFML.Window;
using MainWindow.UniCorn.Controllers.Interfaces;
using MainWindow.UniCorn.Models.Interfaces;
using MainWindow.UniCorn.Views.Interfaces;
using UniCorn.MainWindow;
using UniCorn;
using UniCorn.Logic.Field;

namespace MainWindow.UniCorn.Views
{
    public class MainView : IMainView
    {
        private readonly IMainViewController m_mainViewController;
        private readonly IMainViewModel m_mainViewModel;

        private BombSpriteHandler m_bombSpriteHandler;
        private RenderWindow m_renderWindow;
        private Sprite m_playerEntity;

        public MainView(IMainViewController mainViewController, IMainViewModel mainViewModel)
        {
            m_mainViewController = mainViewController;
            m_mainViewModel = mainViewModel;

            m_bombSpriteHandler = new BombSpriteHandler("../../Resources/bomb_sprites.png", m_mainViewModel.GetSprizeSize());

            var unicornTexture = new Texture("../../Resources/unicorn.png");
            m_playerEntity = new Sprite(unicornTexture);
        }

        public RenderWindow InitializeWindow()
        {
            var metaData = m_mainViewModel.GetWindowMetaData();

            m_renderWindow = new RenderWindow(new VideoMode(metaData.WindowWidth, (uint)metaData.WindowHeight), MainWindowMetaData.TITLE);
            m_renderWindow.SetFramerateLimit(MainWindowMetaData.FRAMERATE_LIMIT);

            return m_renderWindow;
        }

        public void DrawWindow()
        {
            m_renderWindow.Clear();

            var sprite = m_bombSpriteHandler.GetSprite(GameFieldTileType.BorderLeftRight);

            m_renderWindow.Draw(sprite);

            DrawGameField();
            DrawPlayerEntity();

            m_renderWindow.Display();
        }

        private void DrawGameField()
        {
            var gameFieldSize = m_mainViewModel.GetGameFieldSize();

            for(var i = 0; i < gameFieldSize; ++i)
            {
                for(var j = 0; j < gameFieldSize; ++j)
                {
                    var tileType = m_mainViewModel.GetGameFieldTile(new Vector2i(i, j));
                    var sprite = m_bombSpriteHandler.GetSpritePositioned(tileType, i, j);

                    m_renderWindow.Draw(sprite);
                }
            }
        }

        private void DrawPlayerEntity()
        {
            var pos = m_mainViewModel.GetPlayerEntityPosition();

            m_playerEntity.Position = new Vector2f(pos.X, pos.Y);

            if (m_mainViewModel.GetLastDir() == Keyboard.Key.Left)
            {
                m_playerEntity.Scale = new Vector2f(-1, -1);
            }

            m_renderWindow.Draw(m_playerEntity);
        }
    }
}
