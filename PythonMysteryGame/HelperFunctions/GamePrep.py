#   GamePrep.py
import HelperFunctions.Pieces as Pieces
import HelperFunctions.General as General
import random
import HelperFunctions.Players as Players

def resetBoard():
    print("work to do")
    Pieces.resetPieces()

def startMysteryGame():
    print("----------------- Starting Game -----------------")
    #   ask for number of players (2-8)
    playerCount = int(General.validatingInput("How many players?", Pieces.playerCountOptions))
    #   ask for human's CHARACTER
    humanCharacter = General.validatingInput("What will be your character?", Pieces.CHARACTERS)
    Pieces.RemainingCharacters.remove(humanCharacter)
    #   Set up Player objects
    Pieces.HumanPlayer = Players.Player(humanCharacter, [])
    #   Assign players a character
    setupComputerPlayers(Pieces.RemainingCharacters, playerCount-1)
    Pieces.assemblePlayerList()
    
    #   set up board
    #       take one of each as GUILTY: LOCATION CHARACTER WEPON
    #           Set aside WINNINGSET
    pickWinningSet()
    #       Hand out the remainging cards
    handOutCards()
    setUpNotepads()
    #   Print turn order
    Pieces.printTurnOrder()
    General.pressEnterToContinue()
    startTurns()

def pickWinningSet():
    #   for each set of pieces
    #       Generate random number from 0 to length-1
    #       Grap item at index of random number
    #       place item in WINNINGSET
    for eachSet in [Pieces.CHARACTERS, Pieces.LOCATIONS, Pieces.WEPONS]:
        randomNumber = random.randint(0, eachSet.__len__()-1)
        Pieces.WINNINGSET.append(eachSet[randomNumber])
        for index, eachCard in enumerate(eachSet):
            if not index == randomNumber:
                Pieces.CardsToDeal.append(eachCard)

def setupComputerPlayers(availableCharacters, playerCount):
    for eachPlayer in range(playerCount):
        Pieces.ComputerPlayers.append(Players.Player(availableCharacters.pop(), []))

def handOutCards():
    for index, eachCard in enumerate(Pieces.CardsToDeal):
        Pieces.ALLPLAYERS[index % Pieces.ALLPLAYERS.__len__()].addToHand(eachCard)

def setUpNotepads():
    for eachPlayer in Pieces.ALLPLAYERS:
        eachPlayer.makeNotePad(Pieces.WEPONS, Pieces.LOCATIONS, Pieces.CHARACTERS)


#   Turns

def viewHand():
    Pieces.currentPlayer.printHand()
    return False

def viewNotepad():
    Pieces.currentPlayer.printNotePad()
    return False
def manualUpdateNotepad():
    cardToUpdate = General.validatingInput("What card would you like to update? ", Pieces.ALLCARDS)
    cardOwner = General.validatingInput("Who do you think holds this card? ", Pieces.CHARACTERS + ["murderer!"] )
    Pieces.currentPlayer.updateNotepad(cardToUpdate, cardOwner)
    return False

def makeGuess():
    print("guess time")
    #   Need one of each WEAPON, LOCATION, CHARACTER
    weaponGuess = General.validatingInput("Enter weapon guess", Pieces.WEPONS)
    locationGuess = General.validatingInput("Enter location guess", Pieces.LOCATIONS)
    characterGuess = General.validatingInput("Enter character guess", Pieces.CHARACTERS)
    print("Guessing ", characterGuess, " used ", weaponGuess, " in the ", locationGuess)
    card, found, cardHolder = guess(weaponGuess, locationGuess, characterGuess)
    if found:
        Pieces.currentPlayer.updateNotepad(card, Pieces.playerNameFromIndex(cardHolder).character)
        print("----- FOR YOUR EYES ONLY -----")
        print( Pieces.playerNameFromIndex(cardHolder).character, " shows you ", card)
        print("Your notepad has been updated.")
        print("------------------------------")
    else:
        print("No had a matching card from that set.")
    Pieces.TURNCOUNTER += 1
    return False

def makeAccusation():
    print("accuse time")
    #   Need one of each WEAPON, LOCATION, CHARACTER
    weaponGuess = General.validatingInput("Enter weapon guess", Pieces.WEPONS)
    locationGuess = General.validatingInput("Enter location guess", Pieces.LOCATIONS)
    characterGuess = General.validatingInput("Enter character guess", Pieces.CHARACTERS)
    print( Pieces.currentPlayer.character ," is accusing ", characterGuess, " of using ", weaponGuess, " in the ", locationGuess)
    
    accuseCorrect = True
    for eachGuess in [weaponGuess, locationGuess, characterGuess]:
        if not eachGuess in Pieces.WINNINGSET:
            accuseCorrect = False
    #   if accusation is true
    #       game is over and guesser wins
    #   if accusation is false
    #       player looses and game is over
    General.suspense()
    print("---------------------------------------------------------------------------------------")
    if accuseCorrect:
        print("\t", Pieces.currentPlayer.character, " \x1b[32mWINS!!!!!\x1b[0m")
    else:
        print("\t", Pieces.currentPlayer.character, " \x1b[31mLOST!!!!!\x1b[0m")

    print("---------------------------------------------------------------------------------------")
    return True

turnOptions = {
                "view hand" : viewHand,
                "view notepad" : viewNotepad,
                "update notepad" : manualUpdateNotepad,
                "make guess" : makeGuess,
                "accuse" : makeAccusation
                }

def startTurns():
    gameDone = False
    while not gameDone:
        Pieces.currentPlayer = Pieces.ALLPLAYERS[Pieces.TURNCOUNTER % Pieces.ALLPLAYERS.__len__()]
        print("Its ", Pieces.currentPlayer.character, "'s turn")
        if Pieces.currentPlayer == Pieces.HumanPlayer:
            option = General.validatingInput("Enter turn option:", turnOptions.keys() )
            gameDone = turnOptions[option]()
        else:
            #   fabricate guess
            ComputerGuess()
        General.pressEnterToContinue()

def ComputerGuess():
    #   Come up with one of each card types
    weaponGuess = Pieces.WEPONS[random.randint(0, Pieces.WEPONS.__len__() - 1)]
    locationGuess = Pieces.LOCATIONS[random.randint(0, Pieces.LOCATIONS.__len__() - 1)]
    characterGuess = Pieces.CHARACTERS[random.randint(0, Pieces.CHARACTERS.__len__() - 1)]
    card, found, cardHolder = guess(weaponGuess, locationGuess, characterGuess)
    Pieces.currentPlayer.updateNotepad(card, Pieces.playerNameFromIndex(cardHolder).character)
    Pieces.TURNCOUNTER += 1

def guess(weaponGuess, locationGuess, characterGuess):
    currentNeighborIndex = Pieces.TURNCOUNTER + 1
    endIndex = Pieces.TURNCOUNTER + Pieces.ALLPLAYERS.__len__()
    cardFound = False
    shownCard = None
    while ( currentNeighborIndex < endIndex and not cardFound):
        #   ask neighbor if they have one.
        card, cardFound = Pieces.ALLPLAYERS[currentNeighborIndex % Pieces.ALLPLAYERS.__len__()].checkCard([weaponGuess, locationGuess, characterGuess])
        #   if not:
        #       move on to next neighbor (untill next is current player)
        #   else:
        #       neighbor discreetly shows current player matching card
        #       current player's notepad is updated with neighbor's name in place of the card
        if cardFound:
            print(Pieces.playerNameFromIndex(currentNeighborIndex).character, " shows ", Pieces.currentPlayer.character, " a card.")
            shownCard = card
        else:
            print(Pieces.playerNameFromIndex(currentNeighborIndex).character, " does not.")
            currentNeighborIndex += 1

    return shownCard, cardFound, currentNeighborIndex
