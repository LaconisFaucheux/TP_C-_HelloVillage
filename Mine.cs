public class Mine {
    public static int gainStone = 10;
    public static int stoneCost = 2;
    public static int woodCost = 1;

    public Mine() {
        System.Console.WriteLine("La mine a été crée!");
    }

    public int MineStone(int nbVillagers) {
        return nbVillagers * Mine.gainStone;
    }

}