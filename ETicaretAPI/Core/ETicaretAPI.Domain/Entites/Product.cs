using System;
using ETicaretAPI.Domain.Entites.Common;

namespace ETicaretAPI.Domain.Entites
{
	public class Product:BaseEntity
	{
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }

        public ICollection<Order> Orders { get; set; }




    }
}

