public class Forest {
    public static int gainWood = 10;
    public static int stoneCost = 2;
    public static int woodCost = 1;

    public int CutWood(int nbVillagers) {
        return nbVillagers * Forest.gainWood;
    }

}