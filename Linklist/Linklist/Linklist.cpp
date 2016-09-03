// Linklist.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

struct Element {
	struct Element *flink;
	struct Element *blink;
	int	value;
};

struct Element head;

int _tmain(int argc, _TCHAR* argv[])
{
	return 0;
}

Void
InitializeListHead()
{
	head.blink = &head;
	head.flink = &head;
	head.value = 0;
}

InsertListEntry( struct Element *node, bool insertAtHead)
{
	struct	Element *lastEntry;
	struct	Element *firstEntry;

	if (insertAtHead) {
		firstEntry = head.flink;
		firstEntry->blink = node;
		node->flink = firstEntry;
		node->blink = head;
		head.flink = node;
	} else {
		lastEntry = head.blink;
		lastEntry->flink = node;
		node->blink = lastEntry;
		node->flink = head;
		head.blink = node;
	}
}

RemoveListEntry(struct Element *node)
{
	struct Element *prev;
	struct Element *next;

	prev = node->blink;
	next = node->flink;

	prev->flink = next;
	next->blink = prev;
	node->blink = node;
	node->flink = node;
}

struct Element *
RemoveHeadList()
{
	struct Element *firstEntry;
	struct Element *nextEntry;

	firstEntry = head.flink;
	nextEntry = firstEntry->flink;
	head.flink = nextEntry;
	nextEntry->blink = &head;

	return firstEntry;
}

struct Element *
RemoveTailList()
{
	struct Element *firstEntry;
	struct Element *nextEntry;

	firstEntry = head.blink;
	nextEntry = firstEntry->blink;
	head.blink = nextEntry;
	nextEntry->flink = &head;

	return firstEntry;
}