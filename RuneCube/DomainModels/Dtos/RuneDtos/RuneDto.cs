namespace DomainModels.Dtos.RuneDtos
{
    public class RuneDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Color { get; set; }
        public byte Count { get; set; }
        public int MaxResponseTime { get; set; }
        public int EachSideCount { get; set; }
        public int SidesCount { get; set; }

    }
}
