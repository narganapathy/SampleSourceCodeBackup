// BinaryTree.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "stdlib.h"
#include "stdio.h"
#include "malloc.h"

#define	TRUE 1
#define	FALSE 0

typedef struct _Element {
	struct _Element *left;
	struct _Element *right;
	int		value;
} Element;

Element *Root = NULL;

void
InsertElement(
	int	val
	)
{
	Element	*current,  *parent, *node;

	current = Root;

	node = (Element *)malloc(sizeof(Element));
	if (!node) {
		return;
	}

	node->value = val;
	node->left = node->right  = NULL;

	if (Root == NULL) {
		Root = node;
		return;
	}

	while (current) {
		parent = current;
		if (current->value > val) {
			current = current->left;
		} else {
			current = current->right;
		}
	}

	if (val < parent->value) {
		parent->left = node;
	} else {
		parent->right = node;
	}
}

void
DFSVisitNode(Element *node)
{
	if (node->left) {
		DFSVisitNode(node->left);
	} 

	printf("%d ", node->value);

	if (node->right) {
		DFSVisitNode(node->right);
	}
}

void
BFSVisitNode(Element *node)
{
	printf("%d ", node->value);
	if (node->left) {
		BFSVisitNode(node->left);
	} 

	if (node->right) {
		BFSVisitNode(node->right);
	}
}


void
DeleteElement(
	  Element *parent,
	  Element *current,
	  bool		left
	  )
{
	Element	*nextLargest;

	if (parent == NULL) { // We are removing the root
		Root = current->right;
		if (current->left == NULL) {
			Root = current->right;
		} else if (current->right == NULL) {
			Root = current->left;
		} else {
			// get the next largest node after current
			nextLargest = current->right;
			while (nextLargest->left) {
				nextLargest = nextLargest->left;
			}
			nextLargest->left = current->left;
			Root = current->right;
		}
	}

	if (current->left == NULL) {
		if (left) {
			parent->left = current->right;
		} else {
			parent->right = current->right;
		}
	} else if (current->right == NULL) {
		if (left) {
			parent->left = current->left;
		} else {
			parent->right = current->left;
		}
	} else {	// Both children are present
		// get the next largest node after current
		nextLargest = current->right;
		while (nextLargest->left) {
			nextLargest = nextLargest->left;
		}
		nextLargest->left = current->left;
		if (left ) { 
			 parent->left = current->right;
		} else {
			parent->right = current->right;
		}
		
		/*
		 * Another approach
		// get the next smallest node after current
		nextSmallest = current->left;
		while (nextSmallest) {
			nextSmallest = nextSmallest->right;
		}
		nextSmallest->right = current->right;
		if (left ) { 
			 parent->left = current->left;
		} else {
			parent->right = current->left;
		}
		*/
	}
}
void
RemoveElement(int val)
{
	bool left;
	Element *current, *parent;

	current = Root;
	parent = NULL;
	while (current) {
		if (current->value == val) {
			printf("element %d found\n", val);
			DeleteElement(parent, current, left);
			return;
		} 
		parent = current;	
		if (current->value < val) {
			current = current->right;
			left = FALSE;
		} else {
			current = current->left;
			left = TRUE;
		}
	}
	printf("element %d not found\n", val);
}


int	range_min = 10;
int range_max = 20000;

int
GetRandomNumber()
{
	int u = (double)rand()/(RAND_MAX + 1) *(range_max - range_min);
	return (u + range_min);
}

int	elements[30];

int _tmain(int argc, _TCHAR* argv[])
{
	int i;
	for (i = 0; i < 30; i ++) {
		elements[i] = GetRandomNumber();
		InsertElement(elements[i]);
	}

	printf("Depth first search\n");
	DFSVisitNode(Root);
	printf("\n");
	printf("Breadth first search\n");
	BFSVisitNode(Root);

	for (i = 4; i < 10; i++ ) {
		RemoveElement(elements[i]);
		printf("Depth first search removing %d\n", elements[i]);
		DFSVisitNode(Root);
		printf("\n");
	}

	return 0;
}
