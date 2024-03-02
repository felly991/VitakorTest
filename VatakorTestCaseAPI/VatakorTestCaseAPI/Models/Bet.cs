using System;
using System.Collections.Generic;

namespace VatakorTestCaseAPI.Models;

public partial class Bet
{
    public int Id { get; set; }

    public int? Usersid { get; set; }

    public int? Lotid { get; set; }

    public int? Salary { get; set; }

    public Lot? Lot { get; set; }

    public User? Users { get; set; }
}
