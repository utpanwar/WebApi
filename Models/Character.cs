namespace Controllers.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Robin";    
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defencse { get; set; } = 12;
        public int Intelligence { get; set; } = 11;
        public RpgClass Class { get; set; } = RpgClass.Knight;


    }
}