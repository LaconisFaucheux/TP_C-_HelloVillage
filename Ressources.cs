public class Ressources {
    private int _food;
    private int _foodMax = 250;
    private int _woods;
    private int _woodMax = 250;
    private int _stones;
    private int _stonesMax = 250;
    public int level = 0;

    public Ressources() {
        this._woods = 10;
        this._stones = 10;
        this._food = 10;
    }

    public int GetWood() {
        return _woods;
    }

    public int GetStone() {
        return _stones;
    }

    public int GetFood() {
        return _food;
    } 

    public int GetMax() { //Dans la mesure o� le d�p�t fait augmenter simultan�ment bois et pierre, inutile de faire un getter diff�renci�
        return _woodMax;
    }

    public void UseStone(int nbr) {
        if (nbr <= this._stones) this._stones -= nbr;
    }

    public void UseWood(int nbr) {
        if (nbr <= this._woods) this._woods -= nbr;
    }

    public void UseFood(int nbr) {
        if (nbr <= this._food) this._food -= nbr;
    } 

    public void AddStone (int nbr) {
        if (this._stones + nbr > _stonesMax){
            this._stones = _stonesMax;
            System.Console.WriteLine("Maximum de pierres atteint!");
        } else {            
            this._stones += nbr;
        }
    }

    public void AddWood (int nbr) {
        if (this._woods + nbr > _woodMax){
            this._woods = _woodMax;
            System.Console.WriteLine("Maximum de bois atteint!");
        } else {
            this._woods += nbr;            
        }
    }

    public void AddFood (int nbr) {
        if (this._food + nbr > _foodMax){
            this._food = _foodMax;
            System.Console.WriteLine("Maximum de nourriture atteint!");
        } else {
            this._food += nbr;            
        }
    }

    public void Upgrade() {
        int woodCost = _woodMax * (80/100);
        int stoneCost = _stonesMax * (80/100);
        int foodCost = _foodMax * (80/100);

        if (this._woods < woodCost || this._stones < stoneCost || this._food < foodCost) {
            System.Console.WriteLine("Ressources insuffisantes");
        } else {
            _woodMax *= 2;
            _stonesMax *= 2;
            _foodMax *= 2;
            _woods -= woodCost;
            _stones -= stoneCost;
            _food -= foodCost;
            this.level++;
        }
    }
}