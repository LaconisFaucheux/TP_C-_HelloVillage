public class Village {
    private string _name;
    private Ressources _myRessources;
    public int villageois = 0;
    public House chefHome;
    public House[] listHouse;
    public Mine mine;


    public Village (string name) {
        this._name = name;
        this._myRessources = new Ressources();
        this.chefHome = new House();
        this.villageois += House.villageois;
        this.listHouse = new House[] {this.chefHome};
        this.mine = new Mine();
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
            for (int i = 0; i < nbrVillagers; i++) {
                _myRessources.UseStone(Mine.stoneCost);
                _myRessources.UseWood(Mine.woodCost);
                _myRessources.AddStone(Mine.gainStone);
            }
        }
    }   
}