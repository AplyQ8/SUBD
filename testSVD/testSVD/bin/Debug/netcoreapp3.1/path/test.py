import numpy as num
import os

matrix = []
with open("origin_matrix.txt", 'r') as file:
    for line in file:
        matrix.append([float(x) for x in line.split()])

U, S, Vh = num.linalg.svd(matrix)

if (os.path.exists("U.txt")):
    os.remove("U.txt")
if (os.path.exists("S.txt")):
    os.remove("S.txt")
if (os.path.exists("Vh.txt")):
    os.remove("Vh.txt")

with open("U.txt", 'w') as uf:
    for i in range(len(U)):
        for j in range(len(U[i])):
            uf.write(str(U[i][j]) + " ")
        uf.write("\n")
with open("S.txt", 'w') as sf:
    for i in range(len(S)):
        sf.write(str(S[i]) + " ")
with open("Vh.txt", 'w') as vf:
    for i in range(len(U)):
        for j in range(len(Vh[i])):
            vf.write(str(Vh[i][j]) + " ")
        vf.write("\n")