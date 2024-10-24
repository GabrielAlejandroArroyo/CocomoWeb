namespace CocomoBackend.DTOs
{
    public class CocomoVersionUpdateDTO
    {
        public int Id { get; set; }

        public int IdCocomoHead { get; set; }

        public string Version { get; set; }

        public int IdCocomoStateVersion { get; set; }
    }
}
