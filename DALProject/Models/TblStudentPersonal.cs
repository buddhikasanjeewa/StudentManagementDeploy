using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class TblStudentPersonal
{
    public Guid Uid { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Nic { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public string? Address { get; set; }
  
    public byte[]? Profile_Image { get; set; } = Array.Empty<byte>();
}
