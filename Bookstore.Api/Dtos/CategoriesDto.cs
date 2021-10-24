using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Api.Dtos
{
  public class CategoryCreateDto
  {
    [Required]
    [MaxLength(100, ErrorMessage = "This field must have only 100 character.")]
    [MinLength(3, ErrorMessage = "This field must have at least 3 character.")]
    public string nome { get; set; }
  }

  public class CategoryUpdateDto : CategoryCreateDto { }

  public class CategoryReadDto
  {
    public int Id { get; set; }
    public string nome { get; set; }
    public IList<BooksReadDto> Books { get; set; }

  }

}