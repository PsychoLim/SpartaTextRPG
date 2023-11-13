# SpartaTextRPG
C# 스파르타코딩클럽 TextRPG 개인과제

---
### 이런 기능을 구현했습니다.
1. 메인 화면 출력
2. 스텟창 출력
3. 인벤토리 출력 및 아이템 장착 해제

### 어떤 문법을 사용?
1. 클래스의 생성자를 이용한 캐릭터의 스텟 구현
2. List를 활용한 인벤토리 구현
3. 프로퍼티를 활용한 캐릭터와 아이템의 수치
4. 메서드의 매개변수를 활용한 리스트의 index값 변경
---
### 코드입니다.
```

namespace SpartaTextRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Plyaer player = new Plyaer();
            player.addItme();

            while (true)
            {
                player.pintMain();
                

            }    
        }
    }
}

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



namespace SpartaTextRpg
{

    // 장착관리 장착을 한다라는 건 캐릭터에게 추가적으로 능력치가 생긴다 라는것.
    // 추가적으로 능력치는 

    class Plyaer
    {
        int Lv = 1;
        int Hp = 100;
        int At = 10;
        int Def = 5;
        int Gold = 1500;
        string job = "전사";

        List<Items> Inventory = new List<Items>();



        public void addItme()
        {
            Inventory.Add(new Items(2, 0, 0, "낡은 검", null, false));
            Inventory.Add(new Items(0, 0, 5, "무쇠갑옷", null, false));

        }

        public void pintMain()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신걸 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("1. 상태보기\n2. 인벤토리");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n");


            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    pintStatus();
                    break;
                case ConsoleKey.D2:
                    pintInventory();
                    break;
                default:
                    pintMain();
                    Console.WriteLine("잘못된 입력입니다.\n");
                    Thread.Sleep(1000);
                    break;
            }

        }

        public void pintStatus()
        {
            Console.Clear();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine($"Lv. {Lv}\nChad ( {job} )\n공격력 : {At}\n방어력 : {Def}\n체 력 : {Hp}\nGold : {Gold}\n");
            Console.WriteLine("0. 나가기\n\n원하시는 행동을 입력해주세요.");
            Console.WriteLine("");

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.D0:
                    pintMain();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.\n");
                    Thread.Sleep(1000);
                    pintStatus();
                    break;
            }
        }


        public void pintInventory()
        {
            Console.Clear();



            Console.WriteLine($"[아이템 목록]\n- 1 {Inventory[0].equipItem} {Inventory[0].itemName}     | 공격력 +{Inventory[0].addAtk} | 쉽게 볼 수 있는 낡은 검입니다.");
            Console.WriteLine($"- 2 {Inventory[1].equipItem} {Inventory[1].itemName}    | 방어력 +{Inventory[1].addDef} | 무쇠로 만들어져 튼튼한 갑옷입니다.");           
            Console.WriteLine("0. 나가기\n1. 아이템 장착\n2. 아이템 해제\n원하시는 행동을 입력해주세요.");
            Console.WriteLine("");


            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D0:
                    pintMain();
                    break;

                case ConsoleKey.D1:
                    Console.WriteLine("장착할 아이템을 선택해주세요.");

                    ConsoleKeyInfo selectEquipItem = Console.ReadKey();
                    switch (selectEquipItem.Key)
                    {
                        case ConsoleKey.D0:
                            pintMain();
                            break;
                        case ConsoleKey.D1:
                            equipItem(0);
                            break;
                        case ConsoleKey.D2:
                            equipItem(1);
                            break;

                    }
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("해제할 아이템을 선택해주세요.");

                    ConsoleKeyInfo selectClearItem = Console.ReadKey();
                    switch (selectClearItem.Key)
                    {
                        case ConsoleKey.D0:
                            pintMain();
                            break;
                        case ConsoleKey.D1:
                            clearItem(0);
                            break;
                        case ConsoleKey.D2:
                            clearItem(1);
                            break;

                    }
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.\n");
                    Thread.Sleep(1000);
                    pintInventory();
                    break;
            }
            pintInventory();
        }

        public void equipItem(int index)
        {

            if (Inventory[index].isEquip == false)
            {
                Inventory[index].isEquip = true;
                Inventory[index].equipItem = "[E]";               
                At += Inventory[index].addAtk;
                Hp += Inventory[index].addHp;
                Def += Inventory[index].addDef;
                Console.WriteLine($"{Inventory[index].itemName} 을 장착합니다.");
            }
            
            Thread.Sleep(1000);

        }

        public void clearItem(int index)
        {

            if (Inventory[index].isEquip == true)
            {
                Inventory[index].isEquip = false;
                Inventory[index].equipItem = null;               
                At -= Inventory[index].addAtk;
                Hp -= Inventory[index].addHp;
                Def -= Inventory[index].addDef;
                Console.WriteLine($"{Inventory[index].itemName} 을 해제합니다.");
            }
            
            Thread.Sleep(1000);

        }

    }
}

