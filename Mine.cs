public class Mine {
    public static int gainStone = 10;
    public static int stoneCost = 2;
    public static int woodCost = 1;

    private int _level = 0;

    public Mine() {
        System.Console.WriteLine("La mine a été crée!");
    }

    public int GetLevel() {
        return this._level;
    }

    public int MineStone(int nbVillagers) {
        return nbVillagers * Mine.gainStone + _level * 10;
    }

    public void Upgrade() {
        this._level += 1;
    }

    

}