#   Players.py

class Player:
    def __init__(self, character, hand):
        self.character = str(character)
        self.hand = list(hand)
        self.weponList = {}
        self.locationList = {}
        self.characterList = {}

    def addToHand(self, newCard):
        self.hand.append(newCard)
    
    def printHand(self):
        print(self.character, "\'s hand: ")
        for eachCard in self.hand:
            print("\t", eachCard)
    
    def printPlayer(self):
        print("----- ", self.character, " -----")
        print("\thand:")
        for eachCard in self.hand:
            print("\t\t", eachCard)
        self.printNotePad()

    def makeNotePad(self, wepons, locations, characters):
        for eachCard in wepons:
            self.weponList[eachCard] = "0"
        for eachCard in locations:
            self.locationList[eachCard] = "0"
        for eachCard in characters:
            self.characterList[eachCard] = "0"
        for eachCard in self.hand:
            if eachCard in wepons:
                self.weponList[eachCard] = self.character
            elif eachCard in locations:
                self.locationList[eachCard] = self.character
            else:
                self.characterList[eachCard] = self.character

    def printNotePad(self):
        justifyLength = 20
        print("---- NOTEPAD ----")
        print("wepons:")
        for eachWepon in self.weponList:
            print("\t", eachWepon,": ", str(self.weponList[eachWepon]).rjust(justifyLength - eachWepon.__len__(), " "))
        print("locations:")
        for eachLocation in self.locationList:
            print("\t", eachLocation,": ", str(self.locationList[eachLocation]).rjust(justifyLength - eachLocation.__len__(), " "))
        print("characters:")
        for eachCharacter in self.characterList:
            print("\t", eachCharacter,": ", str(self.characterList[eachCharacter]).rjust(justifyLength - eachCharacter.__len__(), " "))


    
    def checkCard(self, cardSet):
        #   card set is [weapon, location, character]
        print("Asking ", self.character, " if they have ", cardSet)
        for eachCard in cardSet:
            if eachCard in self.hand:
                return eachCard, True
        return None, False

    def updateNotepad(self, card, cardHolder):
        for eachCardSet in [self.weponList, self.locationList, self.characterList]:
            if card in eachCardSet.keys():
                eachCardSet[card] = cardHolder

