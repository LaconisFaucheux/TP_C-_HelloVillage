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
System.Console.WriteLine(gondolin.listHouse.Length);
System.Console.WriteLine(gondolin.villageois);


}

Main();