import os as sys
import cmd as cmd

def hanoisort(initialArray, tempArray, finalArray, length):
    if (length > 0) :
        print('1: Initial {0} Temp {1} Final {2}  count {3}'.format(initialArray, tempArray, finalArray, length))
        hanoisort(initialArray, finalArray, tempArray, length-1)
        finalArray.append(initialArray.pop())
        hanoisort(tempArray, initialArray, finalArray, length - 1)
        print('2: Initial {0} Temp {1} Final {2} count {3}'.format(initialArray, tempArray, finalArray, length))

if __name__ == "__main__":
       a = [4,3,2,1]
       b = []
       c = []
       hanoisort(a, b, c, len(a))
       print('3: Initial {0} Temp {1} Final {2} count {3}'.format(a, b, c, len(a)))
       # t = (1,2,4,5)
       t = range (2, 20, 2)
       for i, v in enumerate(t):
           print (i, v)
       print (t)
       while True:
           ok = input("Do you want to exit ?")
           if (ok in ('y', 'yes')):
               sys._exit(0)
           else:
                print("Not valid " + ok);
            
