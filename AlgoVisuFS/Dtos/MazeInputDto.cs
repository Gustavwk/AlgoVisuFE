using System.ComponentModel.DataAnnotations;

namespace AlgoVisuFS.WebApi.Dtos
{
    public class MazeInputDto
    {
        [Required]
        public MazeModelDto MazeModel { get; set; }
        [Required]
        public CellGetDto starCell { get; set; }
    }
}
