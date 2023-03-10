public class Village {
    private string _name;
    private Ressources _myRessources;
    public int villageois = 0;
    public House chefHome;
    public House[] listHouse;
    public Mine mine;
    public Forest forest;
    public Fields fields;


    public Village(string name) {
        this._name = name;
        this._myRessources = new Ressources();
        this.chefHome = new House();
        this.villageois += House.villageois;
        this.listHouse = new House[] { this.chefHome };
        this.mine = new Mine();
        this.forest = new Forest();
        this.fields = new Fields();
        string action =
            $"1) Afficher le statut de {GetName()}\n" +
            "2) Bâtir une demeure (3 unités de bois, 3 unités de nourriture et 3 unités de pierres requises)\n" +
            "3) Quérir de la bonne pierre (coûte 2 pierres, un de nourriture et un bois, mais rapporte 10 pierres)\n" +
            "4) Quérir du bois solide (coûte 2 pierres, un de nourriture et un bois, mais rapporte 10 bois) \n" +
            "5) Quérir bonne pitance (coûte 2 pierres, un de nourriture et un bois, mais rapporte 10 de nourriture) \n" +
            "6) Améliorer les pioches (ajoute 10 au rendement de la mine contre 10 fois le rendement actuel de la mine) \n" +
            "7) Améliorer les haches (ajoute 10 au rendement de la forêt contre 10 fois le rendement actuel de la forêt) \n" +
            "8) Améliorer les charrues (ajoute 10 au rendement des champs contre 10 fois le rendement actuel des champs) \n" +
            $"9) Améliorer les dépôts (double la capacité des dépôts de bois, de nourriture et de pierre contre 80% du maximum actuel de chaque (Max actuel: {_myRessources.GetMax()})). \n" +
            $"10) Attaque de barbares! Lancer automatique de dé à 10 faces:\n  - Si vous faites plus de 7, vous vainquez les barbares et récupérez leurs bien (toutes les ressources x2)\n" +
            $"  - Si vous faites moins de 7, les barbares détruisent un bâtiment (1 bâtiment restant minimum).\n" +
            "0) Quitter\n";
        bool game = true;

        while (game) {
            System.Console.WriteLine($"********** BIENVENUE À {GetName().ToUpper()} **********\n");
            System.Console.WriteLine(action);
            System.Console.Write("Ordonnez messire, et nous nous exécuterons: ");
            int choice = -1;
            try {
                choice = int.Parse(System.Console.ReadLine());

                if (choice < 0) Console.WriteLine("Bigre Monseigneur, votre choix est trop négatif! ");

            } catch {
                Console.WriteLine("Palsambleu Votre Altesse! Votre choix n'est point dans la Sainte liste!");
            }


            switch (choice) {
                case 1:
                    System.Console.WriteLine($"\n{GetName()}, tour d'horizon:");
                    System.Console.WriteLine($"Vous avez {listHouse.Length} maisons, et donc {villageois} villageois.");
                    Console.WriteLine
                        ($"Votre mine est de niveau {mine.GetLevel()} avec un rendement de {mine.GetLevel() * 10 + 10}, votre forêt de niveau {forest.GetLevel()}, avec un rendement de {forest.GetLevel() * 10 + 10} " +
                        $"et vos champs de niveau {fields.GetLevel()} avec un rendement de {fields.GetLevel() * 10 + 10}");
                    Console.WriteLine
                        ($"Vous disposez actuellement de {_myRessources.GetWood()} / {_myRessources.GetMax()} bois, de {_myRessources.GetStone()} / {_myRessources.GetMax()} pierres, " +
                        $" et de {_myRessources.GetFood()} / {_myRessources.GetMax()} nourriture.\n");
                    break;

                case 2:
                    Console.Write("Combien de demeures souhaitez-vous bâtir? ");
                    int houseNbr = 0;
                    try {
                        houseNbr = int.Parse(System.Console.ReadLine());

                        if (choice < 0) Console.WriteLine("Mais... Monseigneur, nous ne pouvons bâtir un nombre négatif de demeures!\n");

                    } catch {
                        Console.WriteLine("Palsambleu Votre Altesse! Votre choix n'est point dans la Sainte liste!\n");
                    }
                    BuildHouse(houseNbr);
                    LookAround();
                    break;

                case 3:
                    Console.WriteLine("Combien de valeureux villageois souhaitez-vous envoyer à la mine?");
                    int villagerNbrStone = 0;
                    try {
                        villagerNbrStone = int.Parse(System.Console.ReadLine());

                        if (choice < 0) Console.WriteLine("Mais... Monseigneur, nous ne pouvons envoyer un nombre négatif de villageois!\n");

                    } catch {
                        Console.WriteLine("Palsambleu Votre Altesse! Votre choix n'est point dans la Sainte liste!\n");
                    }
                    MineStone(villagerNbrStone);
                    LookAround();
                    break;

                case 4:
                    Console.WriteLine("Combien de valeureux villageois souhaitez-vous envoyer couper du bois?");
                    int villagerNbrWood = 0;
                    try
                    {
                        villagerNbrWood = int.Parse(System.Console.ReadLine());

                        if (choice < 0) Console.WriteLine("Mais... Monseigneur, nous ne pouvons envoyer un nombre négatif de villageois!\n");

                    }
                    catch
                    {
                        Console.WriteLine("Palsambleu Votre Altesse! Votre choix n'est point dans la Sainte liste!\n");
                    }
                    CutWood(villagerNbrWood);
                    LookAround();
                    break;

                case 5:
                    Console.WriteLine("Combien de valeureux villageois souhaitez-vous envoyer aux champs?");
                    int villagerNbrFood = 0;
                    try
                    {
                        villagerNbrFood = int.Parse(System.Console.ReadLine());

                        if (choice < 0) Console.WriteLine("Mais... Monseigneur, nous ne pouvons envoyer un nombre négatif de villageois!\n");

                    }
                    catch
                    {
                        Console.WriteLine("Palsambleu Votre Altesse! Votre choix n'est point dans la Sainte liste!\n");
                    }
                    GrowFood(villagerNbrFood);
                    LookAround();
                    break;

                case 6:
                    UpgradeMine();
                    LookAround();
                    break;

                case 7:
                    UpgradeForest();
                    LookAround();
                    break;

                case 8:
                    UpgradeFields();
                    LookAround();
                    break;

                case 9:
                    UpgradeRessource();
                    LookAround();
                    break;

                case 10:
                    WildHordesAttack();
                    break;

                case 0:
                    Console.WriteLine("Ne nous abandonnez pas Monseigneur!\n   0 = Arrière vilain! J'ai à faire!\n" +
                        "   1 = Qu'il en soit ainsi fidèles sujets, je vais rester un peu! Acclamez-moi prestemment!");
                    int leaveChoice = 0;
                    try {
                        leaveChoice = int.Parse(System.Console.ReadLine());

                        if (leaveChoice < 0 || leaveChoice > 2) {
                            Console.WriteLine("Diantre, que devons-nous comprendre?");
                        } else if (leaveChoice == 0) {
                            game = false;
                        }

                    } catch {
                        Console.WriteLine("Palsambleu Votre Altesse! Votre choix n'est point dans la Sainte liste!");
                    }
                    break;
            }
        }
    }

    public string GetName() {
        return _name;
    }

    public int GetWood() {
        return _myRessources.GetWood();
    }

    public int GetStone() {
        return _myRessources.GetStone();
    }

    public int GetFood() {
        return _myRessources.GetFood();
    }

    private void AddHouse() {
        Array.Resize(ref listHouse, listHouse.Length + 1);
        listHouse[listHouse.Length - 1] = new House();
        this.villageois = listHouse.Length * 10;
    }

    private void DeleteHouse() {
        listHouse[listHouse.Length - 1] = null;
        Array.Resize(ref listHouse, listHouse.Length - 1);
        this.villageois = listHouse.Length * 10;
    }

    public void MineStone(int nbrVillagers) {
        if (nbrVillagers > this.villageois) {
            System.Console.WriteLine($"Pas assez de villageois! ({villageois} villageois disponibles).");
        } else if (Mine.stoneCost * nbrVillagers > _myRessources.GetStone() || Mine.woodCost * nbrVillagers > _myRessources.GetWood() || Mine.foodCost * nbrVillagers > _myRessources.GetFood()) {
            System.Console.WriteLine("Ressources insuffisantes!");
        } else {
            _myRessources.UseStone(Mine.stoneCost * nbrVillagers);
            _myRessources.UseWood(Mine.woodCost * nbrVillagers);
            _myRessources.UseFood(Mine.foodCost * nbrVillagers);
            _myRessources.AddStone(mine.MineStone(nbrVillagers));
            Console.WriteLine($"C'est trois Nains qui ... Ah non! {nbrVillagers} villageois ont utilisé: {Mine.woodCost * nbrVillagers}" +
                $"bois, {Mine.stoneCost * nbrVillagers} pierre et {Mine.foodCost} nourriture pour ramener {mine.MineStone(nbrVillagers)} pierres!\n");
        }
    }

    public void CutWood(int nbrVillagers) {
        if (nbrVillagers > this.villageois) {
            System.Console.WriteLine($"Pas assez de villageois! ({villageois} villageois disponibles).");
        } else if (Forest.stoneCost * nbrVillagers > _myRessources.GetStone() || Forest.woodCost * nbrVillagers > _myRessources.GetWood() || Forest.foodCost * nbrVillagers > _myRessources.GetFood()) {
            System.Console.WriteLine("Ressources insuffisantes!");
        } else {
            _myRessources.UseStone(Forest.stoneCost * nbrVillagers);
            _myRessources.UseWood(Forest.woodCost * nbrVillagers);
            _myRessources.UseFood(Forest.foodCost * nbrVillagers);
            _myRessources.AddWood(forest.CutWood(nbrVillagers));
            Console.WriteLine($"{nbrVillagers} villageois ont utilisé: {Forest.woodCost * nbrVillagers} " +
                $"bois, {Forest.stoneCost * nbrVillagers} pierre et {Forest.foodCost} nourriture pour ramener {forest.CutWood(nbrVillagers)} bois!\n");
        }
    }

    public void GrowFood(int nbrVillagers) {
        if (nbrVillagers > this.villageois) {
            System.Console.WriteLine($"Pas assez de villageois! ({villageois} villageois disponibles).");
        } else if (Fields.stoneCost * nbrVillagers > _myRessources.GetStone() || Fields.woodCost * nbrVillagers > _myRessources.GetWood() || Fields.foodCost * nbrVillagers > _myRessources.GetFood()) {
            System.Console.WriteLine("Ressources insuffisantes!");
        } else {
            _myRessources.UseStone(Fields.stoneCost * nbrVillagers);
            _myRessources.UseWood(Fields.woodCost * nbrVillagers);
            _myRessources.UseFood(Fields.foodCost * nbrVillagers);
            _myRessources.AddFood(fields.GatherFood(nbrVillagers));
            Console.WriteLine($"{nbrVillagers} villageois ont utilisé: {Fields.woodCost * nbrVillagers} " +
                $"bois, {Fields.stoneCost * nbrVillagers} pierre et {Fields.foodCost} pour ramèner {fields.GatherFood(nbrVillagers)} nourriture!\n");
        }
    }

    public void BuildHouse(int houseNbr) {
        if (House.stone_needed * houseNbr > _myRessources.GetStone() || House.wood_needed * houseNbr > _myRessources.GetWood() || House.food_needed * houseNbr > _myRessources.GetFood()) {
            System.Console.WriteLine("Ressources insuffisantes!");
        } else {
            _myRessources.UseFood(House.food_needed * houseNbr);
            _myRessources.UseStone(House.stone_needed * houseNbr);
            _myRessources.UseWood(House.wood_needed * houseNbr);
            for (int i = 0; i < houseNbr; i++) {
                AddHouse();
            }

            if (houseNbr > 1) {
                Console.WriteLine($"{houseNbr} demeures ont été construites. {houseNbr * House.villageois} nouveaux villageois vous acclament!\n");
            }
            else {
                Console.WriteLine($"{houseNbr} demeure a été construite. {houseNbr * House.villageois} nouveaux villageois vous acclament!\n");
            }
        }
    }

    public void UpgradeRessource() {
        _myRessources.Upgrade();
        Console.WriteLine($"Dépôts améliorés au niveau {_myRessources.level}!");
    }

    public void LookAround() {
        if (_myRessources.GetStone() < 2) {
            _myRessources.AddStone(1);
        }

        if (_myRessources.GetWood() < 1) {        
        _myRessources.AddWood(1);
        }

        if (_myRessources.GetFood() < 1) {
            _myRessources.AddFood(1);
        }
    }

    public void UpgradeMine(){
        if (_myRessources.GetStone() < ((mine.GetLevel() * 10) + 10) * 10) { // J'imagine que tu souhaitais qu'on utilise la méthode GetLevel, sinon j'aurais fait une méthode publique GetGainStone dans la classe Mine
            System.Console.WriteLine("Ressources insuffisantes!");
        } else {
            _myRessources.UseStone(((mine.GetLevel() * 10) + 10) * 10);
            mine.Upgrade();
            Console.WriteLine($"Mine améliorée au niveau {mine.GetLevel()}!");
        }
    }

    public void UpgradeForest() {
        if (_myRessources.GetWood() < ((forest.GetLevel() * 10) + 10) * 10) { // J'imagine que tu souhaitais qu'on utilise la méthode GetLevel, sinon j'aurais fait une méthode publique GetGainStone dans la classe Mine
            System.Console.WriteLine("Ressources insuffisantes!");
        } else {
            _myRessources.UseWood(((forest.GetLevel() * 10) + 10) * 10);
            forest.Upgrade();
            Console.WriteLine($"Forêt améliorée au niveau {forest.GetLevel()}!");
        }
    }

    public void UpgradeFields() {
        if (_myRessources.GetFood() < ((fields.GetLevel() * 10) + 10) * 10) { // J'imagine que tu souhaitais qu'on utilise la méthode GetLevel, sinon j'aurais fait une méthode publique GetGainStone dans la classe Mine
            System.Console.WriteLine("Ressources insuffisantes!");
        } else {
            _myRessources.UseFood(((fields.GetLevel() * 10) + 10) * 10);
            fields.Upgrade();
            Console.WriteLine($"Champs améliorés au niveau {fields.GetLevel()}!");
        }
    }

    public void GetLevels() { //Methode pour tester la bonne incrémentation des lvl
        System.Console.WriteLine(mine.GetLevel());
        System.Console.WriteLine(forest.GetLevel());
        System.Console.WriteLine(fields.GetLevel());
    }

    public void WildHordesAttack () {
        int diceThrow = new Random().Next(1, 11);
        Console.WriteLine($"Votre score: {diceThrow}");

        if ( diceThrow > 7) {
            Console.WriteLine("Vous avez repoussé l'assaut! Les barbares terrifiés laissent sur place de nombreuses ressources que vous récupérez.");
            _myRessources.AddStone(_myRessources.GetStone());
            _myRessources.AddFood(_myRessources.GetFood());
            _myRessources.AddStone(_myRessources.GetStone());
        } else if (listHouse.Length > 1) {
            Console.WriteLine($"Les barbares ont détruit une maison avant de repartir. Il vous reste {listHouse.Length -1} maisons.\n");
            DeleteHouse();
        } else {
            Console.WriteLine("Une seule maison? Ce village de pécores ne vaut pas un assaut... On s'en va les gars!\n");
        }
    }

}