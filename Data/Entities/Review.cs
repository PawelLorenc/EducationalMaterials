namespace Data.Entities
{
    public record Review
    {
        public int id { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public string TextReview { get; set; }

        [Range(1, 10,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int PointReview { get; set; }

    }
}