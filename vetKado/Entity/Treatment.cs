namespace vetKado.Entity
{
    public class Treatment
    {
        public int TreatmentId { get; set; }
        public DateTime Date { get; set; }=DateTime.Now;
        public string Type { get; set; }
        public string Medicine { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
