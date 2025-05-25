using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public abstract class BaseEntity
    {
        [Key] // Eğer Id dışında başka isimde ve/veya tipte bir öncelikli anahtar (primary key) belirlemek istersek bu özellik (Property/Method/Class Attributes) yazılır.
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
        public bool Deleted { get; set; } = false;
    }
}
