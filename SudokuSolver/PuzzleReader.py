import SudokuSolver as solver

def makePuzzleTableFromTxtFile(puzzleFile):
    puzzleList = []
    puzzle = []
    puzzleLine = []
    for eachLine in puzzleFile:
        numberLine = list(eachLine)
        for eachElement in numberLine:
            if eachElement.isdigit():
                puzzleLine.append(int(eachElement))
                if len(puzzleLine) == 9:
                    puzzle.append(puzzleLine)
                    puzzleLine = []
                    if len(puzzle) == 9:
                        puzzleList.append(puzzle)
                        puzzle = []
    return puzzleList

   
puzzleFile = open("puzzles.txt", "r")

puzzleList = makePuzzleTableFromTxtFile(puzzleFile)

puzzleFile.close()

solutionFile = open("solutions.txt", "r")

solutionList = makePuzzleTableFromTxtFile(solutionFile)

solutionFile.close()


def printPossible(possible):
    for eachRow in possible:
        line = ""
        for eachSpotList in eachRow:
            line += str(eachSpotList) + "\t"
        print(line)

def printPuzzle(puzzle):
    for puzzleNumber, eachPuzzle in enumerate(puzzle):
        print("\n\t", puzzleNumber)
        for eachLine in eachPuzzle:
            print(eachLine)
        print("\n")

def printPuzzleTable(puzzle):
    for eachLine in puzzle:
        print(eachLine)

printPuzzle(puzzleList)
printPuzzle(solutionList)
for eachPuzzle in puzzleList:
    solution = solver.sudoku(eachPuzzle)
    if solution == None:
        print("no solution found :-(")
    else:
        print("Solved! ---------------------")
        printPuzzleTable(solution)
    