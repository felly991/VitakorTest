using System;
using System.Collections.Generic;

namespace VatakorTestCaseAPI.Models;

public partial class Lot
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? StartBet { get; set; }

    public bool? Alive { get; set; }

    public DateTime? DateCreated { get; set; }

    public List<Bet> Bets { get; set; } = new List<Bet>();

    public List<User> Users { get; set; } = new List<User>();
}
