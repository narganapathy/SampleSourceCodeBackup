// SortApp.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "stdio.h"

#define	TRUE 1
#define FALSE 0

int	buffer[10] = {8, 7, 6, 9, 10, 1, 2, 4, 3, 5};
int	masterCopy[10] = {8, 7, 6, 9, 10, 1, 2, 4, 3, 5};

void
SelectionSort(int buffer[], int n)
{
	int		i, j;
	int		temp;

	for ( i = 0; i < n; i++) {
		for (j = i+1; j < n; j++) {
			if (buffer[i] > buffer[j]) {
				temp = buffer[i];
				buffer[i] = buffer[j];
				buffer[j] = temp;
			}
		}
	}
}

void
BubbleSort(int buffer[], int n)
{
	int		i, j;
	int		temp;
	bool	swapped = FALSE;

	for ( j = 0; j < n; j++) {
		for (i = 0; i < (n-j-1); i++) {

			if (buffer[i] > buffer[i+1]) {
				temp = buffer[i+1];
				buffer[i+1] = buffer[i];
				buffer[i] = temp;
				swapped = TRUE;
			}
		}
		if (!swapped) break;
	}
}

int	 mergeBuffer[10];

void
MergeSort(int buffer[], int n)
{
	int	*firstBuffer;
	int	firstLength;
	int	*secondBuffer;
	int	secondLength;
	int	temp, i,j, k;

	// if 1 element its already sorted
	if (n == 1) {
		return;
	}

	// if 2 elements then do a swap to sort
	if (n == 2) {
		if (buffer[0] > buffer[1]) {
			temp = buffer[0];
			buffer[0] = buffer[1];
			buffer[1] = temp;
		}
		return;
	}

	firstBuffer = buffer;
	firstLength = n/2;

	MergeSort(firstBuffer, firstLength);

	secondBuffer = &buffer[n/2];
	secondLength = n - (n/2);

	MergeSort(secondBuffer, secondLength);

	//
	// Merge the two arrays
	//

	i = 0;
	j = 0;
	for (k = 0; k < n; k++) {
		if ((i < firstLength) && (j < secondLength)) {
			if (firstBuffer[i] > secondBuffer[j] ) {
				mergeBuffer[k] = secondBuffer[j];
				j++;
			} else {
				mergeBuffer[k] = firstBuffer[i];
				i++;
			}
		} else if (i < firstLength) { // Still elements in the first buffer
			mergeBuffer[k] = firstBuffer[i];
			i++;
		} else {
			if (j >= secondLength) {
				printf("Assert failure\n");
				return;
			}

			mergeBuffer[k] = secondBuffer[j];
			j++;
		}
	}

	//
	// Copy to the original buffer.
	//

	for (k = 0; k < n; k++) {
		buffer[k] = mergeBuffer[k];
	}
}

int _tmain(int argc, _TCHAR* argv[])
{
	int i;

	printf("SelectionSort: ");
	SelectionSort(buffer, 10);
	for (i = 0; i < 10; i++) {
		printf("%d ", buffer[i]);
	}

	for (i = 0; i < 10; i++) {
		buffer[i] = masterCopy[i];
	}

	printf("\nBubbleSort: ");
	BubbleSort(buffer, 10);
	for (i = 0; i < 10; i++) {
		printf("%d ", buffer[i]);
	}

	for (i = 0; i < 10; i++) {
		buffer[i] = masterCopy[i];
	}
	printf("\nMergeSort: ");
	MergeSort(buffer, 10);
	for (i = 0; i < 10; i++) {
		printf("%d ", buffer[i]);
	}

	return 0;
}
