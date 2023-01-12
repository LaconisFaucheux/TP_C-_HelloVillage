public class Ressources {
    private int _woods;
    private int _stones;

    public Ressources() {
        this._woods = 10;
        this._stones = 10;
    }

    public int GetWood() {
        return _woods;
    }

    public int GetStone() {
        return _stones;
    }

    public void UseStone(int nbr) {
        if (nbr <= this._stones) this._stones -= nbr;
    }

    public void UseWood(int nbr) {
        if (nbr <= this._woods) this._woods -= nbr;
    }

    public void AddStone (int nbr) {
        this._stones += nbr;
    }

    public void AddWood (int nbr) {
        this._woods += nbr;
    }
}