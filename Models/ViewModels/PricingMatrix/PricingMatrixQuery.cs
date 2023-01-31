namespace Models.ViewModels.PricingMatrix
{
	public class PricingMatrixQuery
	{
		public short? ModelId { get; set; }
		
		public byte? MemorySizeId { get; set; }
		
		public byte? GradeId { get; set; }

        public string? ModelName { get; set; }
    }
}
