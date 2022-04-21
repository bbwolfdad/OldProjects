#   ----------------------------
#   Austin Downing
#   10/28/2020
#   PascalsTriangle.py
#   ----------------------------

import sys
import time

startTime = time.time()

correctForm = "pascalsTriangle.py <interger>"

if sys.argv.__len__() < 2:
    exit("too few arguments: " + correctForm)
elif sys.argv.__len__() > 2:
    exit("too many arguments: " + correctForm)

levels = int(sys.argv[1]) # number of triangle levels to make

if levels < 1:
    exit("number of levels too low. Must be greater than or equal to 1")

print("number of levels to print ", levels)

levelArray = []
currentLevel = []
previousLevel = []


for currentLevelIndex in range(0, levels):
    currentLevel = []
    for currentEntryIndex in range(0, currentLevelIndex + 1):
        if currentEntryIndex == 0:
            currentLevel.append(1)
        elif currentEntryIndex == currentLevelIndex:
            currentLevel.append(1)
        else:
            currentLevel.append( previousLevel.__getitem__(currentEntryIndex - 1) + previousLevel.__getitem__(currentEntryIndex) )
    previousLevel = currentLevel.copy()
    levelArray.append(currentLevel.copy())

outputFile = open("output.pascal", "w")

stopTime = time.time()

outputFile.write("Time to compute: " + str(stopTime - startTime) + "\n" )
outputFile.write(f"Number of levels in Triangle = {levels}\n\n")
print("Time to compute: " + str(stopTime - startTime) )
currentLevelString = ""
tenth = int(levels/10) + 1
for currentLevelIndex in range(0, levels):
    currentLevel = levelArray.__getitem__(currentLevelIndex)
    #currentLevelString = ""
    for currentEntryIndex in range(0, currentLevelIndex + 1):
        currentLevelString = currentLevelString + " " + str(currentLevel.__getitem__(currentEntryIndex)) + ""
    currentLevelString = currentLevelString + "\n"
    if currentLevelIndex % tenth == 0:
        print("currently writing line ", currentLevelIndex)
        print("percent Complete: ", int((currentLevelIndex / levels) * 100))
        print("current time: ", time.time() - stopTime)
    #print(currentLevelString)
    #outputFile.write(currentLevelString)
outputFile.write(currentLevelString)
outputFile.write("\n\n")

creatingFileTimeEnd = time.time()
print("Time to create file: " + str(creatingFileTimeEnd - stopTime) )
outputFile.write("Time to create file: " + str(creatingFileTimeEnd - stopTime) )

outputFile.close()
