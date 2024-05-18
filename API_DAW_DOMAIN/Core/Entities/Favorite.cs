using System;
using System.Collections.Generic;

namespace API_DAW_DOMAIN.Core.Entities;

public partial class Favorite
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? CreatedAt { get; set; }
}
