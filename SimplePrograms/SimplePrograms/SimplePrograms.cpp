// SimplePrograms.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

typedef struct _node 
{
	struct _node *next;
	struct _node *prev;
	int elem;
} node;

node Head;

#define		NUMELEMENTS 30
node TestArray[NUMELEMENTS];


void InitializeHead()
{
	Head.next = &Head;
	Head.prev = &Head;
}

void InsertHead(node *n)
{
	
	n->prev = &Head;
	n->next = Head.next;
	n->next->prev = n;
	Head.next = n;
}

void InsertTail(node *n)
{
	
	n->next = &Head;
	n->prev = Head.prev;
	n->prev->next = n;
	Head.prev = n;
}

node *RemoveHead()
{
	if (Head.next == &Head)
	{
		return nullptr;
	}

	node *n = Head.next;
	Head.next = n->next;
	n->next->prev = &Head;
	n->next = n->prev = nullptr;
	return n;
}

node *RemoveTail()
{
	if (Head.prev == &Head)
	{
		return nullptr;
	}

	node *n = Head.prev;
	Head.prev = n->prev;
	n->prev->next = &Head;
	n->next = n->prev = nullptr;
	return n;
}

void RemoveNode(node *n)
{
	n->next->prev = n->prev;
	n->prev->next = n->next;
	n->next = n->prev = nullptr;
}


node *SlHead = nullptr;

void
InsertSLHead(node *n)
{
	n->next = SlHead;
	SlHead = n;
}

node *RemoveSLHead()
{

	if (SlHead == nullptr)
	{
		return nullptr;
	}
	node *n = SlHead;
	SlHead = SlHead->next;
	n->next = nullptr;
	return n;
}

node *RemoveSLNode(int elem)
{
	node *n;
	node *prev;
	n = SlHead;
	prev = nullptr;
	while ( n != nullptr)
	{
		if (n->elem == elem)
		{
			if (prev == nullptr)
			{
				SlHead = n->next;
				return n;
			} 
			else
			{
				prev->next = n->next;
				return n;
			}
		}
		prev = n;
		n = n->next;
	}
	return nullptr;
}

void ReverseSLList()
{
	node *n;
	node *prev = nullptr;
	node *next = nullptr;
	n = SlHead;
	while ( n != nullptr)
	{
		next = n->next;
		n->next = prev;
		prev = n;
		n = next;
	}
	SlHead = prev;
}

int _tmain(int argc, _TCHAR* argv[])
{
	InitializeHead();
	node *n;
	for (int i = 0; i < NUMELEMENTS; i++)
	{
		n = &TestArray[i];
		n->elem = i;
		InsertHead(n);
	}


	while ((n = RemoveTail()) != nullptr)
	{
		printf("removetail Node element %d\n", n->elem);
	}

	for (int i = 0; i < NUMELEMENTS; i++)
	{
		n = &TestArray[i];
		InsertTail(n);
	}


	while ((n = RemoveHead()) != nullptr)
	{
		printf("removehead Node element %d\n", n->elem);
	}

	for (int i = 0; i < NUMELEMENTS; i++)
	{
		n = &TestArray[i];
		InsertTail(n);
	}

	for (int i = 0; i < NUMELEMENTS; i++)
	{
		n = &TestArray[i];
		RemoveNode(n);
	}

	if ((Head.next == &Head) && (Head.prev == &Head))
	{
		printf("Final list is empty\n");
	}


	for (int i = 0; i < NUMELEMENTS; i++)
	{
		n = &TestArray[i];
		InsertSLHead(n);
	}

	while ((n = RemoveSLHead()) != nullptr)
	{
		printf("removeSLhead Node element %d\n", n->elem);
	}

	for (int i = 0; i < NUMELEMENTS; i++)
	{
		n = &TestArray[i];
		InsertSLHead(n);
	}
	
	for (int i = 0; i < NUMELEMENTS; i++)
	{
		n = &TestArray[i];
		RemoveSLNode(i);
	}
	if (SlHead == nullptr)
	{
		printf("Singly list is empty\n");
	}
	for (int i = 0; i < NUMELEMENTS; i++)
	{
		n = &TestArray[i];
		InsertSLHead(n);
	}
	ReverseSLList();
	n = SlHead;
	while (n != nullptr)
	{
		printf("After reverse %d\n", n->elem);
		n = n->next;
	}
	return 0;
}