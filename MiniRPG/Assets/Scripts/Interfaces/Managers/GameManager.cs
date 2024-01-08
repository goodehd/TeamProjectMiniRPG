using UnityEngine;

namespace Managers
{
    public class GameManager
    {
        

        public UI_SELECT_CHARACTER CurrentCharacterType { get; set; }
        public GameObject Player { get; set; }
        public DungeonLevel Level { get; set; }
        public void Init()
        {

        }
    }
}