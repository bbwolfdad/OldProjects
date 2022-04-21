# General.py

import time

def validatingInput(prompt, validInputs):
    #   validInputs is a list of valid strings
    print(prompt)
    print("Options:")
    for eachInput in validInputs:
        print("\t", eachInput)
    fromUser = input("Enter response: ").strip()
    if fromUser in validInputs:
        return fromUser
    else:
        print("Invalid input")
        return validatingInput(prompt, validInputs)

def playCheck(response):
    if response == "yes":
        return True
    else:
        return False

def clearScreen():
    for eachLine in range(200):
        print("\n")

def pressEnterToContinue():
    input("Press Enter to continue: ")
    clearScreen()

def suspense():
    for eachMoment in range(5):
        print(".")
        time.sleep(0.5)