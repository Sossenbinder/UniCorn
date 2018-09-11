using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCorn.DataModels;
using UniCorn.Logic.Field;

namespace MainWindow.UniCorn.Models.Interfaces
{
    public interface IMainViewModel
    {
        void InitializeGameField();
        WindowMetadata GetWindowMetaData();
        int GetGameFieldSize();
        int GetSprizeSize();
        GameFieldTileType GetGameFieldTile(int posX, int posY);
        void MovePlayerEntity(Keyboard.Key keyDir);
        Vector2f GetPlayerEntityPosition();
    }
}
