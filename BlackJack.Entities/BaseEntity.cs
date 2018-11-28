using System;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Entities
{
	//TODO: абстрактным классом сделать +
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
