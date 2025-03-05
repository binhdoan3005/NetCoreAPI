using System.ComponentModel.DataAnnotations;
using MvcMovie.Models;
namespace MvcMovie;

public class Employee : Person 
{
    public string EmployeeId { get; set; }
    public int Age { get; set; }
}
