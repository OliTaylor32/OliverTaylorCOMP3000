[System.Serializable]
public class MainGameData
{
    //Player Data
    public int gold;
    public int speedXP;
    public int attackXP;
    public int boostXP;
    public int lastArea; //0-Solicia, 1-Solicia2, 2-Solicia3
    public int speedLvl;
    public int attackLvl;
    public int boostLvl;
    public int headwear;
    public int costume;
    public int gloves;
    public int shoes;

    //Solicia Data
    public int solicia1; //0-not completed, 1-C, 2-B, 3-A
    public int solicia2; //-1 not unlocked, 0-not completed, 1-C, 2-B, 3-A
    public bool sQuest1; //Talking to veg seller
    public bool sQuest2; //Finding the Wallet
    public bool sChest1;
    public bool sChest2;
    public bool sChest3;
    public bool sChest4;

    public MainGameData(int gold, int speedXP, int attackXP, int boostXP, int lastArea, int speedlvl, int attacklvl, int boostlvl, int headwear, int costume, int gloves, int shoes,
        int solicia1, int solicia2, bool sQuest1, bool sQuest2, bool sChest1, bool sChest2, bool sChest3, bool sChest4)
    {
        this.gold = gold;
        this.speedXP = speedXP;
        this.attackXP = attackXP;
        this.boostXP = boostXP;
        this.lastArea = lastArea;
        this.speedLvl = speedlvl;
        this.attackLvl = attacklvl;
        this.boostLvl = boostlvl;
        this.headwear = headwear;
        this.costume = costume;
        this.gloves = gloves;
        this.shoes = shoes;

        this.solicia1 = solicia1;
        this.solicia2 = solicia2;
        this.sQuest1 = sQuest1;
        this.sQuest2 = sQuest2;
        this.sChest1 = sChest1;
        this.sChest2 = sChest2;
        this.sChest3 = sChest3;
        this.sChest4 = sChest4;
    }

}
