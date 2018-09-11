using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWindow.UniCorn.Views.Interfaces
{
    public interface IMainView
    {
        RenderWindow InitializeWindow();
        void DrawWindow();
    }
}
