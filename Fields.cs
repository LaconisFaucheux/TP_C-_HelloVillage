public class Fields {
    public static int gainFood = 10;
    public static int stoneCost = 2;
    public static int woodCost = 1;
    public static int foodCost = 1;
    private int _level = 0;
  
    public int GetLevel() {
        return this._level;
    }
    
    public int GatherFood(int nbVillagers) {
        return nbVillagers * Fields.gainFood + _level * 10;
    }

    public void Upgrade() {
        this._level += 1;
    }



}