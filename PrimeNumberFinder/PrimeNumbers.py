# Python PrimeNumbers

# imports
import math

# Functions
def isPrime(number):
    for eachInteger in range(2, int(math.sqrt(number)) + 1 ):
        if number % eachInteger == 0:
            return False
    return True

# Main
primeNumberLimit = 10000000
listOfPrimes = []

print("------------------ Start ------------------")

for eachNumber in range(2, primeNumberLimit + 1 ):
    if eachNumber % int(primeNumberLimit/10) == 0:
        print(eachNumber)
    if isPrime(eachNumber):
        listOfPrimes.append(eachNumber)

fileName = "PrimeNumbers-" + str(primeNumberLimit) + ".txt"
primeFile = open(fileName, "w")

primeFile.write(str(listOfPrimes))
primeFile.close()
print("------------------ Done ------------------")
print("The prime numbers have been writen to ", fileName, " in the format of a python list.")
print("[2, 3, 5, ...]")
