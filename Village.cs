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
            $"0) Afficher le statut de {GetName()}"+
            "1) Bâtir une demeure \n"+
            "2) Quérir de la bonne pierre  \n"+
            "3) Quérir du bois solide \n"+
            "4) Améliorer les pioches (Mine) \n"+ 
            "5) Améliorer les haches (Forêt) \n"+
            "6) Améliorer les dépôts \n"+
            "0) Quitter";

        while (true) {
            System.Console.WriteLine($"Bienvenue à {GetName()}!");
            System.Console.WriteLine("Que souhaitez vous faire?");
            System.Console.WriteLine(action);
            int choice = int.Parse(System.Console.ReadLine());

            switch (choice) {
                case 1:
                System.Console.WriteLine(GetName());
                System.Console.WriteLine($"Vous avez {listHouse.Length} maisons, et donc {villageois} villageois.");
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
        }
    }

    public void UpgradeRessource() {
        _myRessources.Upgrade();
        LookAround();
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
        }
    }

    public void UpgradeForest() {
        if (_myRessources.GetWood() < ((forest.GetLevel() * 10) + 10) * 10) { // J'imagine que tu souhaitais qu'on utilise la méthode GetLevel, sinon j'aurais fait une méthode publique GetGainStone dans la classe Mine
            System.Console.WriteLine("Ressources insuffisantes!");
        } else {
            _myRessources.UseWood(((mine.GetLevel() * 10) + 10) * 10);
            forest.Upgrade();
        }
    }

    public void GetLevels() { //Methode pour tester la bonne incrémentation des lvl
        System.Console.WriteLine(mine.GetLevel());
        System.Console.WriteLine(forest.GetLevel());
    }

}