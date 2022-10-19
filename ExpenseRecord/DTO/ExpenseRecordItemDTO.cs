using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseRecord.DTO
{
    public class ERItemDTO
    {
        public int? Id { get; set; }

        public string? Description { get; set; }

        public string? Type { get; set; }

        public string? Amount { get; set; }

        public string? Date { get; set; }

    }
}
