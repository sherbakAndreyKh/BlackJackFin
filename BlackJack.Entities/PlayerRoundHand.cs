﻿using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("PlayerRoundHand")]
    public class PlayerRoundHand : BaseEntity
    {
        public int Score { get; set; }

        public long PlayerId { get; set; }
        public long RoundId { get; set; }
    }
}
