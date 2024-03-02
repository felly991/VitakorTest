using System;
using System.Collections.Generic;

namespace VatakorTestCaseAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly? Birthday { get; set; }

    public List<Bet> Bets { get; set; } = new List<Bet>();

    public List<Lot> Lots { get; set; } = new List<Lot>();
}
