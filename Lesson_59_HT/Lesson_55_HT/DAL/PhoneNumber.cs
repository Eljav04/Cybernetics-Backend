using System;
using System.Collections.Generic;

namespace Lesson_55_HT.DAL;

public partial class PhoneNumber
{
    public int PhoneNumberId { get; set; }

    public int? ContactId { get; set; }

    public string PhoneNumber1 { get; set; } = null!;

    public virtual Contact? Contact { get; set; }
}
