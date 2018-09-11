using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainWindow.UniCorn.Controllers;

namespace UniCorn
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new MainViewController();
            controller.RunMainWindow();
        }
    }
}
