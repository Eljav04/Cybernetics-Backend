using System;
using System.Collections.Generic;

namespace Lesson_55_HT.DAL;

public partial class Contact
{
    public int ContactId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? LocationId { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
}
