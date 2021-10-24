using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.Api.Models
{
  public class Users : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }

  }
}