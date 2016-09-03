// AvlTree.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

typedef struct _node {
	struct _node *left;
	struct _node *right;
	int elem;
	int height;
} node;

node *root;

int _tmain(int argc, _TCHAR* argv[])
{
	return 0;
}

void
Insert(int elem, node *n, node **parent)
{
	if (n == nullptr) {
		node *n1 = new node();
		n1->elem = elem;
		n1->right = nullptr;
		n1->left = 0;
		n1->height = 0;
		*parent = n1;
	} else {
		if (n->elem > elem) {
			Insert(elem, n->left, &n->left);
		} else {
			Insert(elem, n->right, &n->right);
		}
	}

	if (Difference(n) > 0)
	{
		BalanceRight(n);
	}
	else
	{
		BalanceLeft(n);
	}
	FixHeight(n);
}

void
FixHeight (node *n)
{
	int rtHeight, ltHeight;

	if (n->right == nullptr) {
		rtHeight = -1;
	} else {
		rtHeight = n->right->height;
	}

	if (n->left == nullptr) {
		ltHeight = -1;
	} else {
		ltHeight = n->left->height;
	}

	if (ltHeight > rtHeight) {
		n->height = ltHeight + 1;
	} else {
		n->height = rtHeight + 1;
	}
}

int Difference(node *n)
{
	int diff;
	int ltHeight, rtHeight;
	if (n->left == nullptr) {
		ltHeight = -1;
	}
	else
	{
		ltHeight = n->left->height;
	}
	if (n->right == nullptr) {
		rtHeight = -1;
	} 
	else
	{
		rtHeight = n->right->height;
	}
	return (ltHeight-rtHeight);
}
