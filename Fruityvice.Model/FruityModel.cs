﻿namespace Fruityvice.Model
{
    public class FruityModel
    {
        public int Id { get; set; }
        public string Genus { get; set; }
        public string? Name { get; set; }
        public string Family { get; set; }
        public string? Order { get; set; }
        public int NutritionsId { get; set; }
    }
}
