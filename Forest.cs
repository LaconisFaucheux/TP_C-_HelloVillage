public class Forest {
    public static int gainWood = 10;
    public static int stoneCost = 2;
    public static int woodCost = 1;
    private int _level = 0;
  
    public int GetLevel() {
        return this._level;
    }
    
    public int CutWood(int nbVillagers) {
        return nbVillagers * Forest.gainWood + _level * 10;
    }

    public void Upgrade() {
        this._level += 1;
    }



}