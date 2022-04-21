import copy


tableSections = {
    0   :   0,
    1   :   0,
    2   :   0,
    3   :   3,
    4   :   3,
    5   :   3,
    6   :   6,
    7   :   6,
    8   :   6,
}

def sudoku(puzzle):
    print("puzzle: ")
    for eachLine in puzzle:
        print(eachLine)
    print("\n")
    solution = copy.deepcopy(puzzle)
    tableNotDone = True
    possibleTable = generatePossibleTable(solution)
    while tableNotDone:
        tableUpdateable = updatePuzzle(solution, possibleTable)
        xyWingElimination(possibleTable)
        tableNotDone = checkIfTableIsDone(solution)
        if (not tableUpdateable) and tableNotDone:
            print("final solution in stuck state ")
            for eachRow in solution:
                print(eachRow)
            #printPossible(possibleTable)
            input("Stuck\nhit enter to continue: ") 
            return None
    return solution

def xyWingElimination(possibleTable):
    for rowIndex, eachRow in enumerate(possibleTable):
        for columnIndex, eachColumn in enumerate(eachRow):
            if len(eachColumn) == 2:
                #   check for other two entry cells it intercects with
                listOfIntersectingCells = getListOfIntersectingCells(rowIndex, columnIndex)
                listOfSizeTwoCells = []
                for eachCell in listOfIntersectingCells:
                    if not len(possibleTable[eachCell[0]][eachCell[1]]) == 2:
                        listOfSizeTwoCells.append(eachCell)

def getListOfIntersectingCells( rowIndex, columnIndex):
    columnIntersections = getColumnIntersections( rowIndex, columnIndex)
    rowIntersections = getRowIntersections( rowIndex, columnIndex)
    squareIntersections = getSquareIntersections( rowIndex, columnIndex)
    return set(columnIntersections + rowIntersections + squareIntersections)

def getColumnIntersections( rowIndex, columnIndex):
    columnIntersections = []
    for eachRow in range(0, 9):
        if not eachRow == rowIndex:
            columnIntersections.append((eachRow, columnIndex))
    return columnIntersections
    
def getRowIntersections( rowIndex, columnIndex):
    rowIntersections = []
    for eachColumn in range(0, 9):
        if not eachColumn == columnIndex:
            rowIntersections.append((rowIndex, eachColumn))
    return rowIntersections
    
def getSquareIntersections( rowIndex, columnIndex):
    squareIntersections = []
    rowSection = tableSections[rowIndex]
    columnSection = tableSections[columnIndex]
    for eachRow in range(3):
        for eachColumn in range(3):
            if eachRow + rowSection == rowIndex and eachColumn + columnSection == columnIndex:
                pass
            else:
                squareIntersections.append((rowSection+eachRow, columnSection+eachColumn))
    return squareIntersections

def checkIfTableIsDone(puzzle):
    for eachLine in puzzle:
        if 0 in eachLine:
            return True

    return False

def removeNumberFromPossible( possibleTable, lineNumber, spotNumber, numberToRemove):
    #   remove from row
    for eachPossibleList in possibleTable[lineNumber]:
        try:
            eachPossibleList.remove(numberToRemove)
        except ValueError:
            pass
    #   remove from column
    for eachRow in possibleTable:
        try:
            eachRow[spotNumber].remove(numberToRemove)
        except ValueError:
            pass
    #   remove from square
    lineNumberSection = tableSections[lineNumber]
    spotNumberSection = tableSections[spotNumber]
    for eachLineInRange in range(3):
        for eachSpotInRange in range(3):
            try:
                possibleTable[lineNumberSection+eachLineInRange][spotNumberSection+eachSpotInRange].remove(numberToRemove)
            except ValueError:
                pass


def updatePuzzle(puzzle, possibleTable):
    tableUpdateable = False
    for lineNumber, eachLine in enumerate(possibleTable):
        for spotNumber, eachPossibleList in enumerate(eachLine):
            if len(eachPossibleList) == 1 and not eachPossibleList[0] == "x":
                puzzle[lineNumber][spotNumber] = eachPossibleList[0]
                removeNumberFromPossible( possibleTable, lineNumber, spotNumber, eachPossibleList[0])
                possibleTable[lineNumber][spotNumber] = ["x"]
                tableUpdateable = True
    return tableUpdateable

def checkSquare(puzzle, lineNumber, spotInLine, number):
    lineNumberRange = tableSections[lineNumber]
    spotNumberRange = tableSections[spotInLine]
    if(
        puzzle[lineNumberRange][spotNumberRange] == number or
        puzzle[lineNumberRange][spotNumberRange+1] == number or
        puzzle[lineNumberRange][spotNumberRange+2] == number or
        puzzle[lineNumberRange+1][spotNumberRange] == number or
        puzzle[lineNumberRange+1][spotNumberRange+1] == number or
        puzzle[lineNumberRange+1][spotNumberRange+2] == number or
        puzzle[lineNumberRange+2][spotNumberRange] == number or
        puzzle[lineNumberRange+2][spotNumberRange+1] == number or
        puzzle[lineNumberRange+2][spotNumberRange+2] == number 
    ):
        return False
    else:
        return True

def checkRow(puzzle, lineNumber, spotInLine, number):
    if number in puzzle[lineNumber]:
        return False
    else:
        return True

def checkColumn(puzzle, lineNumber, spotInLine, number):
    for eachNumber in range(0, 9):    
        if(puzzle[eachNumber][spotInLine] == number):
            return False

    return True

def generatePossibleTable(puzzle):    
    possibleTable = []
    for lineNumber, eachLine in enumerate( puzzle ):
        possibleTableLine = []
        for spotInLine, eachSpot in enumerate( eachLine ):
            possibleNumberList = []
            if eachLine[spotInLine] == 0:
                for eachNumber in range(1, 10):
                    if (
                        checkSquare(puzzle, lineNumber, spotInLine, eachNumber ) and
                        checkRow(puzzle, lineNumber, spotInLine, eachNumber ) and
                        checkColumn(puzzle, lineNumber, spotInLine, eachNumber ) 
                        ):
                        possibleNumberList.append(eachNumber)
                possibleTableLine.append(possibleNumberList)
            else:
                possibleTableLine.append(["x"])
        possibleTable.append(possibleTableLine)
    print("--------------")
    for eachLine in possibleTable:
        print(eachLine)
    print("\n")
    return possibleTable


