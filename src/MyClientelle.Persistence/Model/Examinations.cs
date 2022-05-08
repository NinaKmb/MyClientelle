namespace Kampa.MyClientelle.Persistence.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kampa.MyClientelle.Persistence.Helpers;

public class Examinations : Entity<long>
{
  public string Exam { get; set; } = string.Empty;
}
