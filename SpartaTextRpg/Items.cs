using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaTextRpg
{
    class Items
    {
        public string itemName { get; set; }
        public int addAtk { get; }
        public int addHp { get; }
        public int addDef { get; }

        public string equipItem { get; set; }
        public bool isEquip { get;  set;}

        public Items(int _addAtk, int _addHp, int _addDef, string _itemName, string _equipItem , bool _isEquip)
        {
            addAtk = _addAtk;
            addHp = _addHp;
            addDef = _addDef;
            itemName = _itemName;
            isEquip = _isEquip;
            equipItem = _equipItem;
        }

    }
}
