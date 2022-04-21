#   Pieces.py

LOCATIONS = ["foyer", "bedroom", "bathroom", "dinning", "kitchen", "trash heap"]
CHARACTERS = ["blue", "red", "yellow", "green", "white", "orange", "indigo", "violet"]
WEPONS = ["words", "pen", "sword", "wrench", "paper", "mean name"]
ALLCARDS = LOCATIONS + CHARACTERS + WEPONS
LongestName = 0
RemainingCharacters = CHARACTERS.copy()
HumanPlayer = None
ComputerPlayers = []
playerCountOptions = ["2", "3", "4", "5", "6", "7", "8"]
WINNINGSET = []
CardsToDeal = []
ALLPLAYERS = []
TURNCOUNTER = 0
currentPlayer = None

#   Pieces functions

def resetPieces():
    global RemainingCharacters
    global HumanPlayer
    global ComputerPlayers
    global WINNINGSET
    global CardsToDeal
    global ALLPLAYERS
    global TURNCOUNTER
    global currentPlayer
    global LongestName

    RemainingCharacters = CHARACTERS.copy()
    HumanPlayer = None
    ComputerPlayers = []
    WINNINGSET = []
    CardsToDeal = []
    ALLPLAYERS = []
    TURNCOUNTER = 0
    currentPlayer = None
    LongestName = calculateLongest()
    
def calculateLongest():
    global ALLCARDS
    longestName = 0
    for eachCard in ALLCARDS:
        if longestName < eachCard.__len__():
            longestName = eachCard.__len__()
    return longestName
    
    

def assemblePlayerList():
    if not HumanPlayer == None:
        ALLPLAYERS.append(HumanPlayer)
    for eachCPUPlayer in ComputerPlayers:
        ALLPLAYERS.append(eachCPUPlayer)

def printComputerPlayers():
    print("Computer Players:")
    for eachComputerPlayer in ComputerPlayers:
        eachComputerPlayer.printPlayer()

def printAllPlayers():
    print("----- All Players -----")
    for eachPlayer in ALLPLAYERS:
        eachPlayer.printPlayer()
    print("-----------------------")

def printTurnOrder():
    print("---- Turn Order ----")
    for index, eachPlayer in enumerate(ALLPLAYERS):
        print("\t", index, "\t", eachPlayer.character)

def playerNameFromIndex(index):
    return ALLPLAYERS[index % ALLPLAYERS.__len__()]