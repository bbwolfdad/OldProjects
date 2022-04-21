
def choice(dialog, options):
    respose = ""
    while True:
        print("Options:")
        for each in options:
            print("\t"+each)
        respose = input("\n" + dialog + " ")
        respose = respose.lower()
        if respose in options:
            return respose

def runcheck():
    return False

def removeRepetes(keyword):
    tempKeyword = ""
    for eachletter in keyword:
        if eachletter not in tempKeyword:
            tempKeyword += eachletter

    return tempKeyword

def generateKeyWord():
    tempKeyword = input("\nEnter new keyword: ")
    keyword = tempKeyword.lower()
    print(keyword)
    keywordNoRepete = removeRepetes(keyword)
    print(keywordNoRepete)
    return keyword, keywordNoRepete

def generateGrid(kw):
    grid = []
    for eachLetter in kw:
        grid.append(eachLetter)
    for eachLetter in alphabet:
        if eachLetter not in grid:
            grid.append(eachLetter)
    return grid

def getDecrypted():
    tempDecrypted = input("\nEnter decrypted: ")
    tempDecrypted = tempDecrypted.lower()
    if len(tempDecrypted) % 2 == 1:
        tempDecrypted += "x"
    print(tempDecrypted)
    return tempDecrypted

def getEncrypted():
    tempEncrypted = input("\nEnter encrypted: ")
    tempEncrypted = tempEncrypted.lower()
    if len(tempEncrypted) % 2 == 1:
        tempEncrypted += "x"
    print(tempEncrypted)
    return tempEncrypted

def detectPattern(pair1, pair2):
    if pair1[0] == pair2[0]:
        return "row"
    elif pair1[1] == pair2[1]:
        return "col"
    else:
        return "square"

def decrypt(encrypted):
    decrypted = ""
    for number in range(0, len(encrypted), 2):
        pair = []
        pair.append(encrypted[number])
        pair.append(encrypted[number+1])
        indexPair = [grid.index(pair[0]), grid.index(pair[1])]
        print(pair)
        row1 = int(indexPair[0]/5)
        col1 = indexPair[0]%5
        row2 = int(indexPair[1]/5)
        col2 = indexPair[1]%5
        print(row1, col1)
        print(row2, col2)
        pattern = detectPattern([row1, col1], [row2, col2])
        print(pattern)
        if pattern == "row":
            col1D = col1 - 1
            col2D = col2 - 1
            row1D = row1
            row2D = row2
            if col1D < 0:
                col1D = 4
            if col2D < 0:
                col2D = 4
        elif pattern == "col":
            col1D = col1
            col2D = col2
            row1D = row1 - 1
            row2D = row2 - 1
            if row1D < 0:
                row1D = 4
            if row2D < 0:
                row2D = 4
        else:
            row1D = row1
            row2D = row2
            col1D = col2
            col2D = col1
        decrypted += grid[col1D + (row1D*5)]
        decrypted += grid[col2D + (row2D*5)]

    return decrypted

def encrypt(preEncrypted):    
    encrypted = ""
    for number in range(0, len(preEncrypted), 2):
        pair = []
        pair.append(preEncrypted[number])
        pair.append(preEncrypted[number+1])
        indexPair = [grid.index(pair[0]), grid.index(pair[1])]
        print(pair)
        row1 = int(indexPair[0]/5)
        col1 = indexPair[0]%5
        row2 = int(indexPair[1]/5)
        col2 = indexPair[1]%5
        print(row1, col1)
        print(row2, col2)
        pattern = detectPattern([row1, col1], [row2, col2])
        print(pattern)
        if pattern == "row":
            col1D = col1 + 1
            col2D = col2 + 1
            row1D = row1
            row2D = row2
            if col1D > 4:
                col1D = 0
            if col2D > 4:
                col2D = 0
        elif pattern == "col":
            col1D = col1
            col2D = col2
            row1D = row1 + 1
            row2D = row2 + 1
            if row1D > 4:
                row1D = 0
            if row2D > 4:
                row2D = 0
        else:
            row1D = row1
            row2D = row2
            col1D = col2
            col2D = col1
        encrypted += grid[col1D + (row1D*5)]
        encrypted += grid[col2D + (row2D*5)]

    return encrypted
    

def printGrid(grid):
    print(grid)
    print(len(grid))
    for index in range(5):
        print("|", grid[(index*5)], grid[(index*5)+1], grid[(index*5)+2], grid[(index*5)+3], grid[(index*5)+4], "|")

keyword = ""
keywordNoRepete = ""
running = True
alphabet = []
grid = []

for eachNumber in range(97, 123):
    if eachNumber != 106:
        alphabet.append(chr(eachNumber))

while running:
    keyword, keywordNoRepete = generateKeyWord()
    grid = generateGrid(keywordNoRepete)
    printGrid(grid)
    #   encrypt or decrypt?
    response = choice("What whould you like to do?", ["encrypt", "decrypt"])
    if response == "encrypt":
        # encrypt
        preEncrypted = getDecrypted()
        encrypted = encrypt(preEncrypted)
        print(encrypted)
    else:
        encrypted = getEncrypted()
        decrypted = decrypt(encrypted)
        print(decrypted)
    running = runcheck()
