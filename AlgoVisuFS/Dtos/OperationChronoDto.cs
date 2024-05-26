using System.ComponentModel.DataAnnotations;

namespace AlgoVisuFS.WebApi.Dtos
{
    public class OperationChronoDto<T>
    {
        [Required]
        public int SequenceNumber { get; set; }
        public T? From { get; set; }
        public T? To { get; set; }
    }
}
