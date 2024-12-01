# we get the rows from the input file (default location for input file in visual studio python app is in root folder of the project)
with open("input.txt") as f:
    lines = f.readlines()
    
# we create two empty integer lists
list1 = []
list2 = []

# we create separate lists for part B because we modify lists in part A
list1b = []
list2b = []

# we split every row using the 3 spaces between the numbers and then we add the numbers into two separate lists. We also need to convert the numbers from string to int.
for line in lines:
    number1 = int(line.split("   ")[0])
    number2 = int(line.split("   ")[1])
    
    list1.append(number1)
    list2.append(number2)
    
    list1b.append(number1)
    list2b.append(number2)
    
# part A

total_distance = 0

# we can use earlier list to determine the number of iterations (also would have worked with list1 or list2 because in python number of iterations doesn't change during for loop even if list size changes)
for line in lines:
    # we get the smallest value from each list
    smallest1 = min(list1)
    smallest2 = min(list2)
    
    # we remove the smallest value from each list so that we get the next smallest numbers in the next iteration
    list1.remove(smallest1)
    list2.remove(smallest2)
    
    # we calculate the distance between the smallest numbers and add it to the total distance
    distance = abs(smallest1 - smallest2)
    total_distance += distance
    
print("Total distance: " + str(total_distance))

# part B

total_sim_score = 0

for number1 in list1b:
    # we use a second for-loop to count the matching numbers (this search could have been done in other ways as well)
    matches = 0
    for number2 in list2b:
        if (number1 == number2):
            matches += 1
    
    # we calculate the similarity score by multiplying the number with amount of matches, and then we add it to the total score
    sim_score = matches * number1
    total_sim_score += sim_score
    
print("Similarity score: " + str(total_sim_score))