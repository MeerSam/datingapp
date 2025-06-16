using System;
using System.ComponentModel.DataAnnotations;
namespace API.Entities;

public class AppUser
// class represents a table in a database
{ 
    public int Id { get; set; }
    public required string UserName { get; set; }

}
 