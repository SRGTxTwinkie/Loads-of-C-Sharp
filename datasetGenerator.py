import random
import os

x = open("dataset.txt", "w")

for i in range(3000):
    x.write(str(random.randrange(0,3000)))
    x.write("\n")
