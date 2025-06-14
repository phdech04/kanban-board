using System.Collections.Generic;
public class Card { public int Id { get; set; } public string Title { get; set; } }
public class Column { public int Id { get; set; } public string Title { get; set; } public List<Card> Cards { get; set; } }