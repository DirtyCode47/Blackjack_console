using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_console
{
    internal class GameModes
    {
        public bool pickMode = false; //Кнопка Q - взять карту
        public bool justPlayMode = false; //Кнопка W - ничего не делать и играть // пасс
        public bool doubleMode = false; //Кнопка E - сыграть с удвоением суммы
        public bool SplitMode = false; //Кнопка R - сплит
        public bool SurrenderMode = false; //Кнопка T - сдаться и получить половину от ставки
        public bool InsuranceMode = false; //Кнопка Y - страховка от блэкджека
    }
}
