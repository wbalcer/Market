import matplotlib.pyplot as plt

#Inflation
file_path = 'ioutput.txt'
data = []

try:
    with open(file_path, 'r') as file:
        data = [float(line.strip()) for line in file if line.strip()]
except FileNotFoundError:
    print(f"Error: The file '{file_path}' was not found.")
    exit(1)
except ValueError as e:
    print(f"Error while parsing the file: {e}")
    exit(1)

plt.figure(figsize=(20, 12))
plt.plot(data, label='Inflation', color='blue', linewidth=1)
plt.title("Inflation over rounds", fontsize=14)
plt.xlabel("Round", fontsize=12)
plt.ylabel("Inflation%", fontsize=12)
plt.legend()
plt.grid(True)
plt.tight_layout()
plt.savefig("iplot.png")
plt.close()  

#Prices
file_path_s = 'poutput.txt'
data_s = []

try:
    with open(file_path_s, 'r') as file:
        for line in file:
            if line.strip():
                data_s.append([float(x) for x in line.strip().split()])
except FileNotFoundError:
    print(f"Error: The file '{file_path_s}' was not found.")
    exit(1)
except ValueError as e:
    print(f"Error while parsing the file '{file_path_s}': {e}")
    exit(1)

data_s = list(zip(*data_s))

column_names = ["Crucial", "Essential", "Standard", "Optional", "Luxury", "SuperLuxury"]

if len(column_names) != len(data_s):
    print("Error: Number of column names does not match the number of columns in the data.")
    exit(1)

plt.figure(figsize=(20, 12))
for i, (column, name) in enumerate(zip(data_s, column_names)):
    plt.plot(column, label=name, linewidth=1.5)

plt.title("Lowest Price Changes Over Rounds", fontsize=14)
plt.xlabel("Round", fontsize=12)
plt.ylabel("Price", fontsize=12)
plt.legend()
plt.grid(True)
plt.tight_layout()
plt.savefig("pplot.png")

#Markup
file_path_s = 'moutput.txt'
data_s = []

try:
    with open(file_path_s, 'r') as file:
        for line in file:
            if line.strip():
                data_s.append([float(x) for x in line.strip().split()])
except FileNotFoundError:
    print(f"Error: The file '{file_path_s}' was not found.")
    exit(1)
except ValueError as e:
    print(f"Error while parsing the file '{file_path_s}': {e}")
    exit(1)

data_s = list(zip(*data_s))

column_names = ["Crucial", "Essential", "Standard", "Optional", "Luxury", "SuperLuxury"]

if len(column_names) != len(data_s):
    print("Error: Number of column names does not match the number of columns in the data.")
    exit(1)

plt.figure(figsize=(20, 12))
for i, (column, name) in enumerate(zip(data_s, column_names)):
    plt.plot(column, label=name, linewidth=1.5)

plt.title("Markup of the Lowest Price Over Rounds", fontsize=14)
plt.xlabel("Round", fontsize=12)
plt.ylabel("Markup", fontsize=12)
plt.legend()
plt.grid(True)
plt.tight_layout()
plt.savefig("mplot.png")


#Sales
file_path_s = 'soutput.txt'
data_s = []

try:
    with open(file_path_s, 'r') as file:
        for line in file:
            if line.strip():
                data_s.append([float(x) for x in line.strip().split()])
except FileNotFoundError:
    print(f"Error: The file '{file_path_s}' was not found.")
    exit(1)
except ValueError as e:
    print(f"Error while parsing the file '{file_path_s}': {e}")
    exit(1)

data_s = list(zip(*data_s))

column_names = ["Crucial", "Essential", "Standard", "Optional", "Luxury", "SuperLuxury"]

if len(column_names) != len(data_s):
    print("Error: Number of column names does not match the number of columns in the data.")
    exit(1)

plt.figure(figsize=(20, 12))
for i, (column, name) in enumerate(zip(data_s, column_names)):
    plt.plot(column, label=name, linewidth=1.5)

plt.title("Sales Over Rounds", fontsize=14)
plt.xlabel("Round", fontsize=12)
plt.ylabel("# of sales", fontsize=12)
plt.legend()
plt.grid(True)
plt.tight_layout()
plt.savefig("splot.png")



#Salesman
file_path_s = 'Soutput.txt'
data_s = []

try:
    with open(file_path_s, 'r') as file:
        for line in file:
            if line.strip():
                data_s.append([float(x) for x in line.strip().split()])
except FileNotFoundError:
    print(f"Error: The file '{file_path_s}' was not found.")
    exit(1)
except ValueError as e:
    print(f"Error while parsing the file '{file_path_s}': {e}")
    exit(1)

data_s = list(zip(*data_s))

column_names = ["Wholesaler", "Everyday Specialist", "Luxurious", "Local", "Supermarket", "Optional Goods", "Wholesaler Premium"]

if len(column_names) != len(data_s):
    print("Error: Number of column names does not match the number of columns in the data.")
    exit(1)

plt.figure(figsize=(20, 12))
for i, (column, name) in enumerate(zip(data_s, column_names)):
    plt.plot(column, label=name, linewidth=1.5)

plt.title("Profit Over Rounds", fontsize=14)
plt.xlabel("Round", fontsize=12)
plt.ylabel("$ earned", fontsize=12)
plt.legend()
plt.grid(True)
plt.tight_layout()
plt.savefig("Splot.png")