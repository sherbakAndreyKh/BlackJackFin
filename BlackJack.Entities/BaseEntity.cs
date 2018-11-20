using System;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
