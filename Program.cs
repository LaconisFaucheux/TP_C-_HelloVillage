void Main() {
System.Console.WriteLine(House.wood_needed);
System.Console.WriteLine(House.stone_needed);

House justAHouse = new House();
// justAHouse.wood_needed; //erreur attendue constatée

Village gondolin = new Village("Gondolin");
System.Console.WriteLine(gondolin.getName());
System.Console.WriteLine(gondolin.listHouse.Length);
// gondolin.addHouse();
// gondolin.addHouse();
System.Console.WriteLine(gondolin.villageois);
System.Console.WriteLine("\n");

// gondolin.MineStone(50);
// System.Console.WriteLine(gondolin.GetStone());
// System.Console.WriteLine(gondolin.GetWood());

// gondolin.MineStone(6);
// System.Console.WriteLine(gondolin.GetStone());
// System.Console.WriteLine(gondolin.GetWood());

// gondolin.MineStone(5);
// gondolin.MineStone(5);
// System.Console.WriteLine(gondolin.GetStone());
// System.Console.WriteLine(gondolin.GetWood());

// gondolin.MineStone(5);
// System.Console.WriteLine("\n");

// System.Console.WriteLine(Forest.gainWood);
// System.Console.WriteLine(Forest.stoneCost);
// System.Console.WriteLine(Forest.woodCost);
// Forest test = new Forest();
// test.woodCost; // erreur constatée
// test.gainWood; // erreur constatée
// test.stoneCost; // erreur constatée
System.Console.WriteLine("\n");

gondolin.CutWood(50);
System.Console.WriteLine(gondolin.GetStone());
System.Console.WriteLine(gondolin.GetWood());

gondolin.CutWood(6);
System.Console.WriteLine(gondolin.GetStone());
System.Console.WriteLine(gondolin.GetWood());

gondolin.CutWood(5);
gondolin.CutWood(5);
System.Console.WriteLine(gondolin.GetStone());
System.Console.WriteLine(gondolin.GetWood());

gondolin.CutWood(5);
System.Console.WriteLine("\n");
}

Main();