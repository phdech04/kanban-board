using System.Collections.Generic;
using System.Linq;

public class KanbanService
{
    public List<Column> Columns { get; set; }
    public KanbanService()
    {
        Columns = new List<Column>
        {
            new Column { Id = 1, Title = "To Do", Cards = new List<Card> { new Card { Id = 1, Title = "Sample Task" } } },
            new Column { Id = 2, Title = "In Progress", Cards = new List<Card>() },
            new Column { Id = 3, Title = "Done", Cards = new List<Card>() }
        };
    }

    public void MoveCard(int cardId, int fromCol, int toCol)
    {
        var from = Columns.First(c => c.Id == fromCol);
        var to = Columns.First(c => c.Id == toCol);
        var card = from.Cards.First(c => c.Id == cardId);
        from.Cards.Remove(card);
        to.Cards.Add(card);
    }
}