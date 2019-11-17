
using System;

namespace All_The_Things.Models

{
  public class Item
  {
    public int id { get; set; }

    public int SKU { get; set; }

    public string Name { get; set; }

    public string ShortDescription { get; set; }

    public int NumberInStock { get; set; }

    public int Price { get; set; }

    public DateTime DateOrdered { get; set; } = DateTime.Now;
  }
}