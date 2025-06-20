namespace RealStateApp.Application.Dto
{
    public class PropertyImageDto
    {
        public required string IdProperty { get; set; }
        public string? file { get; set; }
        public bool Enabled { get; set; }

    }
}
