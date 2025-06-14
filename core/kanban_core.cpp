#include "kanban_core.h"

KanbanCore::KanbanCore() {
    columns = {
        {1, "To Do", { {1, "Sample Task"} }},
        {2, "In Progress", {}},
        {3, "Done", {}}
    };
}

void KanbanCore::MoveCard(int cardId, int fromCol, int toCol) {
    auto& from = *std::find_if(columns.begin(), columns.end(), [fromCol](const Column& c){ return c.id == fromCol; });
    auto& to = *std::find_if(columns.begin(), columns.end(), [toCol](const Column& c){ return c.id == toCol; });
    auto it = std::find_if(from.cards.begin(), from.cards.end(), [cardId](const Card& c){ return c.id == cardId; });
    if (it != from.cards.end()) {
        to.cards.push_back(*it);
        from.cards.erase(it);
    }
}