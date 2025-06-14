#pragma once
#include <vector>
#include <string>

struct Card { int id; std::string title; };
struct Column { int id; std::string title; std::vector<Card> cards; };

class KanbanCore {
public:
    std::vector<Column> columns;
    KanbanCore();
    void MoveCard(int cardId, int fromCol, int toCol);
};