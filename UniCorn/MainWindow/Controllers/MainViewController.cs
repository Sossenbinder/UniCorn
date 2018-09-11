using SFML.Graphics;
using System;
using MainWindow.UniCorn.Controllers.Interfaces;
using MainWindow.UniCorn.Models;
using MainWindow.UniCorn.Models.Interfaces;
using MainWindow.UniCorn.Views;
using MainWindow.UniCorn.Views.Interfaces;
using SFML.Window;

namespace MainWindow.UniCorn.Controllers
{
    public class MainViewController : IMainViewController
    {
        private readonly IMainView m_mainView;
        private readonly IMainViewModel m_mainViewModel;

        private readonly RenderWindow m_mainViewWindow;

        public MainViewController()
        {
            m_mainViewModel = new MainViewModel();
            m_mainView = new MainView(this, m_mainViewModel);
            m_mainViewWindow = m_mainView.InitializeWindow();

            Initialize();
        }

        private void Initialize()
        {
            RegisterEvents();

            m_mainViewModel.InitializeGameField();
        }

        private void RegisterEvents()
        {
            m_mainViewWindow.Closed += HandleWindowClose;

            m_mainViewWindow.KeyPressed += HandleKeyPress;
        }

        public void RunMainWindow()
        {
            while (m_mainViewWindow.IsOpen)
            {
                m_mainViewWindow.DispatchEvents();
                m_mainView.DrawWindow();
            }
        }

        private void HandleWindowClose(object sender, EventArgs e)
        {
            m_mainViewWindow.Close();
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Up || e.Code == Keyboard.Key.Down
                || e.Code == Keyboard.Key.Left || e.Code == Keyboard.Key.Right)
            {
                m_mainViewModel.MovePlayerEntity(e.Code);
            }
        }
    }
}
