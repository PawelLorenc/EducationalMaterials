namespace Data.Entities
{
    public record Review
    {
        public int Id { get; set; }

        public int MaterialNAvigationPointId { get; set; }
        public MaterialNavigationPoint Material { get; set; }

        public string TextReview { get; set; }

        [Range(1, 10,
            ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int PointReview { get; set; }

    }
}