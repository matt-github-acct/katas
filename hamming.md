> http://exercism.io/exercises/csharp/hamming/readme

#Hamming
Write a program that can calculate the Hamming difference between two DNA strands.

A mutation is simply a mistake that occurs during the creation or copying of a nucleic acid, in particular DNA. Because nucleic acids are vital to cellular functions, mutations tend to cause a ripple effect throughout the cell. Although mutations are technically mistakes, a very rare mutation may equip the cell with a beneficial attribute. In fact, the macro effects of evolution are attributable by the accumulated result of beneficial microscopic mutations over many generations.

The simplest and most common type of nucleic acid mutation is a point mutation, which replaces one base with another at a single nucleotide.

By counting the number of differences between two homologous DNA strands taken from different genomes with a common ancestor, we get a measure of the minimum number of point mutations that could have occurred on the evolutionary path between the two strands.

This is called the 'Hamming distance'.

It is found by comparing two DNA strands and counting how many of the nucleotides are different from their equivalent in the other string.

```
GAGCCTACTAACGGGAT
CATCGTAATGACGGCCT
^ ^ ^  ^ ^    ^^
```
The Hamming distance between these two DNA strands is 7.

#Note
The Hamming distance is only defined for sequences of equal length.

#Test Cases
```
First String:  "" 
Second String: "" 
Expected Value: 0 


First String:  "A"
Second String: "B"
Expected Value: 1

First String:  "A"
Second String: "A"
Expected Value: 0

First String:  "GGACTGA"
Second String: "GGACTGA"
Expected Value: 0

First String:  "ACT"
Second String: "GGA"
Expected Value: 3

First String:  "GGACGGATTCTG"
Second String: "AGGACGGATTCT"
Expected Value: 9

First String:  "GGACG"
Second String: "GGTCG"
Expected Value: 1

First String:  "ACCAGGG"
Second String: "ACTATGG"
Expected Value: 2
```
