#   MontyHall.py
import random
from time import time_ns

def montyHall(sampleSize : int, swap : bool) -> None:
    startTime = time_ns()
    print("-----------------------------------------------")

    if swap:
        print("\nWith Swap")
    else:
        print("\nWithout Swap")

    correct = 0
    incorrect = 0

    for sample in range(sampleSize):
        #   doors are represented by numbers 1, 2, 3
        options = [0,1,2]
        notIt = [0,1,2]

        #   The winning door is selected randomly
        hiddenSelection = random.randint(0,2)

        #   The guessed door is selected randomly
        guess = random.randint(0,2)

        #   remove guess from future guess Options
        options.remove(guess)

        #   remove Winning door from list
        notIt.remove(hiddenSelection)

        #   Host cannot remove the guessed door
        if guess != hiddenSelection:
            notIt.remove(guess)

        #   At this point one or two doors can be removed.
        #   Remove one at random
        removedDoor = notIt[random.randint(0, len(notIt)-1)]

        #   remove the removed door from the options
        options.remove(removedDoor)

        #   Swap time
        if swap:
            newGuess = options[0]
        else:
            newGuess = guess

        if newGuess == hiddenSelection:
            correct += 1
        else:
            incorrect += 1
        
    print("\tCorrect     = ", correct)
    print("\tIncorrect   = ", incorrect)
    print(f"\tPercent     = {100*(correct/sampleSize): .2f}" )
    print("\tTotal Count = ", correct + incorrect)

    print("Time(s): ", (time_ns()-startTime)/1000000000)

    print("\n-----------------------------------------------")
    

montyHall(1000000, True)
montyHall(1000000, False)
