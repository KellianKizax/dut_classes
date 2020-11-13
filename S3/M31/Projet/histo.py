import matplotlib.pyplot as plt
import pandas as pd

data = pd.read_csv('data.csv', sep=';',header=None, squeeze=True)

data = data.sort_values(data.columns[1])

data.hist(data.columns[1])
plt.ylabel("Fréquence d'apparition")
plt.xlabel('Valeurs de la V.A.')
plt.title('Représentation de la loi exponentielle')

plt.show()