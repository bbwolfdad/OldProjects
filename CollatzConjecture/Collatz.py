#   Collatz.py
#       Austin Downing
#       3n+1 problem
#   Formula
#       If even -> n/2
#       If odd  -> 3n+1

#   imports
import matplotlib.pyplot as plt

#   globals

maxSeed = 10000000
peak = 0
longestSequenceLength = 0
numbers = {}
menuOptions = ["exit", "print seed", "print all", "print associative list", "graph seed"]

#   functions

def checkNumber(number):
    nextNumber = number
    while(nextNumber not in numbers and nextNumber >= 1):
        if nextNumber % 2 == 0:
            nextNumber = evenNumber(nextNumber)
        else:
            nextNumber = oddNumber(nextNumber)

def evenNumber(number):
    nextNumber = int(number/2)
    numbers[number] = nextNumber
    return nextNumber

def oddNumber(number):
    nextNumber = int(3*number + 1)
    numbers[number] = nextNumber
    return nextNumber

def validateInput(message, options):
    while True:
        print(message)
        for eachOption in options:
            print("\t", eachOption)
        response = input("enter one of the above: ")
        if response in options:
            print("response accepted")
            return response
        else:
            print("response regected")

def printSeedSequence(seed):
    if seed in numbers:
        sequenceList = buildSequence(seed)
        printLine = str(seed) + "\t->\t"
        for index, eachSeed in enumerate( sequenceList ):
            printLine = printLine + " " + str(eachSeed)
            if index % 10 == 0:
                printLine += "\n\t\t"
        print(printLine)
    else:
        print("not valid seed")

#   menu functions
def exitMenu():
    return True
def printSeed():
    while(True):
        response = input("What seed do you want to see? ")
        if response.isnumeric() and int(response) in numbers:
            printSeedSequence(int(response))
            return False
        else:
            print("value not valid")
    return False
def printAllNumbers():
    global longestSequenceLength
    for eachNumber in range(1, maxSeed+1):
        sequenceList = [eachNumber]
        nextNumber = eachNumber
        while nextNumber != 1:
            nextNumber = numbers[nextNumber]
            sequenceList.append(nextNumber)
        printLine = str(sequenceList[0]) + "\t ->\t"
        for eachNumber in sequenceList:
            printLine = printLine + " " + str(eachNumber)
        print(printLine)
        if sequenceList.__len__() > longestSequenceLength:
            longestSequenceLength = sequenceList.__len__()
    print("Highest value = ", peak)
    print("longest sequence = ", longestSequenceLength)
    return False

def printAssociativeList():
    print("----Associative List----")
    keys = numbers.keys()
    for eachKey in keys:
        print(eachKey, "\t -> \t ", numbers[eachKey])

def graphSeed():
    figure, axes = plt.subplots()
    seedList = []
    seedList.append(chooseNumber("enter number of seed"))
    response = "yes"
    while response == "yes":
        response = validateInput("Do you want another seed?", ["yes", "no"])
        if response == "yes":
            seedResponse = chooseNumber("enter number of seed")
            if seedResponse in numbers:
                seedList.append(seedResponse)
            else:
                print(str(seedResponse), "not in sequence")
    for seed in seedList:
        if seed in numbers:
            sequenceList = buildSequence(seed)
            print("graphing ", str(seed))
            rangeList = list(range(0, len(sequenceList)))
            axes.plot(rangeList, sequenceList, label=str(seed))
        else:
            print("seed not in number set")
    plt.title("3n+1 where n = " + str(seedList))
    plt.ylabel("n")
    axes.legend()
    plt.grid()
    plt.show()


menuDict = {"exit" : exitMenu, 
            "print seed" : printSeed, 
            "print all" : printAllNumbers, 
            "print associative list" : printAssociativeList,
            "graph seed" : graphSeed
            }
    
def menu():
    done = False
    while(not done):
        response = validateInput("Select menu option", menuOptions)
        done = menuDict[response]()
        
def chooseSeed():
    return chooseNumber("enter max seed number")

def chooseNumber(message):
    while(True):
        response = input(message + ": ")
        if response.isnumeric and int(response) > 1:
            return int(response)
        else:
            print("Input invalid")

def buildSequence(seed):
    if seed in numbers:
        sequenceList = [seed]
        nextNumber = seed
        while nextNumber > 1:
            nextNumber = numbers[nextNumber]
            sequenceList.append(nextNumber)
    return sequenceList

#   Main

maxSeed = chooseSeed()

tenth = int((maxSeed+1) / 10)
if tenth < 1:
    tenth = 1

for eachNumber in range(1, maxSeed+1):
    if eachNumber % tenth == 0:
        print(str(int(eachNumber/tenth)) + "0%")
    if not eachNumber in numbers:
        checkNumber(eachNumber)

peak = max(numbers.values())
peakLocation = []

print("Seed = ", "{:,}".format(maxSeed))
print("Peak = ", "{:,}".format(peak))
print("Quantity of n calculated = ", "{:,}".format((numbers.keys().__len__())))

menu()

