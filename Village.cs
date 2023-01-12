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
    }

    public string getName() {
        return _name;
    }

    public int GetWood() {
        return _myRessources.GetWood();
    }

    public int GetStone() {
        return _myRessources.GetStone();
    }

    private void addHouse() {
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
                addHouse();
            }
        }
    }
}