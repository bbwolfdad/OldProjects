import cv2
from datetime import date
import time

currentDate = date.today()
currentDateString = currentDate.strftime("%m-%d-%Y_") + time.strftime("%H-%M-%S")
print("photos are tagged -> " + currentDateString)

cv2.namedWindow("preview")
vc = cv2.VideoCapture(0)

if vc.isOpened(): # try to get the first frame
    rval, frame = vc.read()
else:
    rval = False
picCount = 0
timePassed = 0
currentTime = time.time()
while rval:
    timePassed = timePassed + time.time() - currentTime
    currentTime = time.time()
    cv2.imshow("preview", frame)
    rval, frame = vc.read()
    key = cv2.waitKey(20)

    if key == 27: # exit on ESC
        break
    if key == 32:
        print("spacebutton takes pic")
        cv2.imwrite("Images/" + currentDateString + "-WebcamPic-" + str(picCount).zfill(2) + ".png", frame)
        picCount = picCount + 1
    if timePassed >= 30:
        print("Time laps pic " + str(picCount) + " has been taken")
        timePassed = timePassed - 30
        cv2.imwrite("Images/" + currentDateString + "-WebcamPic-" + str(picCount).zfill(2) + ".png", frame)
        picCount = picCount + 1

cv2.destroyWindow("preview")
