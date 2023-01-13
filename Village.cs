public class Village {
    private string _name;
    private Ressources _myRessources;
    public int villageois = 0;
    public House chefHome;
    public House[] listHouse;
    public Mine mine;
    public Forest forest;


    public Village (string name) {
        this._name = name;
        this._myRessources = new Ressources();
        this.chefHome = new House();
        this.villageois += House.villageois;
        this.listHouse = new House[] {this.chefHome};
        this.mine = new Mine();
        this.forest = new Forest();
        string action = 
            $"1) Afficher le statut de {GetName()}\n"+
            "2) Bâtir une demeure (3 unités de bois et 3 unités de pierres requises)\n"+
            "3) Quérir de la bonne pierre (coûte 2 pierres et un bois, mais rapporte 10 pierres)\n"+
            "4) Quérir du bois solide (coûte 2 pierres et un bois, mais rapporte 10 bois) \n" +
            "5) Améliorer les pioches (ajoute 10 au rendement de la mine contre 10 fois le rendement actuel de la mine) \n"+
            "6) Améliorer les haches (ajoute 10 au rendement de la forêt contre 10 fois le rendement actuel de la forêt) \n" +
            $"7) Améliorer les dépôts (double la capacité des dépôts de bois et de pierre contre 80% du maximum actuel de {_myRessources.GetMax()}). \n"+
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
                Console.WriteLine("Palsambleu Votre Altesse! Votre choix n'est point dans la sainte liste!");
            }
            

            switch (choice) {
                case 1:
                    System.Console.WriteLine($"\n{GetName()}, tour d'horizon:");
                    System.Console.WriteLine($"Vous avez {listHouse.Length} maisons, et donc {villageois} villageois.");
                    Console.WriteLine
                        ($"Votre mine est de niveau {mine.GetLevel()} avec un rendement de {mine.GetLevel() * 10 + 10}, votre forêt de niveau {forest.GetLevel()}, avec un rendement de {forest.GetLevel() * 10 + 10}.");
                    Console.WriteLine
                        ($"Vous disposez actuellement de {_myRessources.GetWood()} / {_myRessources.GetMax()} bois et de {_myRessources.GetStone()} / {_myRessources.GetMax()} pierres.\n");
                    break;
                    
                case 2:
                    Console.Write("Combien de demeures souhaitez-vous bâtir? ");
                    int houseNbr = 0;
                    try {
                        houseNbr = int.Parse(System.Console.ReadLine());

                        if (choice < 0) Console.WriteLine("Mais... Monseigneur, nous ne pouvons bâtir un nombre négatif de demeures!\n");

                    } catch {
                        Console.WriteLine("Palsambleu Votre Altesse! Votre choix n'est point dans la sainte liste!\n");
                    }
                    BuildHouse(houseNbr);
                    break;

                case 3:
                    Console.WriteLine("Combien de valeureux villageois souhaitez-vous envoyer à la mine?");
                    int villagerNbrStone = 0;
                    try {
                        villagerNbrStone = int.Parse(System.Console.ReadLine());

                        if (choice < 0) Console.WriteLine("Mais... Monseigneur, nous ne pouvons envoyer un nombre négatif de villageois!\n");

                    } catch {
                        Console.WriteLine("Palsambleu Votre Altesse! Votre choix n'est point dans la sainte liste!\n");
                    }
                    MineStone(villagerNbrStone);
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
                        Console.WriteLine("Palsambleu Votre Altesse! Votre choix n'est point dans la sainte liste!\n");
                    }
                    CutWood(villagerNbrWood);
                    break;

                case 5:
                    UpgradeMine();
                    break;

                case 6:
                    UpgradeForest();
                    break;

                case 7:
                    UpgradeRessource();
                    break;

                case 0:
                    Console.WriteLine("Ne nous abandonnez pas Monseigneur!\n   0 = Arrière vilain! J'ai à faire!\n" +
                        "   1 = Qu'il en soit ainsi fidèles sujets, je vais rester un peu! Acclamez-moi prestemment!");
                    int leaveChoice = 0;
                    try {
                        leaveChoice = int.Parse(System.Console.ReadLine());

                        if (leaveChoice < 0 || leaveChoice > 2) {
                            Console.WriteLine("Diantre, que devons-nous comprendre?");
                        } else if ( leaveChoice == 0) {
                            game = false;
                        } 

                    } catch {
                        Console.WriteLine("Palsambleu Votre Altesse! Votre choix n'est point dans la sainte liste!");                       
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

    private void AddHouse() {
        Array.Resize(ref listHouse, listHouse.Length + 1);
        listHouse[listHouse.Length - 1] = new House();
        this.villageois = listHouse.Length * 10;
    }

    public void MineStone (int nbrVillagers) {
        if (nbrVillagers > this.villageois) {
            System.Console.WriteLine($"Pas assez de villageois! ({villageois} villageois disponibles).");
        } else if (Mine.stoneCost * nbrVillagers > _myRessources.GetStone() || Mine.woodCost * nbrVillagers > _myRessources.GetWood()) {
            System.Console.WriteLine("Ressources insuffisantes!");
        } else {
            _myRessources.UseStone(Mine.stoneCost * nbrVillagers);
            _myRessources.UseWood(Mine.woodCost * nbrVillagers);
            _myRessources.AddStone(mine.MineStone(nbrVillagers));
            Console.WriteLine($"C'est trois Nains qui ... Ah non! {nbrVillagers} villageois ont utilisé: {Mine.woodCost * nbrVillagers}" +
                $"bois et {Mine.stoneCost * nbrVillagers} pierre pour ramèner {mine.MineStone(nbrVillagers)} pierres!\n");
        }
    }

    public void CutWood (int nbrVillagers) {
        if (nbrVillagers > this.villageois) {
            System.Console.WriteLine($"Pas assez de villageois! ({villageois} villageois disponibles).");
        } else if (Forest.stoneCost * nbrVillagers > _myRessources.GetStone() || Forest.woodCost * nbrVillagers > _myRessources.GetWood()) {
            System.Console.WriteLine("Ressources insuffisantes!");
        } else {
            _myRessources.UseStone(Forest.stoneCost * nbrVillagers);
            _myRessources.UseWood(Forest.woodCost * nbrVillagers);
            _myRessources.AddWood(forest.CutWood(nbrVillagers));
            Console.WriteLine($"{nbrVillagers} villageois ont utilisé: {Mine.woodCost * nbrVillagers} " +
                $"bois et {Mine.stoneCost * nbrVillagers} pierre pour ramèner {forest.CutWood(nbrVillagers)} bois!\n");
        }
    }    

    public void BuildHouse (int houseNbr) {
        if (House.stone_needed * houseNbr > _myRessources.GetStone() || House.wood_needed * houseNbr > _myRessources.GetWood()) {
            System.Console.WriteLine("Ressources insuffisantes!");
        } else {
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
        LookAround();
        Console.WriteLine($"Mine améliorée au niveau {_myRessources.level}!");
    }

    public void LookAround () {
        if (_myRessources.level >= 1) {
            _myRessources.AddStone(1);
            _myRessources.AddWood(1);
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
            _myRessources.UseWood(((mine.GetLevel() * 10) + 10) * 10);
            forest.Upgrade();
            Console.WriteLine($"Forêt améliorée au niveau {forest.GetLevel()}!");
        }
    }

    public void GetLevels() { //Methode pour tester la bonne incrémentation des lvl
        System.Console.WriteLine(mine.GetLevel());
        System.Console.WriteLine(forest.GetLevel());
    }

}